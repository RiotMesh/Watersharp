# HOW TO USE - MANUAL (EU)
Watersharp is a library that simplifies working with basic C# functions. Working with files, console, hardware and much more. Perfect for novice developers :)

#### 1. Download the actual library version
[https://github.com/Leviafan4ik-s-Lab/Watersharp/releases](https://github.com/Leviafan4ik-s-Lab/Watersharp/releases "https://github.com/Leviafan4ik-s-Lab/Watersharp/releases")
#### 1. Create a new project based on C# .NET Framework 4.5 +
#### 2. Add link to library into your project
###### *Links -> Add link -> Browse -> Find Watersharp.dll -> Add*
#### 3. Perfect! Now you can fully use library!


# Инструкция по подключению (RU)
Watersharp - это бибилиотека, упрощающая работу с базовыми функциями C#. Работа с файлами, консоль, железо и многое другое. Отлично подойдёт для начинающих разработчиков :)

#### 1. Скачать актуальную версию по ссылке ниже
[https://github.com/Leviafan4ik-s-Lab/Watersharp/releases](https://github.com/Leviafan4ik-s-Lab/Watersharp/releases "https://github.com/Leviafan4ik-s-Lab/Watersharp/releases")
#### 1. Создать проект на основе C# .NET Framework 4.5 +
#### 2. Добавить ссылку на библиотеку в свой проект
###### *Ссылки -> Добавить ссылку -> Обзор -> Найти Watersharp.dll -> Добавить*
#### 3. Отлично! Теперь можно использовать библиотеку!


------------
*work example*

*пример использования*

```csharp
using System;
using Watersharp;

namespace Exampler
{
    class Program
    {
        static void Main(string[] args)
        {

            FileSystem.WriteLine(@"D:\MyFile.txt", "Hello World!");             //пример записи в файл

            FileSystem.Append(@"D:\MyFile.txt", "Again hello world!");          //дополнение текста в файле без перезаписи

            FileSystem.Read(@"D:\MyFile.txt");                                  //пример чтения из файла    

            /*--------------------------------------------*/

            Console.WriteLine(Hardware.CPU_Load());
        }
    }
}
```


*P.S - In Visual Studio (or another C# editors) you just need write a class name, and editor show you more information :)*

*P.S - В Visual Stuio (или другом редакторе) достаточно написать имя класса и редактор подскажет вам что за что отвечает*
