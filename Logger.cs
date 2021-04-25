using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Logger
    {
        public List<string> Log {get; set;}

        public Logger()
        {
            Log = new List<string>();
        }
        public void ShowLog()
        {
            foreach (var i in this.Log)
            {
                Console.Write(i + '\t');
            }
        }
    }

}