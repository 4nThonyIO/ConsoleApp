using System;
using System.IO;

namespace ConsoleApp
{
    class Show : IMethod
    {
        public void Method()//Вывод
        {
            Console.WriteLine("Enter directory path");
            string path = Console.ReadLine();//Ввод пути к папке
            //LoggerNLog.Info($"Path to file enterd. Path = {path}");
            DirectoryInfo di = new DirectoryInfo(path);//Получение инфо об папке
            if (di.Exists)//Если существует
            {
                Console.WriteLine("SubDirectories: ");
                //Вывод поддиректорий
                foreach (var i in di.GetDirectories())
                    Console.WriteLine(i.Name);

                //LoggerNLog.Info($"SubDirs shown");

                Console.WriteLine("Files:");
                //Вывод файлов
                foreach (var i in di.GetFiles())
                    Console.WriteLine(i.Name);

                //LoggerNLog.Info($"Files shown");
            }
            else//Если не существует 
            {
                //LoggerNLog.Warn($"File does not exist. Path = {path}");
                Console.WriteLine("No such directory");
            }
            Console.WriteLine();
        }

    }

}