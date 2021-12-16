using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace herencias
{
    public class Bosses
    {
        public Map table;
        public List<BallForGames> balls;
        public Bosses()
        {
        }

        public void ShowBoss(int LevelName)
        {
            if (LevelName == 1)
            {
                String bossOne = "addons\\BossOne.txt";
                StreamReader bossOneR = new StreamReader(bossOne);

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(bossOneR.ReadToEnd());
            }
        }

        public void BossMinigame(int LevelName, Player PlayerForGames)
        {
            if (LevelName == 1)
            {
                Console.Clear();

                table = new MapBosses(60, 18);
                table.Display();

                balls = new List<BallForGames>();

                ConsoleKeyInfo tecla;
                int timer = 0;

                PlayerForGames.posX = table.cells.GetLength(0) / 2;
                PlayerForGames.posY = table.cells.GetLength(1) - 2;
                PlayerForGames.playerMap = table;
                PlayerForGames.Display();

                do
                {
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    tecla = Console.ReadKey(true);
                    switch (tecla.Key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.NumPad4:
                        case ConsoleKey.LeftArrow:
                            PlayerForGames.Move(-1, 0);
                            break;

                        case ConsoleKey.D:
                        case ConsoleKey.NumPad6:
                        case ConsoleKey.RightArrow:
                            PlayerForGames.Move(1, 0);
                            break;
                    }
                    PlayerForGames.Display();

                    balls.Add(new BallForGames());
                    if (balls.Count > 0)
                    {
                        for (int i = 0; i < balls.Count; i++)
                        {
                            balls[i].map = table;

                            if (balls[i].posX == 0 && balls[i].posY == 0)
                            {
                                balls[i].posX = RNG.Nums(1, table.cells.GetLength(0) - 2);
                                balls[i].posY = 1;
                                balls[i].Display();
                            }

                            if (balls[i].posY < table.cells.GetLength(1))
                            {
                                balls[i].Move(0, 1);
                                balls[i].Display();
                            }
                        }

                        for (int i = 0; i < balls.Count; i++)
                        {
                            if (balls[i].posX == PlayerForGames.posX && balls[i].posY == PlayerForGames.posY)
                            {
                                Final.death = false;
                            }
                        }
                    }

                    timer++;
                } while (timer < 200 && Final.death) ;
            }
        }
    }
}