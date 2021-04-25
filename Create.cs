using System;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Create : IMethod//Создание
    {
        public void Method()
        {
            Console.WriteLine("Directory or file?");
            string path = Console.ReadLine();//Пока еще не путь
            path = path.ToLower();
            if (path == "directory" || path == "dir")//Если папка
            {
                Console.WriteLine("Enter path");
                path = Console.ReadLine();//Ввод пути
                if (!Directory.Exists(path))//Если такая папка не существует
                {
                    Directory.CreateDirectory(path);//Создание
                    Console.WriteLine("Directory created succesfully!");
                }
                else//Если существует
                {
                    Console.WriteLine("Directory already exists!");
                }
            }
            else//Если не папка
            {
                if (path == "file")//Если файл
                {
                    Console.WriteLine("Enter path");
                    path = Console.ReadLine();//Уже путь
                    if (!File.Exists(path))//Если не существует
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))//Создание потока
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))//Создание потока записи
                            {
                                sw.WriteLine("File created");//Запись
                            }
                        }
                        Console.WriteLine("File creted succesfully");//Статус операции
                    }
                    else//Если уже существует
                    {
                        Console.WriteLine("File already exists!");
                    }
                }
                else//Все остальное
                {
                    Console.WriteLine("Unsupported type");
                }
            }
        }

    }

}