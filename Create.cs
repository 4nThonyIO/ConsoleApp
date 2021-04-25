using System;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Create : IMethod
    {
        public void Method()
        {
            Console.WriteLine("Directory or file?");
            string path = Console.ReadLine();//Not an actual path
            path.ToLower();
            if (path == "directory" || path == "dir")
            {
                Console.WriteLine("Enter path");
                path = Console.ReadLine();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("Directory created succesfully!");
                }
                else
                {
                    Console.WriteLine("Directory already exists!");
                }
            }
            else
            {
                if (path == "file")
                {
                    Console.WriteLine("Enter path");
                    path = Console.ReadLine();//Not an actual path
                    if (!File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                            {
                                sw.WriteLine("File created");
                            }
                        }
                        Console.WriteLine("File creted succesfully");
                    }
                    else
                    {
                        Console.WriteLine("File already exists!");
                    }
                }
                else
                {
                    Console.WriteLine("Unsupported type");
                }
            }
        }

    }

}