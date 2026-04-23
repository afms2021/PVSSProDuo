using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Messaging;

namespace PVSS
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    /// 
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            try
            {
                InitializeComponent();
                var screens = Screen.AllScreens;
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
            switch (e.Key == Key.System ? e.SystemKey : e.Key)
            {
                case Key.F7:
                    (System.Windows.Application.Current.MainWindow as MainWindow).TakeSnapshot();
                    break;
                case Key.F8:
                    (System.Windows.Application.Current.MainWindow as MainWindow).TakeSnapshot2();
                    break;
                case Key.Enter:
                    //TO DO
                    break;
                default:
                    break;
            }           
        }

        private void Image_MouseLeftButtonUp2(object sender, MouseButtonEventArgs e)
        {
            string LastTakenPhoto2 = (System.Windows.Application.Current.MainWindow as MainWindow).LastTakenPhoto2;
            ProcessStartInfo psi = new ProcessStartInfo("Explorer.exe", "/select," + LastTakenPhoto2);
            Process.Start(psi);            
        }


        private void MainWindow2_Loaded(object sender, RoutedEventArgs e)
        {
            // Maximize after position is defined in constructor
            this.WindowState = WindowState.Maximized;

            // Subscribe to ViewModel property changes to activate window and focus
            // the OSD text input when OSDPopupVisibility2 becomes true.
            if (DataContext is System.ComponentModel.INotifyPropertyChanged notifyVm)
            {
                notifyVm.PropertyChanged += ViewModel_PropertyChanged;
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "OSDPopupVisibility2")
            {
                var vm = DataContext as ViewModel.MainViewModel;
                if (vm != null && vm.OSDPopupVisibility2)
                {
                    this.Activate();
                    OSDLine122.Focus();
                }
            }
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

                //else
                //{
                    // _Diver2Window.Hide();
                    //_Diver2Window_Open = false;
                //}
            }
        }
                
    }
}
