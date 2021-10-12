using System;

namespace Watersharp
{

    /// <summary>
    /// Additional features for IO system
    /// </summary>
    public static class WConsole
    {

        /// <summary>
        /// Basic ReadLine
        /// </summary>
        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }

        /// <summary>
        /// Custom ReadLine with message
        /// </summary>
        /// <param name="message">Message for user</param>
        public static string ReadLine(string message)
        {
            System.Console.Write(message);
            return System.Console.ReadLine();
        }

        /// <summary>
        /// Basic Read
        /// </summary>
        public static int Read()
        {
            return System.Console.Read();
        }

        /// <summary>
        /// Custom Read with message
        /// </summary>
        /// <param name="message">Message for user</param>
        public static int Read(string message)
        {
            System.Console.Write(message);
            return System.Console.Read();
        }

        /// <summary>
        /// Basic ReadKey
        /// </summary>
        public static ConsoleKeyInfo ReadKey()
        {
            return System.Console.ReadKey();
        }

        /// <summary>
        /// Custom ReadKey with message
        /// </summary>
        /// <param name="message">Message for user</param>
        public static ConsoleKeyInfo ReadKey(string message)
        {
            System.Console.Write(message);
            return System.Console.ReadKey();
        }

    }
}
