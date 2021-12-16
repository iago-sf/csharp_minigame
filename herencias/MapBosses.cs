using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class MapBosses : Map
    {
        public MapBosses(int sizeX, int sizeY)
        {
            cells = new ICell[sizeX, sizeY];

            int width = cells.GetLength(0);
            int height = cells.GetLength(1);

            int posX = width / 2;
            int posY = height / 2;

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    cells[x, y] = new CellWall();
                }
            }

            for (int x = 1; x < cells.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < cells.GetLength(1) - 1; y++)
                {
                    cells[x, y] = new CellSky();
                }
            }

            for (int x = 1; x < cells.GetLength(0) - 1; x++)
            {
                cells[x, cells.GetLength(1) - 2] = new CellFloor();
            }
        }
    }
}