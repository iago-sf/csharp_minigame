using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class MapWalker : Map
    {
        public MapWalker(int sizeX, int sizeY, double perc)
        {
            cells = new ICell[sizeX, sizeY];

            int width = cells.GetLength(0);
            int height = cells.GetLength(1);

            int posX = width / 2;
            int posY = height / 2;

            int floorCount = 0;

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    cells[x, y] = new CellWall();
                }
            }

            cells[posX, posY] = new CellFloor();

            while (floorCount < width * height * perc)
            {
                int direction = RNG.Nums(4);

                if (direction == 0 && posY + 2 < height)
                {
                    posY++;
                }
                else if (direction == 1 && posX + 2 < width)
                {
                    posX++;
                }
                else if (direction == 2 && posY - 1 > 0)
                {
                    posY--;
                }
                else if (direction == 3 && posX - 1 > 0)
                {
                    posX--;
                }
                else
                {
                    posX = width / 2;
                    posY = height / 2;
                }

                if (cells[posX, posY] is CellWall)
                {
                    cells[posX, posY] = new CellFloor();
                    floorCount++;
                }
            }

            base.SetExit();
        }

        public override void Display()
        {
            base.Display();
        }

        public override void PutItems(int q1, int q2)
        {
            base.PutItems(q1, q2);
        }
    }
}