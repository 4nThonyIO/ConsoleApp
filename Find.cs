using System;
using System.IO;

namespace ConsoleApp
{
    class Find : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Enter file name");
            string name = Console.ReadLine();

            FileInfo file;

            Console.WriteLine("Enter path to directory where to search");
            string path = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(path);

            file = FileSearch(dir, name);
            if (file == null)
            {
                file = DirectorySearch(dir, name);
            }
            
            if (file == null)
            {
                Console.WriteLine("No such file");
            }
            else
                Console.WriteLine("File is here:" + file.FullName);
        }

        public FileInfo FileSearch(DirectoryInfo dir, string name)
        {
            foreach (var i in dir.GetFiles())
            {
                if (i.Name == name)
                {
                    return new FileInfo(i.FullName);
                }
            }
            return null;
        }

        public FileInfo DirectorySearch(DirectoryInfo dir, string name)
        {
            FileInfo res;
            foreach (var i in dir.GetDirectories())
            {
                res = FileSearch(i, name);
                if (res != null)
                {
                    return res;
                }
            }

            foreach (var i in dir.GetDirectories())
            {
                res = DirectorySearch(i, name);
                if (res != null)
                {
                    return res;
                }
            }

            return null;
        }
    }
}