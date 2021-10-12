using System;
using System.Linq;

namespace Watersharp
{

    /// <summary>
    /// Something useful features
    /// </summary>
    public class Features
    {

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="str">String value</param>
        /// <returns>Byte array of string</returns>
        public static byte[] StringToByteArray(string str)
        {
            return str.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Convert.ToByte(s, 16))
                .ToArray();
        }

    }
}
