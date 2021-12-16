using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class CellFloor : ICell
    {
        private Item cellItem;
        private Container cellChest;

        public Item hasItem { get => cellItem; set => cellItem = value; }
        public Container chest { get => cellChest; set => cellChest = value; }

        public CellFloor()
        {
        }

        public void Display()
        {
            if (cellItem == null)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("X");
            }
        }
    }
}