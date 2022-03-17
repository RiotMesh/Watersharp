using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Watersharp
{
    /// <summary>
    /// Work with .ini cofiguration files
    /// </summary>
    public class Config
    {

        private static string Path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder Value, int Size, string FilePath);

        /*====================================================================================================*/

        public Config(string iniPath)
        {
            Path = new FileInfo(iniPath).FullName.ToString();
        }

        /*====================================================================================================*/
        // GET VALUE

        /// <summary>
        /// Read param as STRING by name
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as STRING</returns>
        public string Get(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, Path);
                return PreValue.ToString();
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file");
            }
        }

        /// <summary>
        /// Read INI without creating an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as STRING</returns>
        public static string Get(string iniPath, string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, Path);
                return PreValue.ToString();
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file");
            }
        }

        /// <summary>
        /// Read param as INT by name
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as INT</returns>
        public int GetInt(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, Path);
                return Convert.ToInt32(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file as int");
            }
        }

        /// <summary>
        /// Read param as INT by name without creating an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as INT</returns>
        public static int GetInt(string iniPath, string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, iniPath);
                return Convert.ToInt32(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file as int");
            }
        }

        /// <summary>
        /// Read param as DOUBLE by name
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as DOUBLE</returns>
        public double GetDouble(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, Path);
                return Convert.ToDouble(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file as double");
            }
        }

        /// <summary>
        /// Read param as DOUBLE by name without creating an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as DOUBLE</returns>
        public static double GetDouble(string iniPath, string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, iniPath);
                return Convert.ToDouble(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file as double");
            }
        }

        /// <summary>
        /// Read param as FLOAT by name
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as FLOAT</returns>
        public float GetFloat(string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, Path);
                return float.Parse(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file as float");
            }
        }

        /// <summary>
        /// Read param as FLOAT by name without creating an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        /// <returns>Param value as FLOAT</returns>
        public static float GetFloat(string iniPath, string key, string section = "main")
        {
            try
            {
                StringBuilder PreValue = new StringBuilder(1023);
                GetPrivateProfileString(section, key, "", PreValue, 1023, iniPath);
                return float.Parse(PreValue.ToString());
            }
            catch
            {
                throw new Exception("Watersharp-Config: Error reading .ini file as float");
            }
        }

        /*====================================================================================================*/
        // SET VALUE

        /// <summary>
        /// Write param value
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="value">Param value</param>
        /// <param name="section">Param section (default - main)</param>
        public void Set(string key, object value, string section = "main")
        {
            WritePrivateProfileString(section, key, value.ToString(), Path);
        }

        /// <summary>
        /// Write param value without creating an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        /// <param name="value">Param value</param>
        /// <param name="section">Param section (default - main)</param>
        public static void Set(string iniPath, string key, object value, string section = "main")
        {
            WritePrivateProfileString(section, key, value.ToString(), iniPath);
        }

        /// <summary>
        /// Check key in INI file
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        public bool KeyExists(string key, string section = "main")
        {
            return Get(key, section).Length > 0;
        }

        /// <summary>
        /// Check key in INI file without creation an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        /// <param name="section">Param section (default - main)</param>
        public static bool KeyExists(string iniPath, string key, string section = "main")
        {
            return Get(iniPath, key, section).Length > 0;
        }

        /// <summary>
        /// Get INI file path
        /// </summary>
        public string GetIniPath()
        {
            return Path;
        }

        /// <summary>
        /// Remove exist parametr from INI by key
        /// </summary>
        /// <param name="key">Param name</param>
        public void RemoveByKey(string key)
        {
            try
            {
                var inifile = File.ReadAllLines(Path, Encoding.Default).Where(s => !s.Contains(key));
                File.WriteAllLines(Path, inifile, Encoding.Default);
            }
            catch (Exception e)
            {
                throw new Exception("Watersharp-Config: Can`t remove key (" + key + ") in " + Path + "\n" + e.Message);
            }
        }

        /// <summary>
        /// Remove exist parametr from INI by key without creation an instance
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="key">Param name</param>
        public static void RemoveByKey(string iniPath, string key)
        {
            try
            {
                var inifile = File.ReadAllLines(iniPath, Encoding.Default).Where(s => !s.Contains(key));
                File.WriteAllLines(iniPath, inifile, Encoding.Default);
            }
            catch (Exception e)
            {
                throw new Exception("Watersharp-Config: Can`t remove key (" + key + ") in " + iniPath + "\n" + e.Message);
            }
        }

        /// <summary>
        /// Remove exist parametr from INI by value
        /// </summary>
        /// <param name="value">Param value</param>
        public void RemoveByValue(string value)
        {
            try
            {
                var inifile = File.ReadAllLines(Path, Encoding.Default).Where(s => !s.Contains(value));
                File.WriteAllLines(Path, inifile, Encoding.Default);
            }
            catch (Exception e)
            {
                throw new Exception("Watersharp-Config: Can`t remove key by value (" + value + ") in " + Path + "\n" + e.Message);
            }
        }

        /// <summary>
        /// Remove exist parametr from INI by value
        /// </summary>
        /// <param name="iniPath">INI file path</param>
        /// <param name="value">Param value</param>
        public static void RemoveByValue(string iniPath, string value)
        {
            try
            {
                var inifile = File.ReadAllLines(iniPath, Encoding.Default).Where(s => !s.Contains(value));
                File.WriteAllLines(iniPath, inifile, Encoding.Default);
            }
            catch (Exception e)
            {
                throw new Exception("Watersharp-Config: Can`t remove key by value (" + value + ") in " + iniPath + "\n" + e.Message);
            }
        }

    }
}
