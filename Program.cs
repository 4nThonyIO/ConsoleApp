using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandSet cmd = new CommandSet();//Создание набора команд
            Start.Menu(cmd.App);//Запуск меню
        }
    }
}
