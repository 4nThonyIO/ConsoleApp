using System;
using System.IO;

namespace ConsoleApp
{
    class Find : IMethod
    {
        public void Method()//Поиск
        {
            Console.WriteLine("Enter file name");
            string name = Console.ReadLine();//Имя файл который искать
            //LoggerNLog.Info($"Name of file enterd. Name = {name}");

            FileInfo file;//Результат поиска

            Console.WriteLine("Enter path to directory where to search");
            string path = Console.ReadLine();//Путь где искать
            //LoggerNLog.Info($"Path to dir enterd. Path = {path}");

            DirectoryInfo dir = new DirectoryInfo(path);//Инфо об директори

            file = FileSearch(dir, name);//Поиск по файлам
            if (file == null)//Если не нашел
            {   
                //LoggerNLog.Info($"File in dir {path} not found");
                file = DirectorySearch(dir, name);//Поиск по директоии
            }
            
            if (file == null)//Если все еще не нашли
            {
                Console.WriteLine("No such file");//Не существует
                //LoggerNLog.Info($"File not found. Name = {name}");
            }
            else//Если нашли
            {
                Console.WriteLine("File is here:" + file.FullName);//Путь к файлу
                //LoggerNLog.Info($"File found. Path = {file.FullName}");
            }
        }

        public FileInfo FileSearch(DirectoryInfo dir, string name)//Поиск среди файлов в директории 
        {
            foreach (var i in dir.GetFiles())//Получаем колекцию файлов в директории
            {
                if (i.Name == name)//Если имя сходится
                {
                    //LoggerNLog.Info($"File found. Path = {res.FullName}");
                    return new FileInfo(i.FullName);//Возвращяем инфо об файле
                }
            }
            //LoggerNLog.Info($"File in {dir.FullName} not found");
            return null;//Если не существует возвращяем пустоту
        }

        public FileInfo DirectorySearch(DirectoryInfo dir, string name)//Поиск файлов по директориям
        {
            FileInfo res;//Результат
            foreach (var i in dir.GetDirectories())//Получаем набор под-директорий
            {
                res = FileSearch(i, name);//Ищем файлы в директории
                if (res != null)//Если нашли
                {
                    //LoggerNLog.Info($"File found. Path = {res.FullName}");
                    return res;//Возвращяем результат
                }
            }
            

            foreach (var i in dir.GetDirectories())//Получаем набор директорий
            {
                res = DirectorySearch(i, name);//Запускаем повторный поиск в новой директории
                if (res != null)//Если нашли
                {
                    //LoggerNLog.Info($"File found. Path = {res.FullName}");
                    return res;//Возвращяем результат
                }
            }

            //LoggerNLog.Info($"File in dir {dir.FullName} not found");
            return null;//Если ничего не нашли - возвращяем пустоту
        }
    }
}