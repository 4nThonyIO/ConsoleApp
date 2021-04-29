using System;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Copy : IMethod
    {
        public void Method()//Копирование
        {
            Console.WriteLine("Directory or file?");
            string path = Console.ReadLine();//Пока что еще не путь 
            path = path.ToLower();//изменение регистра
            //LoggerNLog.Info($"Choise enterd. Choise = {path}");
            if (path == "directory" || path == "dir")//Если папка
            {
                Console.WriteLine("Enter source path");
                path = Console.ReadLine();//Теперь уже путь к папке
                //LoggerNLog.Info($"Path to dir enterd. Path = {path}");
                if (Directory.Exists(path))//Если папка существует
                {
                    DirectoryInfo sourceDir = new DirectoryInfo(path);//Получаем инфо об папке

                    Console.WriteLine("Enter target path");
                    string target = Console.ReadLine();//Путь куда копировать
                    //LoggerNLog.Info($"Path to target dir enterd. Path = {target}");
                    DirectoryInfo targetDir = new DirectoryInfo(target);//Информация о папке в которую копировать

                    if (sourceDir.FullName.ToLower() == targetDir.FullName.ToLower())//Если имена сходятся
                    {
                        //LoggerNLog.Warn($"Same directory path. Path = {path}");
                        Console.WriteLine("Same directory name error");
                        return;
                    }

                    CopyAll(sourceDir, targetDir);//Метод копирования всей папки
                    Console.WriteLine("Copy succes!");
                    //LoggerNLog.Info($"Copy succes. Result in {targetDir.FullName}");
                }
                else//Если папка не существует
                {
                    //LoggerNLog.Warn($"Dir in {path} does not exists");
                    Console.WriteLine("Directory do not exists!");
                }
            }
            else//Если не папка
            {
                if (path == "file")//Если файл
                {
                    Console.WriteLine("Enter source path");
                    path = Console.ReadLine();//Путь к файлу
                    //LoggerNLog.Info($"Path to file enterd. Path = {path}");
                    if (File.Exists(path))//Если файл существует
                    {
                        FileInfo sourceInfo = new FileInfo(path);//Получение инфо об файле

                        Console.WriteLine("Enter target directory path");
                        string target = Console.ReadLine();//Путь куда копировать
                        //LoggerNLog.Info($"Path to target directory enterd. Path = {target}");
                        DirectoryInfo targetInfo = new DirectoryInfo(target);//Инфо об папке в которую копируем

                        sourceInfo.CopyTo(targetInfo.FullName, true);//Метод копирования
                        //LoggerNLog.Info($"Copy succes. Result in {targetInfo.FullName}");
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        //LoggerNLog.Warn($"File in {path} does not exist");
                        Console.WriteLine("File do not exists!");
                    }
                }
                else//Если что то другое
                {
                    //LoggerNLog.Warn($"Wrong type. Choise = {path}. Possible = File/Directory");
                    Console.WriteLine("Unsupported type");
                }
            }
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)//Метод копирования папки
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())//Если имена сходятся 
            {
                //LoggerNLog.Warn($"Same name error. Name1 = {source.FullName} Name2 = {target.FullName}");
                return;
            }

            if (Directory.Exists(target.FullName) == false)//Если не существует - создаем
            {
                Directory.CreateDirectory(target.FullName);//Создание папки
                //LoggerNLog.Info($"Directory did not exist. Directory in {target.FullName} creted");
            }

            foreach (FileInfo file in source.GetFiles())//Копирование файлов
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, file.Name + " complete!");//Выводим информацию о копировании 
                file.CopyTo(Path.Combine(target.ToString(), file.Name), true);//Копирование
                //LoggerNLog.Info($"File {file.Name} Copy succesful");
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())//Копирование под-директорий
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);//Создаем под-директорию
                CopyAll(diSourceSubDir, nextTargetSubDir);//Рекурсия копирования
                //LoggerNLog.Info($"Directory {target.FullName} Copy succes");
            }
        }
    }

}