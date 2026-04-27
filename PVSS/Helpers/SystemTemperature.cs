using System;
using System.Collections.Generic;
using System.Management;

namespace PVSS.Helpers
{
    /// <summary>
    /// Reads CPU / thermal-zone temperature using WMI only.
    /// No kernel driver (WinRing0) is loaded — no antivirus warnings.
    /// </summary>
    public class Temperature
    {
        public double CurrentValue { get; set; }
        public string InstanceName { get; set; }

        /// <summary>
        /// Returns a list with one entry containing the best available temperature reading.
        /// Uses MSAcpi_ThermalZoneTemperature (root\WMI) which works without any driver.
        /// Temperature values are in tenths of Kelvin: °C = (raw / 10.0) − 273.15
        /// </summary>
        public static List<Temperature> Temperatures
        {
            get
            {
                var result = new List<Temperature>();
                try
                {
                    using (var searcher = new ManagementObjectSearcher(
                        @"root\WMI",
                        "SELECT InstanceName, CurrentTemperature FROM MSAcpi_ThermalZoneTemperature"))
                    {
                        double best = double.MinValue;
                        string bestName = "";

                        foreach (ManagementObject obj in searcher.Get())
                        {
                            try
                            {
                                double raw = Convert.ToDouble(obj["CurrentTemperature"]);
                                double celsius = Math.Round((raw / 10.0) - 273.15, 1);
                                string name = obj["InstanceName"]?.ToString() ?? "Thermal Zone";

                                if (celsius > best)
                                {
                                    best = celsius;
                                    bestName = name;
                                }
                            }
                            catch { }
                        }

                        if (best > double.MinValue)
                            result.Add(new Temperature { CurrentValue = best, InstanceName = bestName });
                    }
                }
                catch
                {
                    // WMI not available or insufficient privileges — return empty list
                }
                return result;
            }
        }

        /// <summary>No-op: kept for API compatibility (no driver to unload).</summary>
        public static void Close() { }
    }
}

