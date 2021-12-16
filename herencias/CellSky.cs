using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class CellSky : ICell
    {
        private Item cellItem;
        private Container cellChest;

        public Item hasItem { get => cellItem; set => cellItem = value; }
        public Container chest { get => cellChest; set => cellChest = value; }

        public CellSky()
        {
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("~");
        }
    }
}