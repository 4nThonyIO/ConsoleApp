using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class CommandSet
    { 
        public Dictionary<string, IMethod> App {get; set;}

        public CommandSet()
        {
            App = new Dictionary<string, IMethod>();
            App.Add("attribute", new Attributer());
            App.Add("copy", new Copy());
            App.Add("create", new Create());
            App.Add("delete", new Delete());
            App.Add("find", new Find());
            App.Add("help", new Help());
            App.Add("move", new Move());
            App.Add("rename", new Rename());
            App.Add("show", new Show());
            App.Add("clear", new Clear());
        }
    }

}