using System.IO;
using System.Threading.Tasks;

namespace Watersharp
{

    /// <summary>
    /// Работа с файловой системой
    /// </summary>
    public class FileSystem
    {

        private static StreamReader SR;
        private static StreamWriter SW;

        /// <summary>
        /// Чтение текста из файла
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public static string Read(string Path)
        {
            string OutputText;

            SR = new StreamReader(Path);
            OutputText = SR.ReadToEnd();

            SR.Close();
            SR.Dispose();

            return OutputText;
        }

        /// <summary>
        /// Асинхронное чтение текста из файла
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public static async Task<string> ReadAsync(string Path)
        {
            string OutputText;

            SR = new StreamReader(Path);
            OutputText = await SR.ReadToEndAsync();

            SR.Close();
            SR.Dispose();

            return OutputText;
        }

        /// <summary>
        /// Запись строки в файл
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Text">Записываемый текст</param>
        public static void WriteLine(string Path, string Text)
        {
            SW = new StreamWriter(Path);
            SW.WriteLine(Text);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Асинхронная запись строки в файл
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Text">Записываемый текст</param>
        public static async Task WriteLineAsync(string Path, string Text)
        {
            SW = new StreamWriter(Path);
            await SW.WriteLineAsync(Text);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Запись символа в файл
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Value">Записываемый символ</param>
        public static void Write(string Path, char[] Value)
        {
            SW = new StreamWriter(Path);
            SW.Write(Value);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Асинхронная запись символа в файл
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Value">Записываемый символ</param>
        public static async Task WriteAsync(string Path, char[] Value)
        {
            SW = new StreamWriter(Path);
            await SW.WriteAsync(Value);

            SW.Close();
            SW.Dispose();
        }

        /// <summary>
        /// Добавление текста в конец файла
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Text">Добовляемый текст</param>
        public static void Append(string Path, string Text)
        {
            string CurrentText = Read(Path);
            Write(Path, (CurrentText + Text).ToCharArray());
        }

        /// <summary>
        /// Асинхронное добавление текста в файл
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        /// <param name="Text">Записываемый символ</param>
        public static async Task AppendAsync(string Path, string Text)
        {
            string CurrentText = await ReadAsync(Path);
            await WriteLineAsync(Path, CurrentText + Text);
        }

    }
}
