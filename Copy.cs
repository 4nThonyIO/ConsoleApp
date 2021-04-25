using System;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Copy : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Directory or file?");
            string path = Console.ReadLine();//Now it is not an actual path
            path.ToLower();
            if (path == "directory" || path == "dir")
            {
                Console.WriteLine("Enter source path");
                path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    DirectoryInfo sourceDir = new DirectoryInfo(path);

                    Console.WriteLine("Enter target path");
                    string target = Console.ReadLine();
                    DirectoryInfo targetDir = new DirectoryInfo(target);

                    if (sourceDir.FullName.ToLower() == targetDir.FullName.ToLower())
                    {
                        Console.WriteLine("Same directory error");
                        return;
                    }

                    CopyAll(sourceDir, targetDir);

                }
                else
                {
                    Console.WriteLine("Directory do not exists!");
                }
            }
            else
            {
                if (path == "file")
                {
                    Console.WriteLine("Enter source path");
                    path = Console.ReadLine();
                    if (File.Exists(path))
                    {
                        FileInfo sourceInfo = new FileInfo(path);

                        Console.WriteLine("Enter target directory path");
                        string target = Console.ReadLine();
                        DirectoryInfo targetInfo = new DirectoryInfo(target);

                        sourceInfo.CopyTo(targetInfo.FullName, true);
                    }
                    else
                    {
                        Console.WriteLine("File do not exists!");
                    }
                }
                else
                {
                    Console.WriteLine("Unsupported type");
                }
            }
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }

}