using System;

namespace ConsoleApp
{
    class Clear : IMethod
    {
        public void Method()//Очистка
        {
            //LoggerNLog.Info($"Console cleared");
            Console.Clear();//Очистка консоли
        }
    }

}