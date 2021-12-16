using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class MapRuins : Map
    {
        public MapRuins(int sizeX, int sizeY)
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

            for (int x = 4; x < cells.GetLength(0) - 5; x++)
            {
                for (int y = 4; y < cells.GetLength(1) - 5; y++)
                {
                    int prMark = RNG.Nums(10);

                    if (prMark >= 9)
                    {
                        cells[x, y] = new CellSky();
                    }
                }
            }

            for (int x = 4; x < cells.GetLength(0) - 5; x++)
            {
                for (int y = 4; y < cells.GetLength(1) - 5; y++)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        if (x + i < width && x - i > 1 && y + i < height && y - i > 1)
                        {
                            if (cells[x + i, y] is CellSky)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    cells[x + j, y] = new CellBridge();
                                }
                            }
                            if (cells[x, y + i] is CellSky)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    cells[x, y + j] = new CellBridge();
                                }
                            }
                            if (cells[x - i, y] is CellSky)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    cells[x - j, y] = new CellBridge();
                                }
                            }
                            if (cells[x, y - i] is CellSky)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    cells[x, y - j] = new CellBridge();
                                }
                            }
                        }
                    }
                    if (cells[x, y] is CellSky)
                    {
                        for (int x0 = x - 3; x0 < x + 4; x0++)
                        {
                            for (int y0 = y - 3; y0 < y + 4; y0++)
                            {
                                if (!(cells[x0, y0] is CellBridge))
                                {
                                    cells[x0, y0] = new CellWall();
                                }
                            }
                        }
                        for (int x0 = x - 2; x0 < x + 3; x0++)
                        {
                            for (int y0 = y - 2; y0 < y + 3; y0++)
                            {
                                cells[x0, y0] = new CellFloor();
                            }
                        }
                    }
                }
            }
            SmoothMap();

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

        public void SmoothMap()
        {
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    if (cells[x, y] is CellWall)
                    {
                        if (x - 1 >= 0 && x + 1 < cells.GetLength(0)
                        && y - 1 >= 0 && y + 1 < cells.GetLength(1))
                        {
                            int i = 0;
                            if (!(cells[x, y - 1] is CellWall)) i++;
                            if (!(cells[x + 1, y - 1] is CellWall)) i++;
                            if (!(cells[x + 1, y] is CellWall)) i++;
                            if (!(cells[x + 1, y + 1] is CellWall)) i++;
                            if (!(cells[x, y + 1] is CellWall)) i++;
                            if (!(cells[x - 1, y + 1] is CellWall)) i++;
                            if (!(cells[x - 1, y] is CellWall)) i++;
                            if (!(cells[x - 1, y - 1] is CellWall)) i++;

                            if (i>=4 && i<=5)
                            {
                                cells[x, y] = new CellBridge();
                            }
                        }
                    }
                }
            }
        }
    }
}