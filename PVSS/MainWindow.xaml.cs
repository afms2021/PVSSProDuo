using PVSS.ViewModel;
using Microsoft.Win32;
using OxyPlot.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;

namespace PVSS
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ComVisible(false)]
    public partial class MainWindow : Window
    {
        public string SnapshotsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots";
        public string ChartsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts";
        public string SnapshotsDirectoryPath2 = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots2";
        public string ChartsDirectoryPath2 = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts2";
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        /// 

        public MainWindow()
        {
            this.WindowState = System.Windows.WindowState.Maximized;
            try
            {
              InitializeComponent();
            }
            catch (Exception)
            {

            }
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        public void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TakeSnapshot();
        }

        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key == Key.System ? e.SystemKey : e.Key)
            {
                case Key.F7: // Photo 1
                    TakeSnapshot();
                    break;
                case Key.F8: //  Photo 2
                    TakeSnapshot2();
                    break;
                default:
                    break;
            }
        }
        
        public string LastTakenPhoto2;

        public void TakeSnapshot2()
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap(1450, 1053, 96, 96, PixelFormats.Pbgra32);

            MainWindow2 win2 = Application.Current.Windows.OfType<MainWindow2>().FirstOrDefault();
            if (win2 != null)
            {
                bmp.Render(win2.video1Element);
            }          
           
            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));
            SnapshotsDirectoryPath2 = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots2";

            if (!Directory.Exists(SnapshotsDirectoryPath2))
            {
                Directory.CreateDirectory(SnapshotsDirectoryPath2);
            }



            string OutputVideoFileName = string.Format(@"{0}\{1}.bmp", SnapshotsDirectoryPath2, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); // was dd-MM-yyyy hh_mm_ss_fff due to PM/AM format
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
        public void TakeSnapshot()
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap(1450, 1053, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(videoElement);

            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            if (!Directory.Exists(SnapshotsDirectoryPath))
            {
                Directory.CreateDirectory(SnapshotsDirectoryPath);
            }

            SnapshotsDirectoryPath = Directory.GetCurrentDirectory() + "\\My Dives" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots";

            string OutputVideoFileName = string.Format(@"{0}\{1}.bmp", SnapshotsDirectoryPath, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); // was dd-MM-yyyy hh_mm_ss_fff due to PM/AM format
            try
            {
                using (FileStream s = new FileStream(OutputVideoFileName, FileMode.CreateNew, FileAccess.Write))
                {
                    encoder.Save(s);
                    LastTakenPhoto = OutputVideoFileName;
                }
            }
            catch (IOException)
            {

            }

            string fullPathToSound = Path.GetFullPath(@"Photo.wav");
            SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
            simpleSound.Play();

        }

        public string LastTakenPhoto;
               
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var psi = new ProcessStartInfo("Explorer.exe", "/select," + LastTakenPhoto);
            Process.Start(psi);
            //Process.Start(LastTakenPhoto);  // Some times crash to be done by Arlindo Dez.2015. Solved 27.Abr.2019 Manuel ALberto
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (!Directory.Exists(ChartsDirectoryPath))
            {
                Directory.CreateDirectory(ChartsDirectoryPath);
            }

            if (!Directory.Exists(ChartsDirectoryPath2))
            {
                Directory.CreateDirectory(ChartsDirectoryPath2);
            }

            var dlg = new SaveFileDialog
            {
                Filter = ".png files|*.png|.svg files|*.svg|.pdf files|*.pdf|.xaml files|*.xaml",
                DefaultExt = ".png",
                InitialDirectory = ChartsDirectoryPath,
                FileName = string.Format(@"{0}", DateTime.Now.ToString("dd-mm-yyyy HH_mm_ss_fff"))
            };
            if (dlg.ShowDialog(this).Value)
            {
                var ext = Path.GetExtension(dlg.FileName).ToLower();
                switch (ext)
                {
                    case ".png":
                        plot2.SaveBitmap(dlg.FileName);
                        break;
                    case ".svg":
                        var rc = new OxyPlot.Wpf.ShapesRenderContext(null);
                        var svg = plot2.Model.ToSvg(plot2.ActualWidth, plot2.ActualHeight, false, rc);
                        File.WriteAllText(dlg.FileName, svg);
                        break;
                    case ".pdf":
                        PdfExporter.Export(plot2.Model, dlg.FileName, plot2.ActualWidth, plot2.ActualHeight);
                        break;
                    case ".xaml":
                        plot2.SaveXaml(dlg.FileName);
                        break;
                }
                OpenContainingFolder(dlg.FileName);
            }
        }

        private void OpenContainingFolder(string fileName)
        {
            // var folder = Path.GetDirectoryName(fileName);
            var psi = new ProcessStartInfo("Explorer.exe", "/select," + fileName);
            Process.Start(psi);
        }

        private void MySD_Camera_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MyHD_Camera_Checked(object sender, RoutedEventArgs e)
        {

        }

        
    }
}