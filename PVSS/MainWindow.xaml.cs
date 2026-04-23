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
        public string JobNameDiretory1 = "D:\\PVSS DUO PRO 1";
        public string JobNameDiretory2 = "E:\\PVSS DUO PRO 2";
        public string VideoDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos1";
        public string VideoDirectoryPath2 = "E:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Videos2";
        public string SnapshotsDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots1";
        public string SnapshotsDirectoryPath2 = "E:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots2";
        public string ChartsDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts1";
        public string ChartsDirectoryPath2 = "E:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Charts2";
        public string LogPath = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\log.txt";




        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        /// 

        public MainWindow()
        {
            this.WindowState = System.Windows.WindowState.Maximized;
            try
            {   
                if (!Directory.Exists(VideoDirectoryPath1))
                {
                    Directory.CreateDirectory(VideoDirectoryPath1);
                }
                if (!Directory.Exists(VideoDirectoryPath2))
                {
                    Directory.CreateDirectory(VideoDirectoryPath2);
                }

                if (!Directory.Exists(SnapshotsDirectoryPath1))
                {
                    Directory.CreateDirectory(SnapshotsDirectoryPath1);
                }
                if (!Directory.Exists(SnapshotsDirectoryPath2))
                {
                    Directory.CreateDirectory(SnapshotsDirectoryPath2);
                }

                if (!Directory.Exists(ChartsDirectoryPath1))
                {
                    Directory.CreateDirectory(ChartsDirectoryPath1);
                }
                if (!Directory.Exists(ChartsDirectoryPath2))
                {
                    Directory.CreateDirectory(ChartsDirectoryPath2);
                }

                if (!File.Exists(LogPath))
                {
                    File.Create(LogPath);
                }
                InitializeComponent();
            }
            catch (Exception)
            {

            }
            Closing += (s, e) => ViewModelLocator.Cleanup();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Activate(); // Ensure Monitor 1 has OS-level focus on startup

            if (DataContext is System.ComponentModel.INotifyPropertyChanged notifyVm)
            {
                notifyVm.PropertyChanged += (s, args) =>
                {
                    if (args.PropertyName == "OSDPopupVisibility")
                    {
                        var vm = DataContext as ViewModel.MainViewModel;
                        if (vm != null && vm.OSDPopupVisibility)
                        {
                            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                            {
                                this.Activate();
                                OSDLine1.Focus();
                                OSDLine1.SelectAll();
                            }));
                        }
                    }
                };
            }
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

            SnapshotsDirectoryPath2 = "E:\\PVSS DUO PRO 2" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots2";

            if (!Directory.Exists(SnapshotsDirectoryPath2))
            {
                Directory.CreateDirectory(SnapshotsDirectoryPath2);
            }
            
            string OutputPhotoFileName2 = string.Format(@"{0}\{1}.bmp", SnapshotsDirectoryPath2, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); // was dd-MM-yyyy hh_mm_ss_fff due to PM/AM format
            try
            {
                using (FileStream s = new FileStream(OutputPhotoFileName2, FileMode.CreateNew, FileAccess.Write))
                {
                    encoder.Save(s);
                    LastTakenPhoto2 = OutputPhotoFileName2;
                }
            }
            catch (IOException)
            {

            }


            string fullPathToSound = Path.GetFullPath(@"Photo.wav");
            SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
            simpleSound.Play();

        }
        public string LastTakenPhoto1;
        public void TakeSnapshot()
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap(1450, 1053, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(videoElement);

            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            SnapshotsDirectoryPath1 = "D:\\PVSS DUO PRO 1" + "\\" + Properties.Settings.Default.JobNameText + "\\Snapshots1";

            if (!Directory.Exists(SnapshotsDirectoryPath1))
            {
                Directory.CreateDirectory(SnapshotsDirectoryPath1);
            }

            string OutputPhotoFileName1 = string.Format(@"{0}\{1}.bmp", SnapshotsDirectoryPath1, DateTime.Now.ToString("dd-MM-yyyy HH_mm_ss_fff")); // was dd-MM-yyyy hh_mm_ss_fff due to PM/AM format
            try
            {
                using (FileStream s = new FileStream(OutputPhotoFileName1, FileMode.CreateNew, FileAccess.Write))
                {
                    encoder.Save(s);
                    LastTakenPhoto1 = OutputPhotoFileName1;
                }
            }
            catch (IOException)
            {

            }

            string fullPathToSound = Path.GetFullPath(@"Photo.wav");
            SoundPlayer simpleSound = new SoundPlayer(fullPathToSound);
            simpleSound.Play();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var psi = new ProcessStartInfo("Explorer.exe", "/select," + LastTakenPhoto1);
            Process.Start(psi);
            //Process.Start(LastTakenPhoto);  // Some times crash to be done by Arlindo Dez.2015. Solved 27.Abr.2019 Manuel ALberto
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (!Directory.Exists(ChartsDirectoryPath1))
            {
                Directory.CreateDirectory(ChartsDirectoryPath1);
            }

            if (!Directory.Exists(ChartsDirectoryPath2))
            {
                Directory.CreateDirectory(ChartsDirectoryPath2);
            }

            var dlg = new SaveFileDialog
            {
                Filter = ".png files|*.png|.svg files|*.svg|.pdf files|*.pdf|.xaml files|*.xaml",
                DefaultExt = ".png",
                InitialDirectory = ChartsDirectoryPath1,
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