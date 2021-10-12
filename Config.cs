using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Watersharp
{
    /// <summary>
    /// Класс для работы с файлами конфигураций (.INI)
    /// </summary>
    public class Config
    {

        private static string Path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder Value, int Size, string FilePath);

        public Config(string IniPath)
        {
            Path = new FileInfo(IniPath).FullName.ToString();
        }

        /// <summary>
        /// Изменение пути к рабочему ini файлу
        /// </summary>
        /// <param name="NewPath">Путь к файлу</param>
        public static void SetIniPath(string NewPath)
        {
            Path = NewPath;
        }

        /// <summary>
        /// Чтение значения параметра по имени (строка)
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public string GetString(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
                return PreValue.ToString();
            }
            catch
            {
                throw new Exception("Ошибка чтения параметра. Проверьте правильность передаваемых данных");
            }
        }

        /// <summary>
        /// Чтение значения параметра по имени (целое число)
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public int GetInt(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
                return Convert.ToInt32(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Ошибка чтения параметра. Проверьте правильность передаваемых данных");
            }
        }

        /// <summary>
        /// Чтение значения параметра по имени (число двойной точности)
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public double GetDouble(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
                return Convert.ToDouble(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Ошибка чтения параметра. Проверьте правильность передаваемых данных");
            }
        }

        /// <summary>
        /// Запись значения параметра по имени (строка)
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="value">Значение</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public void Set(string key, string value, string section = "main")
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        /// <summary>
        /// Запись значения параметра по имени (целое число)
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="value">Значение</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public void Set(string key, int value, string section = "main")
        {
            WritePrivateProfileString(section, key, value.ToString(), Path);
        }

        /// <summary>
        /// Запись значения параметра по имени (число двойной точности)
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="value">Значение</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public void Set(string key, double value, string section = "main")
        {
            WritePrivateProfileString(section, key, value.ToString(), Path);
        }

        /// <summary>
        /// Проверка существования параметра с указанным именем
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - main)</param>
        public bool KeyExists(string key, string section = "main")
        {
            return GetString(key, section).Length > 0;
        }

    }
}
