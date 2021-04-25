using System;
using System.Text;
using System.IO;

namespace ConsoleApp
{
    class Rename : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Enter path to file for renameing");
            string path = Console.ReadLine();

            FileInfo file1 = new FileInfo(path);

            Console.WriteLine("Enter path with new name");
            path = Console.ReadLine();

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                { 
                    
                }
            }

            FileInfo file2 = new FileInfo(path);
            File.Copy(file1.Name, file2.Name);
            file1.Delete();

        }
    }

}