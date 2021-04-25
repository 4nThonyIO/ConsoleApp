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
            DirectoryInfo di = new DirectoryInfo(path);//Получение инфо об папке
            if (di.Exists)//Если существует
            {
                Console.WriteLine("SubDirectories: ");
                //Вывод поддиректорий
                foreach (var i in di.GetDirectories())
                    Console.WriteLine(i.Name);

                Console.WriteLine("Files:");
                //Вывод файлов
                foreach (var i in di.GetFiles())
                    Console.WriteLine(i.Name);
            }
            else//Если не существует 
            {
                Console.WriteLine("No such directory");
            }
            Console.WriteLine();
        }

    }

}