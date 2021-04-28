using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoggerNLog.Info($"Program started.");
                CommandSet cmd = new CommandSet();//Создание набора команд
                Start.Menu(cmd.App);//Запуск меню
            }
            catch (Exception x)//Если есть ошибка
            {
                Console.WriteLine(x.Message);//Вывод сообщения об ошибке
            }
        }
    }
}
