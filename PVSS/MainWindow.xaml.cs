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
            if (e.Key == System.Windows.Input.Key.F8)
            {
                MainWindow2 win2 = new MainWindow2();

                win2.TakeSnapshot2();
            }

            if (e.Key == System.Windows.Input.Key.F7)
            {
                TakeSnapshot();
            }
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
        public string LastTakenPhoto2;
       
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