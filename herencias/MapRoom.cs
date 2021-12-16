using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class MapRoom : Map
    {
        public MapRoom(int sizeX, int sizeY)
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

            for (int x = 3; x < cells.GetLength(0) - 2; x += 4)
            {
                for (int y = 3; y < cells.GetLength(1) - 2; y += 4)
                {
                    int prMark = RNG.Nums(100);

                    if (prMark >= 40)
                    {
                        cells[x, y] = new CellSky();
                    }
                }
            }

            for (int x = 3; x < cells.GetLength(0) - 2; x += 1)
            {
                for (int y = 3; y < cells.GetLength(1) - 2; y += 1)
                {
                    if (cells[x, y] is CellSky)
                    {
                        for (int i = x; i < width - 1; i++)
                        {
                            if (x + i < width - 1 && cells[x + i, y] is CellSky)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    if (!(cells[x + j, y] is CellSky))
                                    {
                                        cells[x + j, y] = new CellBridge();
                                    }
                                }
                            }
                        }

                        for (int i = y; i < height - 1; i++)
                        {
                            if (y + i < height - 1 && cells[x, y + i] is CellSky)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    if (!(cells[x, y + j] is CellSky))
                                    {
                                        cells[x, y + j] = new CellBridge();
                                    }
                                }
                            }
                        }

                        for (int i = 1; i < x; i++)
                        {
                            if (x - i > 1 && cells[x - i, y] is CellSky)
                            {
                                for (int j = i; j < x; j++)
                                {
                                    if (!(cells[x - j, y] is CellSky))
                                    {
                                        cells[x - j, y] = new CellBridge();
                                    }
                                }
                            }
                        }

                        for (int i = 1; i < y; i++)
                        {
                            if (y - i > 1 && cells[x, y - i] is CellSky)
                            {
                                for (int j = i; j < y; j++)
                                {
                                    if (!(cells[x, y - j] is CellSky))
                                    {
                                        cells[x, y - j] = new CellBridge();
                                    }
                                }
                            }
                        }
                    }

                    if (cells[x, y] is CellSky)
                    {
                        for (int x0 = x - 2; x0 < x + 3; x0++)
                        {
                            for (int y0 = y - 2; y0 < y + 3; y0++)
                            {
                                if (!(cells[x0, y0] is CellBridge))
                                {
                                    cells[x0, y0] = new CellWall();
                                }
                            }
                        }

                        for (int x0 = x - 1; x0 < x + 2; x0++)
                        {
                            for (int y0 = y - 1; y0 < y + 2; y0++)
                            {
                                cells[x0, y0] = new CellFloor();
                            }
                        }
                    }
                }
            }

            base.SetEntry();
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

        public override void SetSide()
        {
            base.SetSide();
        }

        public override void PutEnemies(int i, Map map)
        {
            base.PutEnemies(i, map);
        }
    }
}