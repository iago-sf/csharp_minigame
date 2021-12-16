using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public abstract class Item
    {
        public String name;

        public Item() {
        }

        public virtual void Action() {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 19);
        }
    }
}