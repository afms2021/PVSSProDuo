using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Sensoray;

namespace PVSS
{
    /// <summary>
    /// Animated splash screen with hardware readiness checks.
    /// Runs all checks asynchronously, then signals the caller to open MainWindow.
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        // ------------------------------------------------------------------ //
        //  Public result: set to true when the app is ready to proceed.       //
        // ------------------------------------------------------------------ //
        public bool ReadyToLaunch { get; private set; } = false;

        // Raised when all checks are complete (pass or warn) → App can open MainWindow.
        public event EventHandler LaunchReady;

        // ------------------------------------------------------------------ //
        //  Checklist item for the WrapPanel                                   //
        // ------------------------------------------------------------------ //
        public class CheckItem
        {
            public string Icon      { get; set; }
            public string Label     { get; set; }
            public Brush  ItemColor { get; set; }

            public static CheckItem Pending(string label) =>
                new CheckItem { Icon = "○", Label = label, ItemColor = new SolidColorBrush(Colors.Gray) };

            public static CheckItem OK(string label) =>
                new CheckItem { Icon = "✔", Label = label, ItemColor = new SolidColorBrush(Color.FromRgb(0x2E, 0xCC, 0x71)) };

            public static CheckItem Warn(string label) =>
                new CheckItem { Icon = "⚠", Label = label, ItemColor = new SolidColorBrush(Colors.Orange) };

            public static CheckItem Fail(string label) =>
                new CheckItem { Icon = "✘", Label = label, ItemColor = new SolidColorBrush(Colors.OrangeRed) };
        }

        private ObservableCollection<CheckItem> _items = new ObservableCollection<CheckItem>();

        private enum ComPortResult { NoPorts, Mismatch, OK }

        // Index for each check step so we can update it in place
        private const int IDX_SENSORAY  = 0;
        private const int IDX_DRIVE_D   = 1;
        private const int IDX_DRIVE_E   = 2;
        private const int IDX_DIRS      = 3;
        private const int IDX_DLL       = 4;
        private const int IDX_COMPORTS  = 5;

        // Progress bar track pixel width — measured after layout pass
        private double _trackWidth = 0;

        // ================================================================== //
        public SplashScreenWindow()
        {
            InitializeComponent();

            _items.Add(CheckItem.Pending("Sensoray S2253"));
            _items.Add(CheckItem.Pending("Drive D:"));
            _items.Add(CheckItem.Pending("Drive F:"));
            _items.Add(CheckItem.Pending("Directories"));
            _items.Add(CheckItem.Pending("mid2253.dll"));
            _items.Add(CheckItem.Pending("COM Ports"));

            CheckList.ItemsSource = _items;
        }

        // ================================================================== //
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Measure actual track width after first render
            _trackWidth = ProgressFill.ActualWidth > 0
                ? ProgressFill.ActualWidth
                : ((FrameworkElement)ProgressFill.Parent).ActualWidth;

            // Kick off async checks
            _ = RunChecksAsync();
        }

        // ================================================================== //
        //  MAIN CHECK SEQUENCE                                                //
        // ================================================================== //
        private async Task RunChecksAsync()
        {
            // Total steps for the progress bar
            const int TOTAL_STEPS = 7;
            int step = 0;

            // ── 1. Small delay so the fade-in animation plays fully ──────── //
            SetProgress(step, TOTAL_STEPS, "Starting up…");
            await Task.Delay(400);

            // ── 2. Sensoray S2253 Board ──────────────────────────────────── //
            SetProgress(++step, TOTAL_STEPS, "Waiting for Sensoray S2253 board…");
            bool sensorayOk = await Task.Run(() => CheckSensorayBoard());
            UpdateItem(IDX_SENSORAY, sensorayOk ? CheckItem.OK("Sensoray S2253") : CheckItem.Warn("Sensoray S2253"));

            // ── 3. Drive D: ──────────────────────────────────────────────── //
            SetProgress(++step, TOTAL_STEPS, "Checking Drive D:\\…");
            bool driveDExists = await Task.Run(() => DriveExists("D:\\"));
            bool driveDSpace  = driveDExists && await Task.Run(() => CheckDrive("D:\\", 5.0));
            UpdateItem(IDX_DRIVE_D, !driveDExists
                ? CheckItem.Fail("Drive D: not found")
                : (driveDSpace ? CheckItem.OK("Drive D:") : CheckItem.Warn("Drive D: low space")));

            // ── 4. Drive F: ──────────────────────────────────────────────── //
            SetProgress(++step, TOTAL_STEPS, "Checking Drive F:\\…");
            bool driveEExists = await Task.Run(() => DriveExists("F:\\"));
            bool driveESpace  = driveEExists && await Task.Run(() => CheckDrive("F:\\", 5.0));
            UpdateItem(IDX_DRIVE_E, !driveEExists
                ? CheckItem.Fail("Drive F: not found")
                : (driveESpace ? CheckItem.OK("Drive F:") : CheckItem.Warn("Drive F: low space")));

            // ── 5. Output directories ────────────────────────────────────── //
            SetProgress(++step, TOTAL_STEPS, "Checking output directories…");
            bool dirs = await Task.Run(() => CheckDirectories());
            UpdateItem(IDX_DIRS, dirs ? CheckItem.OK("Directories") : CheckItem.Warn("Directories"));

            // ── 6. mid2253.dll ───────────────────────────────────────────── //
            SetProgress(++step, TOTAL_STEPS, "Checking Sensoray driver DLL…");
            bool dll = await Task.Run(() => CheckDll());
            UpdateItem(IDX_DLL, dll ? CheckItem.OK("mid2253.dll") : CheckItem.Fail("mid2253.dll missing"));

            // ── 7. COM Ports ─────────────────────────────────────────────── //
            SetProgress(++step, TOTAL_STEPS, "Scanning COM ports…");
            var (comResult, comSaved, comAvailable) = await Task.Run(() => CheckComPorts());

            // On mismatch, auto-correct to the first available port and save it
            string comActive = comSaved;
            if (comResult == ComPortResult.Mismatch)
            {
                comActive = comAvailable[0];
                PVSS.Properties.Settings.Default.COMPort = comActive;
                PVSS.Properties.Settings.Default.Save();
            }

            switch (comResult)
            {
                case ComPortResult.OK:
                    UpdateItem(IDX_COMPORTS, CheckItem.OK(
                        $"COM Ports — using: {comActive}  |  available: {string.Join(", ", comAvailable)}"));
                    break;
                case ComPortResult.Mismatch:
                    UpdateItem(IDX_COMPORTS, CheckItem.Warn(
                        $"COM Ports — '{comSaved}' not found, switched to: {comActive}  |  available: {string.Join(", ", comAvailable)}"));
                    break;
                case ComPortResult.NoPorts:
                    UpdateItem(IDX_COMPORTS, CheckItem.Fail(
                        string.IsNullOrEmpty(comSaved)
                            ? "COM Ports — no ports detected"
                            : $"COM Ports — no ports detected  (last used: {comSaved})"));
                    break;
            }

            // ── Final ────────────────────────────────────────────────────── //
            bool anyDriveMissing = !driveDExists || !driveEExists;
            bool noComPorts      = comResult == ComPortResult.NoPorts;
            bool canStart        = !anyDriveMissing && !noComPorts;

            SetProgress(TOTAL_STEPS, TOTAL_STEPS, canStart ? "Ready!" : "Cannot start — check warnings below.");
            await Task.Delay(600);

            if (!canStart)
            {
                var sb = new System.Text.StringBuilder();
                if (anyDriveMissing)
                {
                    sb.Append("Missing drive(s): ");
                    if (!driveDExists) sb.Append("D:  ");
                    if (!driveEExists) sb.Append("F:  ");
                    sb.Append(" — connect the required storage drive(s).");
                }
                if (noComPorts)
                {
                    if (sb.Length > 0) sb.AppendLine();
                    sb.Append("No COM ports detected — connect the serial device and restart.");
                }
                ShowDriveWarning(sb.ToString());
                return; // block launch
            }

            ReadyToLaunch = true;
            LaunchReady?.Invoke(this, EventArgs.Empty);
        }

        // ================================================================== //
        //  CHECK METHODS                                                      //
        // ================================================================== //

        /// <summary>
        /// Open the S2253 board and wait up to 8 seconds for at least 1 device.
        /// </summary>
        private bool CheckSensorayBoard()
        {
            try
            {
                S2253.OpenBoard(-1);
                int numDev = 0;
                int tries = 80;   // 80 × 100 ms = 8 seconds max
                do
                {
                    S2253.GetNumDevices(ref numDev);
                    if (numDev > 0) break;
                    Thread.Sleep(100);
                    tries--;
                } while (tries > 0);

                return numDev > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true when the drive letter is present and ready.
        /// </summary>
        private bool DriveExists(string root)
        {
            try { return Directory.Exists(root) && new DriveInfo(root).IsReady; }
            catch { return false; }
        }

        /// <summary>
        /// Check drive exists and has at least minFreeGB of free space.
        /// </summary>
        private bool CheckDrive(string root, double minFreeGB)
        {
            try
            {
                if (!Directory.Exists(root)) return false;
                var info = new DriveInfo(root);
                return info.IsReady && (info.AvailableFreeSpace / (1024.0 * 1024 * 1024) >= minFreeGB);
            }
            catch { return false; }
        }

        /// <summary>
        /// Ensure the main output directories are writable (creates them if missing).
        /// </summary>
        private bool CheckDirectories()
        {
            try
            {
                var jobName = Properties.Settings.Default.JobNameText;
                var paths = new[]
                {
                    @"D:\PVSS DUO PRO 1\" + jobName + @"\Videos1",
                    @"D:\PVSS DUO PRO 1\" + jobName + @"\Snapshots1",
                    @"D:\PVSS DUO PRO 1\" + jobName + @"\Charts1",
                    @"F:\PVSS DUO PRO 2\" + jobName + @"\Videos2",
                    @"F:\PVSS DUO PRO 2\" + jobName + @"\Snapshots2",
                    @"F:\PVSS DUO PRO 2\" + jobName + @"\Charts2",
                };
                foreach (var p in paths)
                {
                    if (!Directory.Exists(p))
                        Directory.CreateDirectory(p);
                }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Verify mid2253.dll is present next to the executable.
        /// </summary>
        private bool CheckDll()
        {
            try
            {
                var exeDir = AppDomain.CurrentDomain.BaseDirectory;
                return File.Exists(Path.Combine(exeDir, "mid2253.dll"));
            }
            catch { return false; }
        }

        /// <summary>
        /// Check that at least one serial port is available on this machine.
        /// </summary>
        private (ComPortResult result, string savedPort, string[] available) CheckComPorts()
        {
            string saved = PVSS.Properties.Settings.Default.COMPort ?? "";
            string[] ports;
            try   { ports = System.IO.Ports.SerialPort.GetPortNames(); }
            catch { ports = new string[0]; }

            if (ports.Length == 0)
                return (ComPortResult.NoPorts, saved, ports);

            bool match = System.Array.Exists(ports,
                p => string.Equals(p, saved, System.StringComparison.OrdinalIgnoreCase));

            return match
                ? (ComPortResult.OK,      saved, ports)
                : (ComPortResult.Mismatch, saved, ports);
        }

        // ================================================================== //
        //  UI HELPERS (must run on the UI thread)                             //
        // ================================================================== //

        private void SetProgress(int step, int total, string label)
        {
            Dispatcher.Invoke(() =>
            {
                double fraction = total == 0 ? 0 : (double)step / total;
                int pct = (int)(fraction * 100);

                // Animate bar width
                double targetW = fraction * ((FrameworkElement)ProgressFill.Parent).ActualWidth;
                var anim = new DoubleAnimation(targetW, TimeSpan.FromMilliseconds(280));
                ProgressFill.BeginAnimation(FrameworkElement.WidthProperty, anim);

                StepLabel.Text   = label;
                PercentLabel.Text = pct + " %";
                StatusText.Text  = label;
            });
        }

        private void UpdateItem(int index, CheckItem replacement)
        {
            Dispatcher.Invoke(() =>
            {
                if (index >= 0 && index < _items.Count)
                    _items[index] = replacement;
            });
        }

        private void ShowDriveWarning(string message)
        {
            Dispatcher.Invoke(() =>
            {
                DriveWarningText.Text = message;
                DriveWarningText.Visibility = Visibility.Visible;
                StatusText.Text = "Application cannot start. Fix the issue(s) above and restart.";
            });
        }

        private void ShowComMismatchWarning(string message)
        {
            Dispatcher.Invoke(() =>
            {
                DriveWarningText.Text = message;
                DriveWarningText.Visibility = Visibility.Visible;
                // StatusText stays at "Ready!" — app will still launch
            });
        }
    }
}
