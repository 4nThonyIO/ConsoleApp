using System;
using System.IO;

namespace ConsoleApp
{
    class Rename : IMethod
    {
        public void Method()//Переименование
        {
            Console.WriteLine("Enter path to file for renameing");
            string path = Console.ReadLine();//Путь к файлк что бы переименовать
            LoggerNLog.Info($"Path to file enterd. Path = {path}");
            if (File.Exists(path))//если файл сущевствует
            {
                FileInfo file1 = new FileInfo(path);//Инфо об исходном файле

                Console.WriteLine("Enter path with new name");
                path = Console.ReadLine();//Путь и новое имя
                LoggerNLog.Info($"New name entered. Path = {path}");

                FileInfo file2 = new FileInfo(path);//Получение инфо об новом файле
                file1.CopyTo(file2.FullName, true);//Копирование начального файла в новый
                LoggerNLog.Info($"File Copy succes.");
                file1.Delete();//Удаление изначального файла
                LoggerNLog.Info($"Previous file Delete succes");
                Console.WriteLine("Operation succesfull!");
                LoggerNLog.Info($"Rename succes. Path = {file2.FullName}");
            }
            else
            {
                LoggerNLog.Warn($"File does not exists. Path = {path}");
                Console.WriteLine("Such file does not exist!");
            }
        }
    }

}