using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class BallForGames
    {
        public int posX, posY;
        public Map map;
        public BallForGames()
        {
            posX = 0;
            posY = 0;
        }

        public void Move(int movX, int movY)
        {
            int nextX = posX + movX;
            int nextY = posY + movY;

            if (nextX >= 1 && nextX < map.cells.GetLength(0) - 1
            && nextY >= 1 && nextY <= map.cells.GetLength(1) - 1)
            {
                Console.SetCursorPosition(posX, posY);
                map.cells[posX, posY].Display();

                posX += movX;
                posY += movY;
            }
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posX, posY);
            Console.Write("o");
        }
    }
}