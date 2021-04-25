using System;
using System.IO;

namespace ConsoleApp
{
    class Move : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Do you want to move file or directory?");
            string choise = Console.ReadLine();

            Console.WriteLine("Enter path who to move");
            string source = Console.ReadLine();

            Console.WriteLine("Enter directory where to move");
            string target = Console.ReadLine();
            DirectoryInfo dirTarget = new DirectoryInfo(target);

            if (choise == "file" || choise == "File")
            {
                FileInfo fileSource = new FileInfo(source);
                if (fileSource.Exists && dirTarget.Exists)
                {
                    fileSource.MoveTo(dirTarget.FullName);
                }
                else
                {
                    Console.WriteLine("File or directory does not exist");
                }
            }
            if (choise == "Directory" || choise == "directory" || choise == "dir")
            {
                DirectoryInfo dirSource = new DirectoryInfo(source);
                if (dirSource.Exists && dirTarget.Exists)
                {
                    dirSource.MoveTo(dirTarget.FullName);
                }
                else
                {
                    Console.WriteLine("File or directory does not exist");
                }
            }

        }
    }

}