using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace PVSS
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            try
            {
                InitializeComponent();
                var screens = System.Windows.Forms.Screen.AllScreens;
                var firstSecondary = screens.FirstOrDefault(s => s.Primary == false);
                if (firstSecondary != null)
                {
                    WindowStartupLocation = WindowStartupLocation.Manual;
                    // Ensure Window is minimzed on creation
                    WindowState = WindowState.Minimized; 
                    // Define Position on Secondary screen, for "Normal" window-mode
                    // ( Here Top/Left-Position )
                    Left = firstSecondary.Bounds.Left;
                    Top = firstSecondary.Bounds.Top;
                    Loaded += MainWindow2_Loaded;

                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }

            }
            catch (Exception)
            {

            }

        }
      
        public void Window_KeyUp2(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F7)
            {
                (Application.Current.MainWindow as MainWindow).TakeSnapshot();             
            }

            if (e.Key == System.Windows.Input.Key.F8)
            {
                TakeSnapshot2();
            }
        }
        
        //private string LastTakenPhoto2 = null;
        public string SnapshotsDirectoryPath;
        private string LastTakenPhoto2;

        public void TakeSnapshot2()
        {
            int screenTop = (int)SystemParameters.VirtualScreenTop;
            int screenLeft = (int)SystemParameters.VirtualScreenLeft;
            
            // Create a bitmap of the appropriate size to receive the screenshot.
            using (Bitmap bmp2 = new Bitmap(1450, 1053, PixelFormat.Format32bppPArgb))
            {
                // Draw the screenshot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp2))
                {
                    g.CopyFromScreen(screenLeft + 400, screenTop, 0, 0, bmp2.Size);
                }
                
                SnapshotsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots";

                string OutputVideoFileName2 = string.Format(@"{0}\{1}.bmp", SnapshotsDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); // was dd-MM-yyyy hh_mm_ss_fff due to PM/AM format
                try
                {
                    bmp2.Save(OutputVideoFileName2, ImageFormat.Bmp);
                    //MainWindow win3 = new MainWindow();
                    LastTakenPhoto2 = OutputVideoFileName2;
                }
                catch (IOException)
                {

                }                               
            }
                     
            string fullPathToSound = Path.GetFullPath(@"Photo.wav");
            SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
            simpleSound.Play();

        }

        private void Image_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            LastTakenPhoto2 = (Application.Current.MainWindow as MainWindow).LastTakenPhoto;
            var psi = new ProcessStartInfo("Explorer.exe", "/select," + LastTakenPhoto2);
            Process.Start(psi);            
        }


        private void MainWindow2_Loaded(object sender, RoutedEventArgs e)
        {
            // Maximize after position is defined in constructor
            this.WindowState = WindowState.Maximized;            
        }


        public static bool _Diver2Window_Open = false;
        public static void Diver2IsEnabled_Checked(bool Diver2IsEnabled)
        {
            if (Diver2IsEnabled)
            {
                PVSS.MainWindow2 _Diver2Window = new PVSS.MainWindow2
                {
                    Topmost = true,
                };

                if (!_Diver2Window.IsActive && !_Diver2Window_Open)
                {
                    _Diver2Window.Show();
                    _Diver2Window_Open = true;
                }
                else
                {
                    _Diver2Window.Hide();
                    _Diver2Window_Open = false;
                }
            }
        }
    }
}
