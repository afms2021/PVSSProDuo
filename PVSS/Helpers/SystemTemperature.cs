using System;
using System.Collections.Generic;
using OpenHardwareMonitor.Hardware;

namespace PVSS.Helpers
{
    public class Temperature
    {
        public double CurrentValue { get; set; }
        public string InstanceName { get; set; }

        // Reuse a single Computer instance across calls to avoid re-initialising the driver each tick.
        private static Computer _computer;
        private static readonly object _lock = new object();

        private static bool _computerFailed = false;

        private static Computer GetComputer()
        {
            if (_computerFailed) return null;
            if (_computer == null)
            {
                lock (_lock)
                {
                    if (_computer == null && !_computerFailed)
                    {
                        try
                        {
                            var c = new Computer
                            {
                                IsCpuEnabled = true,
                                IsMotherboardEnabled = true,
                                IsGpuEnabled = false,
                                IsStorageEnabled = false,
                                IsMemoryEnabled = false,
                                IsNetworkEnabled = false
                            };
                            c.Open(false);
                            _computer = c;
                        }
                        catch
                        {
                            _computerFailed = true;
                        }
                    }
                }
            }
            return _computer;
        }

        public static List<Temperature> Temperatures
        {
            get
            {
                var result = new List<Temperature>();
                try
                {
                    var computer = GetComputer();
                    if (computer == null) return result;

                    // Update all hardware before reading — guard each individually
                    foreach (var hardware in computer.Hardware)
                    {
                        try { hardware.Update(); } catch { }
                        foreach (var sub in hardware.SubHardware)
                        {
                            try { sub.Update(); } catch { }
                        }
                    }

                    // Prefer CPU Package temperature; fall back to any CPU temp; then any motherboard temp
                    ISensor best = null;
                    foreach (var hardware in computer.Hardware)
                    {
                        try
                        {
                            foreach (var sub in hardware.SubHardware)
                                foreach (var sensor in sub.Sensors)
                                    if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                                        if (best == null ||
                                            (sensor.Name.IndexOf("Package", StringComparison.OrdinalIgnoreCase) >= 0 && hardware.HardwareType == HardwareType.Cpu))
                                            best = sensor;

                            foreach (var sensor in hardware.Sensors)
                                if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                                    if (best == null ||
                                        (sensor.Name.IndexOf("Package", StringComparison.OrdinalIgnoreCase) >= 0 && hardware.HardwareType == HardwareType.Cpu))
                                        best = sensor;
                        }
                        catch { }
                    }

                    if (best != null)
                        result.Add(new Temperature
                        {
                            CurrentValue = Math.Round((double)best.Value.Value, 1),
                            InstanceName = best.Hardware.Name + " / " + best.Name
                        });
                }
                catch
                {
                    // Driver not available or insufficient privileges — return empty list
                }
                return result;
            }
        }

        /// <summary>Call on application exit to cleanly unload the kernel driver.</summary>
        public static void Close()
        {
            lock (_lock)
            {
                _computer?.Close();
                _computer = null;
            }
        }
    }
}



