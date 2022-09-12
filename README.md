# HOW TO USE - MANUAL
Compatable with .NET Framework 4.7.2 + (Console, WinForms, WPF)

Watersharp is a library that simplifies working with basic C# functions. Working with files, console, hardware and much more. Perfect for novice developers :)

#### 1. Download the actual library version
[https://github.com/Leviafan4ik-s-Lab/Watersharp/releases](https://github.com/Leviafan4ik-s-Lab/Watersharp/releases "https://github.com/Leviafan4ik-s-Lab/Watersharp/releases")
#### 2. Create a new project based on C# .NET Framework 4.7.2 + (4.7.2 + only for WS 1.0 +)
#### 3. Add link to library into your project
###### *Links -> Add link -> Browse -> Find Watersharp-xxx.dll -> Add*
#### 4. Perfect! Now you can fully use library!

# EXAMPLES
#### WConsole
Improve basic console input/output like in Python

```csharp
using System;
using Watersharp;

namespace WSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = WConsole.ReadLine("Input your name: ");
            Console.WriteLine("Hello, {0}!", name);

            WConsole.ReadKey("Press any key to exit ...");
        }
    }
}
```

#### Internet
This class improve you work with internet! Take a look...

```csharp
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using Watersharp;

namespace WSTest
{
    internal class DownloadTEST
    {
        private static int prevPerc = 0;
        private static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("Downloading file...");
            sw.Start();

            // call file downloading and subscribe to special events
            // for traking progress and completion
            Internet.DownloadFileAdvanced("riotmesh.ru/File.zip", "File.zip",
                OnDownloadProgressChanged, OnDownloadCompleted);

            Console.ReadKey();
        }

        private static void OnDownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download completed!");
        }

        private static void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // calculate average download speed using StopWatch
            string speed = (Convert.ToDouble(e.BytesReceived) / 1024 / 1024 / sw.Elapsed.TotalSeconds).ToString("0.0") + " Мб/с";

            // display information into console title
            if (e.ProgressPercentage > prevPerc)
            {
                Console.Title = e.ProgressPercentage.ToString() + "% -> " + speed;
                prevPerc = e.ProgressPercentage;
            }
        }
    }
}
```

#### Hardware
This class improve you work with internet! Take a look...

```csharp
using System;
using Watersharp;

namespace WSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Hardware.CPUModel()); // cpu name
            Console.WriteLine(Hardware.GPUModel()); // gpu name
            Console.WriteLine(Hardware.CPUFreq());  // cpu current frequency
            Console.WriteLine(Hardware.MEMApp());   // application RAM usage
            // and some other...

            Console.ReadKey();
        }
    }
}
```

#### FileSystem
Simple work with files (reading / writing / append)

```csharp
using System;
using Watersharp;

namespace WSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // static method use
            string fileName = WConsole.ReadLine("Input file name: ");
            Console.WriteLine(FileSystem.Read(fileName));

            // instance
            FileSystem file = new FileSystem("test.txt");
            Console.WriteLine(file.ReadAsync());

            // and some other mehods inside FileSystem class!
        }
    }
}
```

#### Config
Simple work with configuration files (.ini)

```csharp
using System;
using Watersharp;

namespace WSTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // static method use
            Config.Set("config.ini", "version", "1.0");
            Config.Set("config.ini", "year", 2022);
            Console.WriteLine(Config.Get("config.ini", "version"));
            Console.WriteLine(Config.GetInt("config.ini", "year"));

            // instance
            Config cfg = new Config("config.ini");
            cfg.Set("build", "#05");
            cfg.Set("size_mb", 0.23);
            Console.WriteLine(cfg.GetFloat("size_mb"));

            // and some other mehods inside Config class!
        }
    }
}
```
