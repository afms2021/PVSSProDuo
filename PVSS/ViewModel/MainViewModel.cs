// +---------------------------------+-------------+----------------------------------------------------------------------------------------------------------------+ 
// |    Developer                    |    Date     |                             Comments                                                                           |
// |---------------------------------+-------------+----------------------------------------------------------------------------------------------------------------+
// | Manuel Parente                  | 15/JUN/2012 | First Version CodeName DIVER-II                                                                                |
// | Arlindo Silva                   | 03/DEC/2012 | SetBitrate to 3000, improve recorded video quality.                                                            |
// | Arlindo Silva                   | 09/DEC/2012 | Set MP4 Mode.                                                                                                  |
// | Arlindo Silva                   | 10/SEP/2013 | Speedup Seek (forward) in play mode.                                                                           |
// | Arlindo Silva                   | 18/SEP/2013 | Wait for USB to detetct S2253 board some MB USB ports are too slow.                                            |
// | Arlindo Silva                   | 14/JAN/2015 | Passtrought Video to Output.                                                                                   |
// | Arlindo Silva                   | 14/JAN/2015 | Turn-off Camera on exit.                                                                                       |
// | Arlindo Silva                   | 14/JAN/2015 | Close S2253 Board on exit.                                                                                     |
// | Arlindo Silva/Manuel Parente    | 14/JAN/2015 | Turn-off Light on exit.                                                                                        |
// | Manuel Parente                  | 22/JAN/2015 | Clear Error Message and restart REC STOP/START every minute.                                                   |
// | Arlindo Silva                   | 02/MAR/2015 | Changed to PDF due to Win 10 photo viwer black background, no axes shown.                                      |
// | Arlindo Silva                   | 26/MAR/2015 | Onesecondtick loop due to Preview Image freezing.                                                              |
// | Arlindo Silva                   | 27/MAR/2015 | System S2253 crash with large text and 160 char lenght.(not used anymore)                                      |
// | Arlindo Silva                   | 14/APR/2015 | Improve Battery Voltage Readings conversion parameter y=xm+b => m=4.675578 and b=-4.8.                         |
// | Arlindo Silva                   | 20/APR/2015 | Battery Level Warning (NOTE: 720 => 11.6Vdc)                                                                   |
// | Arlindo Silva                   | 29/APR/2015 | Battery Level Critical (NOTE: 702 => 11.2Vdc)                                                                  |
// | Manuel Parente                  | 02/DEC/2015 | Bitrate must be 96, otherwise it will crash due to USB bandwith.                                               |
// | Arlindo Silva                   | 09/DEC/2015 | Added Crop Funcion , improve Aspect Ratio for round object.                                                    |
// | Arlindo Silva                   | 25/OCT/2016 | Depth Conversion factor as a parameter.                                                                        |
// | Arlindo Silva                   | 27/FEV/2017 | Depth Conversion added settings sea / fresh water, 25 Barg sensor option and Depth offset.                     |
// | Arlindo Silva                   | 02/MAR/2017 | Video Recording Key, was F4 now F3 toggle ON-OFF.                                                              |
// | Arlindo Silva                   | 14/NOV/2017 | Added Auto Smapshot after enter Commnet Text                                                                   |
// | Manuel Parente/Arlindo Silva    | 30/DEC/2017 | Added Job Directory Structures based on JobName.                                                               |
// | Manuel Parente/Arlindo Silva    | 25/MAY/2018 | Added WPFMediaKit ver .net 4.5, corretced several warnings (p.ex. Close App Cleanup is not working).           |
// | Arlindo Silva                   | 18/JUN/2018 | New Layout design Gray Style.                                                                                  |
// | Arlindo Silva                   | 11/OUT/2018 | Added Avoid Invalid Directory Name Chars and blank spaces                                                      |
// | Arlindo Silva                   | 30/NOV/2018 | Improved GPS message dialog and detection.                                                                     |
// | Arlindo Silva                   | 12/DEC/2018 | Add a Splash Screen.                                                                                           |
// | Arlindo Silva                   | 14/APR/2019 | Added HD720p 4in1 Camera Option Should be set from 1080p to 720p CBVS (composite Video).                       |
// | Arlindo Silva                   | 14/APR/2019 | Added Interpolate Mode Option                                                                                  |
// | Arlindo Silva                   | 14/APR/2019 | Added Unit conntetct to external 230Vac power Warning Battery Charger ON - Telemetry Board Updated new String. |
// | Arlindo Silva                   | 14/APR/2019 | Added to Settings HD/SD option, Interpolated ON/OFF.                                                           |
// | Arlindo Silva                   | 14/APR/2019 | Settings Layout minor cosmetic Changes.                                                                        |
// | Arlindo Silva                   | 24/APR/2019 | Added Suppress Editing Company, Job Name and Diver Name while recording.                                       |  
// | Manuel Parente                  | 27/APR/2019 | Solved LastSnapShot Exception and Photo Viewer                                                                 |                           
// | Arlindo Silva                   | 07/MAY/2019 | Added exception handling whem Telemetry COM port is missing.                                                   |
// | Arlindo Silva                   | 07/MAY/2019 | Added Internal PCB Over Temperature Warning @ > 52 ºC.                                                         |
// | Arlindo Silva                   | 24/APR/2021 | Update to Sensoray DLL 1.2.38.1 .                                                                              |
// | Arlindo Silva                   | 12/MAY/2021 | Added Compiler options to use serial COM port dialogue with PRODIVING Telemetry Unit change baudrate to 19200  |
// | Arlindo Silva                   | 11/JUN/2021 | Ver 5.6 - Update to Sensoray DLL 1.2.39.1 .                                                                    |
// | Arlindo Silva                   | 01/AUG/2021 | Ver 5.6a - Update to Sensoray DLL 1.2.41.1 Solved problems with Codec detection new Win 10 versions.           |                           
// | Arlindo Silva                   | 01/AUG/2021 | To slow to Fast Forward with long videos ( more than 1hour)   SENSORAY - comb filter re-enabled on PAL         | 
// | Arlindo Silva                   | 03/AUG/2021 | Error in settings, since version 5.6 DLL ver 1.39.1, should be 115200 was 19600 due PRODIVING  Telemetry       | 
// | Arlindo Silva                   | 10/OUT/2021 | Added Video File with Zero lenght Check and Warning, due to fast toggle REC/STOP using F3 key.                 | 
// | Arlindo Silva                   | 17/OUT/2021 | Added Error Log File to Working Directory (based on JobName)                                                   | 
// | Arlindo Silva                   | 01/NOV/2021 | Added No COM port found warning. Removed not working properly                                                  | 
// | Arlindo Silva                   | 04/JAN/2022 | Added DLL 1.2.45.0 with Log,  corrected error on Styldedtxt enumeration.Time is flicking .id = 4 is duplicated | 
// | Arlindo Silva                   | 14/FEB/2022 | Added Cleanup on Close and updated to Sensoray 1.2.46.0 DLL solved issues with 32bit running on 64bits machine | 
// | Arlindo Silva                   | 05/APR/2022 | Added Directory Create based on JobName, if not exist.                                                         | 
// | Arlindo Silva                   | 05/APR/2022 | Save Chart when batery level is critical and Stop/Start Recording every minute                                 | 
// | Arlindo Silva                   | 20/APR/2022 | PVSS PRO DUO Initial Version                                                                                   | 
// +---------------------------------+-------------+----------------------------------------------------------------------------------------------------------------+

//#define DEPTH_SIMULATOR // DEPTH_SIMULATOR: comment out the line to use real sensor data
#define PVSS_PRO  // PVSS or PVSS_PRO  *** PVSS 115200 baudrate / Prodving 19200 baudrate ***

using PVSS.Helpers;
using System.Globalization;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PCComm;
using Sensoray;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PVSS.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    [ComVisible(false)]
    public sealed class MainViewModel : ViewModelBase, ICleanup, IDisposable
    {
        public string JobNameDiretory1 = "D:\\PVSS DUO PRO 1";
        public string JobNameDiretory2 = "F:\\PVSS DUO PRO 2";
        public string VideoDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos1";
        public string VideoDirectoryPath2 = "F:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos2";
        public string SnapshotsDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots1";
        public string SnapshotsDirectoryPath2 = "F:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots2";
        public string ChartsDirectoryPath1 = "D:\\PVSS DUO PRO 1" +  "\\" + Properties.Settings.Default.JobNameText + "\\Charts1";
        public string ChartsDirectoryPath2 = "F:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts2";
        public string LogPath = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\log.txt";
        
        private FileSystemWatcher fileSystemWatcher;

        private const int BUFFER_SIZE = 1327104;
        private const int WM_DEVICEEVENT = 0x8002;

        private const int STREAM_A = 0;
        private const int STREAM_B = 1;
        private const int VIDEO_OUT = 2; // by ARLINDO 14-Jan-2015  Passtrought Video to Output

        private const string NullString = null;

        private DispatcherTimer DivingTimer1 = new DispatcherTimer();
        private DispatcherTimer DivingTimer2 = new DispatcherTimer();
#if DEPTH_SIMULATOR
        private int _simTick = 0; // increments every TelemetryTimer tick (1 second)
#endif
        // Previous depth values for ascending detection (auto light-off)
        private float _prevDepth1 = 0f;
        private float _prevDepth2 = 0f;

        public const string AutoLightOffPropertyName = "AutoLightOff";
        private bool _autoLightOff = Properties.Settings.Default.AutoLightOff;
        public bool AutoLightOff
        {
            get { return _autoLightOff; }
            set
            {
                if (_autoLightOff == value) return;
                _autoLightOff = value;
                Properties.Settings.Default.AutoLightOff = value;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(AutoLightOffPropertyName);
            }
        }


        private DispatcherTimer TelemetryTimer = new DispatcherTimer();
        //private DispatcherTimer LowBatErrorTimer = new DispatcherTimer();
        private DispatcherTimer DiskMonitorTimer = new DispatcherTimer();
        private DispatcherTimer DisplayLineTimer = new DispatcherTimer();

        private DateTime startDateTime1;
        private DateTime startDateTime2;

        //Snapshot variables
        private IntPtr bufPtr;
        private GCHandle bufHandle;

        private Byte[] buffer = new Byte[BUFFER_SIZE];
        private Byte[] tmpBuffer = new Byte[BUFFER_SIZE];
        private Byte[] ovlBuffer = new Byte[BUFFER_SIZE];

        //Battery Colors
        private static SolidColorBrush GreenBrush = new SolidColorBrush(Color.FromScRgb(1f, 0f, 1f, 0f));
        private static SolidColorBrush OrangeBrush = new SolidColorBrush(Color.FromScRgb(1f, 1f, 1f, 0f));
        private static SolidColorBrush RedBrush = new SolidColorBrush(Color.FromScRgb(1f, 1f, 0f, 0f));

        //Depth Sensor status
        private static string DEPTH_SENSOR1_STATUS_OK = "ok";
        private static string DEPTH_SENSOR1_STATUS_OPEN = "open";
        private static string DEPTH_SENSOR1_STATUS_SHORT = "short";
        private static string DEPTH_SENSOR2_STATUS_OK = "ok";
        private static string DEPTH_SENSOR2_STATUS_OPEN = "open";
        private static string DEPTH_SENSOR2_STATUS_SHORT = "short";
        float DepthSensorReading1;
        float DepthSensorReading2;


        // Battery Charger Status / Now is Always conneted to Power Line
        private static string BATTERY_CHARGER_STATUS_ON = "on";
        private static string BATTERY_CHARGER_STATUS_OFF = "off";

        private bool Sensoray_codec = false;
        private bool _startupCompleted = false;
        private string Last_file_name1 = "noname1";
        private string Last_file_name2 = "noname2";
        //private string TemperatureLevel;

#if PVSS_PRO
        private int result;
        private int _pro_open1 = 0;
        private int _pro_short1 = 0;
        private int _pro_open2 = 0;
        private int _pro_short2 = 0;
        public bool _IsDepthStringValid = false;
        private bool _Chart1_saved = false;
        private bool _Chart2_saved = false;
        private bool _dive1StartLogged = false;
        private bool _dive1StopLogged = false;
        private bool _dive2StartLogged = false;
        private bool _dive2StopLogged = false;

        // Change Baudrate in settings to 19200 / PVSS use 115200
                

#endif

#region IO COMMANDS
#if PVSS_PRO

        private const string IO_COMMAND_TURN_CAMERA_ON_1_2 = "$RLY,1,1,0,0,*6B\r\n";
        private const string IO_COMMAND_TURN_CAMERA_ON_1 = "$RLY,1,0,0,0,*6A\r\n";
        private const string IO_COMMAND_TURN_CAMERA_ON_2 = "$RLY,0,1,0,0,*6A\r\n";  

        private const string IO_COMMAND_TURN_CAMERA_OFF_1_2 = "$RLY,0,0,0,0,*6B\r\n";
        private const string IO_COMMAND_TURN_CAMERA_OFF_1 = "$RLY,0,1,0,0,*6A\r\n";
        private const string IO_COMMAND_TURN_CAMERA_OFF_2 = "$RLY,1,0,0,0,*6A\r\n";


        private const string IO_COMMAND_TURN_LIGHT_ON_1_2 = "$DVD,4095,4095,*7A\r\n";
        private const string IO_COMMAND_TURN_LIGHT_ON_1 = "$DVD,4095,0,*42\r\n"; 
        private const string IO_COMMAND_TURN_LIGHT_ON_2 = "$DVD,0,4095,*42\r\n"; 
     
        private const string IO_COMMAND_TURN_LIGHT_OFF_1_2 = "$DVD,0,0,*7A\r\n";
        private const string IO_COMMAND_TURN_LIGHT_OFF_1 = "$DVD,0,4095,*42\r\n"; 
        private const string IO_COMMAND_TURN_LIGHT_OFF_2 = "$DVD,4095,0,*42\r\n"; 

        private string sensorstatus1 = "";
        private string sensorstatus2 = "";
#else

        private const string IO_COMMAND_TURN_LIGHT_ON = "L";
        private const string IO_COMMAND_TURN_CAMERA_ON = "C";
        private const string IO_COMMAND_TURN_LIGHT_OFF = "l"; // L lowercase not number 1
        private const string IO_COMMAND_TURN_CAMERA_OFF = "c";
#endif

        #endregion

        #region Video
        /// <summary>
        /// The <see cref="Video" /> property's name.
        /// </summary>
        public const string VideoPropertyName = "Video";

        private DirectShowLib.DsDevice _Video;

        /// <summary>
        /// Sets and gets the Video property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DirectShowLib.DsDevice Video
        {
            get
            {
                return _Video;
            }

            set
            {
                if (_Video == value)
                {
                    return;
                }

                _Video = value;
                RaisePropertyChanged(VideoPropertyName);
            }
        }
        #endregion Video

        #region Video1
        /// <summary>
        /// The <see cref="Video1" /> property's name.
        /// </summary>
        public const string Video1PropertyName = "Video1";

        private DirectShowLib.DsDevice _Video1;

        /// <summary>
        /// Sets and gets the Video property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DirectShowLib.DsDevice Video1
        {
            get
            {
                return _Video1;
            }

            set
            {
                if (_Video1 == value)
                {
                    return;
                }

                _Video1 = value;
                RaisePropertyChanged(Video1PropertyName);
            }
        }
        #endregion Video1

        #region Record ToggleSwitch

        /// <summary>
        /// The <see cref="IsRecording" /> property's name.
        /// </summary>
        public const string IsRecordingPropertyName = "IsRecording";
        private bool _isRecording = false;
        /// <summary>
        /// Sets and gets the IsRecording property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRecording
        {
            get
            {
                return _isRecording;
            }

            set
            {
                if (_isRecording == value)
                {
                    return;
                }

                _isRecording = value;

                RaisePropertyChanged(IsRecordingPropertyName);
            }
        }

        private RelayCommand _executeStartOrStopRecording;

        /// <summary>
        /// Gets the ExecuteStartOrStopRecording.
        /// </summary>
        public RelayCommand ExecuteStartOrStopRecording
        {
            get
            {
                return _executeStartOrStopRecording
                    ?? (_executeStartOrStopRecording = new RelayCommand(ExecuteExecuteStartOrStopRecording));
            }
        }

        private void ExecuteExecuteStartOrStopRecording()
        {
            if (IsRecording)
            {

                SetOSDStyledREC(STREAM_A);
                string fullPathToSound = Path.GetFullPath(@"Start_Rec.wav");
                try { var simpleSound = new SoundPlayer(fullPathToSound); simpleSound.Play(); } catch { }
                DiveTime1 = TimeSpan.Zero;
                startDateTime1 = DateTime.Now;
                StartRecording();

                SuppressEditing = true;

                _Chart1_saved = false;
                StatusMessage = "Recording - F3 STOP"; //Was F3 now toggle START/STOP Arlindo 02.MAR.2017
                
                DivingTimer1.Start();

                //Log("System Started and Internal Temperature was:" + TemperatureLevel + " ºC");

                MaxDepthValue1 = 0f;
                MaxDepthString1 = "0.0 m";
         
                MyPlotModel.Axes.Clear();
                MyPlotModel2.Axes.Clear();
                (MyPlotModel.Series[0] as LineSeries).Points.Clear();
                (MyPlotModel2.Series[0] as LineSeries).Points.Clear();
                MyPlotModel.Series.Clear();
                MyPlotModel2.Series.Clear();
                SetupCharting();

                if (!_dive1StartLogged)
                {
                    _dive1StartLogged = true;
                    _dive1StopLogged = false;
                    Log("Start Recording 1");
                    Log("Start Dive - Internal Temperature: " + TemperatureStatus.ToString("00") + " ºC");
                    Log("Start Diving Depth 1 was: " + Depth1 + " m");
                    Log("Start Dive Profile Chart 1");
                }
            }
            else
            {
                SetOSDStyledRECSTOP(STREAM_A);

                StopRecording();

                if(IsRecording2)
                {
                    SuppressEditing = true;
                }

                if (!IsRecording && !IsRecording2)
                {
                    SuppressEditing = false;
                    SuppressEditing2 = false;
                }

                SaveChartImage1();
                _Chart1_saved = true;

                if (!_dive1StopLogged)
                {
                    _dive1StopLogged = true;
                    _dive1StartLogged = false;
                    Log("Stop Recording 1");
                    Log("End Dive - Internal Temperature: " + TemperatureStatus.ToString("00") + " ºC");
                    Log("Maximum Depth 1 was: " + MaxDepthValue1 + " m");
                    Log("Ended Dive Depth 1 was: " + Depth1 + " m");
                    Log("Save Dive Profile Chart 1" + "\r\n");
                }
                StatusMessage = "Stopped - F3 REC";

                DivingTimer1.Stop();
                startDateTime1 = DateTime.Now;
                string fullPathToSound = Path.GetFullPath(@"Stop_Rec.wav");
                try { var simpleSound = new SoundPlayer(fullPathToSound); simpleSound.Play(); } catch { }
            }

        }

        /// <summary>
        /// The <see cref="IsRecording2" /> property's name.
        /// </summary>
        public const string IsRecordingPropertyName2 = "IsRecording2";
        private bool _isRecording2= false;
        /// <summary>
        /// Sets and gets the IsRecording property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRecording2
        {
            get
            {
                return _isRecording2;
            }

            set
            {
                if (_isRecording2 == value)
                {
                    return;
                }

                _isRecording2 = value;

                RaisePropertyChanged(IsRecordingPropertyName2);
            }
        }

        public RelayCommand _executeStartOrStopRecording2;

        /// <summary>
        /// Gets the ExecuteStartOrStopRecording.
        /// </summary>
        public RelayCommand ExecuteStartOrStopRecording2
        {
            get
            {
                return _executeStartOrStopRecording2
                    ?? (_executeStartOrStopRecording2 = new RelayCommand(ExecuteExecuteStartOrStopRecording2));
            }
        }

        private void ExecuteExecuteStartOrStopRecording2()
        {
            if (IsRecording2)
            {
                SetOSDStyledREC2(STREAM_A);
                string fullPathToSound = Path.GetFullPath(@"Start_Rec.wav");
                try { var simpleSound = new SoundPlayer(fullPathToSound); simpleSound.Play(); } catch { }
                DiveTime2 = TimeSpan.Zero;
                startDateTime2 = DateTime.Now;
                StartRecording2();

                SuppressEditing2 = true;
                
                if (!IsRecording)
                {
                    SuppressEditing = true;
                }
                
                StatusMessage2 = "Recording - F4 STOP"; // F4 now toggle START/STOP Arlindo 02.MAR.2017
                _Chart2_saved = false;

                DivingTimer2.Start();

                //Log("System Started and Internal Temperature was:" + TemperatureLevel + " �C");
                MaxDepthValue2 = 0f;
                MaxDepthString2 = "0.0 m";

                MyPlotModel21.Axes.Clear();
                MyPlotModel22.Axes.Clear();
                (MyPlotModel21.Series[0] as LineSeries).Points.Clear();
                (MyPlotModel22.Series[0] as LineSeries).Points.Clear();
                MyPlotModel21.Series.Clear();
                MyPlotModel22.Series.Clear();
                SetupCharting2();

                if (!_dive2StartLogged)
                {
                    _dive2StartLogged = true;
                    _dive2StopLogged = false;
                    Log("Start Recording 2");
                    Log("Start Dive - Internal Temperature: " + TemperatureStatus.ToString("00") + " ºC");
                    Log("Start Diving Depth 2 was: " + Depth2 + " m");
                    Log("Start Dive Profile Chart 2");
                }
            }
            else
            {
                SetOSDStyledRECSTOP2(STREAM_A);


                StopRecording2();

                if(IsRecording)
                {
                    SuppressEditing = true;
                }
                
                if (!IsRecording && !IsRecording2)
                {
                    SuppressEditing = false;
                    SuppressEditing2 = false;
                }
               


                SaveChartImage2(); //Arlindo OUT21
                _Chart2_saved = true;

                if (!_dive2StopLogged)
                {
                    _dive2StopLogged = true;
                    _dive2StartLogged = false;
                    Log("Stop Recording 2");
                    Log("End Dive - Internal Temperature: " + TemperatureStatus.ToString("00") + " ºC");
                    Log("Maximum Depth 2 was: " + MaxDepthValue2 + " m");
                    Log("Ended Dive Depth 2 was: " + Depth2 + " m");
                    Log("Save Dive Profile Chart 2" + "\r\n");
                }
                StatusMessage2 = "Stopped - F4 REC";

                DivingTimer2.Stop();
                startDateTime2 = DateTime.Now;
                string fullPathToSound = Path.GetFullPath(@"Stop_Rec.wav");
                try { var simpleSound = new SoundPlayer(fullPathToSound); simpleSound.Play(); } catch { }
            }

        }
        #region Log File 
        public void Log(string logMessage)
        {
            LogPath = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\log.txt";
           
            using (StreamWriter w = File.AppendText(LogPath))
            w.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()} {"- " + logMessage}");
            
        }
        #endregion

        private void SaveChartImage1()
        {
            ChartsDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts1";
            if (!Directory.Exists(ChartsDirectoryPath1))
            {
                Directory.CreateDirectory(ChartsDirectoryPath1);
            }
            // Changed to PDF due to Win 10 photo viwer black background, no axes visible by Arlindo Dez-2015
            string fileName = string.Format(@"{0}\{1}.pdf", ChartsDirectoryPath1, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));
            OxyPlot.Pdf.PdfExporter.Export(MyPlotModel2, fileName, MyPlotModel2.Width, MyPlotModel2.Height); // was Width - 50
           
        }
        private void SaveChartImage2()
        {
            ChartsDirectoryPath2 = "F:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts2";
            if (!Directory.Exists(ChartsDirectoryPath2))
            {
                Directory.CreateDirectory(ChartsDirectoryPath2);
            }
            // Changed to PDF due to Win 10 photo viwer black background, no axes visible by Arlindo Dez-2015
            string fileName2 = string.Format(@"{0}\{1}.pdf", ChartsDirectoryPath2, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));
            OxyPlot.Pdf.PdfExporter.Export(MyPlotModel22, fileName2, MyPlotModel22.Width, MyPlotModel22.Height); // was Width - 50

        }
        #endregion

        #region Status String

        /// <summary>
        /// The <see cref="StatusMessage" /> property's name.
        /// </summary>
        public const string StatusMessagePropertyName = "StatusMessage";

        private string _statusMessage = "[Status]";

        /// <summary>
        /// Sets and gets the StatusMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }

            set
            {
                if (_statusMessage == value)
                {
                    return;
                }

                _statusMessage = value;
                RaisePropertyChanged(StatusMessagePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="StatusMessage2" /> property's name.
        /// </summary>
        public const string StatusMessagePropertyName2 = "StatusMessage2";

        private string _statusMessage2 = "[Status2]";

        /// <summary>
        /// Sets and gets the StatusMessage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StatusMessage2
        {
            get
            {
                return _statusMessage2;
            }

            set
            {
                if (_statusMessage2 == value)
                {
                    return;
                }

                _statusMessage2 = value;
                RaisePropertyChanged(StatusMessagePropertyName2);
            }
        }

        #endregion

        #region Board Info

        /// <summary>
        /// The <see cref="BoardInfoString" /> property's name.
        /// </summary>
        public const string BoardInfoStringPropertyName = "BoardInfoString";

        private string _boardInfo = "Board Info:";

        /// <summary>
        /// Sets and gets the BoardInfoString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BoardInfoString
        {
            get
            {
                return _boardInfo;
            }

            set
            {
                if (_boardInfo == value)
                {
                    return;
                }

                _boardInfo = value;
                RaisePropertyChanged(BoardInfoStringPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="BoardInfoString2" /> property's name.
        /// </summary>
        public const string BoardInfoStringPropertyName2 = "BoardInfoString2";

        private string _boardInfo2 = "Board Info:";

        /// <summary>
        /// Sets and gets the BoardInfoString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BoardInfoString2
        {
            get
            {
                return _boardInfo2;
            }

            set
            {
                if (_boardInfo2 == value)
                {
                    return;
                }

                _boardInfo2 = value;
                RaisePropertyChanged(BoardInfoStringPropertyName2);
            }
        }

        #endregion

        #region SuppressEditing

        /// <summary>
        /// The <see cref="SuppressEditing" /> property's name.
        /// </summary>
        public const string SuppressEditingPropertyName = "SuppressEditing";

        private bool _suppress = false;

        /// <summary>
        /// Sets and gets the SuppressEditing property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool SuppressEditing
        {
            get
            {
                return !IsRecording;
            }

            set
            {
                if (_suppress == value)
                {
                    return;
                }

                _suppress = value;
                RaisePropertyChanged(SuppressEditingPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SuppressEditing2" /> property's name.
        /// </summary>
        public const string SuppressEditingPropertyName2 = "SuppressEditing2";

        private bool _suppress2 = false;

        /// <summary>
        /// Sets and gets the SuppressEditing property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool SuppressEditing2
        {
            get
            {
                return !IsRecording2;
            }

            set
            {
                if (_suppress2 == value)
                {
                    return;
                }

                _suppress2 = value;
                RaisePropertyChanged(SuppressEditingPropertyName2);
            }
        }


        #endregion


        #region Open Folder Command

        private RelayCommand _openFolderCommand;

        /// <summary>
        /// Gets the OpenFolderCommand.
        /// </summary>
        public RelayCommand OpenFolderCommand
        {
            get
            {
                return _openFolderCommand
                    ?? (_openFolderCommand = new RelayCommand(ExecuteOpenFolderCommand));
            }
        }

        private void ExecuteOpenFolderCommand()
        {
            var runExplorer = new ProcessStartInfo();
            if (Properties.Settings.Default.JobNameText == (""))
            {
                VideoDirectoryPath1 = "D:\\PVSS DUO PRO 1";
            }
            else
            //VideoDirectoryPath1 = Directory.GetCurrentDirectory() + "\\My Dives1" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos";
            runExplorer.FileName = "explorer.exe";
            runExplorer.Arguments = VideoDirectoryPath1;
            Process.Start(runExplorer);
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()

        {
            Messenger.Default.Register<string>(this, CallCleanUp);

            StatusMessage = "Stopped - F3 REC";
            StatusMessage2 = "Stopped - F4 REC";

            if (IsInDesignModeStatic)
            {
                BoardInfoString = "Board Info: N/A";
                BatteryPercentage = 50;
                FreeDiskSpace_GB = 90.01;
                AvailableVideoTime_Hours = "12.50";
                DepthSensorStatusText1 = "Depth sensor malfunction. (short)";
                DepthSensorMessageColor1 = RedBrush;
                DepthSensorStatusText2 = "Depth sensor malfunction. (short)";
                DepthSensorMessageColor2 = RedBrush;

                DepthString1 = "12,3 m";
                DepthString2 = "22,4 m";
                Longitude = "41º11'14,2139''N";
                Latitude = "08º42'12,269''W";
                return;
            }

            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"mid2253.dll");
            DLLVersion = myFileVersionInfo.FileVersion;

            //Just used to get all the COM Ports available
            Thread.Sleep(2000); // Arlindo NOV 2021 Wait till all COM ports come up

            CommunicationManager c = new CommunicationManager();
            COMPortsList = c.GetPortNames();

            // If the saved COM port is not in the available list, auto-select the first available one
            if (COMPortsList.Count > 0 && !COMPortsList.Contains(COMPortListSelectedItem))
            {
                _COMPortListSelectedItem = COMPortsList[0]; // set backing field directly, no save/PropertyChanged yet
            }

            //Used to start the application with telemetry already on
            COMPortIsEnabled = true;
            ExecuteStartOrStopCOMPortMethod();
            
            SetupBoard();

            // Updates Dive time
            DivingTimer1.Interval = TimeSpan.FromSeconds(1);
            DivingTimer1.Tick += new EventHandler(DivingTimer_Tick1);
            DivingTimer2.Interval = TimeSpan.FromSeconds(1);
            DivingTimer2.Tick += new EventHandler(DivingTimer_Tick2);


            // Updates OSD Date
            TelemetryTimer.Interval = TimeSpan.FromSeconds(1);
            TelemetryTimer.Tick += new EventHandler(OneSecondTimer_tick);
            TelemetryTimer.Start();

            //Clear Low Battery  Message flag
            //LowBatErrorTimer.Interval = TimeSpan.FromMinutes(1);
            //LowBatErrorTimer.Tick += new EventHandler(One_Minute_Timer_tick);

            // Update disk space available every 15 seconds
            DiskMonitorTimer.Interval = TimeSpan.FromSeconds(15);
            DiskMonitorTimer.Tick += new EventHandler(DiskMonitorTimer_Tick);
            DiskMonitorTimer.Start();
            DiskMonitorTimer_Tick(null, null);

            // Commnet Text line Display Interval Timer by a ComboBox 5, 10, 15 seconds or Always ON
            DisplayLineTimer.Interval = TimeSpan.FromSeconds(5);
            DisplayLineTimer.Tick += new EventHandler(DisplayLineTimer_tick);

            System.Windows.Application.Current.MainWindow.KeyUp += new System.Windows.Input.KeyEventHandler(MainWindow_KeyUp);
           
            // Instruct the file system watcher to call the FileCreated method
            // when there are files created at the folder.
            if (!Directory.Exists(JobNameDiretory1))
                Directory.CreateDirectory(JobNameDiretory1);
            try
            {
                fileSystemWatcher = new FileSystemWatcher(JobNameDiretory1)
                {
                    IncludeSubdirectories = true,
                    //fileSystemWatcher.Filter = "*.*";
                    NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.DirectoryName
                };
                fileSystemWatcher.Created += new FileSystemEventHandler(FileSystemWatcher_Created);
                fileSystemWatcher.EnableRaisingEvents = true;
            }
            catch (Exception) { /* Drive not ready — snapshots won't update live */ }

            void FileSystemWatcher_Created(object sender, FileSystemEventArgs e) // Solved Exception by Manuel Alberto 27.Abri.2019
            {
                string filepath1 = new Uri(e.FullPath).ToString();
                string extension = Path.GetExtension(filepath1);
                if (extension == ".bmp")
                {
                    LastSnapshotImage1 = new Uri(e.FullPath);                   
                }

            }

            // Instruct the file system watcher to call the FileCreated method
            // when there are files created at the folder.
            if (Directory.Exists(Path.GetPathRoot(JobNameDiretory2)))
            {
                if (!Directory.Exists(JobNameDiretory2))
                    Directory.CreateDirectory(JobNameDiretory2);
                try
                {
                    fileSystemWatcher = new FileSystemWatcher(JobNameDiretory2)
                    {
                        IncludeSubdirectories = true,
                        //fileSystemWatcher.Filter = "*.*";
                        NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.DirectoryName
                    };
                    fileSystemWatcher.Created += new FileSystemEventHandler(FileSystemWatcher_Created2);
                    fileSystemWatcher.EnableRaisingEvents = true;
                }
                catch (Exception) { /* Drive not ready — snapshots won't update live */ }
            }


            void FileSystemWatcher_Created2(object sender, FileSystemEventArgs e) 
            {
                string filepath2 = new Uri(e.FullPath).ToString();
                string extension = Path.GetExtension(filepath2);
                if (extension == ".bmp")
                {
                    LastSnapshotImage2 = new Uri(e.FullPath);
                }

            }

            SetupCharting();
            SetupCharting2();

            // List of devices at Developer Machine
            //Blackmagic WDM Capture
            //Logitech Webcam C160
            //Sensoray 2253 Capture A
            //Sensoray 2253 Capture B
            //Sensoray 2253 Decode
            //Decklink Video Capture
            //Trust 1080p Full HD Webcam

            var allVideoDevices = WPFMediaKit.DirectShow.Controls.MultimediaUtil.VideoInputDevices;

            Sensoray_codec = false;
            foreach (DirectShowLib.DsDevice device in allVideoDevices)
            {
                //if (device.Name == "Trust 1080p Full HD Webcam"       // dev/test camera Diver 1
                if (device.Name == "Sensoray 2253 Capture A")    // production Sensoray Diver 1
                {
                    Video = device;  // Diver 1
                    Sensoray_codec = true;
                    break;
                }
            }
            foreach (DirectShowLib.DsDevice device in allVideoDevices)
            {
                //if (device.Name == "Logitech Webcam C160"             // dev/test camera Diver 2
                if (device.Name == "Sensoray 2253 Capture A #3")       // production Sensoray Diver 2                                                                        
                {
                    Video1 = device;  // Diver 2
                    Sensoray_codec = true;
                    break;
                }
            }

            if (!Sensoray_codec)   //Arlindo 2021
            {
                Thread thread = new Thread(
                        () =>
                        {
                            Log("Error - No Video Encoder Detected");
                            System.Windows.MessageBox.Show("Video Encoder Error, Please Reboot PVSS System!",
                            "No Video Encoder Detected",
                            MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);
                        });
                thread.Start();
                System.Windows.Application.Current.Shutdown();
            }

            _startupCompleted = true;
        }
        private void CallCleanUp(string obj)
        {
            Cleanup();
        }

        void DiskMonitorTimer_Tick(object sender, EventArgs e)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())  // Cames from onesecondtick loop due to Preview Image freezing by ARLINDO 26.MAR.2015
            {
                if (drive.IsReady && drive.Name == "D:\\")
                {
                    FreeDiskSpace_GB = Math.Round(Convert.ToDouble(drive.AvailableFreeSpace) / 1024 / 1024 / 1024, 2);
                    TimeSpan t = TimeSpan.FromHours(_freeDiskSpace_GB / 1.34);
                    AvailableVideoTime_Hours = t.TotalHours.ToString("F2", CultureInfo.InvariantCulture);
                }
            }

            // Read CPU/Motherboard temperature via WMI (MSAcpi_ThermalZoneTemperature)
            try
            {
                var temps = Temperature.Temperatures;
                if (temps != null && temps.Count > 0)
                {
                    TemperatureStatus = (float)temps[0].CurrentValue;
                    string tempStr = TemperatureStatus.ToString("00");

                    // Critical: > 55 ºC  (ambient/chassis thermal zone — not CPU core)
                    if (TemperatureStatus > 55 && !AlreadyShownCriticalOverTemperature)
                    {
                        AlreadyShownCriticalOverTemperature = true;
                        Log("CRITICAL Ambient Over Temperature at: " + tempStr + " ºC");
                        Thread tcrit = new Thread(() =>
                        {
                            System.Windows.MessageBox.Show(
                                "  CRITICAL Ambient Temperature at " + tempStr + " ºC !!!\n" +
                                " !! Check system ventilation and cooling immediately !! ",
                                "* CRITICAL * Ambient Temperature",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        });
                        tcrit.Start();
                    }
                    else if (TemperatureStatus <= 50)
                    {
                        AlreadyShownCriticalOverTemperature = false; // re-arm once cooled
                    }

                    // Warning: > 45 ºC
                    if (TemperatureStatus > 45 && !AlreadyShownWarningOverTemperature)
                    {
                        AlreadyShownWarningOverTemperature = true;
                        Log("Warning Ambient Over Temperature at: " + tempStr + " ºC");
                        Thread twarn = new Thread(() =>
                        {
                            System.Windows.MessageBox.Show(
                                "  Ambient Temperature at " + tempStr + " ºC, too High\n" +
                                " !! Check system ventilation !! ",
                                "* WARNING * Ambient Temperature",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                        });
                        twarn.Start();
                    }
                    else if (TemperatureStatus <= 40)
                    {
                        AlreadyShownWarningOverTemperature = false; // re-arm once cooled down
                    }
                }
            }
            catch
            {
                // Sensor not available on this hardware
            }
        }

        void DisplayLineTimer_tick(object sender, EventArgs e)
        {
            OSDLine1Submitted = ""; // Clear Styled text
            SetOSDStyled1(STREAM_A);
            SetOSDStyled1(STREAM_B);

            OSDLine12Submitted = ""; // Clear Styled text
            SetOSDStyled12(STREAM_A);
            SetOSDStyled12(STREAM_B);

            DisplayLineTimer.Stop();
        }

            
        void MainWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
           
            switch (e.Key == Key.System ? e.SystemKey : e.Key) // due to use of "F10" a special system key
            {
                case Key.F1: // Camera 1
                    IsCameraOn1 = !IsCameraOn1;
                    break;
                case Key.F2: // Camera 2
                    IsCameraOn2 = !IsCameraOn2;
                    break;
                case Key.F3:  // REC 1
                    IsRecording = !IsRecording;
                    break;
                case Key.F4:  // REC 2
                    IsRecording2 = !IsRecording2;
                    break;
                case Key.F5: // Comment 1 
                    OSDPopupVisibility = !OSDPopupVisibility;
                    break;
                case Key.F6: // Comment 2
                    OSDPopupVisibility2 = !OSDPopupVisibility2;
                    break;
                case Key.F9:  // Light 1
                    IsLightOn = !IsLightOn;
                    break;
                case Key.F10: // Light 2
                    IsLightOn2 = !IsLightOn2;
                    e.Handled = true;
                    break;
                case Key.Enter:
                    if (OSDPopupVisibility)
                    {
                        OSDLine1Submitted = OSDLine1;
                        OSDPopupVisibility = false;
                        
                        MainWindow win11 = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                        if (win11 != null)
                        {
                            Thread.Sleep(150);
                            win11.TakeSnapshot();
                        }
                    }
                     
                    if (OSDPopupVisibility2)
                    {
                        OSDLine12Submitted = OSDLine12;
                        OSDPopupVisibility2 = false;
                        MainWindow win12 = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                        if (win12 != null)
                        {
                            Thread.Sleep(150);
                            win12.TakeSnapshot2();                          
                        }
                    }
                    break;
                default:
                    break;
            }
        }

       
        // Just because we are using PRODIVING telemetry
        private bool AlreadyShownWarningChargerOn = false; // Power Line Warning Always on
        private bool AlreadyShownWarningOverTemperature = false;   // CPU Warning  > 70 ºC
        private bool AlreadyShownCriticalOverTemperature = false;   // CPU Critical > 85 ºC

        // Calculate Checksum of incoming string to check if is valid
        public static string GetChecksum(string sentence)
        {
            //Start with first Item
            int checksum = Convert.ToByte(sentence[sentence.IndexOf('#') + 1]);
            // Loop through all chars to get a checksum
            for (int i = sentence.IndexOf('#') + 2; i < sentence.IndexOf('*'); i++)
            {
                // No. XOR the checksum with this character's value
                checksum ^= Convert.ToByte(sentence[i]);
            }
            // Return the checksum formatted as a two-character hexadecimal
            return checksum.ToString("X2");
        }

        private void IOPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {     
#if PVSS_PRO            
            try
            {
                if ((!string.IsNullOrEmpty(MyCommunicationManager.LastMsg)) && (MyCommunicationManager.LastMsg.StartsWith("#DVA")))
                {
                    string new_depth = MyCommunicationManager.LastMsg;
                                        
                    string _ReadCheckSum = new_depth.Substring(new_depth.Length - 5);
                    string _CalculatedCheckSum = (GetChecksum(new_depth));
                    
 
                    int _Read = int.Parse(_ReadCheckSum, System.Globalization.NumberStyles.HexNumber);  // Because checksum is a 2 bytes hex p. ex. "7C" "73"
                    int _Calculated = int.Parse(_CalculatedCheckSum, System.Globalization.NumberStyles.HexNumber);

                    if (_Read == _Calculated)
                    {
                        _IsDepthStringValid =true;
                    }
                    else
                    {
                        _IsDepthStringValid = false;
                    }
                 
                    if (_IsDepthStringValid)  // #DVA,1,1024,0,1,2,1024,0,1,*7C => #DVA, <1>, <value1>, <short1>, <open1>, <2>, <value2>, <short2>, <open2>*<checksum>
                    {
                        //Console.WriteLine("Valid: " + MyCommunicationManager.LastMsg); //Arlindo 2021
                        string[] new_depthinfo = new_depth.Split(',');
                        string ch1 = new_depthinfo[1];
                        //Console.WriteLine("Diver " + ch1);

                        string ch1_depth = new_depthinfo[2];
                        if (int.TryParse(ch1_depth, out result) == true)
                        {
                            int _pro_depth1 = int.Parse(ch1_depth);//, CultureInfo.InvariantCulture.NumberFormat);
                            //Console.WriteLine("Depth 1 " + _pro_depth1);
                            DepthSensorReading1 = _pro_depth1;
                        }

                        string ch1_short = new_depthinfo[3];
                        if (int.TryParse(ch1_short, out result) == true)
                        {
                            _pro_short1 = int.Parse(ch1_short);//, CultureInfo.InvariantCulture.NumberFormat);
                        }

                        string ch1_open = new_depthinfo[4];
                        if (int.TryParse(ch1_open, out result) == true)
                        {
                            _pro_open1 = int.Parse(ch1_open);//, CultureInfo.InvariantCulture.NumberFormat);
                        }

                        //Console.WriteLine("Sensor Open " + _pro_open1);
                        if (_pro_open1 == 1)
                        {
                            sensorstatus1 = "open";
                        }
                        if (_pro_short1 == 1)
                        {
                            sensorstatus1 = "short";
                        }
                        if ((_pro_open1 == 0) && (_pro_short1 == 0))
                        {
                            sensorstatus1 = "ok";
                        }

                        string ch2 = new_depthinfo[5];
                        //Console.WriteLine("Diver " + ch2);

                        string ch2_depth = new_depthinfo[6];
                        //Console.WriteLine("Depth " + ch2_depth);
                        if (int.TryParse(ch2_depth, out result) == true)
                        {
                            int _pro_depth2 = int.Parse(ch2_depth); //, CultureInfo.InvariantCulture.NumberFormat);
                            //Console.WriteLine("Depth 2 " + _pro_depth2);
                            DepthSensorReading2 = _pro_depth2;
                        }

                        string ch2_short = new_depthinfo[7];
                        //Console.WriteLine("Sensor Short " + ch2_short);
                        if (int.TryParse(ch1_short, out result) == true)
                        {
                            _pro_short2 = int.Parse(ch2_short); //, CultureInfo.InvariantCulture.NumberFormat);
                        }

                        string ch2_open = new_depthinfo[8];
                        //Console.WriteLine("Sensor Open " + ch2_open);
                        if (int.TryParse(ch2_open, out result) == true)
                        {
                            _pro_open2 = int.Parse(ch2_open); //, CultureInfo.InvariantCulture.NumberFormat);
                        }

                        if (_pro_open2 == 1)
                        {
                            sensorstatus2 = "open";
                        }
                        if (_pro_short2 == 1)
                        {
                            sensorstatus2 = "short";
                        }
                        if ((_pro_open2 == 0) && (_pro_short2 == 0))
                        {
                            sensorstatus2 = "ok";
                        }
                    }
                }
            }
            catch { }
#endif

            ChargerStatus = BATTERY_CHARGER_STATUS_ON; // Overide condition for PVSS PRO DUO
            
            if (ChargerStatus == BATTERY_CHARGER_STATUS_ON && !AlreadyShownWarningChargerOn)
            {
                AlreadyShownWarningChargerOn = true;
                Log("External Mains Power apllied to System");
                var thread = new Thread(
                    () =>
                    {
                        System.Windows.MessageBox.Show("! CAUTION ! External Mains Power apllied to System." + "\n" + "      !!! Dot use when Diver is in Water !!!" + "\n" + "Use only if Grounding and RCD is present ",
                            "* WARNING * Mains Power ON",
                            MessageBoxButton.OK,
                            MessageBoxImage.Exclamation);
                    });
                thread.Start();

            }
            else if (ChargerStatus == BATTERY_CHARGER_STATUS_OFF)
            {
                AlreadyShownWarningChargerOn = false;
            }
      
            try
            {
#if PVSS_PRO
                Depth1 = (float)Math.Round((DepthSensorReading1 * SensorFactor / WaterFactor) / 1024.0f, 1) + Convert.ToSingle(Sensor1_Offset);
                Depth2 = (float)Math.Round((DepthSensorReading2 * SensorFactor / WaterFactor) / 1024.0f, 1) + Convert.ToSingle(Sensor2_Offset);
#else
                int DepthSensorReading = int.Parse(m_pattern_depth.Groups["depth"].Value);
#endif
            }
            catch { }

            if (Depth1 > MaxDepthValue1 && IsRecording)
            {
                MaxDepthValue1 = Depth1;

                MaxDepthString1 = MaxDepthValue1 + " m"; // was #.#
            }

            if (Depth2 > MaxDepthValue2 && IsRecording2)
            {
                MaxDepthValue2 = Depth2;

                MaxDepthString2 = MaxDepthValue2 + " m"; // was #.#
            }

            try
            {
#if PVSS_PRO
                DepthSensorStatus1 = sensorstatus1;
                DepthSensorStatus2 = sensorstatus2;
#else
                DepthSensorStatus = m_pattern_sensorstatus.Groups["sensorstatus"].Value;
#endif
            }
            catch { }

            if (DepthSensorStatus1 == DEPTH_SENSOR1_STATUS_OK)
            {
                DepthSensorStatusText1 = "Depth sensor OK";
                DepthSensorMessageColor1 = GreenBrush;
            }
            else if (DepthSensorStatus1 == DEPTH_SENSOR1_STATUS_OPEN)
            {
                DepthSensorStatusText1 = "Depth sensor malfunction (open)";
                DepthSensorMessageColor1 = RedBrush;
            }
            else if (DepthSensorStatus1 == DEPTH_SENSOR1_STATUS_SHORT)
            {
                DepthSensorStatusText1 = "Depth sensor malfunction (short)";
                DepthSensorMessageColor1 = RedBrush;
            }

            if (DepthSensorStatus2 == DEPTH_SENSOR2_STATUS_OK)
            {
                DepthSensorStatusText2 = "Depth sensor OK";
                DepthSensorMessageColor2 = GreenBrush;
            }
            else if (DepthSensorStatus2 == DEPTH_SENSOR2_STATUS_OPEN)
            {
                DepthSensorStatusText2 = "Depth sensor malfunction (open)";
                DepthSensorMessageColor2 = RedBrush;
            }
            else if (DepthSensorStatus2 == DEPTH_SENSOR2_STATUS_SHORT)
            {
                DepthSensorStatusText2 = "Depth sensor malfunction (short)";
                DepthSensorMessageColor2 = RedBrush;
            }

        }



        void OneSecondTimer_tick(object sender, EventArgs e)
        {
#if DEPTH_SIMULATOR
            // Simulator: sine wave 0–40 m, 120s period. Diver2 offset by 30s.
            _simTick++;
            Depth1 = (float)Math.Round(20.0 + 20.0 * Math.Sin(2.0 * Math.PI * _simTick / 120.0), 1);
            Depth2 = (float)Math.Round(20.0 + 20.0 * Math.Sin(2.0 * Math.PI * (_simTick + 30) / 120.0), 1);
            DepthSensorStatus1 = DEPTH_SENSOR1_STATUS_OK;
            DepthSensorStatus2 = DEPTH_SENSOR2_STATUS_OK;
#endif

            // Auto light-off: turn off light when diver is ascending (depth decreasing) and near surface (< 1m)
            if (AutoLightOff && IsLightOn && Depth1 < 1f && Depth1 < _prevDepth1)
            {
                IsLightOn = false;
                ExecuteChangeLightState();
                Log("Light 1 auto-off: ascending near surface at " + Depth1 + " m");
            }
            _prevDepth1 = Depth1;

            if (AutoLightOff && IsLightOn2 && Depth2 < 1f && Depth2 < _prevDepth2)
            {
                IsLightOn2 = false;
                ExecuteChangeLightState2();
                Log("Light 2 auto-off: ascending near surface at " + Depth2 + " m");
            }
            _prevDepth2 = Depth2;

#if PVSS_PRO
            //MyCommunicationManager.WriteData("$RID,*73\r\n");
            if(COMPortIsEnabled)
            {
                MyCommunicationManager.WriteData("$DVA,*7F\r\n"); // Get depth string
            }
           
            //MyCommunicationManager.WriteData("$RLY,0,0,0,0,*6A\r\n");
#endif
            SetOSDStyled_DiveTime(STREAM_A);
            SetOSDStyled_DiveTime(STREAM_B);

            SetOSDStyled_DiveTime2(STREAM_A);
            SetOSDStyled_DiveTime2(STREAM_B);

            SetOSDStyled_TodayDate(STREAM_A);
            SetOSDStyled_TodayDate(STREAM_B);

            SetOSDStyled_TodayTime(STREAM_A);
            SetOSDStyled_TodayTime(STREAM_B);

            SetOSDStyled_LAT_LONG(STREAM_A);
            SetOSDStyled_LAT_LONG(STREAM_B);

            if (IsRecording)
            {
                DataPoint data = new DataPoint(float.NaN, float.NaN);
                if (DepthSensorStatus1 == DEPTH_SENSOR1_STATUS_OK)
                {
                    data = new DataPoint(TimeSpanAxis.ToDouble(DiveTime1), -Depth1);
                }

                (MyPlotModel.Series[0] as LineSeries).Points.Add(data);
                MyPlotModel.RefreshPlot(true);

                (MyPlotModel2.Series[0] as LineSeries).Points.Add(data);
                MyPlotModel2.RefreshPlot(true);

                MyPlotModel2.Update();

            }
            if (IsRecording2)
            {
                DataPoint data2 = new DataPoint(float.NaN, float.NaN);

                if (DepthSensorStatus2 == DEPTH_SENSOR2_STATUS_OK)
                {
                    data2 = new DataPoint(TimeSpanAxis.ToDouble(DiveTime2), -Depth2);
                }
  
                (MyPlotModel21.Series[0] as LineSeries).Points.Add(data2);
                MyPlotModel21.RefreshPlot(true);

                (MyPlotModel22.Series[0] as LineSeries).Points.Add(data2);
                MyPlotModel22.RefreshPlot(true);

                MyPlotModel22.Update();

            }

        }

        #region IOPorts

        private void SetupIOPorts()
        {
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_1_2);
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF_1_2);
            SetOSDStyledRECSTOP(STREAM_A);
        }


        #endregion

        #region Drive Properties

        /// <summary>
        /// The <see cref="FreeDiskSpace_GB" /> property's name.
        /// </summary>
        public const string FreeDiskSpace_GBPropertyName = "FreeDiskSpace_GB";

        private double _freeDiskSpace_GB = 0;

        /// <summary>
        /// Sets and gets the FreeDiskSpace_GB property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double FreeDiskSpace_GB
        {
            get
            {
                return _freeDiskSpace_GB;
            }

            set
            {
                if (_freeDiskSpace_GB == value)
                {
                    return;
                }

                _freeDiskSpace_GB = value;

                RaisePropertyChanged(FreeDiskSpace_GBPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AvailableVideoTime_Hours" /> property's name.
        /// </summary>
        public const string AvailableVideoTime_HoursPropertyName = "AvailableVideoTime_Hours";

        private string _AvailableVideoTime_Hours = "";

        /// <summary>
        /// Sets and gets the AvailableVideoTime_Hours property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string AvailableVideoTime_Hours
        {
            get
            {
                return _AvailableVideoTime_Hours;
            }

            set
            {
                if (_AvailableVideoTime_Hours == value)
                {
                    return;
                }

                _AvailableVideoTime_Hours = value;
                RaisePropertyChanged(AvailableVideoTime_HoursPropertyName);
            }
        }

        #endregion

        #region DLLVersion

        // <summary>
        /// The <see cref="DLLVersion" /> property's name.
        /// </summary>
        public const string DLLVersionPropertyName = "DLLVersion";

        private string _DLLVersion = "";

        /// <summary>
        /// Sets and gets the DLLVersion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DLLVersion
        {
            get
            {
                return _DLLVersion;
            }

            set
            {
                if (_DLLVersion == value)
                {
                    return;
                }

                _DLLVersion = value;

                RaisePropertyChanged(DLLVersionPropertyName);
            }
        }



        #endregion

        private void DivingTimer_Tick1(object sender, EventArgs e)
        {
            DiveTime1 = DateTime.Now - startDateTime1;
        }
        private void DivingTimer_Tick2(object sender, EventArgs e)
        {
            DiveTime2 = DateTime.Now - startDateTime2;
        }

        #region Clear Low Bat Alarm
        //private void One_Minute_Timer_tick(object sender, EventArgs e) //by ARLINDO Clear Error Message and restart REC STOP/START every minute
        //{
        //    LowBatErrorTimer.Stop();
        //    SendKeys.SendWait("{ESC}");
        //   // AlreadyShownWarningBatteryLevelCritical = false;
        //    LowBatErrorTimer.Start();            
        //}
        #endregion

        // Setup Sensoray Boxes
        private void SetupBoard()
        {
            Int32 numDevices = 0;
            UInt32 serial_number = 0;
            Int32 param = 0;
            UInt32 serial_number2 = 0;
            Int32 param2 = 0;
            String deviceId1;
            String deviceId2;

            S2253.OpenBoard(-1);

            // Get Board Info  try it 4 times, some MB USB ports are too slow by Arlindo 18-SET-2013
            int tries = 4;
            do
            {
                S2253.GetNumDevices(ref numDevices);
                Thread.Sleep(100);
                tries--;
            }
            while (numDevices < 1 && tries > 0);

            S2253.GetSerialNumber(ref serial_number, 0);
            S2253.GetParam(S2253.MID2253_PARAM.MID2253_PARAM_FIRMWARE, ref param, 0, 0);

            S2253.GetSerialNumber(ref serial_number2, 1);
            S2253.GetParam(S2253.MID2253_PARAM.MID2253_PARAM_FIRMWARE, ref param2, 1, 0);
            
            if (numDevices == 2)
            {
                deviceId1 = "1";
                deviceId2 = "2";
            }
            else
            {
                deviceId1 = "1";
                deviceId2 = "None";
            }

            BoardInfoString = String.Format("Board Info: ID:{0} SN:{1} FW:{2}", deviceId1, serial_number, param);
            BoardInfoString2 = String.Format("Board Info: ID:{0} SN:{1} FW:{2}", deviceId2, serial_number2, param2);

            #region Set Board Clock

            DateTime startTime = new DateTime(1970, 1, 1);
            UInt32 time_t;
            S2253.MID2253CLOCK clk;

            // Set the S2253 Clock
            time_t = Convert.ToUInt32((DateTime.Now - startTime).TotalSeconds);
            clk.sec = time_t;
            clk.usec = 0;
            S2253.SetClock(ref clk, 0);

            #endregion

            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_BRIGHTNESS, 128, 0);
            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_CONTRAST, 128, 0);
            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_SATURATION, 128, 0);
            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_HUE, 0, 0);

            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_BRIGHTNESS, 128, 1);
            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_CONTRAST, 128, 1);
            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_SATURATION, 128, 1);
            S2253.SetLevel(Sensoray.S2253.MID2253_LEVEL_HUE, 0, 1);

            // Set default values for the streams
            IsPALChecked = true;
            IsNTSCChecked = false;

            IsSDCameraChecked = true;
         
            IsHDCameraChecked = false;
            
            IsInterpolatedChecked = true;
            
            //Set Sensor and Water Type defaults
            Is_10_BarG = true;
            Is_25_BarG = false;
            IsSeaWaterChecked = true;
            IsFreshWaterChecked = false;

            S2253.SetVidSys(S2253.MID2253_VIDSYS.MID2253_VIDSYS_PAL, 0);
            S2253.SetPreviewType(S2253.MID2253_PREVIEWTYPE.MID2253_PREVIEWTYPE_VMR9, 0, STREAM_A);

            S2253.SetVidSys(S2253.MID2253_VIDSYS.MID2253_VIDSYS_PAL, 1);
            S2253.SetPreviewType(S2253.MID2253_PREVIEWTYPE.MID2253_PREVIEWTYPE_VMR9, 1, STREAM_A);

            S2253.SetStreamType((Int32)S2253.MID2253_STREAMTYPE.MID2253_STYPE_UYVY, 0, STREAM_A);
            S2253.SetStreamType((Int32)S2253.MID2253_STREAMTYPE.MID2253_STYPE_H264, 0, STREAM_B);
            S2253.SetOutputMode(S2253.MID2253_OUTPUT_MODE.MID2253_OUTPUT_PASSTHRU, 0); // new by ARLINDO 14-Jan-2015  Pass Video to Output

            S2253.SetStreamType((Int32)S2253.MID2253_STREAMTYPE.MID2253_STYPE_UYVY, 1, STREAM_A);
            S2253.SetStreamType((Int32)S2253.MID2253_STREAMTYPE.MID2253_STYPE_H264, 1, STREAM_B);
            S2253.SetOutputMode(S2253.MID2253_OUTPUT_MODE.MID2253_OUTPUT_PASSTHRU, 1); 

            S2253.SetRecordMode(S2253.MID2253_RECMODE.MID2253_RECMODE_AV, 0, STREAM_B);  // Video + Audio
            S2253.SetMp4Mode(S2253.MID2253_MP4MODE.MID2253_MP4MODE_STANDARD, 0, STREAM_B); // new 6.Dec.2012

            S2253.SetRecordMode(S2253.MID2253_RECMODE.MID2253_RECMODE_AV, 1, STREAM_B);  
            S2253.SetMp4Mode(S2253.MID2253_MP4MODE.MID2253_MP4MODE_STANDARD, 1, STREAM_B);

            S2253.SetImageSize(640, 480, 0, STREAM_A);
            S2253.SetImageSize(640, 480, 0, STREAM_B);

            S2253.SetImageSize(640, 480, 1, STREAM_A);
            S2253.SetImageSize(640, 480, 1, STREAM_B);

            S2253.SetIDR(1, 0, STREAM_B); //new at 10.SET.2013 by Arlindo (speed-up seek in play mode)
            S2253.SetIDR(1, 1, STREAM_B); 

            // Memory allocation for snapshots & Overlay
            bufHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            bufPtr = (IntPtr)bufHandle.AddrOfPinnedObject().ToInt32();
            //OSDOption = true;


            // AAC Audio bit rate verification
            //S2253.MID2253_AUDIO_BITRATE bitrate = new S2253.MID2253_AUDIO_BITRATE();
            //S2253.GetAudioBitrate(ref bitrate, 0, STREAM_B);

            S2253.SetAudioInput(S2253.MID2253_AUDIO_INPUT.MID2253_AUDIO_LINE, 0);
            S2253.SetAudioInput(S2253.MID2253_AUDIO_INPUT.MID2253_AUDIO_LINE, 1);


            /* Bitrate must be 96, otherwise it will crash due to USB bandwith - Manuel/Arlindo 02/12/2015 */
            S2253.SetAudioBitrate(S2253.MID2253_AUDIO_BITRATE.MID2253_AUDBR_96, 0, STREAM_B);
            S2253.SetAudioBitrate(S2253.MID2253_AUDIO_BITRATE.MID2253_AUDBR_96, 1, STREAM_B);

            AGC = true;
            AudioGainValue = 50;

            // Display mandatory strings                 
            SetOSDStyled2(STREAM_A);  // Company
            SetOSDStyled2(STREAM_B);
     
            SetOSDStyledJobName(STREAM_A); // Job Name
            SetOSDStyledJobName(STREAM_B);
            
            SetOSDStyledDiverName(STREAM_A); // Diver 1 Name
            SetOSDStyledDiverName(STREAM_B);
            SetOSDStyledDiver2Name(STREAM_A); // Diver 2 Name
            SetOSDStyledDiver2Name(STREAM_B);

        }

        private void StartRecording()
        {
            VideoDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\"  + Properties.Settings.Default.JobNameText + "\\Videos1";
        
            if (!Directory.Exists(VideoDirectoryPath1))
            {
                Directory.CreateDirectory(VideoDirectoryPath1);
            }


            string OutputVideoFileName1 = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath1, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));

            Last_file_name1 = OutputVideoFileName1; // Save last video file path and name, to be used by StopRecoding()

            if (File.Exists(OutputVideoFileName1))
            {
                string NewOutputVideoFileName = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath1, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); /// Arlindo OUT21
                File.Create(NewOutputVideoFileName);
            }


            S2253.SetBitrate(3000, 0, STREAM_B); //was 2500 03.12.2012 by Arlindo
            S2253.SetJpegQ(75, 0, STREAM_B);
           
            try
            {
                S2253.StartRecord(OutputVideoFileName1, 0, STREAM_B);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.InnerException.ToString(), e.Message);
            }

        }
        private void StartRecording2()
        {
            VideoDirectoryPath2 = "F:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos2";

            if (!Directory.Exists(VideoDirectoryPath2))
            {
                Directory.CreateDirectory(VideoDirectoryPath2);
            }


            string OutputVideoFileName2 = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath2, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));

            Last_file_name2 = OutputVideoFileName2; // Save last video file path and name, to be used by StopRecoding()

            if (File.Exists(OutputVideoFileName2))
            {
                string NewOutputVideoFileName = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath2, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); /// Arlindo OUT21
                File.Create(NewOutputVideoFileName);
            }

            S2253.SetBitrate(3000, 1, STREAM_B);
            S2253.SetJpegQ(75, 1, STREAM_B);

            try
            {
                S2253.StartRecord(OutputVideoFileName2, 1, STREAM_B);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.InnerException.ToString(), e.Message);
            }

        }

        private void StopRecording()
        {
            S2253.StopStream(0, STREAM_B);

            FileInfo info = new FileInfo(Last_file_name1);
            if (info.Exists && info.Length == 0)
            {
                System.Windows.MessageBox.Show("Video File is Empty or Severe Corruted !!!",
                          "*** WARNING ***",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning); // file existe but is empty
                Log("Diver 1 Video File is Empty or Severe Corruted");
            }
        }

        private void StopRecording2()
        {
            S2253.StopStream(1, STREAM_B);

            FileInfo info = new FileInfo(Last_file_name2);
            if (info.Exists && info.Length == 0)
            {
                System.Windows.MessageBox.Show("Video File is Empty or Severe Corruted !!!",
                          "*** WARNING ***",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning); // file existe but is empty
                Log("Diver 2 Video File is Empty or Severe Corruted");
            }
        }

        #region OSD

        public void SetOSDStyled_LAT_LONG(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_lat_long;
            st_osd_lat_long.osdChan = strmidx;
            //st_osd_date.osdOn = 1;
            st_osd_lat_long.id = 14;      // GPS LAT/LONG WAS .id 14 nmust be <= to 7 TBD
            st_osd_lat_long.xoffset = 66;
            st_osd_lat_long.yoffset = 400;
            st_osd_lat_long.size = 14;
            st_osd_lat_long.font = "Segoe UI";
            st_osd_lat_long.line = Latitude + "  " + Longitude;


            if (GPSIsEnabled && !Longitude.Contains("!"))
            {
                st_osd_lat_long.osdOn = 1;
            }
            else
            {
                st_osd_lat_long.osdOn = 0;
            }

            st_osd_lat_long.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_lat_long.outline = 4;
            st_osd_lat_long.background = 0;
            st_osd_lat_long.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_lat_long, 0, strmidx);
        }

        public void SetOSDStyled_TodayTime(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_time;
            st_osd_time.osdChan = strmidx;
            //st_osd_time.osdOn = 1; Option ON/OFF
            st_osd_time.id = 4; //"Time" "HH:mm:ss"
            st_osd_time.xoffset = 450;
            st_osd_time.yoffset = 440;
            st_osd_time.size = 14;
            st_osd_time.font = "Segoe UI";


            if (ShowDate)
            {
                st_osd_time.line = DateTime.Now.ToString("HH:mm:ss") + " -";  //Time
            }
            else
            {
                st_osd_time.line = DateTime.Now.ToString("HH:mm:ss");  //Time
                st_osd_time.xoffset = 530;
            }

            if (ShowTime)
            {
                st_osd_time.osdOn = 1;
            }
            else
            {
                st_osd_time.osdOn = 0;
            }

            st_osd_time.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_time.outline = 4;
            st_osd_time.background = 0;
            st_osd_time.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_time, 0, strmidx);
            S2253.SetOsd(ref st_osd_time, 1, strmidx);
        }


        public void SetOSDStyled_TodayDate(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_date;
            st_osd_date.osdChan = strmidx;
            //st_osd_date.osdOn = 1;  Option ON/OFF
            st_osd_date.id = 7; // "Date" "dd/MM/yyyy"
            st_osd_date.xoffset = 518;
            st_osd_date.yoffset = 440;
            st_osd_date.size = 14;
            st_osd_date.font = "Segoe UI";
            st_osd_date.line = DateTime.Now.ToString("dd/MM/yyyy");  //DATE

            if (ShowDate)
            {
                st_osd_date.osdOn = 1;
            }
            else
            {
                st_osd_date.osdOn = 0;
            }

            st_osd_date.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_date.outline = 4;
            st_osd_date.background = 0;
            st_osd_date.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_date, 0, strmidx);
            S2253.SetOsd(ref st_osd_date, 1, strmidx);
        }

        public void SetOSDStyled_DiveTime(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_divetime;
            st_osd_divetime.osdChan = strmidx;
            st_osd_divetime.osdOn = 1;
            st_osd_divetime.id = 6; // "DiveTime" and "Depth" 
            st_osd_divetime.xoffset = 66;
            st_osd_divetime.yoffset = 419;
            st_osd_divetime.size = 14;
            st_osd_divetime.font = "Segoe UI";
            st_osd_divetime.line = DiveTime1.ToString("hh\\:mm\\:ss") + " " + DepthString1;  //DiveTime OSDLine3 
            st_osd_divetime.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_divetime.outline = 4;
            st_osd_divetime.background = 0;
            st_osd_divetime.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_divetime, 0, strmidx);

        }

        public void SetOSDStyled_DiveTime2(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_divetime2;
            st_osd_divetime2.osdChan = strmidx;
            st_osd_divetime2.osdOn = 1;
            st_osd_divetime2.id = 6; // "DiveTime" and "Depth" 
            st_osd_divetime2.xoffset = 66;
            st_osd_divetime2.yoffset = 419;
            st_osd_divetime2.size = 14;
            st_osd_divetime2.font = "Segoe UI";
            st_osd_divetime2.line = DiveTime2.ToString("hh\\:mm\\:ss") + " " + DepthString2;  //DiveTime OSDLine3 
            st_osd_divetime2.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_divetime2.outline = 4;
            st_osd_divetime2.background = 0;
            st_osd_divetime2.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_divetime2, 1, strmidx);

        }

        public void SetOSDStyled1(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd1;
            st_osd1.osdChan = strmidx;
            st_osd1.osdOn = 1;
            st_osd1.id = 1; // User Text line Comments
            st_osd1.xoffset = 66;
            st_osd1.yoffset = 377;
            st_osd1.size = 14;
            st_osd1.font = "Segoe UI";
            st_osd1.line = OSDLine1Submitted; // User Text line Comments
            st_osd1.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd1.outline = 4;
            st_osd1.background = 0;
            st_osd1.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd1, 0, strmidx);

        }
        public void SetOSDStyled12(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd12;
            st_osd12.osdChan = strmidx;
            st_osd12.osdOn = 1;
            st_osd12.id = 1; // User Text line Comments
            st_osd12.xoffset = 66;
            st_osd12.yoffset = 377;
            st_osd12.size = 14;
            st_osd12.font = "Segoe UI";
            st_osd12.line = OSDLine12Submitted; // User Text line Comments
            st_osd12.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd12.outline = 4;
            st_osd12.background = 0;
            st_osd12.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd12, 1, strmidx);

        }

        public void SetOSDStyled2(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd2;
            st_osd2.osdChan = strmidx;
            st_osd2.osdOn = 1;
            st_osd2.id = 2; // "Company"
            st_osd2.xoffset = 490; //was 472 now 490
            st_osd2.yoffset = 419; // now 419 
            st_osd2.size = 14;
            st_osd2.font = "Segoe UI";
            st_osd2.line = OSDLine2;
            st_osd2.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd2.outline = 4;
            st_osd2.background = 0;
            st_osd2.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd2, 0, strmidx);
            S2253.SetOsd(ref st_osd2, 1, strmidx);

        }
        

        public void SetOSDStyledJobName(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osdjob;
            st_osdjob.osdChan = strmidx;
            st_osdjob.osdOn = 1;
            st_osdjob.id = 3; // "Job Name"
            st_osdjob.xoffset = 66;
            st_osdjob.yoffset = 440;
            st_osdjob.size = 14;
            st_osdjob.font = "Segoe UI";
            st_osdjob.line = "Job: " + JobName; //Job line into OSD
            st_osdjob.style = S2253.MID2253_STYLE_OUTLINE;
            st_osdjob.outline = 4;
            st_osdjob.background = 0;
            st_osdjob.color = 0; // 16777215; // White col
            S2253.SetOsd(ref st_osdjob, 0, strmidx);
            S2253.SetOsd(ref st_osdjob, 1, strmidx);
        }

            public void SetOSDStyledDiverName(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_diver;
            st_osd_diver.osdChan = strmidx;
            st_osd_diver.osdOn = 1;
            st_osd_diver.id = 0; // "Diver 1 Name"
            st_osd_diver.xoffset = 250;
            st_osd_diver.yoffset = 440;
            st_osd_diver.size = 14;
            st_osd_diver.font = "Segoe UI";
            st_osd_diver.line = "Diver 1: " + DiverName;
            st_osd_diver.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_diver.outline = 4;
            st_osd_diver.background = 0;
            st_osd_diver.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_diver, 0, strmidx);

        }

        public void SetOSDStyledDiver2Name(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osd_diver2;
            st_osd_diver2.osdChan = strmidx;
            st_osd_diver2.osdOn = 1;
            st_osd_diver2.id = 0; // "Diver 2 Name"
            st_osd_diver2.xoffset = 250;
            st_osd_diver2.yoffset = 440;
            st_osd_diver2.size = 14;
            st_osd_diver2.font = "Segoe UI";
            st_osd_diver2.line = "Diver 2: " + Diver2Name;
            st_osd_diver2.style = S2253.MID2253_STYLE_OUTLINE;
            st_osd_diver2.outline = 4;
            st_osd_diver2.background = 0;
            st_osd_diver2.color = 0; // 16777215; // White color for VIDEO_OUT only
            S2253.SetOsd(ref st_osd_diver2, 1, strmidx);

        }

        /// <summary>
        /// REC/STOP String only in PRIVIEW Channel
        /// </summary>
        /// <param name="strmidx"></param>
        public void SetOSDStyledREC(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osdr;
            st_osdr.osdChan = strmidx;
            st_osdr.osdOn = 1;
            st_osdr.id = 5; // "REC" and "STOP"
            st_osdr.xoffset = 20;
            st_osdr.yoffset = 20;
            st_osdr.size = 14;
            st_osdr.font = "Segoe UI";
            st_osdr.line = "REC";
            st_osdr.style = S2253.MID2253_STYLE_OUTLINE;
            st_osdr.outline = 1; //3
            st_osdr.background = 8; //8
            st_osdr.color = 6683909; //  123456; // Recording label RED was GREEN
            S2253.SetOsd(ref st_osdr, 0, strmidx);
        }
        /// <summary>
        /// REC/STOP String only in PRIVIEW Channel
        /// </summary>
        /// <param name="strmidx"></param>
        public void SetOSDStyledREC2(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osdr2;
            st_osdr2.osdChan = strmidx;
            st_osdr2.osdOn = 1;
            st_osdr2.id = 5; // "REC" and "STOP"
            st_osdr2.xoffset = 20;
            st_osdr2.yoffset = 20;
            st_osdr2.size = 14;
            st_osdr2.font = "Segoe UI";
            st_osdr2.line = "REC";
            st_osdr2.style = S2253.MID2253_STYLE_OUTLINE;
            st_osdr2.outline = 1; //3
            st_osdr2.background = 8; //8
            st_osdr2.color = 6683909; //  123456; // Recording label RED was GREEN
            S2253.SetOsd(ref st_osdr2, 1, strmidx);
        }

        public void SetOSDStyledRECSTOP(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osds;
            st_osds.osdChan = strmidx;
            st_osds.osdOn = 1;
            st_osds.id = 5; // "REC" and "STOP"
            st_osds.xoffset = 20;
            st_osds.yoffset = 20;
            st_osds.size = 14;
            st_osds.font = "Segoe UI";
            st_osds.line = "STOP";
            st_osds.style = S2253.MID2253_STYLE_OUTLINE;
            st_osds.outline = 1; //3
            st_osds.background = 8; //8
            st_osds.color = 16712462; //16711680; // Stop Label GREEN was RED
            S2253.SetOsd(ref st_osds, 0, strmidx);
        }

        public void SetOSDStyledRECSTOP2(int strmidx)
        {
            S2253.MID2253_OSD_STYLEDTEXT st_osds2;
            st_osds2.osdChan = strmidx;
            st_osds2.osdOn = 1;
            st_osds2.id = 5; // "REC" and "STOP"
            st_osds2.xoffset = 20;
            st_osds2.yoffset = 20;
            st_osds2.size = 14;
            st_osds2.font = "Segoe UI";
            st_osds2.line = "STOP";
            st_osds2.style = S2253.MID2253_STYLE_OUTLINE;
            st_osds2.outline = 1; //3
            st_osds2.background = 8; //8
            st_osds2.color = 16712462; //16711680; // Stop Label GREEN was RED
            S2253.SetOsd(ref st_osds2, 1, strmidx);
        }

        #endregion

        #region Video Levels

        #region Brightness
        /// <summary>
        /// The <see cref="BrightnessValue" /> property's name.
        /// </summary>
        public const string BrightnessValuePropertyName = "BrightnessValue";

        private int _brightnessValue = 128;

        /// <summary>
        /// Sets and gets the BrightnessValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int BrightnessValue
        {
            get
            {
                return _brightnessValue;
            }

            set
            {
                if (_brightnessValue == value)
                {
                    return;
                }

                _brightnessValue = value;
                S2253.SetLevel(S2253.MID2253_LEVEL_BRIGHTNESS, value, 0);
                //S2253.SetLevel(S2253.MID2253_LEVEL_BRIGHTNESS, value, STREAM_B);
                RaisePropertyChanged(BrightnessValuePropertyName);
            }
        }

        #endregion

        #region Contrast
        /// <summary>
        /// The <see cref="ContrastValue" /> property's name.
        /// </summary>
        public const string ContrastValuePropertyName = "ContrastValue";

        private int _contrast = 128;

        /// <summary>
        /// Sets and gets the ContrastValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ContrastValue
        {
            get
            {
                return _contrast;
            }

            set
            {
                if (_contrast == value)
                {
                    return;
                }

                _contrast = value;
                S2253.SetLevel(S2253.MID2253_LEVEL_CONTRAST, value, 0);
                //S2253.SetLevel(S2253.MID2253_LEVEL_CONTRAST, value, STREAM_B);
                RaisePropertyChanged(ContrastValuePropertyName);
            }
        }
        #endregion

        #region Saturation
        /// <summary>
        /// The <see cref="SaturationValue" /> property's name.
        /// </summary>
        public const string SaturationValuePropertyName = "SaturationValue";

        private int _saturation = 128;

        /// <summary>
        /// Sets and gets the SaturationValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SaturationValue
        {
            get
            {
                return _saturation;
            }

            set
            {
                if (_saturation == value)
                {
                    return;
                }

                _saturation = value;
                S2253.SetLevel(S2253.MID2253_LEVEL_SATURATION, value, 0);
                //S2253.SetLevel(S2253.MID2253_LEVEL_SATURATION, value, STREAM_B);
                RaisePropertyChanged(SaturationValuePropertyName);
            }
        }
        #endregion

        #region Hue
        /// <summary>
        /// The <see cref="HueValue" /> property's name.
        /// </summary>
        public const string HueValuePropertyName = "HueValue";

        private int _hue = 128;

        /// <summary>
        /// Sets and gets the HueValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int HueValue
        {
            get
            {
                return _hue;
            }

            set
            {
                if (_hue == value)
                {
                    return;
                }

                _hue = value;
                S2253.SetLevel(S2253.MID2253_LEVEL_HUE, value, 0);
                //S2253.SetLevel(S2253.MID2253_LEVEL_HUE, value, STREAM_B);
                RaisePropertyChanged(HueValuePropertyName);
            }
        }
        #endregion

        #region Video Mode (PAL/NTSC)

        #region PAL
        /// <summary>
        /// The <see cref="IsPALChecked" /> property's name.
        /// </summary>
        public const string IsPALCheckedPropertyName = "IsPALChecked";

        private bool _pal = true;

        /// <summary>
        /// Sets and gets the IsPALChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsPALChecked
        {
            get
            {
                return _pal;
            }

            set
            {
                if (_pal == value)
                {
                    return;
                }

                _pal = value;
                if (!IsRecording)
                {
                    if (value == true)
                    {
                        S2253.SetVidSys(S2253.MID2253_VIDSYS.MID2253_VIDSYS_PAL, 0);
                    }
                }
                RaisePropertyChanged(IsPALCheckedPropertyName);
            }
        }

        #endregion

        #region NTSC
        /// <summary>
        /// The <see cref="IsNTSCChecked" /> property's name.
        /// </summary>
        public const string IsNTSCCheckedPropertyName = "IsNTSCChecked";

        private bool _ntsc = false;

        /// <summary>
        /// Sets and gets the IsNTSCChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsNTSCChecked
        {
            get
            {
                return _ntsc;
            }

            set
            {
                if (_ntsc == value)
                {
                    return;
                }

                _ntsc = value;
                if (!IsRecording)
                {
                    if (value == true)
                    {
                        S2253.SetVidSys(S2253.MID2253_VIDSYS.MID2253_VIDSYS_NTSC, 0);
                    }
                }
                RaisePropertyChanged(IsNTSCCheckedPropertyName);
            }
        }
        #endregion
        #endregion
        #region Audio

        #region Audio Gain
        /// <summary>
        /// The <see cref="AudioGainValue" /> property's name.
        /// </summary>
        public const string AudioGainValuePropertyName = "AudioGainValue";

        private int _audioGain = 0;

        /// <summary>
        /// Sets and gets the AudioGainValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int AudioGainValue
        {
            get
            {
                return _audioGain;
            }

            set
            {
                if (_audioGain == value)
                {
                    return;
                }

                _audioGain = value;

                S2253.SetAudioGain(AGC, value, 0); // was STREAM_B

                RaisePropertyChanged(AudioGainValuePropertyName);
            }
        }
        #endregion

        #region AGC

        /// <summary>
        /// The <see cref="AGC" /> property's name.
        /// </summary>
        public const string AGCValuePropertyName = "AGCValue";

        private bool _aGCValue = false;

        /// <summary>
        /// Sets and gets the AGCValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool AGC
        {
            get
            {
                return _aGCValue;
            }

            set
            {
                if (_aGCValue == value)
                {
                    return;
                }

                _aGCValue = value;
                RaisePropertyChanged(AGCValuePropertyName);
            }
        }

        #endregion

        #endregion

        #region OSD Option


        #region OSD Text Option // Not Udsed

        ///// <summary>
        ///// The <see cref="OSDTextOption" /> property's name.
        ///// </summary>
        //public const string OSDTextOptionPropertyName = "OSDTextOption";

        //private string _osdTextOption = "Size Small";

        ///// <summary>
        ///// Sets and gets the OSDTextOption property.
        ///// Changes to that property's value raise the PropertyChanged event. 
        ///// </summary>
        //public string OSDTextOption
        //{
        //    get
        //    {
        //        return _osdTextOption;
        //    }

        //    set
        //    {
        //        if (_osdTextOption == value)
        //        {
        //            return;
        //        }

        //        _osdTextOption = value;
        //        RaisePropertyChanged(OSDTextOptionPropertyName);
        //    }
        //}

        #endregion

        #region OSD Option // NOt Used

        /// <summary>
        /// The <see cref="OSDOption" /> property's name.
        /// </summary>
        //public const string OSDOptionPropertyName = "OSDOption";

        //private bool? _myProperty = true;

        ///// <summary>
        ///// Sets and gets the OSDOption property.
        ///// Changes to that property's value raise the PropertyChanged event. 
        ///// </summary>
        //public bool? OSDOption
        //{
        //    get
        //    {
        //        return _myProperty;
        //    }

        //    set
        //    {
        //        if (_myProperty == value)
        //        {
        //            return;
        //        }

        //        _myProperty = value;

        //        switch (value)
        //        {
        //            case true:
        //                OSDTextOption = "Size Small";
        //                OSDOptionToInt = 1;
        //                break;
        //            case false:
        //                OSDTextOption = "Size Big";
        //                OSDOptionToInt = 1;     // Was 2, but system S2253 crash with large text and 160 char by ARLINDO 27-03-2015
        //                break;
        //            default:
        //                OSDTextOption = "No Text";
        //                OSDOptionToInt = 0;
        //                break;
        //        }

        //        //SetOSD(STREAM_A);
        //        //SetOSD(STREAM_B);
        //        //SetOSD(VIDEO_OUT);

        //        RaisePropertyChanged(OSDOptionPropertyName);
        //    }
        //}

        #endregion

        #region TimerValue
        /// <summary>
        /// The <see cref="TimerValue" /> property's name.
        /// </summary>
        public const string TimerValuePropertyName = "TimerValue";

        /// <summary>
        /// Sets and gets the DisplayTimer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 
        private ListBoxItem _TimerValue = null;

        public ListBoxItem TimerValue
        {
            get
            {
                return _TimerValue;
            }

            set
            {
                if (_TimerValue == value)
                {
                    return;
                }

                _TimerValue = value;


                if (value.Content.ToString() != "Always On")
                {
                    int newValue = Convert.ToInt32(value.Content);
                    DisplayLineTimer.Interval = TimeSpan.FromSeconds(newValue);
                }

                OSDLine1Submitted = "";
                OSDLine12Submitted = "";
                DisplayLineTimer.Stop();

                RaisePropertyChanged(TimerValuePropertyName);
            }
        }
        #endregion


        #region OSDLine1

        /// <summary>
        /// The <see cref="OSDLine1" /> property's name.
        /// </summary>
        public const string OSDLine1PropertyName = "OSDLine1";

        private string _osdLine1 = "";

        /// <summary>
        /// Sets and gets the OSDLine1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OSDLine1
        {
            get
            {
                return _osdLine1;
            }

            set
            {
                if (_osdLine1 == value)
                {
                    return;
                }

                _osdLine1 = value;

                RaisePropertyChanged(OSDLine1PropertyName);
            }
        }

        #endregion
        #region OSDLine12

        /// <summary>
        /// The <see cref="OSDLine12" /> property's name.
        /// </summary>
        public const string OSDLine12PropertyName = "OSDLine12";

        private string _osdLine12 = "";

        /// <summary>
        /// Sets and gets the OSDLine1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OSDLine12
        {
            get
            {
                return _osdLine12;
            }

            set
            {
                if (_osdLine12 == value)
                {
                    return;
                }

                _osdLine12 = value;

                RaisePropertyChanged(OSDLine12PropertyName);
            }
        }

        #endregion

        #region OSDLine2

        /// <summary>
        /// The <see cref="OSDLine2" /> property's name.
        /// </summary>
        public const string OSDLine2PropertyName = "OSDLine2";

        private string _osdLine2 = Properties.Settings.Default.CompanyText;

        /// <summary>
        /// Sets and gets the OSDLine2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OSDLine2
        {
            get
            {
                return _osdLine2;
            }

            set
            {
                if (_osdLine2 == value)
                {
                    return;
                }

                _osdLine2 = value;

                Properties.Settings.Default.CompanyText = value;
                Properties.Settings.Default.Save();

                SetOSDStyled2(STREAM_A);
                SetOSDStyled2(STREAM_B);

                RaisePropertyChanged(JobNamePropertyName);
            }
        }

        #endregion

        #region JobName

        /// <summary>
        /// The <see cref="JobName" /> property's name.
        /// </summary>
        public const string JobNamePropertyName = "JobName";
        private string _JobName = Properties.Settings.Default.JobNameText;

        /// <summary>
        /// Sets and gets the JobName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 
        public string JobName
        {

            get
            {
                return _JobName;
            }

            set
            {
                if (_JobName == value)
                {
                    return;
                }

                _JobName = MakeValidFileName(value);
                Properties.Settings.Default.JobNameText = _JobName;
                Properties.Settings.Default.Save();

                SetOSDStyledJobName(STREAM_A);
                SetOSDStyledJobName(STREAM_B);
                //SetOSDStyledJobName(VIDEO_OUT);
                RaisePropertyChanged(JobNamePropertyName);

            }
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = new string(Path.GetInvalidFileNameChars());
            string escapedInvalidChars = Regex.Escape(invalidChars);
            string invalidRegex = string.Format(@"([{0}]*\.+$)|([{0}]+)", escapedInvalidChars);

            return Regex.Replace(name, invalidRegex, "").Trim();
        }

        #endregion

        #region DiverName

        /// <summary>
        /// The <see cref="DiverName" /> property's name.
        /// </summary>
        public const string DiverNamePropertyName = "DiverName";
        private string _DiverName = Properties.Settings.Default.DiverNameText;
        /// <summary>
        /// Sets and gets the DiverName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DiverName
        {
            get
            {
                return _DiverName;
            }

            set
            {
                if (_DiverName == value)
                {
                    return;
                }

                _DiverName = value;
                Properties.Settings.Default.DiverNameText = value;
                Properties.Settings.Default.Save();
                SetOSDStyledDiverName(STREAM_A);
                SetOSDStyledDiverName(STREAM_B);

                RaisePropertyChanged(DiverNamePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Diver2Name" /> property's name.
        /// </summary>
        public const string Diver2NamePropertyName = "Diver2Name";
        private string _Diver2Name = Properties.Settings.Default.Diver2NameText;
        /// <summary>
        /// Sets and gets the DiverName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Diver2Name
        {
            get
            {
                return _Diver2Name;
            }

            set
            {
                if (_Diver2Name == value)
                {
                    return;
                }

                _Diver2Name = value;
                Properties.Settings.Default.Diver2NameText = value;
                Properties.Settings.Default.Save();
                SetOSDStyledDiver2Name(STREAM_A);
                SetOSDStyledDiver2Name(STREAM_B);

                RaisePropertyChanged(Diver2NamePropertyName);
            }
        }

        #endregion

        #region OSDLine3

        /// <summary>
        /// The <see cref="OSDLine3" /> property's name.
        /// </summary>
        public const string OSDLine3PropertyName = "OSDLine3";

        private string _osdline3 = "";

        /// <summary>
        /// Sets and gets the OSDLine3 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OSDLine3
        {
            get
            {
                return _osdline3;
            }

            set
            {
                if (_osdline3 == value)
                {
                    return;
                }

                _osdline3 = value;


                RaisePropertyChanged(OSDLine3PropertyName);
            }
        }

        #endregion

      

        /// <summary>
        /// The <see cref="OSDLine1Submitted" /> property's name.
        /// </summary>
        public const string OSDLine1SubmittedPropertyName = "OSDLine1Submitted";

        private string _OSDLine1Submitted = "";

        /// <summary>
        /// Sets and gets the OSDLine1Submitted property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OSDLine1Submitted
        {
            get
            {
                return _OSDLine1Submitted;
            }

            set
            {
                if (_OSDLine1Submitted == value)
                {
                    return;
                }

                _OSDLine1Submitted = value;

                if (TimerValue.Content.ToString() != "Always On")
                {
                    DisplayLineTimer.Start();
                }

                SetOSDStyled1(STREAM_A);
                SetOSDStyled1(STREAM_B);

                RaisePropertyChanged(OSDLine1SubmittedPropertyName);

            }
        }

        /// <summary>
        /// The <see cref="OSDLine12Submitted" /> property's name.
        /// </summary>
        public const string OSDLine12SubmittedPropertyName = "OSDLine12Submitted";

        private string _OSDLine12Submitted = "";

        /// <summary>
        /// Sets and gets the OSDLine1Submitted property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OSDLine12Submitted
        {
            get
            {
                return _OSDLine12Submitted;
            }

            set
            {
                if (_OSDLine12Submitted == value)
                {
                    return;
                }

                _OSDLine12Submitted = value;

                if (TimerValue.Content.ToString() != "Always On")
                {
                    DisplayLineTimer.Start();
                }

                SetOSDStyled12(STREAM_A);
                SetOSDStyled12(STREAM_B);

                RaisePropertyChanged(OSDLine12SubmittedPropertyName);

            }
        }

        #region OSDPopupVisibility

        /// <summary>
        /// The <see cref="OSDPopupVisibility" /> property's name.
        /// </summary>
        public const string OSDPopupVisibilityPropertyName = "OSDPopupVisibility";

        private bool _OSDPopupVisibility = false;

        /// <summary>
        /// Sets and gets the OSDPopupVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool OSDPopupVisibility
        {
            get
            {
                return _OSDPopupVisibility;
            }

            set
            {
                if (_OSDPopupVisibility == value)
                {
                    return;
                }

                _OSDPopupVisibility = value;
                RaisePropertyChanged(OSDPopupVisibilityPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="OSDPopupVisibility2" /> property's name.
        /// </summary>
        public const string OSDPopupVisibilityPropertyName2 = "OSDPopupVisibility2";

        private bool _OSDPopupVisibility2 = false;

        /// <summary>
        /// Sets and gets the OSDPopupVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool OSDPopupVisibility2
        {
            get
            {
                return _OSDPopupVisibility2;
            }

            set
            {
                if (_OSDPopupVisibility2 == value)
                {
                    return;
                }

                _OSDPopupVisibility2 = value;
                RaisePropertyChanged(OSDPopupVisibilityPropertyName2);
            }
        }

        #endregion

        #region OSD Time

        /// <summary>
        /// The <see cref="ShowTime" /> property's name.
        /// </summary>
        public const string ShowTimePropertyName = "ShowTime";

        private bool _showTime = true;

        /// <summary>
        /// Sets and gets the ShowTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowTime
        {
            get
            {
                return _showTime;
            }

            set
            {
                if (_showTime == value)
                {
                    return;
                }

                _showTime = value;


                //SetOSD(STREAM_A);
                //SetOSD(STREAM_B);
                //SetOSD(VIDEO_OUT);

                RaisePropertyChanged(ShowTimePropertyName);
            }
        }

        #endregion

        #region OSD Date

        /// <summary>
        /// The <see cref="ShowDate" /> property's name.
        /// </summary>
        public const string ShowDatePropertyName = "ShowDate";

        private bool _showDate = true;

        /// <summary>
        /// Sets and gets the ShowDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowDate
        {
            get
            {
                return _showDate;
            }

            set
            {
                if (_showDate == value)
                {
                    return;
                }

                _showDate = value;

                //SetOSD(STREAM_A);
                //SetOSD(STREAM_B);
                //SetOSD(VIDEO_OUT);

                RaisePropertyChanged(ShowDatePropertyName);
            }
        }

        #endregion

        #region OSD Offset X

        /// <summary>
        /// The <see cref="OSDOffsetX" /> property's name.
        /// </summary>
        public const string OSDOffsetXPropertyName = "OSDOffsetX";

        private int _osdOffsetX = 10;

        /// <summary>
        /// Sets and gets the OSDOffsetX property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OSDOffsetX
        {
            get
            {
                return _osdOffsetX;
            }

            set
            {
                if (_osdOffsetX == value)
                {
                    return;
                }

                _osdOffsetX = value;

                //SetOSD(STREAM_A);
                //SetOSD(STREAM_B);
                //SetOSD(VIDEO_OUT);

                RaisePropertyChanged(OSDOffsetXPropertyName);
            }
        }


        #endregion

        #region OSD Offset Y

        /// <summary>
        /// The <see cref="OSDOffsetY" /> property's name.
        /// </summary>
        public const string OSDOffsetYPropertyName = "OSDOffsetY";

        private int _osdOffsetY = 400;

        /// <summary>
        /// Sets and gets the OSDOffsetY property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OSDOffsetY
        {
            get
            {
                return _osdOffsetY;
            }

            set
            {
                if (_osdOffsetY == value)
                {
                    return;
                }

                _osdOffsetY = value;

                //SetOSD(STREAM_A);
                //SetOSD(STREAM_B);
                //SetOSD(VIDEO_OUT);
                RaisePropertyChanged(OSDOffsetYPropertyName);
            }
        }

        #endregion

        #region DiveTime

        /// <summary>
        /// The <see cref="DiveTime1" /> property's name.
        /// </summary>
        public const string DiveTimePropertyName1 = "DiveTime1";

        private TimeSpan _diveTime1 = TimeSpan.Zero;

        /// <summary>
        /// Sets and gets the DiveTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan DiveTime1
        {
            get
            {
                return _diveTime1;
            }

            set
            {
                if (_diveTime1 == value)
                {
                    return;
                }

                _diveTime1 = value;
                RaisePropertyChanged(DiveTimePropertyName1);
            }
        }
        /// <summary>
        /// The <see cref="DiveTime2" /> property's name.
        /// </summary>
        public const string DiveTimePropertyName2 = "DiveTime2";

        private TimeSpan _diveTime2 = TimeSpan.Zero;

        /// <summary>
        /// Sets and gets the DiveTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan DiveTime2
        {
            get
            {
                return _diveTime2;
            }

            set
            {
                if (_diveTime2 == value)
                {
                    return;
                }

                _diveTime2 = value;
                RaisePropertyChanged(DiveTimePropertyName2);
            }
        }

        #endregion

        #region Camera Control

        #region IsCameraOn

        /// <summary>
        /// The <see cref="IsCameraOn1" /> property's name.
        /// </summary>
        public const string IsCameraOnPropertyName1 = "IsCameraOn1";

        private bool _isCameraOn1 = false;

        /// <summary>
        /// Sets and gets the IsCameraOn1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsCameraOn1
        {
            get
            {
                return _isCameraOn1;
            }

            set
            {
                if (_isCameraOn1 == value)
                {
                    return;
                }

                _isCameraOn1 = value;
                RaisePropertyChanged(IsCameraOnPropertyName1);
            }
        }

        /// <summary>
        /// The <see cref="IsCameraOn2" /> property's name.
        /// </summary>
        public const string IsCameraOnPropertyName2 = "IsCameraOn2";

        private bool _isCameraOn2 = false;

        /// <summary>
        /// Sets and gets the IsCameraOn2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsCameraOn2
        {
            get
            {
                return _isCameraOn2;
            }

            set
            {
                if (_isCameraOn2 == value)
                {
                    return;
                }

                _isCameraOn2 = value;
                RaisePropertyChanged(IsCameraOnPropertyName2);
            }
        }
        #endregion

        #region Turn Camera On/Off

        private RelayCommand _ChangeCameraState1;

        /// <summary>
        /// Gets the ChangeCameraState1.
        /// </summary>
        public RelayCommand ChangeCameraState1
        {
            get
            {
                return _ChangeCameraState1
                    ?? (_ChangeCameraState1 = new RelayCommand(ExecuteChangeCameraState1));
            }
        }

        private void ExecuteChangeCameraState1()
        {
            if (IsCameraOn1)
            {
                if (IsCameraOn2)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_ON_1_2);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_ON_1);

            }
            else
            {
                if (IsCameraOn2)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_1);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_1_2);
            }



        }

        private RelayCommand _ChangeCameraState2;
        /// <summary>
        /// Gets the ChangeCameraState2.
        /// </summary>
        public RelayCommand ChangeCameraState2
        {
            get
            {
                return _ChangeCameraState2
                    ?? (_ChangeCameraState2 = new RelayCommand(ExecuteChangeCameraState2));
            }
        }

        private void ExecuteChangeCameraState2()
        {
           
            if (IsCameraOn2)
            {
                if (IsCameraOn1)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_ON_1_2);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_ON_2);

            }
            else
            {
                if (IsCameraOn1)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_2);
                }
                else
                MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_1_2);
            }


        }

        #endregion


        #endregion

        #region Light Control

        #region IsLightOn

        /// <summary>
        /// The <see cref="IsLightOn" /> property's name.
        /// </summary>
        public const string IsLightOnPropertyName = "IsLightOn";

        private bool _isLightOn = false;

        /// <summary>
        /// Sets and gets the IsLightOn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLightOn
        {
            get
            {
                return _isLightOn;
            }

            set
            {
                if (_isLightOn == value)
                {
                    return;
                }

                _isLightOn = value;
                RaisePropertyChanged(IsLightOnPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsLightOn2" /> property's name.
        /// </summary>
        public const string IsLightOnPropertyName2 = "IsLightOn2";

        private bool _isLightOn2 = false;

        /// <summary>
        /// Sets and gets the IsLightOn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLightOn2
        {
            get
            {
                return _isLightOn2;
            }

            set
            {
                if (_isLightOn2 == value)
                {
                    return;
                }

                _isLightOn2 = value;
                RaisePropertyChanged(IsLightOnPropertyName2);
            }
        }
        #endregion

        #region Turn Light On/Off

        private RelayCommand _changeLightState;

        /// <summary>
        /// Gets the ChangeLightState.
        /// </summary>
        public RelayCommand ChangeLightState
        {
            get
            {
                return _changeLightState
                    ?? (_changeLightState = new RelayCommand(ExecuteChangeLightState));
            }
        }

        private void ExecuteChangeLightState()
        {
            if (IsLightOn)
            {
                if (IsLightOn2)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_ON_1_2);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_ON_1);

            }
            else
            {
                if (IsLightOn2)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF_1);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF_1_2);
            }
        }

        private RelayCommand _changeLightState2;

        /// <summary>
        /// Gets the ChangeLightState2.
        /// </summary>
        public RelayCommand ChangeLightState2
        {
            get
            {
                return _changeLightState2
                    ?? (_changeLightState2 = new RelayCommand(ExecuteChangeLightState2));
            }
        }

        private void ExecuteChangeLightState2()
        {
            if (IsLightOn2)
            {
                if (IsLightOn)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_ON_1_2);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_ON_2);

            }
            else
            {
                if (IsLightOn)
                {
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF_2);
                }
                else
                    MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF_1_2);
            }
        }

        #endregion

        #endregion

        #region Depth
        /// <summary>
        /// The <see cref="DepthString1" /> property's name.
        /// </summary>
        public const string DepthStringPropertyName1= "DepthString1";

        private string _depthString1 = " 0,0 m";

        /// <summary>
        /// Sets and gets the DepthString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthString1
        {
            get
            {
                return _depthString1;
            }

            set
            {
                if (_depthString1 == value)
                {
                    return;
                }

                _depthString1 = value;
                RaisePropertyChanged(DepthStringPropertyName1);
            }
        }

        /// <summary>
        /// The <see cref="DepthString2" /> property's name.
        /// </summary>
        public const string DepthStringPropertyName2 = "DepthString2";

        private string _depthString2 = " 0,0 m";

        /// <summary>
        /// Sets and gets the DepthString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthString2
        {
            get
            {
                return _depthString2;
            }

            set
            {
                if (_depthString2 == value)
                {
                    return;
                }

                _depthString2 = value;
                RaisePropertyChanged(DepthStringPropertyName2);
            }
        }

        /// <summary>
        /// The <see cref="MaxDepthString1" /> property's name.
        /// </summary>
        public const string MaxDepthStringPropertyName1 = "MaxDepthString1";

        private string _maxDepthString1 = "0,0 m";

        /// <summary>
        /// Sets and gets the MaxDepthString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MaxDepthString1
        {
            get
            {
                return _maxDepthString1;
            }

            set
            {
                if (_maxDepthString1 == value)
                {
                    return;
                }

                _maxDepthString1 = value;
                RaisePropertyChanged(MaxDepthStringPropertyName1);
            }
        }

        private float MaxDepthValue1 = 0f;



        /// <summary>
        /// The <see cref="MaxDepthString2" /> property's name.
        /// </summary>
        public const string MaxDepthStringPropertyName2 = "MaxDepthString2";

        private string _maxDepthString2 = "0,0 m";

        /// <summary>
        /// Sets and gets the MaxDepthString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MaxDepthString2
        {
            get
            {
                return _maxDepthString2;
            }

            set
            {
                if (_maxDepthString2 == value)
                {
                    return;
                }

                _maxDepthString2 = value;
                RaisePropertyChanged(MaxDepthStringPropertyName2);
            }
        }

        private float MaxDepthValue2 = 0f;


        /// <summary>
        /// The <see cref="Depth1" /> property's name.
        /// </summary>
        public const string DepthPropertyName1 = "Depth1";

        private float _auxdepth1 = 0.0f;

        /// <summary>
        /// Sets and gets the Depth property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float Depth1
        {
            get
            {
                return _auxdepth1;
            }

            set
            {
                if (_auxdepth1 == value)
                {
                    return;
                }

                _auxdepth1 = value;

                DepthString1 = Depth1.ToString("0.0") + " m";
                RaisePropertyChanged(DepthPropertyName1);
            }
        }
        /// <summary>
        /// The <see cref="Depth2" /> property's name.
        /// </summary>
        public const string DepthPropertyName2 = "Depth2";

        private float _auxdepth2 = 0.0f;

        /// <summary>
        /// Sets and gets the Depth property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float Depth2
        {
            get
            {
                return _auxdepth2;
            }

            set
            {
                if (_auxdepth2 == value)
                {
                    return;
                }

                _auxdepth2 = value;

                DepthString2 = Depth2.ToString("0.0") + " m";
                RaisePropertyChanged(DepthPropertyName2);
            }
        }

        /// <summary>
        /// The <see cref="Is_10_BarG" /> property's name.
        /// </summary>
        public const string Is_10_BarGCheckedPropertyName = "Is_10_BarG";
        private float SensorFactor = 1000000f;
        private float WaterFactor = 99.484509f;
        private bool _10BarG = true;


        /// <summary>
        /// Sets and gets the Is_10_BarGCheckedPropertyName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Is_10_BarG
        {
            get
            {
                return _10BarG;
            }

            set
            {
                _10BarG = value;
                if (value == true)
                {
                    SensorFactor = 1000000f;
                    return;
                }

                RaisePropertyChanged(Is_10_BarGCheckedPropertyName);

            }

        }

        /// <summary>
        /// The <see cref="Is_25_BarG" /> property's name.
        /// </summary>
        public const string Is_25_BarGCheckedPropertyName = "Is_25_BarG";

        private bool _25BarG = false;

        /// <summary>
        /// Sets and gets the Is_25_BarGCheckedPropertyName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Is_25_BarG
        {
            get
            {
                return _25BarG;
            }

            set
            {
                _25BarG = value;
                if (value == true)
                {
                    SensorFactor = 2500000f;
                    return;
                }

                RaisePropertyChanged(Is_25_BarGCheckedPropertyName);

            }

        }
        #endregion

        #region Water Type
        /// <summary>
        /// The <see cref="IsSeaWaterChecked" /> property's name.
        /// </summary>
        public const string IsSeaWaterCheckedPropertyName = "IsSeaWaterChecked";



        private bool _seawater = true;

        /// <summary>
        /// Sets and gets the IsSeaWaterChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 

        public bool IsSeaWaterChecked
        {
            get
            {
                return _seawater;
            }


            set
            {
                _seawater = value;
                if (value == true)
                {
                    WaterFactor = (1025 * 9.80665f); // Sea Water Density * Gravity
                    return;
                }


                RaisePropertyChanged(IsSeaWaterCheckedPropertyName);
            }

        }

        /// <summary>
        /// The <see cref="IsFreshWaterChecked" /> property's name.
        /// </summary>
        public const string IsFreshWaterCheckedPropertyName = "IsFreshWaterChecked";

        private bool _freshwater = false;

        /// <summary>
        /// Sets and gets the IsFreshWaterChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsFreshWaterChecked
        {
            get
            {
                return _freshwater;
            }

            set
            {
                _freshwater = value;
                if (value == true)
                {
                    WaterFactor = (1000 * 9.80665f); // Fresh Water Density * Gravity
                    return;
                }

                RaisePropertyChanged(IsFreshWaterCheckedPropertyName);
            }

        }
        #endregion

        #region Camera Type
        /// <summary>
        /// The <see cref="IsSDCameraChecked" /> property's name.
        /// </summary>
        public const string IsSDCameraCheckedPropertyName = "IsSDCameraChecked";

        private bool _SDCamera = Properties.Settings.Default.IsSDCameraChecked;

        /// <summary>
        /// Sets and gets the IsFreshWaterChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsSDCameraChecked
        {
            get
            {
                return _SDCamera;
            }

            set
            {
                _SDCamera = value;
                if (value == true)
                {
                    S2253.SetInputCrop(10, 0, 704, 576, 0);   // Added new function to mid2253.cs, due wrong PAL aspect ratio by Arlindo 9.Dez.2015
                    S2253.SetInterpolateMode(1, 0);
                    S2253.SetInputCrop(10, 0, 704, 576, 1);   // Added new function to mid2253.cs, due wrong PAL aspect ratio by Arlindo 9.Dez.2015
                    S2253.SetInterpolateMode(1, 1);
                    return;
                }

                Properties.Settings.Default.IsSDCameraChecked = value;
                Properties.Settings.Default.Save();

                RaisePropertyChanged(IsSDCameraCheckedPropertyName);
            }

        }

        /// <summary>
        /// </summary>
        public const string IsHDCameraCheckedPropertyName = "IsHDCameraChecked";

        //private bool _HDCamera = false;
        private bool _HDCamera = Properties.Settings.Default.IsHDCameraChecked;

        /// <summary>
        /// Sets and gets the IsFreshWaterChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsHDCameraChecked
        {
            get
            {
                return _HDCamera;
            }

            set
            {
                _HDCamera = value;
                if (value == true)
                {
                    S2253.SetInputCrop(10, 0, 560, 576, 0);   // Added for new 1080p camera by Arlindo 9.Abr.2016 TODO  external settings Adjust lett from 0 to 10 15-MAy-2019
                    S2253.SetInterpolateMode(0, 0);
                    S2253.SetInputCrop(10, 0, 560, 576, 1);   // Added for new 1080p camera by Arlindo 9.Abr.2016 TODO  external settings Adjust lett from 0 to 10 15-MAy-2019
                    S2253.SetInterpolateMode(0, 1);

                    return;
                }

                Properties.Settings.Default.IsHDCameraChecked = value;
                Properties.Settings.Default.Save();

                RaisePropertyChanged(IsSDCameraCheckedPropertyName);
            }

        }
        /// <summary>
        /// </summary>
        public const string IsInterpolatedCheckedPropertyName = "IsInterpolatedChecked";

        //private bool _IsInterpolated = false;
        private bool _IsInterpolated = Properties.Settings.Default.IsInterpolatedChecked;

        /// <summary>
        /// Sets and gets the IsFreshWaterChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsInterpolatedChecked
        {
            get
            {
                return _IsInterpolated;
            }

            set
            {
                S2253.SetInterpolateMode(0, 0);
                S2253.SetInterpolateMode(0, 1);
                _IsInterpolated = value;
                if (value == true)
                {
                    S2253.SetInterpolateMode(1, 0);
                    S2253.SetInterpolateMode(1, 1);
                    return;
                }

                Properties.Settings.Default.IsInterpolatedChecked = value;
                Properties.Settings.Default.Save();

                RaisePropertyChanged(IsSDCameraCheckedPropertyName);
            }

        }

        #endregion

        /// <summary>
        /// The <see cref="Sensor1_Offset_Value" /> property's name.
        /// </summary>
        /// 
        public double Sensor1_Offset = 0.0;
        public double Sensor1_Offset_Value
        {
            get { return Sensor1_Offset; }
            set { Sensor1_Offset = value; }
        }

        /// <summary>
        /// The <see cref="Sensor2_Offset_Value" /> property's name.
        /// </summary>
        /// 
        public double Sensor2_Offset = 0.0;
        public double Sensor2_Offset_Value
        {
            get { return Sensor2_Offset; }
            set { Sensor2_Offset = value; }
        }


        #endregion



        #endregion

        #region Telemetry

        #region Battery Status
        /// <summary>
        /// The <see cref="BatteryStatus" /> property's name.
        /// </summary>
        public const string BatteryStatusPropertyName = "BatteryStatus";

        private float _batteryStatus = 0f;

        /// <summary>
        /// Sets and gets the BatteryStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float BatteryStatus
        {
            get
            {
                return _batteryStatus;
            }

            set
            {
                if (_batteryStatus == value)
                {
                    return;
                }


                _batteryStatus = value;

                RaisePropertyChanged(BatteryStatusPropertyName);
            }
        }
        #endregion

        #region BatteryPercentage

        /// <summary>
        /// The <see cref="BatteryPercentage" /> property's name.
        /// </summary>
        public const string BatteryPercentagePropertyName = "BatteryPercentage";

        private int _battPercent = 0;

        /// <summary>
        /// Sets and gets the BatteryPercentage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int BatteryPercentage
        {
            get
            {
                return _battPercent;
            }

            set
            {
                if (_battPercent == value)
                {
                    return;
                }

                _battPercent = value;

                if (value > 100)
                {
                    _battPercent = 100;
                }

                if (value < 100 && value >= 95)
                {
                    _battPercent = 95;
                }

                if (value < 95 && value >= 90)
                {
                    _battPercent = 90;
                }

                if (value < 90 && value >= 85)
                {
                    _battPercent = 85;
                }

                if (value < 85 && value >= 80)
                {
                    _battPercent = 80;
                }

                if (value < 80 && value >= 75)
                {
                    _battPercent = 75;
                }

                if (value < 75 && value >= 70)
                {
                    _battPercent = 70;
                }

                if (value < 70 && value >= 65)
                {
                    _battPercent = 65;
                }

                if (value < 65 && value >= 60)
                {
                    _battPercent = 60;
                }

                if (value < 60 && value >= 55)
                {
                    _battPercent = 55;
                }

                if (value < 55 && value >= 50)
                {
                    _battPercent = 50;
                }

                if (value < 50 && value >= 45)
                {
                    _battPercent = 45;
                }

                if (value < 45 && value >= 40)
                {
                    _battPercent = 40;
                }

                if (value < 40 && value >= 35)
                {
                    _battPercent = 35;
                }

                if (value < 35 && value >= 30)
                {
                    _battPercent = 30;
                }

                if (value < 30 && value >= 25)
                {
                    _battPercent = 25;
                }

                if (value < 0)
                {
                    _battPercent = 0;
                }



                if (_battPercent <= 25)
                {
                    BatteryColor = RedBrush;
                }
                if (_battPercent >= 25 && _battPercent < 50)
                {
                    BatteryColor = OrangeBrush;
                }
                if (_battPercent >= 50)
                {
                    BatteryColor = GreenBrush;
                }


                RaisePropertyChanged(BatteryPercentagePropertyName);
            }
        }


        #endregion

        #region BatteryColor

        /// <summary>
        /// The <see cref="BatteryColor" /> property's name.
        /// </summary>
        public const string BatteryColorPropertyName = "BatteryColor";

        private Brush _batteryColor = GreenBrush;

        /// <summary>
        /// Sets and gets the BatteryColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Brush BatteryColor
        {
            get
            {
                return _batteryColor;
            }

            set
            {
                if (_batteryColor == value)
                {
                    return;
                }

                _batteryColor = value;
                RaisePropertyChanged(BatteryColorPropertyName);
            }
        }

        #endregion

        #region Battery Charger Status

        /// <summary>
        /// The <see cref="ChargerStatus" /> property's name.
        /// </summary>
        public const string ChargerStatusPropertyName = "ChargerStatus";

        private string _chargerstatus = "";

        /// <summary>
        /// Sets and gets the TemperatureStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ChargerStatus
        {
            get
            {
                return _chargerstatus;
            }

            set
            {
                if (_chargerstatus == value)
                {
                    return;
                }

                _chargerstatus = value;
                RaisePropertyChanged(ChargerStatusPropertyName);
            }
        }
        #endregion

        #region TemperatureStatus

        /// <summary>
        /// The <see cref="TemperatureStatus" /> property's name.
        /// </summary>
        public const string TemperatureStatusPropertyName = "TemperatureStatus";

        private float _temperature = 0f;

        /// <summary>
        /// Sets and gets the TemperatureStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float TemperatureStatus
        {
            get
            {
                return _temperature;
            }

            set
            {
                if (_temperature == value)
                {
                    return;
                }

                _temperature = value;
                RaisePropertyChanged(TemperatureStatusPropertyName);
            }
        }
        #endregion

        #region Depth Sensor Status

        /// <summary>
        /// The <see cref="DepthSensorStatus1" /> property's name.
        /// </summary>
        public const string DepthSensorStatusPropertyName1 = "DepthSensorStatus1";

        private string _depthSensorStatus1 = "";

        /// <summary>
        /// Sets and gets the DepthSensorStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthSensorStatus1
        {
            get
            {
                return _depthSensorStatus1;
            }

            set
            {
                if (_depthSensorStatus1 == value)
                {
                    return;
                }

                _depthSensorStatus1 = value;


                RaisePropertyChanged(DepthSensorStatusPropertyName1);
            }
        }
        #endregion

        #region DepthSensorStatusText

        /// <summary>
        /// The <see cref="DepthSensorStatusText1" /> property's name.
        /// </summary>
        public const string DepthSensorStatusTextPropertyName1 = "DepthSensorStatusText1";

        private string _DepthSensorStatusText1 = "";

        /// <summary>
        /// Sets and gets the DepthSensorStatusText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthSensorStatusText1
        {
            get
            {
                return _DepthSensorStatusText1;
            }

            set
            {
                if (_DepthSensorStatusText1 == value)
                {
                    return;
                }

                _DepthSensorStatusText1 = value;
                RaisePropertyChanged(DepthSensorStatusTextPropertyName1);
            }
        }



        /// <summary>
        /// The <see cref="DepthSensorStatus2" /> property's name.
        /// </summary>
        public const string DepthSensorStatusPropertyName2 = "DepthSensorStatus2";

        private string _depthSensorStatus2 = "";

        /// <summary>
        /// Sets and gets the DepthSensorStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthSensorStatus2
        {
            get
            {
                return _depthSensorStatus2;
            }

            set
            {
                if (_depthSensorStatus2 == value)
                {
                    return;
                }

                _depthSensorStatus2 = value;


                RaisePropertyChanged(DepthSensorStatusPropertyName2);
            }
        }
        #endregion

        #region DepthSensorStatusText

        /// <summary>
        /// The <see cref="DepthSensorStatusText2" /> property's name.
        /// </summary>
        public const string DepthSensorStatusTextPropertyName2 = "DepthSensorStatusText2";

        private string _DepthSensorStatusText2 = "";

        /// <summary>
        /// Sets and gets the DepthSensorStatusText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthSensorStatusText2
        {
            get
            {
                return _DepthSensorStatusText2;
            }

            set
            {
                if (_DepthSensorStatusText2 == value)
                {
                    return;
                }

                _DepthSensorStatusText2 = value;
                RaisePropertyChanged(DepthSensorStatusTextPropertyName2);
            }
        }



        #endregion

        #region DepthSensorMessageColor

        /// <summary>
        /// The <see cref="DepthSensorMessageColor1" /> property's name.
        /// </summary>
        public const string DepthSensorMessageColorPropertyName1 = "DepthSensorMessageColor1";

        private Brush _DepthSensorMessageColor1 = GreenBrush;

        /// <summary>
        /// Sets and gets the DepthSensorMessageColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>  
        public Brush DepthSensorMessageColor1
        {
            get
            {
                return _DepthSensorMessageColor1;
            }

            set
            {
                if (_DepthSensorMessageColor1 == value)
                {
                    return;
                }

                _DepthSensorMessageColor1 = value;
                RaisePropertyChanged(DepthSensorMessageColorPropertyName1);
            }
        }



        /// <summary>
        /// The <see cref="DepthSensorMessageColor2" /> property's name.
        /// </summary>
        public const string DepthSensorMessageColorPropertyName2 = "DepthSensorMessageColor2";

        private Brush _DepthSensorMessageColor2 = GreenBrush;

        /// <summary>
        /// Sets and gets the DepthSensorMessageColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>  
        public Brush DepthSensorMessageColor2
        {
            get
            {
                return _DepthSensorMessageColor2;
            }

            set
            {
                if (_DepthSensorMessageColor2 == value)
                {
                    return;
                }

                _DepthSensorMessageColor2 = value;
                RaisePropertyChanged(DepthSensorMessageColorPropertyName2);
            }
        }

        #endregion

        #endregion

        #region LastSnapshotImage
        /// <summary>
        /// The <see cref="LastSnapshotImage1" /> property's name.
        /// </summary>
        public const string LastSnapshotImagePropertyName1 = "LastSnapshotImage1";

        private Uri _lastSnapshotImage1;

        /// <summary>
        /// Sets and gets the LastSnapshotImage1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri LastSnapshotImage1
        {
            get
            {
                return _lastSnapshotImage1;
            }

            set
            {
                if (_lastSnapshotImage1 == value)
                {
                    return;
                }
                _lastSnapshotImage1 = value;

                RaisePropertyChanged(LastSnapshotImagePropertyName1);
            }
        }

        /// <summary>
        /// The <see cref="LastSnapshotImage2" /> property's name.
        /// </summary>
        public const string LastSnapshotImagePropertyName2 = "LastSnapshotImage2";

        private Uri _lastSnapshotImage2;

        /// <summary>
        /// Sets and gets the LastSnapshotImage1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri LastSnapshotImage2
        {
            get
            {
                return _lastSnapshotImage2;
            }

            set
            {
                if (_lastSnapshotImage2 == value)
                {
                    return;
                }
                _lastSnapshotImage2 = value;

                RaisePropertyChanged(LastSnapshotImagePropertyName2);
            }
        }




        #endregion

        #region Charting & Plotting

        #region MyPlotModel
        /// <summary>
        /// The <see cref="MyPlotModel" /> property's name.
        /// </summary>
        public const string MyPlotModelPropertyName = "MyPlotModel";

        private PlotModel _myPlotModel = new PlotModel();

        /// <summary>
        /// Sets and gets the MyPlotModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PlotModel MyPlotModel
        {
            get
            {
                return _myPlotModel;
            }

            set
            {
                if (_myPlotModel == value)
                {
                    return;
                }

                _myPlotModel = value;
                RaisePropertyChanged(MyPlotModelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="MyPlotModel" /> property's name.
        /// </summary>
        public const string MyPlotModel2PropertyName = "MyPlotModel";

        private PlotModel _myPlotModel2 = new PlotModel();

        /// <summary>
        /// Sets and gets the MyPlotModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PlotModel MyPlotModel2
        {
            get
            {
                return _myPlotModel2;
            }

            set
            {
                if (_myPlotModel2 == value)
                {
                    return;
                }

                _myPlotModel2 = value;
                RaisePropertyChanged(MyPlotModel2PropertyName);
            }
        }



        /// <summary>
        /// The <see cref="MyPlotModel21" /> property's name.
        /// </summary>
        public const string MyPlotModelPropertyName21 = "MyPlotModel21";

        private PlotModel _myPlotModel21 = new PlotModel();

        /// <summary>
        /// Sets and gets the MyPlotModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PlotModel MyPlotModel21
        {
            get
            {
                return _myPlotModel21;
            }

            set
            {
                if (_myPlotModel21 == value)
                {
                    return;
                }

                _myPlotModel21 = value;
                RaisePropertyChanged(MyPlotModelPropertyName21);
            }
        }

        /// <summary>
        /// The <see cref="MyPlotModel22" /> property's name.
        /// </summary>
        public const string MyPlotModel22PropertyName = "MyPlotModel22";

        private PlotModel _myPlotModel22 = new PlotModel();

        /// <summary>
        /// Sets and gets the MyPlotModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PlotModel MyPlotModel22
        {
            get
            {
                return _myPlotModel22;
            }

            set
            {
                if (_myPlotModel22 == value)
                {
                    return;
                }

                _myPlotModel22 = value;
                RaisePropertyChanged(MyPlotModel22PropertyName);
            }
        }



        #endregion


        private void SetupCharting()
        {
            MyPlotModel.Series.Add(new LineSeries()  // View window
            {
                Title = DateTime.Now.ToString() + " " + DiverName,
                Points = new List<IDataPoint>(),
                BrokenLineColor = OxyColors.Red,
                BrokenLineThickness = 1,
                BrokenLineStyle = LineStyle.Dash,
                TextColor = OxyColors.White
            });

            MyPlotModel.Axes.Add(new TimeSpanAxis(AxisPosition.Bottom, "Time", "hh:mm:ss"));
            MyPlotModel.Axes.Add(new LinearAxis(AxisPosition.Left, "Depth"));

            MyPlotModel.Axes[0].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel.Axes[0].MinorGridlineStyle = LineStyle.Dot;
            MyPlotModel.Axes[0].TicklineColor = OxyColors.White;

            MyPlotModel.Axes[1].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel.Axes[1].MinorGridlineStyle = LineStyle.Dot;
            MyPlotModel.Axes[1].TicklineColor = OxyColors.White;

            MyPlotModel.AutoAdjustPlotMargins = true;

            MyPlotModel.TextColor = OxyColors.White;
            MyPlotModel.Axes[0].TextColor = OxyColors.White;
            MyPlotModel.Axes[1].TextColor = OxyColors.White;
            MyPlotModel.PlotAreaBorderColor = OxyColors.White;

            //--------------------------------------------------------------

            MyPlotModel2.Series.Add(new LineSeries() //Printed Chart
            {
                Title = DateTime.Now.ToString() + " " + DiverName,
                Points = new List<IDataPoint>(),

                BrokenLineColor = OxyColors.Red,
                BrokenLineThickness = 1,
                BrokenLineStyle = LineStyle.Dash,
                TextColor = OxyColors.Black,
                Background = OxyColors.AliceBlue

            });

            MyPlotModel2.Title = "DIVER 1 DEPTH PROFILE";

            MyPlotModel2.Axes.Add(new TimeSpanAxis(AxisPosition.Bottom, "Time (hh:mm:ss)", "hh:mm:ss"));
            MyPlotModel2.Axes.Add(new LinearAxis(AxisPosition.Left, "Depth (m)"));

            MyPlotModel2.Axes[0].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel2.Axes[0].MinorGridlineStyle = LineStyle.Dot;

            MyPlotModel2.Axes[1].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel2.Axes[1].MinorGridlineStyle = LineStyle.Dot;

            MyPlotModel2.Padding = new OxyThickness(0, 40, 40, 40);

            MyPlotModel2.AutoAdjustPlotMargins = true;
        }

        private void SetupCharting2()
        {

            MyPlotModel21.Series.Add(new LineSeries()  // View window
            {
                 Title = DateTime.Now.ToString() + " " + Diver2Name,
                 Points = new List<IDataPoint>(),
                 BrokenLineColor = OxyColors.Red,
                 BrokenLineThickness = 1,
                 BrokenLineStyle = LineStyle.Dash,
                 TextColor = OxyColors.White
            });

            MyPlotModel21.Axes.Add(new TimeSpanAxis(AxisPosition.Bottom, "Time", "hh:mm:ss"));
            MyPlotModel21.Axes.Add(new LinearAxis(AxisPosition.Left, "Depth"));

            MyPlotModel21.Axes[0].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel21.Axes[0].MinorGridlineStyle = LineStyle.Dot;
            MyPlotModel21.Axes[0].TicklineColor = OxyColors.White;

            MyPlotModel21.Axes[1].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel21.Axes[1].MinorGridlineStyle = LineStyle.Dot;
            MyPlotModel21.Axes[1].TicklineColor = OxyColors.White;

            MyPlotModel21.AutoAdjustPlotMargins = true;

            MyPlotModel21.TextColor = OxyColors.White;
            MyPlotModel21.Axes[0].TextColor = OxyColors.White;
            MyPlotModel21.Axes[1].TextColor = OxyColors.White;
            MyPlotModel21.PlotAreaBorderColor = OxyColors.White;

            //--------------------------------------------------------------

            MyPlotModel22.Series.Add(new LineSeries() //Printed Chart
            {
                Title = DateTime.Now.ToString() + " " + Diver2Name,
                Points = new List<IDataPoint>(),

                BrokenLineColor = OxyColors.Red,
                BrokenLineThickness = 1,
                BrokenLineStyle = LineStyle.Dash,
                TextColor = OxyColors.Black,
                Background = OxyColors.AliceBlue

            });

            MyPlotModel22.Title = "DIVER 2 DEPTH PROFILE";

            MyPlotModel22.Axes.Add(new TimeSpanAxis(AxisPosition.Bottom, "Time (hh:mm:ss)", "hh:mm:ss"));
            MyPlotModel22.Axes.Add(new LinearAxis(AxisPosition.Left, "Depth (m)"));

            MyPlotModel22.Axes[0].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel22.Axes[0].MinorGridlineStyle = LineStyle.Dot;

            MyPlotModel22.Axes[1].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel22.Axes[1].MinorGridlineStyle = LineStyle.Dot;

            MyPlotModel22.Padding = new OxyThickness(0, 40, 40, 40);

            MyPlotModel22.AutoAdjustPlotMargins = true;
        }
    

        #endregion

        #region Serial Ports Methods and Properties

        #region COMPortsList

        /// <summary>
        /// The <see cref="COMPortsList" /> property's name.
        /// </summary>
        public const string COMPortsListPropertyName = "COMPortsList";

        private List<string> _COMPortsList = new List<string>();

        /// <summary>
        /// Sets and gets the COMPortsList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<string> COMPortsList
        {
            get
            {
                return _COMPortsList;
            }

            set
            {
                if (_COMPortsList == value)
                {
                    return;
                }

                _COMPortsList = value;
                RaisePropertyChanged(COMPortsListPropertyName);
            }
        }
        #endregion

        #region COMPortListSelectedItem

        /// <summary>
        /// The <see cref="COMPortListSelectedItem" /> property's name.
        /// </summary>
        public const string COMPortListSelectedItemPropertyName = "COMPortListSelectedItem";

        private string _COMPortListSelectedItem = Properties.Settings.Default.COMPort;

        /// <summary>
        /// Sets and gets the COMPortListSelectedItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string COMPortListSelectedItem
        {
            get
            {
                return _COMPortListSelectedItem;
            }

            set
            {
                if (_COMPortListSelectedItem == value)
                {
                    return;
                }

                Properties.Settings.Default.COMPort = value;
                Properties.Settings.Default.Save();

                _COMPortListSelectedItem = value;
                RaisePropertyChanged(COMPortListSelectedItemPropertyName);
            }
        }

        #endregion

        #region GPSCOMPortListSelectedItem

        public const string GPSCOMPortListSelectedItemPropertyName = "GPSCOMPortListSelectedItem";

        private string _GPSCOMPortListSelectedItem = "COM6";

        /// <summary>
        /// Sets and gets the GPS COM port selection property.
        /// </summary>
        public string GPSCOMPortListSelectedItem
        {
            get { return _GPSCOMPortListSelectedItem; }
            set
            {
                if (_GPSCOMPortListSelectedItem == value) return;
                _GPSCOMPortListSelectedItem = value;
                RaisePropertyChanged(GPSCOMPortListSelectedItemPropertyName);
            }
        }

        #endregion

        #region GPSBaudRate

        public List<int> GPSBaudRatesList { get; } = new List<int> { 4800, 9600, 19200, 38400, 57600, 115200 };

        private int _GPSBaudRateSelected = 4800;
        public int GPSBaudRateSelected
        {
            get { return _GPSBaudRateSelected; }
            set
            {
                if (_GPSBaudRateSelected == value) return;
                _GPSBaudRateSelected = value;
                RaisePropertyChanged(nameof(GPSBaudRateSelected));
            }
        }

        #endregion

        #region BaudRate

        /// <summary>
        /// The <see cref="BaudRate" /> property's name.
        /// </summary>
        public const string BaudRatePropertyName = "BaudRate";

        private int _BaudRate = Properties.Settings.Default.BaudRate;

        /// <summary>
        /// Sets and gets the BaudRate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int BaudRate
        {
            get
            {
                return _BaudRate;
            }

            set
            {
                if (_BaudRate == value)
                {
                    return;
                }

                _BaudRate = value;

                Properties.Settings.Default.BaudRate = value;
                Properties.Settings.Default.Save();

                RaisePropertyChanged(BaudRatePropertyName);
            }
        }

        #endregion

        #region COMPortIsEnabled

        /// <summary>
        /// The <see cref="COMPortIsEnabled" /> property's name.
        /// </summary>
        public const string COMPortIsEnabledPropertyName = "COMPortIsEnabled";

        private bool _COMPortIsEnabled = false;

        /// <summary>
        /// Sets and gets the COMPortIsEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool COMPortIsEnabled
        {
            get
            {
                return _COMPortIsEnabled;
            }

            set
            {
                if (_COMPortIsEnabled == value)
                {
                    return;
                }

                _COMPortIsEnabled = value;
                RaisePropertyChanged(COMPortIsEnabledPropertyName);
            }
        }

        #endregion

        #region Execute COM Port

        private RelayCommand _ExecuteStartOrStopCOMPort;
        /// <summary>
        /// Gets the ExecuteStartOrStopCOMPort.
        /// </summary>
        public RelayCommand ExecuteStartOrStopCOMPort
        {
            get
            {
                return _ExecuteStartOrStopCOMPort
                    ?? (_ExecuteStartOrStopCOMPort = new RelayCommand(ExecuteStartOrStopCOMPortMethod));
            }
        }

        private CommunicationManager MyCommunicationManager = new CommunicationManager();

        private void ExecuteStartOrStopCOMPortMethod()
        {
            if (COMPortIsEnabled)
            {
                // Close and detach any previously open port first
                if (MyCommunicationManager != null)
                {
                    try
                    {
                        MyCommunicationManager.comPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(IOPort_DataReceived);
                        if (MyCommunicationManager.comPort.IsOpen)
                            MyCommunicationManager.comPort.Close();
                    }
                    catch { /* ignore cleanup errors */ }
                }

                //start port
                MyCommunicationManager = new CommunicationManager(BaudRate.ToString(), "None", "1", "8", COMPortListSelectedItem)
                {
                    CurrentTransmissionType = CommunicationManager.TransmissionType.Text
                };

                bool portOpened = false;
                try
                {
                    portOpened = MyCommunicationManager.OpenPort();
                    if (portOpened)
                    {
                        MyCommunicationManager.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(IOPort_DataReceived);
                        SetupIOPorts();
                    }
                    else
                    {
                        COMPortIsEnabled = false;
                        Log("COM port could not be opened: " + COMPortListSelectedItem);
                        if (_startupCompleted)
                        {
                            System.Windows.MessageBox.Show(
                                "Could not open " + COMPortListSelectedItem + ".\nCheck that the device is connected and the port is not in use.",
                                "COM Port Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                        }
                    }
                }
                catch (Exception e)
                {
                    COMPortIsEnabled = false;
                    Log("COM port error: " + e.Message);
                    if (_startupCompleted)
                    {
                        System.Windows.MessageBox.Show(
                            "COM port error on " + COMPortListSelectedItem + ":\n" + e.Message,
                            "COM Port Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                if (MyCommunicationManager != null)
                {
                    try
                    {
                        MyCommunicationManager.comPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(IOPort_DataReceived);
                        if (MyCommunicationManager.comPort.IsOpen)
                            MyCommunicationManager.comPort.Close();
                    }
                    catch { /* ignore cleanup errors */ }
                }
            }
        }


        #endregion

        #region DIVER2
        /// <summary>
        /// The <see cref="Diver2IsEnabled" /> property's name.
        /// </summary>
        public const string Diver2IsEnabledPropertyName = "Diver2IsEnabled";

        private bool _Diver2IsEnabled = false;

        /// <summary>
        /// Sets and gets the GPSIsEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Diver2IsEnabled
        {
            get
            {
                return _Diver2IsEnabled;
            }

            set
            {
                if (_Diver2IsEnabled == value)
                {
                    return;
                }

                _Diver2IsEnabled = value;

                MainWindow2.PerformDiver2IsEnabled_Checked(Diver2IsEnabled);

                RaisePropertyChanged(Diver2IsEnabledPropertyName);
            }
        }

        
        #endregion DIVER2

        #region GPS

        /// <summary>
        /// The <see cref="GPSIsEnabled" /> property's name.
        /// </summary>
        public const string GPSIsEnabledPropertyName = "GPSIsEnabled";

        private bool _GPSIsEnabled = false;

        /// <summary>
        /// Sets and gets the GPSIsEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool GPSIsEnabled
        {
            get
            {
                return _GPSIsEnabled;
            }

            set
            {
                if (_GPSIsEnabled == value)
                {
                    return;
                }

                _GPSIsEnabled = value;

                RaisePropertyChanged(GPSIsEnabledPropertyName);
            }
        }

        #region Execute GPS Port

        private RelayCommand _ExecuteStartOrStopGPSPort;
        /// <summary>
        /// Gets the ExecuteStartOrStopGPSPort.
        /// </summary>
        public RelayCommand ExecuteStartOrStopGPSPort
        {
            get
            {
                return _ExecuteStartOrStopGPSPort
                    ?? (_ExecuteStartOrStopGPSPort = new RelayCommand(ExecuteStartOrStopGPSPortMethod));
            }
        }

        private System.IO.Ports.SerialPort _gpsSerialPort;
        private Thread _gpsReadThread;
        private volatile bool _gpsReadThreadRunning = false;
        private bool _gpsMethodRunning = false;

        private void ExecuteStartOrStopGPSPortMethod()
        {
            if (_gpsMethodRunning) return;
            _gpsMethodRunning = true;
            try
            {
            if (GPSIsEnabled)
            {
                try
                {
                    _gpsSerialPort = new System.IO.Ports.SerialPort(
                        GPSCOMPortListSelectedItem, GPSBaudRateSelected,
                        System.IO.Ports.Parity.None, 8,
                        System.IO.Ports.StopBits.One);
                    _gpsSerialPort.ReadTimeout = 5000;
                    _gpsSerialPort.DtrEnable = true;
                    _gpsSerialPort.RtsEnable = true;
                    _gpsSerialPort.Open();

                    _gpsReadThreadRunning = true;
                    _gpsReadThread = new Thread(GpsReadLoop) { IsBackground = true, Name = "GPS Read Thread" };
                    _gpsReadThread.Start();

                    Latitude = "";
                    Longitude = "";
                    GPSStatus = "Connected at " + GPSCOMPortListSelectedItem + " @ " + GPSBaudRateSelected;
                    Log("GPS connected at port " + GPSCOMPortListSelectedItem + " @ " + GPSBaudRateSelected + " baud");
                }
                catch (Exception ex)
                {
                    Latitude = "";
                    Longitude = "";
                    GPSStatus = "Error: " + ex.Message;
                    Log("GPS Error: " + ex.Message);
                    _gpsReadThreadRunning = false;
                    try { _gpsSerialPort?.Close(); _gpsSerialPort?.Dispose(); _gpsSerialPort = null; } catch { }
                    _GPSIsEnabled = false;
                    RaisePropertyChanged(GPSIsEnabledPropertyName);
                }
            }
            else
            {
                    _gpsReadThreadRunning = false;

                try
                {
                    if (_gpsSerialPort != null && _gpsSerialPort.IsOpen)
                    {
                        _gpsSerialPort.Close();
                        _gpsSerialPort.Dispose();
                        _gpsSerialPort = null;
                    }
                }
                catch { }

                Latitude = "";
                Longitude = "";
                GPSStatus = "Disconnected";
                Log("GPS disconnected from port " + GPSCOMPortListSelectedItem);
            }
            } finally { _gpsMethodRunning = false; }
        }

        private void GpsReadLoop()
        {
            while (_gpsReadThreadRunning)
            {
                try
                {
                    if (_gpsSerialPort == null || !_gpsSerialPort.IsOpen) break;

                    string line = _gpsSerialPort.ReadLine();
                    string sentence = line.Trim();
                    if (sentence.StartsWith("$"))
                    {
                        ParseNmeaSentence(sentence);
                    }
                }
                catch (TimeoutException)
                {
                    string msg = "No data on " + GPSCOMPortListSelectedItem + " @ " + GPSBaudRateSelected + " baud";
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        GPSStatus = msg;
                    }));
                }
                catch (System.IO.IOException) { break; }
                catch (InvalidOperationException) { break; }
                catch { break; }
            }
        }

        /// Converts decimal degrees to DMS string matching the app's display format: 41º11'14,2139''N
        private static string ToNmeaDms(double decDeg, string direction)
        {
            int deg = (int)decDeg;
            double minFull = (decDeg - deg) * 60.0;
            int min = (int)minFull;
            double sec = (minFull - min) * 60.0;
            // Use comma as decimal separator for seconds, to match existing format
            string secStr = sec.ToString("F4", System.Globalization.CultureInfo.InvariantCulture).Replace('.', ',');
            return string.Format("{0}º{1}'{2}''{3}", deg, min, secStr, direction);
        }

        /// <summary>
        /// Parses GPRMC or GPGGA sentences and updates Latitude/Longitude directly.
        /// Format GPRMC: $GPRMC,hhmmss,A,DDMM.MMMM,N,DDDMM.MMMM,W,...
        /// Format GPGGA: $GPGGA,hhmmss,DDMM.MMMM,N,DDDMM.MMMM,W,fix,...
        /// </summary>
        private void ParseNmeaSentence(string sentence)
        {
            try
            {
                // Strip checksum
                int star = sentence.IndexOf('*');
                string body = star >= 0 ? sentence.Substring(0, star) : sentence;
                string[] f = body.Split(',');
                if (f.Length < 1) return;

                string type = f[0].TrimStart('$').ToUpperInvariant();
                bool isRmc = type == "GPRMC" || type == "GNRMC";
                bool isGga = type == "GPGGA" || type == "GNGGA";

                if (!isRmc && !isGga) return;

                // GPRMC fields: [0]type [1]time [2]status [3]lat [4]N/S [5]lon [6]E/W
                // GPGGA fields: [0]type [1]time [2]lat   [3]N/S [4]lon [5]E/W [6]fix
                int latIdx, nsIdx, lonIdx, ewIdx;
                bool validFix;
                if (isRmc)
                {
                    if (f.Length < 7) return;
                    validFix = f[2].ToUpperInvariant() == "A";
                    latIdx = 3; nsIdx = 4; lonIdx = 5; ewIdx = 6;
                }
                else  // GGA
                {
                    if (f.Length < 7) return;
                    validFix = f[6] != "0" && f[6] != "";
                    latIdx = 2; nsIdx = 3; lonIdx = 4; ewIdx = 5;
                }

                if (!validFix || string.IsNullOrEmpty(f[latIdx]) || string.IsNullOrEmpty(f[lonIdx]))
                {
                    System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Latitude = "";
                        Longitude = "";
                        GPSStatus = "Waiting for GPS fix...";
                    }));
                    return;
                }

                double latRaw = double.Parse(f[latIdx], System.Globalization.CultureInfo.InvariantCulture);
                double lonRaw = double.Parse(f[lonIdx], System.Globalization.CultureInfo.InvariantCulture);

                // Convert DDMM.MMMM → decimal degrees
                double latDeg = Math.Floor(latRaw / 100.0) + (latRaw % 100.0) / 60.0;
                double lonDeg = Math.Floor(lonRaw / 100.0) + (lonRaw % 100.0) / 60.0;

                if (f[nsIdx].ToUpperInvariant() == "S") latDeg = -latDeg;
                if (f[ewIdx].ToUpperInvariant() == "W") lonDeg = -lonDeg;

                string latStr = ToNmeaDms(Math.Abs(latDeg), latDeg >= 0 ? "N" : "S");
                string lonStr = ToNmeaDms(Math.Abs(lonDeg), lonDeg >= 0 ? "E" : "W");

                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Latitude = latStr;
                    Longitude = lonStr;
                    GPSStatus = "";
                }));
            }
            catch { }
        }

        #endregion

        #region Latitude Longitude

        /// <summary>
        /// The <see cref="Latitude" /> property's name.
        /// </summary>
        public const string LatitudePropertyName = "Latitude";

        private string _latitude = "";

        /// <summary>
        /// Sets and gets the Latitude property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Latitude
        {
            get
            {
                return _latitude;
            }

            set
            {
                if (_latitude == value)
                {
                    return;
                }

                _latitude = value;
                RaisePropertyChanged(LatitudePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Longitude" /> property's name.
        /// </summary>
        public const string LongitudePropertyName = "Longitude";
        private string _longitude = "";
        /// <summary>
        /// Sets and gets the Longitude property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Longitude
        {
            get
            {
                return _longitude;
            }

            set
            {
                if (_longitude == value)
                {
                    return;
                }

                _longitude = value;
                RaisePropertyChanged(LongitudePropertyName);
            }
        }

        #region GPSStatus
        public const string GPSStatusPropertyName = "GPSStatus";
        private string _gpsStatus = "";
        public string GPSStatus
        {
            get { return _gpsStatus; }
            set
            {
                if (_gpsStatus == value) return;
                _gpsStatus = value;
                RaisePropertyChanged(GPSStatusPropertyName);
            }
        }
        #endregion

        #endregion
        #endregion
        #region CleanupDiver1
        public void CleanupDiver1()
        {
            // Stop recording if active (mirrors stop branch of ExecuteExecuteStartOrStopRecording)
            if (IsRecording)
            {
                SetOSDStyledRECSTOP(STREAM_A);
                StopRecording();

                if (!IsRecording2)
                {
                    SuppressEditing = false;
                    SuppressEditing2 = false;
                }

                if (!_Chart1_saved)
                {
                    SaveChartImage1();
                    _Chart1_saved = true;
                }

                Log("Stop Recording 1 (shutdown)");
                Log("Maximum Depth was: " + MaxDepthValue1 + " m");
                StatusMessage = "Stopped - F3 REC";
                DivingTimer1.Stop();

                // Update property so UI reflects stopped state
                _isRecording = false;
                RaisePropertyChanged(IsRecordingPropertyName);
            }

            // Turn off camera 1
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_1);

            // Turn off light 1 if on
            if (IsLightOn)
            {
                IsLightOn = false;
            }

            // Close OSD popup if open
            if (OSDPopupVisibility)
            {
                OSDPopupVisibility = false;
            }

            // Clear OSD text overlays on stream A
            OSDLine1Submitted = "";
            SetOSDStyled1(STREAM_A);
        }
        #endregion

        #region CleanupDiver2
        public void CleanupDiver2()
        {
            // Stop recording if active (mirrors stop branch of ExecuteExecuteStartOrStopRecording2)
            if (IsRecording2)
            {
                SetOSDStyledRECSTOP2(STREAM_A);
                StopRecording2();

                if (!IsRecording)
                {
                    SuppressEditing = false;
                    SuppressEditing2 = false;
                }

                if (!_Chart2_saved)
                {
                    SaveChartImage2();
                    _Chart2_saved = true;
                }

                if (!_dive2StopLogged)
                {
                    _dive2StopLogged = true;
                    _dive2StartLogged = false;
                    Log("Stop Recording 2 (Diver2 window closed)");
                    Log("Maximum Depth 2 was: " + MaxDepthValue2 + " m");
                }
                StatusMessage2 = "Stopped - F4 REC";
                DivingTimer2.Stop();

                // Update property so UI toggle reflects stopped state
                _isRecording2 = false;
                RaisePropertyChanged(IsRecordingPropertyName2);
            }

            // Turn off camera 2
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_2);

            // Reset camera toggle so it opens in OFF state next time
            if (IsCameraOn2)
            {
                IsCameraOn2 = false;
            }

            // Turn off light 2 if on
            if (IsLightOn2)
            {
                IsLightOn2 = false;
            }

            // Close OSD popup if open
            if (OSDPopupVisibility2)
            {
                OSDPopupVisibility2 = false;
            }

            // Clear OSD text overlays on stream B
            OSDLine12Submitted = "";
            SetOSDStyled12(STREAM_B);
        }
        #endregion

        #region Cleanup
        public override void Cleanup()
        {
            // Stop all Diver 1 and Diver 2 tasks cleanly before shutdown
            CleanupDiver1();
            CleanupDiver2();

            MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF_1_2); // by ARLINDO 14-Jan-2015
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF_1_2); // by ARLINDO 14-Jan-2015

            S2253.CloseBoard(-1); // by ARLINDO 14-Jan-2015

            try
            {
                if (MyCommunicationManager.comPort.IsOpen)
                    MyCommunicationManager.comPort.Close();
            }
            catch (Exception)
            {
                // Port already closed or unavailable — silently ignore
            }

            base.Cleanup();
        }
        #endregion
        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool dispose_)
        {
            if (dispose_)
            {
                MyCommunicationManager.Dispose();
                fileSystemWatcher.Dispose();
            }
        }
        #endregion
    } // End of Sealed Class
} // End of Namespace
#endregion
