using System;
using System.IO;

namespace ConsoleApp
{
    class Show : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Enter directory path");
            string path = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                Console.WriteLine("SubDirectories: ");
                foreach (var i in di.GetDirectories())
                    Console.WriteLine(i.Name);

                Console.WriteLine("Files:");
                foreach (var i in di.GetFiles())
                    Console.WriteLine(i.Name);
            }
            else
            {
                Console.WriteLine("No such directory");
            }
            Console.WriteLine();
            Console.WriteLine("Press any button to continue");
            Console.ReadKey();
        }

    }

}