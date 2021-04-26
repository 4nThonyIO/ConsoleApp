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
            FileInfo fileTarget = new FileInfo(target);//Инфо о цели

            if (choise == "file")//Если файл
            {
                FileInfo fileSource = new FileInfo(source);//Получаем инфо об файле
                if (fileSource.Exists)//Если путь существуют
                {
                    fileSource.MoveTo(fileTarget.FullName);//Перенос
                    Console.WriteLine("Transfer succeful!");
                }
                else//Если нет
                {
                    Console.WriteLine("File does not exist");
                }
            }
            if (choise == "directory" || choise == "dir")//Если папка
            {
                DirectoryInfo dirSource = new DirectoryInfo(source);//Получаем Инфо об папке
                if (dirSource.Exists)//Если путь и цель существуют
                {
                    dirSource.MoveTo(fileTarget.FullName);//Перенос
                    Console.WriteLine("Transfer succes!");
                }
                else//Если нет
                {
                    Console.WriteLine("Directory does not exist");
                }
            }

        }
    }

}