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

            Console.WriteLine("Enter path who to move");
            string source = Console.ReadLine();//Ввод пути источника 

            Console.WriteLine("Enter directory where to move");
            string target = Console.ReadLine();//Ввод пути цели
            DirectoryInfo dirTarget = new DirectoryInfo(target);//Инфо о цели

            if (choise == "file")//Если файл
            {
                FileInfo fileSource = new FileInfo(source);//Получаем инфо об файле
                if (fileSource.Exists && dirTarget.Exists)//Если и путь и источник существуют
                {
                    fileSource.MoveTo(dirTarget.FullName);//Перенос
                }
                else//Если нет
                {
                    Console.WriteLine("File does not exist");
                }
            }
            if (choise == "directory" || choise == "dir")//Если папка
            {
                DirectoryInfo dirSource = new DirectoryInfo(source);//Получаем Инфо об папке
                if (dirSource.Exists && dirTarget.Exists)//Если путь и цель существуют
                {
                    dirSource.MoveTo(dirTarget.FullName);//Перенос
                }
                else//Если нет
                {
                    Console.WriteLine("Directory does not exist");
                }
            }

        }
    }

}