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
            
            while (menu)
            {
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



    }
}
