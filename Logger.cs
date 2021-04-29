using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Logger
    {
        public List<string> Log {get; set;}//Набор введенных команд

        public Logger()//Конструктор по-умолчанию
        {
            Log = new List<string>();
            //LoggerNLog.Info($"History list created");
        }
        public void ShowLog()//Вывод лога
        {
            foreach (var i in this.Log)
            {
                Console.Write(i + '\t');
            }
            //LoggerNLog.Info($"History showed");
        }
    }

}