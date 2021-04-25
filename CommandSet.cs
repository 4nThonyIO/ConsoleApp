using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class CommandSet//Класс с набором кооманд
    { 
        public Dictionary<string, IMethod> App {get; set;}//Набор команд

        public CommandSet()
        {
            App = new Dictionary<string, IMethod>();//Иницыализация
            //Заполнение
            App.Add("attribute", new Attributer());//Метод аттрибут
            App.Add("copy", new Copy());//Метод копирования
            App.Add("create", new Create());//Метод создания
            App.Add("delete", new Delete());//Метод удаления
            App.Add("find", new Find());//Метод нахождения
            App.Add("help", new Help());//Метод поиска
            App.Add("move", new Move());//Метод перемещения
            App.Add("rename", new Rename());//Метод переименовывания
            App.Add("show", new Show());//Метод вывода
            App.Add("clear", new Clear());//Метод очистки екрана
        }
    }

}