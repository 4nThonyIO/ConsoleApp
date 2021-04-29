using System;
using System.IO;

namespace ConsoleApp
{
    class Move : IMethod
    {
        public void Method()//Перенос
        {
            Console.WriteLine("Do you want to move file or directory?");
            string choise = Console.ReadLine().ToLower();//Выбор типа файла для переноса
            //LoggerNLog.Info($"Choise made. Choise = {choise}");

            Console.WriteLine("Enter path who to move");
            string source = Console.ReadLine();//Ввод пути источника 
            //LoggerNLog.Info($"Source path enterd. Path = {source}");

            Console.WriteLine("Enter directory where to move");
            string target = Console.ReadLine();//Ввод пути цели
            FileInfo fileTarget = new FileInfo(target);//Инфо о цели
            //LoggerNLog.Info($"Path to target file enterd. Path = {target}");

            if (choise == "file")//Если файл
            {
                FileInfo fileSource = new FileInfo(source);//Получаем инфо об файле
                if (fileSource.Exists)//Если путь существуют
                {
                    fileSource.MoveTo(fileTarget.FullName);//Перенос
                    Console.WriteLine("Transfer succeful!");
                    //LoggerNLog.Info($"Move succes. Path = {fileTarget.FullName}");
                }
                else//Если нет
                {
                    //LoggerNLog.Warn($"Path to file does not exist. Path = {source}");
                    Console.WriteLine("File does not exist");
                }
            }
            else
            {
                if (choise == "directory" || choise == "dir")//Если папка
                {
                    DirectoryInfo dirSource = new DirectoryInfo(source);//Получаем Инфо об папке
                    if (dirSource.Exists)//Если путь и цель существуют
                    {
                        dirSource.MoveTo(fileTarget.FullName);//Перенос
                        Console.WriteLine("Transfer succes!");
                        //LoggerNLog.Info($"Move succesfull. Path = {fileTarget.FullName}");
                    }
                    else//Если нет
                    {
                        //LoggerNLog.Warn($"Path to file does not exist. Path = {source}");
                        Console.WriteLine("Directory does not exist");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong type!");
                    //LoggerNLog.Warn($"Wrong choise. Choise = {choise}. Possible choise = File/Dir");
                }
            }
        }
    }

}