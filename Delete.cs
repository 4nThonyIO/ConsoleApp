using System;
using System.IO;

namespace ConsoleApp
{
    class Delete : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Enter path to file which to delete");
            string path = Console.ReadLine();
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            else
            {
                Console.WriteLine("No file to delete");
            }
        }
    }
}