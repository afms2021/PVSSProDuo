using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   PCCom.SerialCommunication Version 1.0.0.0
//   Class file for managing serial port communication
//
//   Copyright (C) 2007  
//   Richard L. McCutchen 
//   Email: richard@psychocoder.net
//   Created: 20OCT07
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//*****************************************************************************************
namespace PCComm
{
    internal class CommunicationManager : IDisposable
    {
        #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex }

        /// <summary>
        /// enumeration to hold our message types
        /// </summary>
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };
        #endregion

        #region Manager Variables
        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;
        //global manager variables
        private readonly Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        public SerialPort comPort = new SerialPort();
        #endregion

        #region Manager Properties
        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property to hold our TransmissionType
        /// of our manager class
        /// </summary>
        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            //now add an event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager()
        {

        }
        #endregion

        #region WriteData
        public void WriteData(string msg)
        {
            if (String.IsNullOrEmpty(msg))
            {
                return;
            }
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    try
                    {
                        //first make sure the port is open
                        //if its not open then open it
                        if (!(comPort.IsOpen == true)) comPort.Open();
                        //send the message to the port
                        comPort.Write(msg);
                        //display the message
                        DisplayData(MessageType.Outgoing, msg.ToString());
                    }
                    catch (Exception)
                    {
                        // Port unavailable or does not exist — silently ignore
                    }
                    break;
                case TransmissionType.Hex:

                default:
                    break;
                    //break;
            }
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        private string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        #region DisplayData
        /// <summary>
        /// method to display the data to & from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData(MessageType type, string msg)
        {
            if (String.IsNullOrEmpty(msg))
            {
                return;
            }

            if (type == MessageType.Incoming)
            {
                LastMsg = msg;
                //Console.WriteLine("RECEIVED: " + msg);
            }
            if (type == MessageType.Outgoing)
            {
                //Console.WriteLine("SENT: " + msg);
            }

        }
        #endregion

        public string LastMsg { get; set; }

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (comPort.IsOpen == true) comPort.Close();

                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //now open the port
                comPort.Open();
                //display message
                DisplayData(MessageType.Normal, "Port opened at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }
        #endregion


        public List<string> GetPortNames()
        {
            List<string> result = new List<string>();

            // Use registry enumeration — more reliable than SerialPort.GetPortNames()
            // which can miss virtual/USB COM ports on some systems.
            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM"))
                {
                    if (key != null)
                    {
                        foreach (var valueName in key.GetValueNames())
                        {
                            var port = key.GetValue(valueName) as string;
                            if (!string.IsNullOrEmpty(port))
                                result.Add(port);
                        }
                    }
                }
            }
            catch { }

            // Fallback to standard enumeration if registry returned nothing
            if (result.Count == 0)
            {
                foreach (var item in SerialPort.GetPortNames())
                    result.Add(item);
            }

            result.Sort();
            return result;
        }


        //#region SetParityValues
        //public void SetParityValues(object obj)
        //{
        //    foreach (string str in Enum.GetNames(typeof(Parity)))
        //    {
        //        ((ComboBox)obj).Items.Add(str);
        //    }
        //}
        //#endregion

        //#region SetStopBitValues
        //public void SetStopBitValues(object obj)
        //{
        //    foreach (string str in Enum.GetNames(typeof(StopBits)))
        //    {
        //        ((ComboBox)obj).Items.Add(str);
        //    }
        //}
        //#endregion

        //#region SetPortNameValues
        //public void SetPortNameValues(object obj)
        //{

        //    foreach (string str in SerialPort.GetPortNames())
        //    {
        //        ((ComboBox)obj).Items.Add(str);
        //    }
        //}
        //#endregion

        #region Dispose
        public void Dispose()
        {
            comPort.Dispose();
        }
        #endregion

        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //determine the mode the user selected (binary/string)
                switch (CurrentTransmissionType)
                {
                    //user chose string
                    case TransmissionType.Text:
                        //read data waiting in the buffer
                        Thread.Sleep(100);
                        string msg = comPort.ReadExisting();
                        //display the data to the user
                        DisplayData(MessageType.Incoming, msg + "\n");
                        break;
                    //user chose binary
                    case TransmissionType.Hex:
                        //retrieve number of bytes in the buffer
                        int bytes = comPort.BytesToRead;
                        //create a byte array to hold the awaiting data
                        byte[] comBuffer = new byte[bytes];
                        //read the data and store it
                        comPort.Read(comBuffer, 0, bytes);
                        //display the data to the user
                        DisplayData(MessageType.Incoming, ByteToHex(comBuffer) + "\n");
                        break;
                    default:
                        //read data waiting in the buffer
                        string str = comPort.ReadExisting();
                        //display the data to the user
                        DisplayData(MessageType.Incoming, str + "\n");
                        break;
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}
