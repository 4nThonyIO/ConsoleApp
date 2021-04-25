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
            if (path == "directory" || path == "dir")//Если папка
            {
                Console.WriteLine("Enter source path");
                path = Console.ReadLine();//Теперь уже путь к папке
                if (Directory.Exists(path))//Если папка существует
                {
                    DirectoryInfo sourceDir = new DirectoryInfo(path);//Получаем инфо об папке

                    Console.WriteLine("Enter target path");
                    string target = Console.ReadLine();//Путь куда копировать
                    DirectoryInfo targetDir = new DirectoryInfo(target);//Информация о папке в которую копировать

                    if (sourceDir.FullName.ToLower() == targetDir.FullName.ToLower())//Если имена сходятся
                    {
                        Console.WriteLine("Same directory name error");
                        return;
                    }

                    CopyAll(sourceDir, targetDir);//Метод копирования всей папки

                }
                else//Если папка не существует
                {
                    Console.WriteLine("Directory do not exists!");
                }
            }
            else//Если не папка
            {
                if (path == "file")//Если файл
                {
                    Console.WriteLine("Enter source path");
                    path = Console.ReadLine();//Путь к файлу
                    if (File.Exists(path))//Если файл существует
                    {
                        FileInfo sourceInfo = new FileInfo(path);//Получение инфо об файле

                        Console.WriteLine("Enter target directory path");
                        string target = Console.ReadLine();//Путь куда копировать
                        DirectoryInfo targetInfo = new DirectoryInfo(target);//Инфо об папке в которую копируем

                        sourceInfo.CopyTo(targetInfo.FullName, true);//Метод копирования
                    }
                    else
                    {
                        Console.WriteLine("File do not exists!");
                    }
                }
                else//Если что то другое
                {
                    Console.WriteLine("Unsupported type");
                }
            }
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)//Метод копирования папки
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())//Если имена сходятся 
            {
                return;
            }

            if (Directory.Exists(target.FullName) == false)//Если не существует - создаем
            {
                Directory.CreateDirectory(target.FullName);//Создание папки
            }

            foreach (FileInfo fi in source.GetFiles())//Копирование файлов
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);//Выводим информацию о копировании 
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);//Копирование
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())//Копирование под-директорий
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);//Создаем под-директорию
                CopyAll(diSourceSubDir, nextTargetSubDir);//Рекурсия копирования
            }
        }
    }

}