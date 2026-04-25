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

        private static Computer GetComputer()
        {
            if (_computer == null)
            {
                lock (_lock)
                {
                    if (_computer == null)
                    {
                        _computer = new Computer
                        {
                            IsCpuEnabled = true,
                            IsMotherboardEnabled = true,
                            IsGpuEnabled = false,
                            IsStorageEnabled = false,
                            IsMemoryEnabled = false,
                            IsNetworkEnabled = false
                        };
                        _computer.Open(false); // false = not portable, uses local machine
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

                    // Update all hardware before reading
                    foreach (var hardware in computer.Hardware)
                    {
                        hardware.Update();
                        foreach (var sub in hardware.SubHardware)
                            sub.Update();
                    }

                    // Prefer CPU Package temperature; fall back to any CPU temp; then any motherboard temp
                    ISensor best = null;
                    foreach (var hardware in computer.Hardware)
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



