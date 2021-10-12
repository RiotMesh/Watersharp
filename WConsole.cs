using System;

namespace Watersharp
{

    /// <summary>
    /// Дополнительные вохможности операций ввода-вывода
    /// </summary>
    public static class WConsole
    {

        /// <summary>
        /// Чтение строки из потока ввода
        /// </summary>
        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        /// <summary>
        /// Чтение строки из потока ввода
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        public static string ReadLine(string message)
        {
            System.Console.Write(message);
            return System.Console.ReadLine();
        }

        /// <summary>
        /// Чтение символа из потока ввода
        /// </summary>
        public static int Read()
        {
            return System.Console.Read();
        }

        /// <summary>
        /// Чтение символа из потока ввода
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        public static int Read(string message)
        {
            System.Console.Write(message);
            return System.Console.Read();
        }

        /// <summary>
        /// Чтение кода нажатой клавиши из потока ввода
        /// </summary>
        public static ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }

        /// <summary>
        /// Чтение кода нажатой клавиши из потока ввода
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        public static ConsoleKeyInfo ReadKey(string message)
        {
            System.Console.Write(message);
            return System.Console.ReadKey();
        }

    }
}
