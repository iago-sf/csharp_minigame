using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class CellDoorSide : ICell
    {
        private Item cellItem;
        private Container cellChest;

        public Item hasItem { get => cellItem; set => cellItem = value; }
        public Container chest { get => cellChest; set => cellChest = value; }

        public CellDoorSide()
        {
        }

        public void Display()
        {
            if (cellItem == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("?");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E");
            }
        }        
    }
}