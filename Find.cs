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

            FileInfo file;//Результат поиска

            Console.WriteLine("Enter path to directory where to search");
            string path = Console.ReadLine();//Путь где искать

            DirectoryInfo dir = new DirectoryInfo(path);//Инфо об директори

            file = FileSearch(dir, name);//Поиск по файлам
            if (file == null)//Если не нашел
            {
                file = DirectorySearch(dir, name);//Поиск по директоии
            }
            
            if (file == null)//Если все еще не нашли
            {
                Console.WriteLine("No such file");//Не существует
            }
            else//Если нашли
                Console.WriteLine("File is here:" + file.FullName);//Путь к файлу
        }

        public FileInfo FileSearch(DirectoryInfo dir, string name)//Поиск среди файлов в директории 
        {
            foreach (var i in dir.GetFiles())//Получаем колекцию файлов в директории
            {
                if (i.Name == name)//Если имя сходится
                {
                    return new FileInfo(i.FullName);//Возвращяем инфо об файле
                }
            }
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
                    return res;//Возвращяем результат
                }
            }

            foreach (var i in dir.GetDirectories())//Получаем набор директорий
            {
                res = DirectorySearch(i, name);//Запускаем повторный поиск в новой директории
                if (res != null)//Если нашли
                {
                    return res;//Возвращяем результат
                }
            }

            return null;//Если ничего не нашли - возвращяем пустоту
        }
    }
}