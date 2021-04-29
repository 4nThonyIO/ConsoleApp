using System;
using System.Collections.Generic;

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
                //LoggerNLog.Info($"Key entered. Key = {key}");
                log.Log.Add(key);//Добавление в лог
                //LoggerNLog.Info($"Key added to history. Key = {key}");
                key = key.ToLower();//Превод к эдиному регистру

                if (cmd.ContainsKey(key))//Если данная команда есть в наборе
                {
                    cmd[key].Method();//Вызов команды
                    //LoggerNLog.Info($"Method {key} worked");
                }
                else
                {
                    if (key == "history")//Если нужен вывод лога
                    {
                        log.ShowLog();//вывод
                        //LoggerNLog.Info($"Method history worked");
                    }
                    else
                    {
                        if (key == "exit")//Если выход
                        {
                            //LoggerNLog.Info($"Program shut down");
                            Console.WriteLine("GoodBye!");//Прощяние
                            menu = false;//Остановка цыкла меню
                        }
                        else//если совершена очепятка
                        {
                            //LoggerNLog.Warn($"Wrong command. Comand = {key}");
                            Console.WriteLine("No such command!");
                        }
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
    }
}
