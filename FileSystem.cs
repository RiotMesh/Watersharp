using System.IO;
using System.Threading.Tasks;

namespace Watersharp
{

    /// <summary>
    /// Basic working with File System
    /// </summary>
    public class FileSystem
    {

        private static StreamReader SR;
        private static StreamWriter SW;

        /*====================================================================================================*/
        // READING

        /// <summary>
        /// Read file
        /// </summary>
        /// <param name="path">Path to file</param>
        public static string Read(string path)
        {
            string OutputText;

            SR = new StreamReader(path);
            OutputText = SR.ReadToEnd();

            SR.Close();
            SR.Dispose();

            return OutputText;
        }

        /// <summary>
        /// Read file Async
        /// </summary>
        /// <param name="path">Path to file</param>
        public static async Task<string> ReadAsync(string path)
        {
            string OutputText;

            SR = new StreamReader(path);
            OutputText = await SR.ReadToEndAsync();

            SR.Close();
            SR.Dispose();

            return OutputText;
        }

        /*====================================================================================================*/
        // WRITING

        /// <summary>
        /// Write text to file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="value">Writable value</param>
        public static void WriteLine(string path, string value)
        {
            SW = new StreamWriter(path);
            SW.WriteLine(value);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Write text to file Async
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="value">Writable value</param>
        public static async Task WriteLineAsync(string path, string value)
        {
            SW = new StreamWriter(path);
            await SW.WriteLineAsync(value);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Write char to file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="value">Записываемый символ</param>
        public static void Write(string path, char[] value)
        {
            SW = new StreamWriter(path);
            SW.Write(value);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Write char to file Async
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="value">Записываемый символ</param>
        public static async Task WriteAsync(string path, char[] value)
        {
            SW = new StreamWriter(path);
            await SW.WriteAsync(value);

            SW.Close();
            SW.Dispose();
        }

        /*====================================================================================================*/
        // APPEND

        /// <summary>
        /// Add text to the end of the file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="value">Added value</param>
        public static void Append(string path, string value)
        {
            string CurrentText = Read(path);
            Write(path, (CurrentText + value).ToCharArray());
        }

        /// <summary>
        /// Add text to the end of the file Async
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="value">Added value</param>
        public static async Task AppendAsync(string path, string value)
        {
            string CurrentText = await ReadAsync(path);
            await WriteLineAsync(path, CurrentText + value);
        }

        /*====================================================================================================*/
        // FILE INFO

        /// <summary>
        /// Get file size in bytes
        /// </summary>
        /// <param name="path">Path to file</param>
        public static long FileSize(string path)
        {
            return new FileInfo(path).Length;
        }

    }
}
