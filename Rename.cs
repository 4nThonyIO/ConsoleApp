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
            if (File.Exists(path))//если файл сущевствует
            {
                FileInfo file1 = new FileInfo(path);//Инфо об исходном файле

                Console.WriteLine("Enter path with new name");
                path = Console.ReadLine();//Путь и новое имя

                FileInfo file2 = new FileInfo(path);//Получение инфо об новом файле
                File.CopyTo(file2.FullName, true);//Копирование начального файла в новый
                file1.Delete();//Удаление изначального файла
                Console.WriteLine("Operation succesfull!");

            }
            else
            {
                Console.WriteLine("Such file does not exist!");
            }
        }
    }

}