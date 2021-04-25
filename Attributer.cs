using System;
using System.IO;

namespace ConsoleApp
{
    class Attributer : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Enter file path");
            string path = Console.ReadLine();

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                Console.WriteLine("Name is " + file.Name);
                Console.WriteLine("Fullname is " + file.FullName);
                Console.WriteLine("Size = " + file.Length + " bytes");
                Console.WriteLine("Directory where file is " + file.DirectoryName);
                Console.WriteLine("Was created " + file.CreationTime);
            }
            else
                Console.WriteLine("This file does not exist");
        }

    }

}