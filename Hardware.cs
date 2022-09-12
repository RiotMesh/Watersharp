using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace Watersharp
{

    /// <summary>
    /// (RU only) Получение информации с датчиков оборудования
    /// </summary>
    public class Hardware
    {

        private static PerformanceCounter loadcpu = new PerformanceCounter("Процессор", "% загруженности процессора", "_Total");
        private static PerformanceCounter freqcpu = new PerformanceCounter("Сведения о процессоре", "Частота процессора", "_Total");

        private static PerformanceCounter appmem = new PerformanceCounter("Process", "Working Set - Private", Process.GetCurrentProcess().ProcessName);
        private static PerformanceCounter loadmem = new PerformanceCounter("Память", "Доступно МБ");

        private static PerformanceCounter loadhdd = new PerformanceCounter("Физический диск", "% активности диска", "0 C: D:");
        private static PerformanceCounter writehdd = new PerformanceCounter("Физический диск", "Скорость записи на диск (байт/с)", "0 C: D:");
        private static PerformanceCounter readhdd = new PerformanceCounter("Физический диск", "Скорость чтения с диска (байт/с)", "0 C: D:");

        private static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[ClassItemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Percentage of CPU usage
        /// </summary>
        public static double CPULoad()
        {
            try
            {
                return loadcpu.NextValue() * 2;
            }
            catch
            {
                return 99;
            }
        }

        /// <summary>
        /// Processor operating frequency
        /// </summary>
        public static double CPUFreq()
        {
            try
            {
                return freqcpu.NextValue();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// The amount of memory occupied by the current application (Megabytes)
        /// </summary>
        public static double MEMApp()
        {
            try
            {
                return appmem.RawValue / 1024.0 / 1024.0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Total RAM usage
        /// </summary>
        public static double MEMLoad()
        {
            try
            {
                return loadmem.NextValue();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// The percentage of loading of the main disk of the system
        /// </summary>
        public static double HDDLoad()
        {
            try
            {
                return loadhdd.NextValue();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Current disk write speed
        /// </summary>
        public static double HDDWrite()
        {
            try
            {
                return writehdd.NextValue() / 1024.0 / 1024.0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Current disk read speed
        /// </summary>
        public static double HDDRead()
        {
            try
            {
                return readhdd.NextValue() / 1024.0 / 1024.0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Remaining battery charge percentage (for devices with battery)
        /// </summary>
        public static float BATTERYRemainingP()
        {
            try
            {
                return SystemInformation.PowerStatus.BatteryLifePercent * 100;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Approximate battery life (for devices with battery)
        /// </summary>
        public static string BATTERYRemaining()
        {
            try
            {
                TimeSpan bl = TimeSpan.FromSeconds(SystemInformation.PowerStatus.BatteryLifeRemaining);
                if (bl.Hours == 0 && bl.Minutes == 0) { return "Питание от сети"; }
                else { return bl.Hours + " h. " + bl.Minutes + " m."; }
            }
            catch
            {
                return "-";
            }
        }

        public static string CPUModel()
        {
            return GetHardwareInfo("Win32_Processor", "Name")[0];
        }

        public static string GPUModel()
        {
            return GetHardwareInfo("Win32_VideoController", "Name")[0];
        }

    }
}
