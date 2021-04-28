using System;

namespace ConsoleApp
{
    interface IMethod//Интерфес наличия метода
    {   
        private static readonly NLog.Logger LoggerNLog = NLog.LogManager.GetCurrentClassLogger();
        void Method(); //Сам метода
    }
}