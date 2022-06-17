using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;

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
      
        public void Window_KeyUp2(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
               case Key.F7:
                   (System.Windows.Application.Current.MainWindow as MainWindow).TakeSnapshot();
                   break;
               case Key.F8:
                    TakeSnapshot2();
                    break;
               default:
                    break;
            }
        }
        
        public string SnapshotsDirectoryPath;
        private string LastTakenPhoto2;

        public void TakeSnapshot2()
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap(1450, 1053, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(video1Element);

            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));
            SnapshotsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots2";

            if (!Directory.Exists(SnapshotsDirectoryPath))
            {
                Directory.CreateDirectory(SnapshotsDirectoryPath);
            }

            

            string OutputVideoFileName = string.Format(@"{0}\{1}.bmp", SnapshotsDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); // was dd-MM-yyyy hh_mm_ss_fff due to PM/AM format
            try
            {
                using (FileStream s = new FileStream(OutputVideoFileName, FileMode.CreateNew, FileAccess.Write))
                {
                    encoder.Save(s);
                    LastTakenPhoto2 = OutputVideoFileName;
                }
            }
            catch (IOException)
            {

            }
            

            string fullPathToSound = Path.GetFullPath(@"Photo.wav");
            SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
            simpleSound.Play();

        }

        private void Image_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            LastTakenPhoto2 = (System.Windows.Application.Current.MainWindow as MainWindow).LastTakenPhoto;
            var psi = new ProcessStartInfo("Explorer.exe", "/select," + LastTakenPhoto2);
            Process.Start(psi);            
        }


        private void MainWindow2_Loaded(object sender, RoutedEventArgs e)
        {
            // Maximize after position is defined in constructor
            this.WindowState = WindowState.Maximized;            
        }

        public static bool _Diver2Window_Open = false;

        public static void PerformDiver2IsEnabled_Checked(bool Diver2IsEnabled)
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
