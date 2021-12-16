using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public abstract class Enemy
    {
        public int posX, posY;
        public int health;
        public Map enemyMap;

        public Enemy()
        { 
        }

        public virtual void Move(int movX, int movY)
        {
            int nextX = posX + movX;
            int nextY = posY + movY;

            if (nextX >= 0 && nextY >= 0
                && nextX < enemyMap.cells.GetLength(0) && nextY < enemyMap.cells.GetLength(1)
                && !(enemyMap.cells[nextX, nextY] is CellWall))
            {
                Console.SetCursorPosition(posX, posY);
                enemyMap.cells[posX, posY].Display();

                posX += movX;
                posY += movY;
            }
        }

        public virtual void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(posX, posY);
        }
    }
}

// ¥ £ $