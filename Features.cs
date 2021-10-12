using System;
using System.Linq;

namespace Watersharp
{

    /// <summary>
    /// База некоторых полезных функций
    /// </summary>
    public class Features
    {
        /*public static void PrintText(string text, int interval = 10)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i].ToString());
                Thread.Sleep(interval);
            }
        }*/

        /// <summary>
        /// Конвертирование строки в массив байтов
        /// </summary>
        /// <param name="str">Требуемая строка</param>
        public static byte[] StringToByteArray(string str)
        {
            return str.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Convert.ToByte(s, 16))
                .ToArray();
        }

    }
}
