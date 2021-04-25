using System;
using System.Text;
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

                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))//Создание потока 
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))//Создание потока записи
                    {
                        
                    }
                }

                FileInfo file2 = new FileInfo(path);//Получение инфо об новом файле
                File.Copy(file1.FullName, file2.FullName);//Копирование начального файла в новый
                file1.Delete();//Удаление изначального файла
            }
        }
    }

}