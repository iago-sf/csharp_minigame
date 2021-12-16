using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class CellVoid : ICell
    {
        private Item cellItem;
        private Container cellChest;

        public Item hasItem { get => cellItem; set => cellItem = value; }
        public Container chest { get => cellChest; set => cellChest = value; }

        public CellVoid()
        {
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("·");
        }
    }
}