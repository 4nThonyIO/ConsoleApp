using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Start
    {
        public static void Menu(Dictionary<string, IMethod> cmd)
        {
            cmd["help"].Method();
            Console.WriteLine();

            Logger log = new Logger();

            string key;
            bool menu = true;
            
            while (menu)
            {
                key = Console.ReadLine();
                log.Log.Add(key);
                key.ToLower();

                if (cmd.ContainsKey(key))
                {
                    cmd[key].Method();
                }
                else
                {   
                    if(key == "history")
                    {
                        log.ShowLog();
                    }
                    if (key == "exit")
                    {
                        Console.WriteLine("GoodBye!");
                        menu = false;
                    }
                    else
                        Console.WriteLine("No such command!");
                }


            }

        }

    }
}
