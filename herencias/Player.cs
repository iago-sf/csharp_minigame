using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Player
    {
        public int posX, posY;
        public int health;
        public Map playerMap;
        public Container backpack;
        public Container lunchBox;

        public Player()
        {
            backpack = new Container(5);
            lunchBox = new Container(10);
            health = 50;
        }

        public void Move(int movX, int movY)
        {
            int nextX = posX + movX;
            int nextY = posY + movY;

            if (nextX >= 0 && nextX < playerMap.cells.GetLength(0)
            && nextY >= 0 && nextY < playerMap.cells.GetLength(1)
            && !(playerMap.cells[nextX, nextY] is CellWall))
            {
                Console.SetCursorPosition(posX, posY);
                playerMap.cells[posX, posY].Display();

                posX += movX;
                posY += movY;
            }

            if (playerMap.cells[posX, posY].hasItem is Weapon || playerMap.cells[posX, posY].hasItem is Utilities)
            {
                Console.SetCursorPosition(79, 1);
                if (backpack.AddItem(playerMap.cells[posX, posY].hasItem))
                {
                    playerMap.cells[posX, posY].hasItem = null;
                    Interface();
                }
            }
            if (playerMap.cells[posX, posY].hasItem is Berry)
            {
                Console.SetCursorPosition(74, 8);
                if (lunchBox.AddItem(playerMap.cells[posX, posY].hasItem))
                {
                    playerMap.cells[posX, posY].hasItem = null;
                    Interface();
                }
            }
        }

        public bool IsEntry => playerMap.cells[posX, posY] is CellDoorEntry;
        public bool IsExit => playerMap.cells[posX, posY] is CellDoorExit;
        public bool IsSide => playerMap.cells[posX, posY] is CellDoorSide;

        public void DropItems()
        {
            if (playerMap.cells[posX, posY].hasItem == null
                && backpack.Content.Count > 0
                && playerMap.cells[posX, posY] is CellFloor)
            {
                int i = 0;
                do
                {
                    Item dropitem = backpack.Content[0];

                    playerMap.cells[posX, posY].hasItem = dropitem;

                    i++;
                } while (playerMap.cells[posX, posY].hasItem == null || i < backpack.Content.Count);
                backpack.Content.RemoveAt(0);
                Console.SetCursorPosition(79, 1);
                Console.WriteLine("            ");
            }
            Interface();
        }
        public void Healing()
        {
            if (lunchBox.Content.Count > 0 && health < 100)
            {
                health += 5;
                lunchBox.Content[0].Action();
                lunchBox.Content.RemoveAt(0);
                Console.SetCursorPosition(74, 8);
                Console.WriteLine("            ");
            }
            Interface();
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posX, posY);
            Console.Write("@");
        }

        public void MiniDisplay(int movX, int movY)
        {
            
        }

        public void InitialDisplay()
        {
            posX = 1;
            posY = 1;

            while (!(playerMap.cells[posX, posY] is CellFloor))
            {
                posX++;

                if (posX > playerMap.cells.GetLongLength(0) - 1)
                {
                    posX = 0;
                    posY++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posX, posY);
            Console.Write("@");
        }

        public void Interface()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(63, 1);
            Console.WriteLine("Backpack items:");
            Console.SetCursorPosition(63, 8);
            Console.WriteLine("Lunch box:");

            Console.SetCursorPosition(63, 11);
            Console.WriteLine("            ");
            Console.SetCursorPosition(63, 11);
            Console.WriteLine("Tu vida:" + health);

            for (int i = 0; i < backpack.Content.Capacity - 2; i++)
            {
                Console.SetCursorPosition(63, 2 + i);
                Console.WriteLine("            ");
            }
            for (int i = 0; i < backpack.Content.Count; i++)
            {
                Console.SetCursorPosition(63, 2 + i);
                Console.WriteLine((i + 1) + " - " + backpack.Content[i].name);
            }
            for (int i = 0; i < lunchBox.Content.Count; i++)
            {
                Console.SetCursorPosition(63, 9);
                Console.WriteLine(lunchBox.Content.Count + " berries");
            }
            if (lunchBox.Content.Count == 0)
            {
                Console.SetCursorPosition(63, 9);
                Console.WriteLine("0 berries");
            }
        }
    }
}