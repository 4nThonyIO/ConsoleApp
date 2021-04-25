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
            FileInfo file = new FileInfo(path);//Инфо об файле
            if (file.Exists)//Если файл существует
            {
                file.Delete();//Удаление
                Console.WriteLine("Delete succesful!");
            }
            else//Если файл не существует
            {
                Console.WriteLine("No file to delete");
            }
        }
    }
}