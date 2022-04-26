using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                    WindowState = WindowState.Minimized; //XAML
                    // Define Position on Secondary screen, for "Normal" window-mode
                    // ( Here Top/Left-Position )
                    Left = firstSecondary.Bounds.Left;
                    Top = firstSecondary.Bounds.Top;
                    Loaded += MainWindow_Loaded;

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
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Maximize after position is defined in constructor
            this.WindowState = WindowState.Maximized;
        }
    }
}
