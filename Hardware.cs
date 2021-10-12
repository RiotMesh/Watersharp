using System;
using System.Diagnostics;
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

        /// <summary>
        /// Процент загруженности процессора
        /// </summary>
        public static double CPU_Load()
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
        /// Рабочая частота процессора
        /// </summary>
        public static double CPU_Freq()
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
        /// Объём памяти, занимаемый текущим приложением (Мегабайты)
        /// </summary>
        public static double MEM_App()
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
        /// Общая загруженность памяти
        /// </summary>
        public static double MEM_Load()
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
        /// Процент нагрузки главного диска системы
        /// </summary>
        public static double HDD_Load()
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
        /// Текущая активная скорость записи на диск
        /// </summary>
        public static double HDD_Write()
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
        /// Текущая активная скорость чтения с диска
        /// </summary>
        public static double HDD_Read()
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
        /// Оставшийся процент заряда батареи (для устройств с АКБ)
        /// </summary>
        public static float BATTERY_RemainingP()
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
        /// Приблизительный срок работы батареи (для устройств с АКБ)
        /// </summary>
        public static string BATTERY_Remaining()
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

    }
}
