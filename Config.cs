using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Watersharp
{
    /// <summary>
    /// Working with .ini cofiguration files
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

        /// <summary>
        /// Change path to .ini file
        /// </summary>
        /// <param name="newPath">.ini file path</param>
        public static void SetIniPath(string newPath)
        {
            Path = newPath;
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
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
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
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
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
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
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
                StringBuilder PreValue = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", PreValue, 255, Path);
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
        public void Set(string key, string value, string section = "main")
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        /// <summary>
        /// Write param value
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="value">Param value</param>
        /// <param name="section">Param section (default - main)</param>
        public void Set(string key, int value, string section = "main")
        {
            WritePrivateProfileString(section, key, value.ToString(), Path);
        }

        /// <summary>
        /// Write param value
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="value">Param value</param>
        /// <param name="section">Param section (default - main)</param>
        public void Set(string key, double value, string section = "main")
        {
            WritePrivateProfileString(section, key, value.ToString(), Path);
        }

        /// <summary>
        /// Write param value
        /// </summary>
        /// <param name="key">Param name</param>
        /// <param name="value">Param value</param>
        /// <param name="section">Param section (default - main)</param>
        public bool KeyExists(string key, string section = "main")
        {
            return Get(key, section).Length > 0;
        }

    }
}
