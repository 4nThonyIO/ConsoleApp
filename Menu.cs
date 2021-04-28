using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Start
    {
        public static void Menu(Dictionary<string, IMethod> cmd)//Меню
        {
            Info();//Вывод информации об командах
            Console.WriteLine();

            Logger log = new Logger();//Создание лога

            string key;
            bool menu = true;//Переменная статуса меню
            string username = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);//Получениеимени пользователя 
            Copyrights();//Вывод легальной информации 

            while (menu)
            {
                Console.Write(username + ">");//Вывод главной директории
                key = Console.ReadLine();//Ввод команды
                log.Log.Add(key);//Добавление в лог
                key = key.ToLower();//Превод к эдиному регистру

                if (cmd.ContainsKey(key))//Если данная команда есть в наборе
                {
                    cmd[key].Method();//Вызов команды
                }
                else
                {
                    if (key == "history")//Если нужен вывод лога
                    {
                        log.ShowLog();//вывод
                    }
                    else
                    {
                        if (key == "exit")//Если выход
                        {
                            Console.WriteLine("GoodBye!");//Прощяние
                            menu = false;//Остановка цыкла меню
                        }
                        else//если совершена очепятка
                            Console.WriteLine("No such command!");
                    }
                }


            }

        }

        public static void Info()
        {
            Console.WriteLine("Show - Отображение всех файлов и папок в текущей директории\n" +
                "Move - Перемещение файлов и папок\n" +
                "Copy - Копирование файлов и папок\n" +
                "Clear - Очистка экрана\n" +
                "Attributes - Просмотр атрибутов указанного файла\n" +
                "Rename - Переименование файлов\n" +
                "Create - Создание\n" +
                "Delete - Удаление\n" +
                "Find - Поиск файлов\n" +
                "History - Истории введенных команд\n" +
                "Exit - Выход");
        }

        public static void Copyrights()//Вывод юридической информации
        {
            Random rnd = new Random();//Генерация версии виндовс
            Console.WriteLine("Microsoft Windows [Version 10.0." + rnd.Next(1000, 99999)+"."+rnd.Next(100, 999)+"]");
            Console.WriteLine("(c) Корпорация Майкрософт (Microsoft Corporation). Все права защищены.");//Вывод инфо
            Console.WriteLine();
        }

        public static string GetUser()//Получение имени пользователя
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\Users");//Получаем инфо об директории с пользователями
            foreach(var subdir in dir.GetDirectories())//Ищем пользователя с именем
            {   
                if(subdir.Name != "Public")//Если имя не public
                {
                    return subdir.FullName;//Возвращяем путь
                }
            }

            return null;
        }
    }
}
