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
            //LoggerNLog.Info($"Choise enterd. Choise = {path}");
            if (path == "directory" || path == "dir")//Если папка
            {
                Console.WriteLine("Enter path");
                path = Console.ReadLine();//Ввод пути
                //LoggerNLog.Info($"Path to dir enterd. Path = {path}");
                if (!Directory.Exists(path))//Если такая папка не существует
                {
                    Directory.CreateDirectory(path);//Создание
                    //LoggerNLog.Info($"Creation succes. Path = {path}");
                    Console.WriteLine("Directory created succesfully!");
                }
                else//Если существует
                {
                    //LoggerNLog.Warn($"Directory in {path} already exist");
                    Console.WriteLine("Directory already exists!");
                }
            }
            else//Если не папка
            {
                if (path == "file")//Если файл
                {
                    Console.WriteLine("Enter path");
                    path = Console.ReadLine();//Уже путь
                    //LoggerNLog.Info($"Path to file enterd. Path = {path}");
                    if (!File.Exists(path))//Если не существует
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))//Создание потока
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))//Создание потока записи
                            {
                                sw.WriteLine("File created");//Запись
                            }
                        }
                        //LoggerNLog.Info($"File created succesfully. Path = {path}");
                        Console.WriteLine("File creted succesfully!");//Статус операции
                    }
                    else//Если уже существует
                    {
                        //LoggerNLog.Warn($"File already exists. Path = {path}");
                        Console.WriteLine("File already exists!");
                    }
                }
                else//Все остальное
                {
                    //LoggerNLog.Warn($"Wrong choise. Choise = {path}. Possible choise = File/Dir");
                    Console.WriteLine("Unsupported type");
                }
            }
        }

    }

}