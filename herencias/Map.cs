using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public abstract class Map
    {
        public ICell[,] cells;
        public List<Enemy> enemies;
        public int n;

        public Map()
        {
            enemies = new List<Enemy>();
        }

        public void SetEntry()
        {
            int x1 = 1;
            int y1 = 1;

            while (!(cells[x1, y1] is CellFloor))
            {
                x1++;

                if (x1 > cells.GetLength(0) - 1)
                {
                    y1++;
                    x1 = 1;
                }
            }

            cells[x1, y1] = new CellDoorEntry();
        }
        public void SetExit()
        { 
            int x1 = cells.GetLength(0) - 1;
            int y1 = cells.GetLength(1) - 1;

            while (!(cells[x1, y1] is CellFloor))
            {
                x1--;

                if (x1 < 1)
                {
                    y1--;
                    x1 = cells.GetLength(0) - 1;
                }
            }

            cells[x1, y1] = new CellDoorExit();
        }
        public virtual void SetSide()
        {
            int x1;
            int y1;
            do
            {
                x1 = RNG.Nums(cells.GetLength(0));
                y1 = RNG.Nums(cells.GetLength(1));
            } while (cells[x1, y1].hasItem != null || !(cells[x1, y1] is CellFloor) || x1 > 10 && y1 > 6);

            cells[x1, y1] = new CellDoorSide();
        }

        public virtual void Display()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i, j);

                    cells[i, j].Display();
                }
            }
        }

        public virtual void PutItems(int quantityBerries, int quantityWeapons)
        {
            int x, y;
            n = RNG.Nums(100);

            for (int i = 0; i < quantityBerries; i++)
            {

                do
                {
                    x = RNG.Nums(cells.GetLength(0));
                    y = RNG.Nums(cells.GetLength(1));
                } while (cells[x, y].hasItem != null || !(cells[x, y] is CellFloor));

                cells[x, y] = new CellBush
                {
                    hasItem = new Berry()
                };
            }

            for (int i = 0; i < quantityWeapons / 2; i++)
            {
                do
                {
                    x = RNG.Nums(cells.GetLength(0));
                    y = RNG.Nums(cells.GetLength(1));
                } while (cells[x, y].hasItem != null || !(cells[x, y] is CellFloor));

                cells[x, y].hasItem = new Knife();
            }
        }

        public virtual void PutEnemies(int i, Map map) 
        {
            for (int j = 0; j < 5 + i; j++)
            {
                int x, y;

                enemies.Add(new Yuan(0, 0));

                do
                {
                    x = RNG.Nums(5, cells.GetLength(0) - 5);
                    y = RNG.Nums(5, cells.GetLength(1) - 5);
                } while (cells[x, y].hasItem != null || !(cells[x, y] is CellFloor));

                enemies[j].enemyMap = map;
                enemies[j].posX = x;
                enemies[j].posY = y;

                enemies[j].Display();
            }
        }
    }
}