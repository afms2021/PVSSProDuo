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
// | Arlindo Silva                   | 05/APR/2022 | Save Chart when batery level is critical and Stop/Start Recoding every minute                                  | 
// | Arlindo Silva                   | 20/APR/2022 | PVSS PRO DUO Initial Version                                                                                   | 
// +---------------------------------+-------------+----------------------------------------------------------------------------------------------------------------+


#define PVSS_PRO  // PVSS or PVSS_PRO  *** PVSS 115200 baudrate / Prodving 19200 baudrate ***

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.IO;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
using Sensoray;
using PCComm;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Media;
using System.Windows.Media;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using DotSpatial.Positioning;
using System.Windows.Forms;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;


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

        private string VideoDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos";
        private string SnapshotsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots";
        private string ChartsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts";
        private string LogPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\log.txt";
        private string JobNameDiretory = Directory.GetCurrentDirectory() + "\\My Dives";

        private FileSystemWatcher fileSystemWatcher;

        private const int BUFFER_SIZE = 1327104;
        private const int WM_DEVICEEVENT = 0x8002;

        private const int STREAM_A = 0;
        private const int STREAM_B = 1;
        private const int VIDEO_OUT = 2; // by ARLINDO 14-Jan-2015  Passtrought Video to Output

        private const string NullString = null;

        private DispatcherTimer DivingTimer1 = new DispatcherTimer();
        private DispatcherTimer DivingTimer2 = new DispatcherTimer();


        private DispatcherTimer TelemetryTimer = new DispatcherTimer();
        private DispatcherTimer LowBatErrorTimer = new DispatcherTimer();
        private DispatcherTimer DiskMonitorTimer = new DispatcherTimer();
        private DispatcherTimer DisplayLineTimer = new DispatcherTimer();

        private DateTime startDateTime1;
        private DateTime startDateTime2;

        private const int BATTERY_LEVEL_WARNING = 720; // was 740 /753 / 750 by ARLINDO 20.ABR.2015 (NOTE: 720 => 11.6Vdc) depend on PCB version with or without Schotky Diode  
        private const int BATTERY_LEVEL_CRITICAL = 702; //was 720 /732 / 730  (NOTE: 702 => 11.2Vdc) 

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
        private static string DEPTH_SENSOR_STATUS_OK = "ok";
        private static string DEPTH_SENSOR_STATUS_OPEN = "open";
        private static string DEPTH_SENSOR_STATUS_SHORT = "short";

        // Battery Charger Status
        private static string BATTERY_CHARGER_STATUS_ON = "on";
        private static string BATTERY_CHARGER_STATUS_OFF = "off";

        private bool Sensoray_codec = false;
        private string Last_file_name = "noname";
        private float BatteryLevel;
        private string TemperatureLevel;

#if PVSS_PRO
        private int result;
        private int _pro_open1 = 0;
        private int _pro_short1 = 0;
        // Change Baudrate in settings to 19200 / PVSS use 115200

#endif

        #region IO COMMANDS
#if PVSS_PRO
        private const string IO_COMMAND_TURN_LIGHT_ON = "$DVD,4095,4095,*7A\r\n";
        private const string IO_COMMAND_TURN_CAMERA_ON = "$RLY,1,1,0,0,*6B\r\n";
        private const string IO_COMMAND_TURN_LIGHT_OFF = "$DVD,0,0,*7A\r\n"; 
        private const string IO_COMMAND_TURN_CAMERA_OFF = "$RLY,0,0,0,0,*6B\r\n";
        private string sensorstatus1 = "";
        //private int _depth1;
        //private int _depth2;
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
                SoundPlayer soundPlayer = new SoundPlayer();
                SoundPlayer simpleSound = soundPlayer;
                simpleSound.SoundLocation = fullPathToSound;
                simpleSound.Play();
                DiveTime1 = TimeSpan.Zero;
                startDateTime1 = DateTime.Now;
                StartRecording();
                StatusMessage = "Recording - F3 STOP"; //Was F3 now toggle START/STOP Arlindo 02.MAR.2017
                SuppressEditing = true;
                DivingTimer1.Start();

                Log("System Started and Internal Temperature was:" + TemperatureLevel + " ºC");
                Log("Battery Level was:" + " " + string.Format("{0:0.00}", BatteryLevel) + " Vdc");
                Log("Start Recording");
                Log("Start Diving Depth was: " + Depth1 + " m");

                MaxDepthValue1 = 0f;
                MaxDepthString1 = "Max: - m";
           

                MyPlotModel.Axes.Clear();
                MyPlotModel2.Axes.Clear();
                (MyPlotModel.Series[0] as LineSeries).Points.Clear();
                (MyPlotModel2.Series[0] as LineSeries).Points.Clear();
                MyPlotModel.Series.Clear();
                MyPlotModel2.Series.Clear();
                SetupCharting();
                Log("Start Dive Profile Chart");
            }
            else
            {
                SetOSDStyledRECSTOP(STREAM_A);


                StopRecording();
                SaveChartImage(); //Arlindo OUT21

                Log("Stop Recording");
                Log("Battery Level was:" + " " + string.Format("{0:0.00}", BatteryLevel) + " Vdc");
                Log("Maximum Depht was: " + MaxDepthValue1 + " m");
                Log("Ended Dive Depth was: " + Depth1 + " m");
                Log("Save Dive Profile Chart" + "\r\n");
                StatusMessage = "Stopped - F3 REC";
                SuppressEditing = false;
                DivingTimer1.Stop();
                startDateTime1 = DateTime.Now;
                string fullPathToSound = Path.GetFullPath(@"Stop_Rec.wav");
                SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
                simpleSound.Play();
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
                SoundPlayer soundPlayer = new SoundPlayer();
                SoundPlayer simpleSound = soundPlayer;
                simpleSound.SoundLocation = fullPathToSound;
                simpleSound.Play();
                DiveTime2 = TimeSpan.Zero;
                startDateTime2 = DateTime.Now;
                StartRecording2();
                StatusMessage2 = "Recording - F4 STOP"; // F4 now toggle START/STOP Arlindo 02.MAR.2017
                SuppressEditing = true;
                DivingTimer2.Start();

                Log("System Started and Internal Temperature was:" + TemperatureLevel + " ºC");
                Log("Battery Level was:" + " " + string.Format("{0:0.00}", BatteryLevel) + " Vdc");
                Log("Start Recording");
                Log("Start Diving Depth was: " + Depth2 + " m");

                MaxDepthValue2 = 0f;
                MaxDepthString2 = "Max: - m";

                MyPlotModel.Axes.Clear();
                MyPlotModel2.Axes.Clear();
                (MyPlotModel.Series[0] as LineSeries).Points.Clear();
                (MyPlotModel2.Series[0] as LineSeries).Points.Clear();
                MyPlotModel.Series.Clear();
                MyPlotModel2.Series.Clear();
                SetupCharting();
                Log("Start Dive Profile Chart");
            }
            else
            {
                SetOSDStyledRECSTOP2(STREAM_A);


                StopRecording2();
                SaveChartImage(); //Arlindo OUT21

                Log("Stop Recording");
                Log("Battery Level was:" + " " + string.Format("{0:0.00}", BatteryLevel) + " Vdc");
                Log("Maximum Depht was: " + MaxDepthValue2 + " m");
                Log("Ended Dive Depth was: " + Depth2 + " m");
                Log("Save Dive Profile Chart" + "\r\n");
                StatusMessage = "Stopped - F4 REC";
                SuppressEditing = false;
                DivingTimer2.Stop();
                startDateTime2 = DateTime.Now;
                string fullPathToSound = Path.GetFullPath(@"Stop_Rec.wav");
                SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
                simpleSound.Play();
            }

        }
        #region Log File 
        //public static void Log(string logMessage, TextWriter w)
        public void Log(string logMessage)

        {
            using (StreamWriter w = File.AppendText(LogPath))
                w.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()} {"- " + logMessage}");
        }
        #endregion

        private void SaveChartImage()
        {
            ChartsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts";
            if (!Directory.Exists(ChartsDirectoryPath))
            {
                Directory.CreateDirectory(ChartsDirectoryPath);
            }
            // Changed to PDF due to Win 10 photo viwer black background, no axes visible by Arlindo Dez-2015
            //string fileName = string.Format(@"{0}\{1}.png", DirectoryPathCharts, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));
            string fileName = string.Format(@"{0}\{1}.pdf", ChartsDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));
            // ((OxyPlot.Wpf.Plot)MyPlotModel2.PlotControl).SaveBitmap(fileName);
            OxyPlot.Pdf.PdfExporter.Export(MyPlotModel2, fileName, MyPlotModel2.Width - 0, MyPlotModel2.Height); // was Width - 50

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
                VideoDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives";
            }
            else
                VideoDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos";
            runExplorer.FileName = "explorer.exe";
            runExplorer.Arguments = VideoDirectoryPath;
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
                AvailableVideoTime_Hours = "12341234.34:23:123";
                DepthSensorStatusText = "Depth sensor malfunction. (short)";
                DepthSensorMessageColor = RedBrush;
                DepthString1 = "32,4 m";
                DepthString2 = "22,4 m";
                Longitude = "41°11'14,2139''N";
                Latitude = "008°42'12,269''W";
                return;
            }

            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"mid2253.dll");

            DLLVersion = myFileVersionInfo.FileVersion;

            //Just used to get all the COM Ports available

            Thread.Sleep(2000); // Arlindo NOV 2021 Wait till all COM ports come up

            CommunicationManager c = new CommunicationManager();
            COMPortsList = c.GetPortNames();

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
            LowBatErrorTimer.Interval = TimeSpan.FromMinutes(1);
            LowBatErrorTimer.Tick += new EventHandler(One_Minute_Timer_tick);

            // Update disk space available every 15 seconds
            DiskMonitorTimer.Interval = TimeSpan.FromSeconds(15);
            DiskMonitorTimer.Tick += new EventHandler(DiskMonitorTimer_Tick);
            DiskMonitorTimer.Start();
            DiskMonitorTimer_Tick(null, null);

            // Commnet Text line Display Interval Timer by a ComboBox 5, 10, 15 seconds or Always ON
            DisplayLineTimer.Interval = TimeSpan.FromSeconds(5);
            DisplayLineTimer.Tick += new EventHandler(DisplayLineTimer_tick);

            System.Windows.Application.Current.MainWindow.KeyUp += new System.Windows.Input.KeyEventHandler(MainWindow_KeyUp);
      
            VideoDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos";
            SnapshotsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots";
            ChartsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts";
            LogPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\log.txt";
            JobNameDiretory = Directory.GetCurrentDirectory() + "\\My Dives";

            if (!Directory.Exists(ChartsDirectoryPath))
            {
                Directory.CreateDirectory(ChartsDirectoryPath);
            }

            if (!Directory.Exists(SnapshotsDirectoryPath))
            {
                Directory.CreateDirectory(SnapshotsDirectoryPath);
            }

            if (!Directory.Exists(VideoDirectoryPath))
            {
                Directory.CreateDirectory(VideoDirectoryPath);
            }

            if (!File.Exists(LogPath))
            {
                File.Create(LogPath);
            }

            // Instruct the file system watcher to call the FileCreated method
            // when there are files created at the folder.
            fileSystemWatcher = new FileSystemWatcher(JobNameDiretory)
            {
                IncludeSubdirectories = true,
                //fileSystemWatcher.Filter = "*.*";
                NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.DirectoryName
            };
            fileSystemWatcher.Created += new FileSystemEventHandler(FileSystemWatcher_Created);
            fileSystemWatcher.EnableRaisingEvents = true;

            if (!Directory.Exists(ChartsDirectoryPath))
            {
                Directory.CreateDirectory(ChartsDirectoryPath);
            }

            SetupCharting();

            // List of devices at Developer Machine
            //Blackmagic WDM Capture
            //Logitech Webcam C160
            //Sensoray 2253 Capture A
            //Sensoray 2253 Capture B
            //Sensoray 2253 Decode
            //Decklink Video Capture
            Sensoray_codec = false;
            foreach (DirectShowLib.DsDevice device in WPFMediaKit.DirectShow.Controls.MultimediaUtil.VideoInputDevices)
            {

                if (device.Name == "Sensoray 2253 Capture A")  //Arlindo 2021                
                {
                    Video = device;  // Connect to this device
                    Sensoray_codec = true;
                    break;
                }
            }
            foreach (DirectShowLib.DsDevice device in WPFMediaKit.DirectShow.Controls.MultimediaUtil.VideoInputDevices)
            {

                if (device.Name == "Sensoray 2253 Capture A #3")  //Arlindo 2022  PVSS Duo                

                {
                    Video1 = device;  // Connect to this device
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
        }
        private void CallCleanUp(string obj)
        {
            Cleanup();
        }

        void DiskMonitorTimer_Tick(object sender, EventArgs e)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())  // Cames from onesecondtick loop due to Preview Image freezing by ARLINDO 26.MAR.2015
            {
                if (drive.IsReady && drive.Name == "C:\\")
                {
                    FreeDiskSpace_GB = Math.Round(Convert.ToDouble(drive.AvailableFreeSpace) / 1024 / 1024 / 1024, 2);
                    TimeSpan t = TimeSpan.FromHours(_freeDiskSpace_GB / 1.34);
                    AvailableVideoTime_Hours = string.Format("{0:N2}", t.TotalHours);
                }
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

        void FileSystemWatcher_Created(object sender, FileSystemEventArgs e) // Solved Exception by Manuel ALberto 27.Abri.2019
        {
            string filepath = new Uri(e.FullPath).ToString();
            string extension = Path.GetExtension(filepath);
            if (extension == ".bmp")
            {
                LastSnapshotImage = new Uri(e.FullPath);
                LastSnapshotImage2 = new Uri(e.FullPath);
            }

        }

        void MainWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {

                case System.Windows.Input.Key.F1:
                    IsCameraOn = !IsCameraOn;
                    break;
                case System.Windows.Input.Key.F2:
                    IsCameraOn = !IsCameraOn;
                    break;
                case System.Windows.Input.Key.F3:  // REC 1
                    IsRecording = !IsRecording;
                    break;
                case System.Windows.Input.Key.F4:  // REC 2
                    IsRecording2 = !IsRecording2;
                    break;
                case System.Windows.Input.Key.F5: // Comment 1 
                    OSDPopupVisibility = !OSDPopupVisibility;
                    break;
                case System.Windows.Input.Key.F6: // Comment 2
                    OSDPopupVisibility2 = !OSDPopupVisibility2;
                    break;
                case System.Windows.Input.Key.F9:  // Light 1
                    IsLightOn = !IsLightOn;
                    break;                
                case System.Windows.Input.Key.F10: // Light 2
                    IsLightOn = !IsLightOn;
                    break;
                case System.Windows.Input.Key.Enter:

                    if (OSDPopupVisibility)
                    {
                        OSDLine1Submitted = OSDLine1;
                        OSDPopupVisibility = false;
                        SendKeys.SendWait("{F7}"); // Added Auto Smapshot ARLINDO 15-NOV-2017 ( must be duplicated to get overlay comment text grabbed ) 
                        SendKeys.SendWait("{F7}"); // Added Auto Smapshot ARLINDO 15-NOV-2017
                    }
                    if (OSDPopupVisibility2)
                    {
                        OSDLine12Submitted = OSDLine12;
                        OSDPopupVisibility2 = false;
                        SendKeys.SendWait("{F8}"); // Added Auto Smapshot ARLINDO 15-NOV-2017 ( must be duplicated to get overlay comment text grabbed ) 
                        SendKeys.SendWait("{F8}"); // Added Auto Smapshot ARLINDO 15-NOV-2017
                    }
                    break;
                default:
                    break;
            }
        }

        private bool AlreadyShownWarningBatteryLevelWarning = false;
        private bool AlreadyShownWarningBatteryLevelCritical = false;
        private bool AlreadyShownWarningChargerOn = false;

        private void IOPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string pattern_temp = "<pcbtemp>(?<pcbtemp>.+)</pcbtemp>\r\n";
            string pattern_depth = "<depth>(?<depth>.+)</depth>\r\n";
            string pattern_vbat = "<vbat>(?<vbat>.+)</vbat>\r\n";
            string pattern_sensorstatus = "<sensorstatus>(?<sensorstatus>.+)</sensorstatus>\r\n";
            string pattern_chargerstatus = "<chargerstatus>(?<chargerstatus>.+)</chargerstatus>\r\n";


            Match m_pattern_temp = Regex.Match(MyCommunicationManager.LastMsg, pattern_temp);
            Match m_pattern_depth = Regex.Match(MyCommunicationManager.LastMsg, pattern_depth);
            Match m_pattern_vbat = Regex.Match(MyCommunicationManager.LastMsg, pattern_vbat);
            Match m_pattern_sensorstatus = Regex.Match(MyCommunicationManager.LastMsg, pattern_sensorstatus);
            Match m_pattern_chargerstatus = Regex.Match(MyCommunicationManager.LastMsg, pattern_chargerstatus);


#if PVSS_PRO
            //Console.WriteLine("New Depth: " + MyCommunicationManager.LastMsg); //Arlindo 2021
            if (string.IsNullOrEmpty(MyCommunicationManager.LastMsg) == false)
            {
                string new_depth = MyCommunicationManager.LastMsg;
                if (new_depth.Contains("#DVA"))  // #DVA,1,0,0,1,2,0,0,1,*7C 
                {
                    string[] new_depthinfo = new_depth.Split(',');
                    string ch1 = new_depthinfo[1];
                    //Console.WriteLine("Diver " + ch1);

                

                    string ch1_depth = new_depthinfo[2];
                    if (int.TryParse(ch1_depth, out result) == true)
                    {
                        int _pro_depth1 = int.Parse(ch1_depth, CultureInfo.InvariantCulture.NumberFormat);
                        //Console.WriteLine("Depth " + _pro_depth1);
                        _depth1 = _pro_depth1;
                    }
            

                    string ch1_short = new_depthinfo[3];
                    if (int.TryParse(ch1_short, out result) == true)
                    {
                        _pro_short1 = int.Parse(ch1_short, CultureInfo.InvariantCulture.NumberFormat);
                    }

                    string ch1_open = new_depthinfo[4];
                    if (int.TryParse(ch1_open, out result) == true)
                    {
                        _pro_open1 = int.Parse(ch1_open, CultureInfo.InvariantCulture.NumberFormat);
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
                        int _pro_depth2 = int.Parse(ch2_depth, CultureInfo.InvariantCulture.NumberFormat);
                        //Console.WriteLine("Depth " + _pro_depth2);
                        _depth2 = _pro_depth2;
                    }

                    string ch2_short = new_depthinfo[7];
                    //Console.WriteLine("Sensor Short " + ch2_short);

                    string ch2_open = new_depthinfo[8];
                    //Console.WriteLine("Sensor Open " + ch2_open);

                }
                
            }
#endif

            try
            {
                ChargerStatus = m_pattern_chargerstatus.Groups["chargerstatus"].Value;
            }
            catch { }

            if (ChargerStatus == BATTERY_CHARGER_STATUS_ON && !AlreadyShownWarningChargerOn)
            {
                AlreadyShownWarningChargerOn = true;
                Log("External Mains Power apllied to System");
                var thread = new Thread(
                    () =>
                    {
                        System.Windows.MessageBox.Show("! CAUTION ! External Mains Power apllied to System." + "\n" + "      !!! Dot use when Diver is in Water !!!" + "\n" + "Use only if Grounding and RCD is present ",
                            "* WARNING * Battery Charger ON",
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
                TemperatureStatus = float.Parse(m_pattern_temp.Groups["pcbtemp"].Value, CultureInfo.InvariantCulture);
                TemperatureLevel = TemperatureStatus.ToString("00");

                if (TemperatureStatus > 52)  // Telemetry PCB Board Temperature in ºC 
                {
                    System.Windows.MessageBox.Show("  Internal Over Temperature at " + TemperatureStatus.ToString("00") + " ºC" + " ,too High" + "\n" + " !! Stop Diving Operations and turn off system !!",
                          "* WARNING * Internal Temperature",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning);
                    Log("Warning Internal Over Temperature at: " + TemperatureLevel + " ºC");
                }
            }
            catch { }


            try
            {
#if PVSS_PRO
                float DepthSensorReading1 = _depth1;
                float DepthSensorReading2 = _depth2;
#else
                int DepthSensorReading = int.Parse(m_pattern_depth.Groups["depth"].Value);
#endif

                //Depth = (float)Math.Round((DepthSensorReading * 99.0f) / 1024.0f, 1); // ARLINDO 25.OUT.2016
                Depth1 = (float)Math.Round((DepthSensorReading1 * SensorFactor / WaterFactor) / 1024.0f, 1) + Convert.ToSingle(Sensor_Offset); //ARLINDO 27.FEV.2017 Ver 5.0
                Depth2 = (float)Math.Round((DepthSensorReading2 * SensorFactor / WaterFactor) / 1024.0f, 1) + Convert.ToSingle(Sensor_Offset); //ARLINDO 27.FEV.2017 Ver 5.0
            }
            catch { }

            if (Depth1 > MaxDepthValue1 && IsRecording)
            {
                MaxDepthValue1 = Depth1;

                MaxDepthString1 = "Max: " + MaxDepthValue1 + " m"; // was #.#
            }

            try
            {
                int BatterySensorValue = int.Parse(m_pattern_vbat.Groups["vbat"].Value);
                BatteryLevel = ((BatterySensorValue * (5.00f / 1024) * 4.675578f) - 4.82f);

                if (BatterySensorValue <= BATTERY_LEVEL_CRITICAL && !AlreadyShownWarningBatteryLevelCritical)
                {
                    AlreadyShownWarningBatteryLevelCritical = true;
                    LowBatErrorTimer.Start();
                    var thread = new Thread(
                        () =>
                        {
                            System.Windows.MessageBox.Show("Battery Level Critical. The video will stop recording.",
                                "Battery Level Critical",
                                MessageBoxButton.OK,
                                MessageBoxImage.Stop);
                            Log("Battery Level Critical" + " " + string.Format("{0:0.00}", BatteryLevel) + " Vdc");
                        });
                    thread.Start();
                    if (IsRecording)
                    {
                        SaveChartImage(); // Arlindo 05/APR/2022
                        StopRecording();
                        StartRecording();
                    }
                }
                else if (BatterySensorValue <= BATTERY_LEVEL_WARNING && !AlreadyShownWarningBatteryLevelWarning)
                {
                    AlreadyShownWarningBatteryLevelWarning = true;
                    LowBatErrorTimer.Start();

                    var thread = new Thread(
                        () =>
                        {
                            System.Windows.MessageBox.Show("Battery level too low. Please recharge battery.",
                                              "Battery Level Low",
                                              MessageBoxButton.OK,
                                              MessageBoxImage.Exclamation);

                            Log("Battery Level Low" + " " + string.Format("{0:0.00}", BatteryLevel) + " Vdc");
                        });
                    thread.Start();
                }


                BatteryStatus = ((BatterySensorValue * (5.00f / 1024)) * 4.675578f) - 4.82f; // y=xm+b => m=4.675578 and b=-4.8 by Arlindo 14.ABR:2015

                BatteryPercentage = Convert.ToInt32(((BatteryStatus - 10.00f) * 100) / (13.20f - 10.00f)); // was min 11,80 was max 13,80 (was 13,00 9.SET.2013)(was 12,87 11.FEB.2014)
                // Percentage display desable at XAML layout Expresion Blend                               // was  ((( BatteryStatus - 11.00f) * 100) / (13.20f - 11.00f))
            }
            catch { }

            try
            {
#if PVSS_PRO
                DepthSensorStatus = sensorstatus1;
#else
                DepthSensorStatus = m_pattern_sensorstatus.Groups["sensorstatus"].Value;
#endif
            }
            catch { }

            if (DepthSensorStatus == DEPTH_SENSOR_STATUS_OK)
            {
                DepthSensorStatusText = "Depth sensor OK";
                DepthSensorMessageColor = GreenBrush;
            }
            else if (DepthSensorStatus == DEPTH_SENSOR_STATUS_OPEN)
            {
                DepthSensorStatusText = "Depth sensor malfunction (open)";
                DepthSensorMessageColor = RedBrush;
            }
            else if (DepthSensorStatus == DEPTH_SENSOR_STATUS_SHORT)
            {
                DepthSensorStatusText = "Depth sensor malfunction (short)";
                DepthSensorMessageColor = RedBrush;
            }
        }



        void OneSecondTimer_tick(object sender, EventArgs e)
        {

#if PVSS_PRO
            //MyCommunicationManager.WriteData("$RID,*73\r\n");
            MyCommunicationManager.WriteData("$DVA,*7F\r\n");
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
                if (DepthSensorStatus == DEPTH_SENSOR_STATUS_OK)
                {
                    data = new DataPoint(TimeSpanAxis.ToDouble(DiveTime1), -Depth1);
                }

                (MyPlotModel.Series[0] as LineSeries).Points.Add(data);
                MyPlotModel.RefreshPlot(true);

                //MyPlotModel.Updated();

                (MyPlotModel2.Series[0] as LineSeries).Points.Add(data);
                MyPlotModel2.RefreshPlot(true);

                MyPlotModel2.Update();

            }
        }

        #region IOPorts

        private void SetupIOPorts()
        {
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF);
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF);
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
        private void One_Minute_Timer_tick(object sender, EventArgs e) //by ARLINDO Clear Error Message and restart REC STOP/START every minute
        {
            LowBatErrorTimer.Stop();
            SendKeys.SendWait("{ESC}");
            AlreadyShownWarningBatteryLevelCritical = false;
            LowBatErrorTimer.Start();
        }
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
            //IsSDCameraChecked = Properties.Settings.Default.IsSDCameraChecked;

            IsHDCameraChecked = false;
            //IsHDCameraChecked = Properties.Settings.Default.IsHDCameraChecked;

            IsInterpolatedChecked = true;
            //IsInterpolatedChecked = Properties.Settings.Default.IsInterpolatedChecked;

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

            //S2253.SetImageSize(720, 576, 0, STREAM_A);
            //S2253.SetImageSize(720, 576, 0, STREAM_B);

            //S2253.SetInputCrop(10, 0, 704, 576, 0);   // Added new function to mid2253.cs, due wrong PAL aspect ratio by Arlindo 9.Dez.2015
            //S2253.SetInputCrop(0, 0, 554, 576, 0);   // Added for new 1080p camera by Arlindo 9.Abr.2019 now is GUI external settings
            //S2253.SetInterpolateMode(1, 0);

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
            VideoDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos";

            if (!Directory.Exists(VideoDirectoryPath))
            {
                Directory.CreateDirectory(VideoDirectoryPath);
            }


            string OutputVideoFileName = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));

            Last_file_name = OutputVideoFileName; // Save last video file path and name, to be used by StopRecoding()

            if (File.Exists(OutputVideoFileName))
            {
                string NewOutputVideoFileName = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); /// Arlindo OUT21
                File.Create(NewOutputVideoFileName);
            }


            S2253.SetBitrate(3000, 0, STREAM_B); //was 2500 03.12.2012 by Arlindo
            S2253.SetJpegQ(75, 0, STREAM_B);
           
            try
            {
                S2253.StartRecord(OutputVideoFileName, 0, STREAM_B);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.InnerException.ToString(), e.Message);
            }

        }
        private void StartRecording2()
        {
            VideoDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos2";

            if (!Directory.Exists(VideoDirectoryPath))
            {
                Directory.CreateDirectory(VideoDirectoryPath);
            }


            string OutputVideoFileName = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff"));

            Last_file_name2 = OutputVideoFileName; // Save last video file path and name, to be used by StopRecoding()

            if (File.Exists(OutputVideoFileName))
            {
                string NewOutputVideoFileName = string.Format(@"{0}\{1}.mp4", VideoDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); /// Arlindo OUT21
                File.Create(NewOutputVideoFileName);
            }

            S2253.SetBitrate(3000, 1, STREAM_B);
            S2253.SetJpegQ(75, 1, STREAM_B);

            try
            {
                S2253.StartRecord(OutputVideoFileName, 1, STREAM_B);
            }
            catch (Exception)
            {
                //MessageBox.Show(e.InnerException.ToString(), e.Message);
            }

        }

        private void StopRecording()
        {
            S2253.StopStream(0, STREAM_B);

            FileInfo info = new FileInfo(Last_file_name);
            if (info.Exists && info.Length == 0)
            {
                System.Windows.MessageBox.Show("Video File is Empty or Severe Corruted !!!",
                          "*** WARNING ***",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning); // file existe but is empty
                Log("Video File is Empty or Severe Corruted");
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
                Log("Video File is Empty or Severe Corruted");
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
                /*
                Regex illegalInFileName = new Regex(@"[()§;:,´#$+%!`&«»{}@\\/:*?""<>|]´");
                value = illegalInFileName.Replace(value, "");
                value = value.Trim();
                */

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
        /// The <see cref="IsCameraOn" /> property's name.
        /// </summary>
        public const string IsCameraOnPropertyName = "IsCameraOn";

        private bool _isCameraOn = false;

        /// <summary>
        /// Sets and gets the IsCameraOn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsCameraOn
        {
            get
            {
                return _isCameraOn;
            }

            set
            {
                if (_isCameraOn == value)
                {
                    return;
                }

                _isCameraOn = value;
                RaisePropertyChanged(IsCameraOnPropertyName);
            }
        }

        #endregion

        #region Turn Camera On/Off

        private RelayCommand _ChangeCameraState;

        /// <summary>
        /// Gets the ChangeCameraState.
        /// </summary>
        public RelayCommand ChangeCameraState
        {
            get
            {
                return _ChangeCameraState
                    ?? (_ChangeCameraState = new RelayCommand(ExecuteChangeCameraState));
            }
        }

        private void ExecuteChangeCameraState()
        {
            if (IsCameraOn)
            {
                MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_ON);
            }
            else
            {
                MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF);
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
                MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_ON);
            }
            else
            {
                MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF);
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

        private string _maxDepthString1 = "Max: 0,0 m";

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

        private string _maxDepthString2 = "Max: 0,0 m";

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

        private float _depth1 = 0.0f;

        /// <summary>
        /// Sets and gets the Depth property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float Depth1
        {
            get
            {
                return _depth1;
            }

            set
            {
                if (_depth1 == value)
                {
                    return;
                }

                _depth1 = value;

                DepthString1 = Depth1.ToString("0.0") + " m";
                RaisePropertyChanged(DepthPropertyName1);
            }
        }
        /// <summary>
        /// The <see cref="Depth2" /> property's name.
        /// </summary>
        public const string DepthPropertyName2 = "Depth2";

        private float _depth2 = 0.0f;

        /// <summary>
        /// Sets and gets the Depth property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public float Depth2
        {
            get
            {
                return _depth2;
            }

            set
            {
                if (_depth2 == value)
                {
                    return;
                }

                _depth2 = value;

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
                _IsInterpolated = value;
                if (value == true)
                {
                    S2253.SetInterpolateMode(1, 0);
                    return;
                }

                Properties.Settings.Default.IsInterpolatedChecked = value;
                Properties.Settings.Default.Save();

                RaisePropertyChanged(IsSDCameraCheckedPropertyName);
            }

        }

        #endregion

        /// <summary>
        /// The <see cref="Sensor_Offset_Value" /> property's name.
        /// </summary>
        /// 
        public double Sensor_Offset = 0.0;
        public double Sensor_Offset_Value
        {
            get { return Sensor_Offset; }
            set { Sensor_Offset = value; }
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
        /// The <see cref="DepthSensorStatus" /> property's name.
        /// </summary>
        public const string DepthSensorStatusPropertyName = "DepthSensorStatus";

        private string _depthSensorStatus = "";

        /// <summary>
        /// Sets and gets the DepthSensorStatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthSensorStatus
        {
            get
            {
                return _depthSensorStatus;
            }

            set
            {
                if (_depthSensorStatus == value)
                {
                    return;
                }

                _depthSensorStatus = value;


                RaisePropertyChanged(DepthSensorStatusPropertyName);
            }
        }
        #endregion

        #region DepthSensorStatusText

        /// <summary>
        /// The <see cref="DepthSensorStatusText" /> property's name.
        /// </summary>
        public const string DepthSensorStatusTextPropertyName = "DepthSensorStatusText";

        private string _DepthSensorStatusText = "";

        /// <summary>
        /// Sets and gets the DepthSensorStatusText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DepthSensorStatusText
        {
            get
            {
                return _DepthSensorStatusText;
            }

            set
            {
                if (_DepthSensorStatusText == value)
                {
                    return;
                }

                _DepthSensorStatusText = value;
                RaisePropertyChanged(DepthSensorStatusTextPropertyName);
            }
        }

        #endregion

        #region DepthSensorMessageColor

        /// <summary>
        /// The <see cref="DepthSensorMessageColor" /> property's name.
        /// </summary>
        public const string DepthSensorMessageColorPropertyName = "DepthSensorMessageColor";

        private Brush _DepthSensorMessageColor = GreenBrush;

        /// <summary>
        /// Sets and gets the DepthSensorMessageColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>  
        public Brush DepthSensorMessageColor
        {
            get
            {
                return _DepthSensorMessageColor;
            }

            set
            {
                if (_DepthSensorMessageColor == value)
                {
                    return;
                }

                _DepthSensorMessageColor = value;
                RaisePropertyChanged(DepthSensorMessageColorPropertyName);
            }
        }

        #endregion

        #endregion

        #region LastSnapshotImage
        /// <summary>
        /// The <see cref="LastSnapshotImage" /> property's name.
        /// </summary>
        public const string LastSnapshotImagePropertyName = "LastSnapshotImage";

        private Uri _lastSnapshotImage;

        /// <summary>
        /// Sets and gets the LastSnapshotImage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri LastSnapshotImage
        {
            get
            {
                return _lastSnapshotImage;
            }

            set
            {
                if (_lastSnapshotImage == value)
                {
                    return;
                }
                _lastSnapshotImage = value;

                RaisePropertyChanged(LastSnapshotImagePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="LastSnapshotImage2" /> property's name.
        /// </summary>
        public const string LastSnapshotImagePropertyName2 = "LastSnapshotImage2";

        public Uri _lastSnapshotImage2;

        /// <summary>
        /// Sets and gets the LastSnapshotImage property.
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

            MyPlotModel2.Title = "Dive Profile";

            MyPlotModel2.Axes.Add(new TimeSpanAxis(AxisPosition.Bottom, "Time (hh:mm:ss)", "hh:mm:ss"));
            MyPlotModel2.Axes.Add(new LinearAxis(AxisPosition.Left, "Depth (m)"));

            MyPlotModel2.Axes[0].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel2.Axes[0].MinorGridlineStyle = LineStyle.Dot;

            MyPlotModel2.Axes[1].MajorGridlineStyle = LineStyle.Solid;
            MyPlotModel2.Axes[1].MinorGridlineStyle = LineStyle.Dot;

            MyPlotModel2.Padding = new OxyThickness(0, 40, 40, 40);

            MyPlotModel2.AutoAdjustPlotMargins = true;
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
                //start port
                MyCommunicationManager = new CommunicationManager(BaudRate.ToString(), "None", "1", "8", COMPortListSelectedItem)
                {
                    CurrentTransmissionType = CommunicationManager.TransmissionType.Text
                };

                try
                {
                    MyCommunicationManager.OpenPort();
                    SetupIOPorts();
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("COM port error: " + e.Message,
                    "Change Settings",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                    COMPortIsEnabled = false;
                    Log("Openning COM port error");
                }
                finally
                {

                    MyCommunicationManager.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(IOPort_DataReceived);

                }

            }
            else
            {
                MyCommunicationManager.comPort.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(IOPort_DataReceived);
                MyCommunicationManager.comPort.Close();
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
                _Diver2IsEnabled = value;

                MainWindow2.PerformDiver2IsEnabled_Checked(Diver2IsEnabled);

                if (_Diver2IsEnabled == value)
                {
                    return;
                }

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

        private NmeaInterpreter interpreter = new NmeaInterpreter();
        private void ExecuteStartOrStopGPSPortMethod()
        {
            if (GPSIsEnabled)
            {
                //start port
                //GPS TESTS
                Devices.AllowBluetoothConnections = false;
                Devices.AllowExhaustiveSerialPortScanning = true;

                Devices.BeginDetection();

                Devices.DeviceDetectionAttempted += new EventHandler<DeviceEventArgs>(Devices_DeviceDetectionAttempted);

                Devices.DeviceDetectionAttemptFailed += new EventHandler<DeviceDetectionExceptionEventArgs>(Devices_DeviceDetectionAttemptFailed);

                Devices.DeviceDetectionStarted += new EventHandler(Devices_DeviceDetectionStarted);

                if (Devices.IsOnlyFirstDeviceDetected == true)
                {
                    Devices.DeviceDetectionCompleted += new EventHandler(Devices_DeviceDetectionCompleted);
                }
                else
                {
                    Devices.DeviceDetected += new EventHandler<DeviceEventArgs>(Devices_DeviceDetected);
                    Devices.DeviceDetectionCanceled += new EventHandler(Devices_DeviceDetectionCanceled);
                }

            }
            else
            {

                interpreter.PositionReceived -= Interpreter_PositionReceived;
                interpreter.Stop();

                Devices.CancelDetection(true);

                var thread = new Thread(
                    () =>
                    {
                        try
                        {
                            Devices.CancelDetection();
                            Devices.Undetect();

                            Latitude = "";
                            Longitude = "! GPS Canceled";
                        }
                        catch { }
                    });

                thread.Start();

                Latitude = "";
                Longitude = "";
            }
        }

        void Devices_DeviceDetectionCanceled(object sender, EventArgs e)
        {
            Latitude = ""; // Delete e
            Longitude = "! Canceled";
        }

        void Devices_DeviceDetectionAttempted(object sender, DeviceEventArgs e)
        {
            Latitude = "" + e.Device;
            Longitude = "! GPS Detection";
        }

        void Devices_DeviceDetectionAttemptFailed(object sender, DeviceDetectionExceptionEventArgs e)
        {
            Latitude = ""; //+ e.Device ;
            Longitude = "! Searching GPS";
        }

        void Devices_DeviceDetectionStarted(object sender, EventArgs e)
        {
            Latitude = "" + e;
            Longitude = "! Waiting for Data";
        }

        void Devices_DeviceDetectionCompleted(object sender, EventArgs e)
        {
            Latitude = "GPS Not Detected";
            Longitude = "! Completed";
        }


        void Devices_DeviceDetected(object sender, DeviceEventArgs e)
        {
            //e.Device.Open();
            //interpreter = new NmeaInterpreter();
            interpreter.Start(e.Device);

            Latitude = "" + e.Device;
            Longitude = "! GPS detected at";
            Log("GPS Detected at port " + e.Device);

            interpreter.PositionReceived += new EventHandler<PositionEventArgs>(Interpreter_PositionReceived);
        }

        void Interpreter_PositionReceived(object sender, PositionEventArgs e)
        {
            if (!e.Position.IsInvalid)
            {
                if (e.Position.Longitude.ToString().Contains("NaN"))
                {
                    Latitude = "";
                    Longitude = "";
                }
                else
                {
                    Latitude = e.Position.Latitude.ToString();
                    Longitude = e.Position.Longitude.ToString();
                }
            }
            else
            {
                Latitude = "";
                Longitude = "! Waiting GPS Data";
            }
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
        private string Last_file_name2;

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

        #endregion
        #endregion
        #region Cleanup
        public override void Cleanup()
        {
            Log("System Stopped and Internal Temperature was: " + TemperatureLevel + " ºC" + "\r\n");
          
            SaveChartImage(); // Arlindo 05/APR/2022
            StopRecording();

            OSDLine1Submitted = ""; // Clear Styled text
            OSDLine12Submitted = ""; // Clear Styled text

            SetOSDStyled1(STREAM_A);
            SetOSDStyled1(STREAM_B);
            SetOSDStyled12(STREAM_A);
            SetOSDStyled12(STREAM_B);


            SetOSDStyledRECSTOP(STREAM_A);
            SetOSDStyledRECSTOP2(STREAM_A);

            MyCommunicationManager.WriteData(IO_COMMAND_TURN_CAMERA_OFF); // by ARLINDO 14-Jan-2015
            MyCommunicationManager.WriteData(IO_COMMAND_TURN_LIGHT_OFF); // by ARLINDO 14-Jan-2015

            S2253.CloseBoard(-1); // by ARLINDO 14-Jan-2015

            MyCommunicationManager.comPort.Close();

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
                interpreter.Dispose();
            }
        }
        #endregion
    } // End of Sealed Class
} // End of Namespace
#endregion
