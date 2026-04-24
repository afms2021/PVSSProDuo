using FTChipID;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace PVSS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [ComVisible(false)]
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Catch unhandled exceptions on background threads (e.g. DotSpatial.Positioning)
            AppDomain.CurrentDomain.UnhandledException += (s, args) =>
            {
                var ex = args.ExceptionObject as Exception;
                // Suppress known DotSpatial NullReferenceException from DetectionThreadProc
                if (ex is NullReferenceException && ex.StackTrace != null &&
                    ex.StackTrace.Contains("DotSpatial.Positioning"))
                    return;
                // Log or show other unhandled exceptions as needed
            };

            // Catch unhandled exceptions on the UI dispatcher
            Current.DispatcherUnhandledException += (s, args) =>
            {
                if (args.Exception is NullReferenceException &&
                    args.Exception.StackTrace != null &&
                    args.Exception.StackTrace.Contains("DotSpatial.Positioning"))
                {
                    args.Handled = true;
                }
            };
        }
        private static void CheckUSBSerial()
        {
            int numDevices = 0, LocID = 0, ChipIDMy = 0;
            string SerialBuffer = "01234567890123456789012345678901234567890123456789";
            string Description = "01234567890123456789012345678901234567890123456789";

#if DEBUG
            bool pass = true;
#else
             bool pass = true; // ATENÇÃO sem proteção Must be FALSE - TODO 
#endif


            try
            {
                System.Threading.Thread.Sleep(500); // Added 8-OUT-2014 due to delay on USB Hardlock
                ChipID.GetNumDevices(ref numDevices);
                if (numDevices > 0)
                {
                    for (int i = 0; i < numDevices; i++)
                    {
                        FTChipID.ChipID.GetDeviceSerialNumber(i, ref SerialBuffer, 50);
                        FTChipID.ChipID.GetDeviceDescription(i, ref Description, 50);
                        FTChipID.ChipID.GetDeviceLocationID(i, ref LocID);
                        FTChipID.ChipID.GetDeviceChipID(i, ref ChipIDMy);

                        if (
                            ((SerialBuffer == "FTVILF7M" && ChipIDMy == -1595346739)) || // PVSS #01 Multisub #1
                            ((SerialBuffer == "A102KUPQ" && ChipIDMy == -1094433575)) || // PVSS #02 S130064 Pommec Alemanha
                            ((SerialBuffer == "A601AZ3W" && ChipIDMy == 899964101)) ||   // PVSS #02 S130064 antiga lida com driver novo após reparação e motherboard novo
                            ((SerialBuffer == "FTWD0UPI" && ChipIDMy == 962135769)) ||   // PVSS #03 S130066 Pommec
                            ((SerialBuffer == "FTWEOKIZ" && ChipIDMy == -36114179)) ||   // PVSS #04 S130067 Pommec
                            ((SerialBuffer == "FTWEQG6P" && ChipIDMy == -1138467367)) || // PVSS #05 S130066 Underwater
                            ((SerialBuffer == "FTWEQGQU" && ChipIDMy == -1105721639)) || // PVSS #06 S130068 Estradas de Portugal
                            ((SerialBuffer == "FTWEQRZ2" && ChipIDMy == -1590753575)) || // PVSS #07 S140015 Odebrecht #1
                            ((SerialBuffer == "FTWF4SY4" && ChipIDMy == -638253351)) ||  // PVSS #08 S140016 Odebrecht #2
                            ((SerialBuffer == "FTVHC2FJ" && ChipIDMy == -1569706791)) || // PVSS #09 S140018 Pommec Romenia PRODIVE !!! (sim é mesmo)
                            ((SerialBuffer == "FTVHC2FJ" && ChipIDMy == -1569706791)) || // PVSS #10 S150007 Pommec sem COMMS was S1400017 inside label
                            ((SerialBuffer == "FTWEQYBB" && ChipIDMy == 1209665241)) ||  // PVSS #11 S150017 Multisub #2
                            ((SerialBuffer == "FTYTP9ZE" && ChipIDMy == 871)) ||         // PVSS #12 S150018 Proaquatica  *** PVSS ROUBADO AO CLIENTE *** was (-180920871=
                            ((SerialBuffer == "FTZ811UL" && ChipIDMy == 206706909)) ||   // PVSS #13 S150019 TSM Madeira
                            ((SerialBuffer == "FTZ81GZN" && ChipIDMy == 1935218909)) ||  // PVSS #14 S160020 Filipe Odebrecht
                            ((SerialBuffer == "FTZ81GZN" && ChipIDMy == 1935218909)) ||  // PVSS #15 S160021 Pommec #21 PVSS
                            ((SerialBuffer == "FT0LY3BN" && ChipIDMy == -2035593143)) || // PVSS #16 S170022 DMS-2 Marinha 
                            ((SerialBuffer == "FT0NTB67" && ChipIDMy == -1280618423)) || // PVSS #17 S170023 XAVISUB #1
                            ((SerialBuffer == "FT175MLV" && ChipIDMy == 1724849741)) ||  // PVSS #18 S180024 Proaquatica #2 
                            ((SerialBuffer == "FT175MX2" && ChipIDMy == 1046660853)) ||  // PVSS #19 S180025 Multisub #3 Laranja
                            ((SerialBuffer == "FT2L9SWI" && ChipIDMy == 115642821)) ||   // PVSS #20 S190025 XAVISUB #2
                            ((SerialBuffer == "FT2L9SUZ" && ChipIDMy == -1683724577)))   // PVSS #21 S190026 XAVISUB #3

                        {
                            pass = true;
                        }
                    }
                }

            }
            catch (ChipIDException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (!pass)
            {
                MessageBox.Show("Insert a valid USB Hardlock Key.",
                "License Hardlock",
                MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
                Application.Current.Shutdown();
            }

        }
    }
}
