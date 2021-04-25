using System;

namespace ConsoleApp
{
    class Help: IMethod
    {  
        public void Method()
        {
            Console.WriteLine("Enter specific command or general for general description");
            string key = Console.ReadLine();
            key.ToLower();

            if (key == "create")
            {
                Console.WriteLine("Create - Создание файла или директории");
                return;
            }

            if (key == "delete" || key == "del")
            {
                Console.WriteLine("Delete - Удаление файла");
                return;
            }

            if (key == "showall")
            {
                Console.WriteLine("ShowAll - Отображение всех файлов и папок в текущей директории");
                return;
            }

            if (key == "move")
            {
                Console.WriteLine("Move - Перемещение файлов(и возможно папок)");
                return;
            }

            if (key == "copy")
            {
                Console.WriteLine("Copy - Копирование файлов и папок");
                return;
            }

            if (key == "clear" || key == "clean")
            {
                Console.WriteLine("Clear - Очистка экрана");
                return;
            }

            if (key == "attributes")
            {
                Console.WriteLine("Attributes - Просмотр базовых атрибутов файла");
                return;
            }

            if (key == "rename")
            {
                Console.WriteLine("Rename - Переименование файлов");
                return;
            }

            if (key == "find")
            {
                Console.WriteLine("Find - Поиск файлов");
                return;
            }

            if (key == "history")
            {
                Console.WriteLine("History - Истории введенных команд");
                return;
            }

            if (key == "exit")
            {
                Console.WriteLine("Exit - Выход");
                return;
            }

            if (key == "general")
            {
                Console.WriteLine("ShowAll - Отображение всех файлов и папок в текущей директории\n" +
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
                return;
            }

            if (key == "help")
            {
                Console.WriteLine("Help - список команд и их функции");
                return;
            }

            Console.WriteLine("No such command!");
        }

    }

}