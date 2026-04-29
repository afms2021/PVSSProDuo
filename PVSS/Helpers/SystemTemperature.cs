using System;
using System.Collections.Generic;
using System.Management;

namespace PVSS.Helpers
{
    /// <summary>
    /// Reads temperature using WMI only — no kernel driver required.
    /// Priority 1: SMART attribute 194 / 190 via MSStorageDriver_ATAPISmartData (root\WMI)
    ///             Works on SATA SSDs and HDDs without any third-party driver.
    /// Priority 2: Fallback to MSAcpi_ThermalZoneTemperature (ACPI thermal zone).
    /// ASUS PRIME B660M-A D4 does not expose ACPI thermal zones, so SMART is used.
    /// </summary>
    public class Temperature
    {
        public double CurrentValue { get; set; }
        public string InstanceName { get; set; }

        // SMART attribute IDs that carry temperature
        private const byte SMART_ATTR_TEMP       = 194; // 0xC2 — HDD/SSD temperature (most vendors)
        private const byte SMART_ATTR_AIRFLOW_TEMP = 190; // 0xBE — Airflow temperature (WD, some Samsung)

        /// <summary>
        /// Parses raw SMART VendorSpecific byte array and returns temperature in °C,
        /// or double.MinValue if not found.
        /// Layout (each attribute = 12 bytes starting at offset 2):
        ///   [0]=AttrId [1-2]=Flags [3]=Current [4]=Worst [5-10]=Raw [11]=Reserved
        /// Temperature raw value: byte[5] = current °C for attr 194/190.
        /// </summary>
        private static double ParseSmartTemp(byte[] data)
        {
            if (data == null || data.Length < 14) return double.MinValue;
            // Up to 30 attributes; each 12 bytes, starting at offset 2
            for (int i = 0; i < 30; i++)
            {
                int offset = 2 + i * 12;
                if (offset + 11 >= data.Length) break;
                byte attrId = data[offset];
                if (attrId == 0) break; // end of attributes
                if (attrId == SMART_ATTR_TEMP || attrId == SMART_ATTR_AIRFLOW_TEMP)
                {
                    double temp = data[offset + 5]; // first byte of 6-byte raw value = °C
                    if (temp > 0 && temp < 120) return temp;
                }
            }
            return double.MinValue;
        }

        public static List<Temperature> Temperatures
        {
            get
            {
                var result = new List<Temperature>();

                // --- 1. SMART temperature via MSStorageDriver_ATAPISmartData ---
                try
                {
                    using (var searcher = new ManagementObjectSearcher(
                        @"root\WMI",
                        "SELECT InstanceName, VendorSpecific FROM MSStorageDriver_ATAPISmartData"))
                    {
                        double best = double.MinValue;
                        string bestName = "";

                        foreach (ManagementObject obj in searcher.Get())
                        {
                            try
                            {
                                byte[] data = obj["VendorSpecific"] as byte[];
                                double temp = ParseSmartTemp(data);
                                if (temp == double.MinValue) continue;

                                string name = obj["InstanceName"]?.ToString() ?? "Drive";
                                if (temp > best)
                                {
                                    best = temp;
                                    bestName = name;
                                }
                            }
                            catch { }
                        }

                        if (best > double.MinValue)
                        {
                            result.Add(new Temperature { CurrentValue = best, InstanceName = "SSD " + bestName });
                            return result;
                        }
                    }
                }
                catch { }

                // --- 2. NVMe / modern drives: MSFT_StorageReliabilityCounter ---
                // MSStorageDriver_ATAPISmartData is SATA-only; NVMe drives appear here instead.
                try
                {
                    using (var searcher = new ManagementObjectSearcher(
                        @"root\Microsoft\Windows\Storage",
                        "SELECT Temperature, DeviceId FROM MSFT_StorageReliabilityCounter"))
                    {
                        double best = double.MinValue;
                        string bestName = "";

                        foreach (ManagementObject obj in searcher.Get())
                        {
                            try
                            {
                                object rawTemp = obj["Temperature"];
                                if (rawTemp == null) continue;
                                double temp = Convert.ToDouble(rawTemp);
                                if (temp <= 0 || temp >= 120) continue;

                                string name = obj["DeviceId"]?.ToString() ?? "NVMe";
                                if (temp > best) { best = temp; bestName = name; }
                            }
                            catch { }
                        }

                        if (best > double.MinValue)
                        {
                            result.Add(new Temperature { CurrentValue = best, InstanceName = "SSD " + bestName });
                            return result;
                        }
                    }
                }
                catch { }

                // --- 3. Fallback: ACPI thermal zone ---
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
                                if (celsius > best) { best = celsius; bestName = name; }
                            }
                            catch { }
                        }

                        if (best > double.MinValue)
                            result.Add(new Temperature { CurrentValue = best, InstanceName = bestName });
                    }
                }
                catch { }

                return result;
            }
        }

        /// <summary>No-op: kept for API compatibility.</summary>
        public static void Close() { }
    }
}
