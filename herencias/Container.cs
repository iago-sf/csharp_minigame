using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Container
    {
        private int size;

        public List<Item> Content;

        public Container(int quantity)
        {
            this.size = quantity;

            Content = new List<Item>();
        }

        public void ShowBI()
        {
            int i = 0;
            foreach (Item item in Content)
            {
                Console.SetCursorPosition(62, 1);

                if (item is Berry)
                {
                    Console.Write((i + 1) + "- Berry");
                }
                if (item is Knife)
                {
                    Console.Write((i + 1) + "- Knife");
                }
                if (item is Stick)
                {
                    Console.Write((i + 1) + "- Stick");
                }
            }
        }

        public bool AddItem(Item item)
        {
            if (Content.Count < size)
            {
                Content.Add(item);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Its full");
                return false;
            }
        }
    }
}