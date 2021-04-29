using System;
using System.IO;

namespace ConsoleApp
{
    class Attributer : IMethod
    {
        public void Method()//Показ аттрибутов
        {
            Console.WriteLine("Enter file path");
            string path = Console.ReadLine();//Ввести путь
            //LoggerNLog.Info($"Path to file enterd. Path = {path}");

            FileInfo file = new FileInfo(path);//Инфо об файле
            if (file.Exists)//Если существует файл
            {
                //LoggerNLog.Info($"Attributes of {path} shown");
                Console.WriteLine("Name is " + file.Name);//вывод имени
                Console.WriteLine("Fullname is " + file.FullName);//вывод пути
                Console.WriteLine("Size = " + file.Length + " bytes");//вывод размера
                Console.WriteLine("Directory where file is " + file.DirectoryName);//вывод папки в которой находится
                Console.WriteLine("Was created " + file.CreationTime);//вывод даты создания
            }
            else//Если нет
            {
                Console.WriteLine("This file does not exist");
                //LoggerNLog.Warn($"{path} does not exist");
            }
        }

    }

}