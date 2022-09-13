using System.IO;
using System.Threading.Tasks;

namespace Watersharp
{

    /// <summary>
    /// Basic working with File System
    /// </summary>
    public class FileSystem
    {

        private string file;

        private StreamReader SRi;
        private StreamWriter SWi;

        private static StreamReader SR;
        private static StreamWriter SW;

        public enum SizeType
        {
            Bytes, KBytes, MBytes, GBytes
        }

        public FileSystem(string filePath)
        {
            if (File.Exists(filePath))
                file = filePath;
            else
                File.Create(filePath);
        }

        #region Instance Actions

        /// <summary>
        /// Read file
        /// </summary>
        public string Read()
        {
            SRi = new StreamReader(file);
            string _cashe = SRi.ReadToEnd();

            SRi.Close();
            SRi.Dispose();
            return _cashe;
        }

        /// <summary>
        /// Read file Async
        /// </summary>
        public async Task<string> ReadAsync()
        {
            SRi = new StreamReader(file);
            string _cashe = await SRi.ReadToEndAsync();

            SRi.Close();
            SRi.Dispose();
            return _cashe;
        }

        /*====================================================================================================*/
        // WRITING

        /// <summary>
        /// Write text to file
        /// </summary>
        /// <param name="value">Writable value</param>
        public void WriteLine(string value)
        {
            SWi = new StreamWriter(file);
            SWi.WriteLine(value);
            SWi.Close();
            SWi.Dispose();
        }

        /// <summary>
        /// Write text to file Async
        /// </summary>
        /// <param name="value">Writable value</param>
        public async Task WriteLineAsync(string value)
        {
            SWi = new StreamWriter(file);
            await SWi.WriteLineAsync(value);
            SWi.Close();
            SWi.Dispose();
        }

        /// <summary>
        /// Write char to file
        /// </summary>
        /// <param name="value">Writable char</param>
        public void Write(string value)
        {
            SWi = new StreamWriter(file);
            SWi.Write(value);
            SWi.Close();
            SWi.Dispose();
        }

        /// <summary>
        /// Write char to file Async
        /// </summary>
        /// <param name="value">Writable char</param>
        public async Task WriteAsync(string value)
        {
            SWi = new StreamWriter(file);
            await SWi.WriteAsync(value);
            SWi.Close();
            SWi.Dispose();
        }

        /*====================================================================================================*/
        // APPEND

        /// <summary>
        /// Add text to end of file
        /// </summary>
        /// <param name="value">Added value</param>
        public void Append(string value)
        {
            Write(file, (Read(file) + value).ToCharArray());
        }

        /// <summary>
        /// Add text to end of file Async
        /// </summary>
        /// <param name="value">Added value</param>
        public async Task AppendAsync(string value)
        {
            await WriteAsync(file, (ReadAsync(file) + value).ToCharArray());
        }

        /// <summary>
        /// Close file and free file
        /// </summary>
        public void Close()
        {
            SRi.Close();
            SRi.Dispose();
            SWi.Close();
            SWi.Dispose();
        }

        #endregion


        #region Static Actions

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
            if (!File.Exists(path))
                File.Create(path);

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
            if (!File.Exists(path))
                File.Create(path);

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
            if (!File.Exists(path))
                File.Create(path);

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
            if (!File.Exists(path))
                File.Create(path);

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
        /// <param name="space">Size units (b, kb, mb, gb)</param>
        public static long GetFileSize(string path, SizeType space = SizeType.Bytes)
        {
            switch(space)
            {
                case SizeType.Bytes:    return new FileInfo(path).Length;
                case SizeType.KBytes:   return new FileInfo(path).Length / 1024;
                case SizeType.MBytes:   return new FileInfo(path).Length / 1024 / 1024;
                case SizeType.GBytes:   return new FileInfo(path).Length / 1024 / 1024 / 1024;
                default:                return 0;
            }
        }

        /// <summary>
        /// Get folder size in bytes
        /// </summary>
        /// <param name="path">Path to folder</param>
        /// <param name="space">Size units (b, kb, mb, gb)</param>
        public static long GetFolderSize(string path, SizeType space = SizeType.Bytes)
        {
            string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            long totalSize = 0;

            foreach(string file in allFiles)
                totalSize += GetFileSize(file);

            switch (space)
            {
                case SizeType.Bytes: return totalSize;
                case SizeType.KBytes: return totalSize / 1024;
                case SizeType.MBytes: return totalSize / 1024 / 1024;
                case SizeType.GBytes: return totalSize / 1024 / 1024 / 1024;
                default: return 0;
            }
        }

        #endregion

    }
}
