using System;
using System.IO;

namespace ConsoleApp
{
    class Delete : IMethod
    {
        public void Method()//Удаление
        {
            Console.WriteLine("Enter path to file which to delete");
            string path = Console.ReadLine();//Путь от кудого удалить
            //LoggerNLog.Info($"Path to file enterd. Path = {path}");
            FileInfo file = new FileInfo(path);//Инфо об файле
            if (file.Exists)//Если файл существует
            {
                file.Delete();//Удаление
                //LoggerNLog.Info($"Delte of file succesful. It was in {path}");
                Console.WriteLine("Delete succesful!");
            }
            else//Если файл не существует
            {
                //LoggerNLog.Info($"File do not exist. Path = {path}");
                Console.WriteLine("No file to delete");
            }
        }
    }
}