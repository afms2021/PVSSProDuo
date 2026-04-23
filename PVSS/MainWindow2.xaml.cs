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
                    var vm = DataContext as ViewModel.MainViewModel;
                    if (vm != null && vm.OSDPopupVisibility2)
                    {
                        vm.OSDLine12Submitted = vm.OSDLine12;
                        vm.OSDPopupVisibility2 = false;
                        var mainWin = System.Windows.Application.Current.MainWindow as MainWindow;
                        if (mainWin != null)
                        {
                            System.Threading.Thread.Sleep(150);
                            mainWin.TakeSnapshot2();
                            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                            {
                                mainWin.Activate();
                            }));
                        }
                    }
                    break;
                default:
                    break;
            }           
        }

        public void FocusOSDInput()
        {
            OSDLine122.Focus();
            OSDLine122.SelectAll();
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

            // Stop all Diver 2 tasks and sync toggle when this window is closed
            this.Closed += (s, args) =>
            {
                _Diver2Window_Open = false;
                var vm = DataContext as ViewModel.MainViewModel;
                if (vm != null)
                {
                    vm.CleanupDiver2();
                    vm.Diver2IsEnabled = false; // sync toggle switch to OFF
                }
            };

            // Return focus to Monitor 1 after Monitor 2 window opens
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
            {
                var mainWin = System.Windows.Application.Current.MainWindow as MainWindow;
                mainWin?.Activate();
            }));

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
                if (!_Diver2Window_Open)
                {
                    PVSS.MainWindow2 _Diver2Window = new PVSS.MainWindow2
                    {
                        Topmost = true,
                    };
                    _Diver2Window.Show();
                    _Diver2Window_Open = true;
                }
            }
            else
            {
                var existing = System.Windows.Application.Current.Windows
                    .OfType<MainWindow2>()
                    .FirstOrDefault();

                if (existing != null)
                {
                    existing.Close();
                }
                _Diver2Window_Open = false;

                // Return focus to Monitor 1
                var mainWin = System.Windows.Application.Current.MainWindow as MainWindow;
                mainWin?.Activate();
            }
        }
                
    }
}
