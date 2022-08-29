using System;
using System.Linq;
using System.Text;

namespace Watersharp
{

    /// <summary>
    /// Something useful features
    /// </summary>
    public class Features
    {

        private static readonly Encoding encoding = Encoding.Default;

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="str">String value</param>
        /// <returns>Byte array of string</returns>
        public static byte[] Encrypt(string str)
        {
            return encoding.GetBytes(str);
        }

        /// <summary>
        /// Convert byte array to string
        /// </summary>
        /// <param name="data">Byte array</param>
        /// <returns>String value</returns>
        public static string Decrypt(byte[] data)
        {
            return encoding.GetString(data);
        }

    }
}
