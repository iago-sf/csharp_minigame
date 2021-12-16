using System;
using System.Collections.Generic;
using System.Text;

namespace herencias
{
    public class Game
    {
        Player player;
        
        Map[] map;
        Bosses boss;

        public Game()
        {
            MapCreation();

            player = new Player()
            {
                playerMap = map[0]
            };
            player.InitialDisplay();
            player.Interface();

            map[0].Display();
        }

        private void MapCreation()
        {
            map = new Map[10];

            map[0] = new MapWalker(60, 18, 0.4);
            map[0].PutItems(50, 10);

            for (int i = 1; i < map.Length; i++)
            {
                map[i] = new MapRoom(60, 18);
                map[i].PutItems(5, 1);
                map[i].PutEnemies(i, map[i]);
            }

            for (int i = 3; i < map.Length; i += 3)
            {
                map[i] = new MapRuins(60, 18);
                map[i].PutItems(5, 1);
                map[i - 1].SetSide();
            }
        }

        public void Screens()
        {
            // 1
            if (player.playerMap == map[0] && player.IsExit
            || player.playerMap == map[2] && player.IsEntry)
            {
                player.playerMap = map[1];
                map[1].Display();
                player.InitialDisplay();
            }
            // 2
            if (player.playerMap == map[1] && player.IsExit
            || player.playerMap == map[4] && player.IsEntry)
            {
                player.playerMap = map[2];
                map[2].Display();
                player.InitialDisplay();
            }
            // 3
            if (player.playerMap == map[2] && player.IsSide)
            {
                player.playerMap = map[3];
                map[3].Display();
                player.InitialDisplay();
            }
            // 4
            if (player.playerMap == map[2] && player.IsExit
            || player.playerMap == map[3] && player.IsExit
            || player.playerMap == map[5] && player.IsEntry)
            {
                player.playerMap = map[4];
                map[4].Display();
                player.InitialDisplay();
            }
            // 5
            if (player.playerMap == map[4] && player.IsExit
            || player.playerMap == map[7] && player.IsEntry)
            {
                player.playerMap = map[5];
                map[5].Display();
                player.InitialDisplay();
            }
            // 6
            if (player.playerMap == map[5] && player.IsSide)
            {
                player.playerMap = map[6];
                map[6].Display();
                player.InitialDisplay();
            }
            // 7
            if (player.playerMap == map[5] && player.IsExit
            || player.playerMap == map[6] && player.IsExit
            || player.playerMap == map[8] && player.IsEntry)
            {
                player.playerMap = map[7];
                map[7].Display();
                player.InitialDisplay();
            }
            // 8
            if (player.playerMap == map[7] && player.IsExit)
            {
                player.playerMap = map[8];
                map[8].Display();
                player.InitialDisplay();
            }
            // 9
            if (player.playerMap == map[8] && player.IsSide)
            {
                player.playerMap = map[9];
                map[9].Display();
                player.InitialDisplay();
            }
            if (player.playerMap == map[8] && player.IsExit)
            {
                Final.end = false;
            }
        }

        public void Controls()
        {
            ConsoleKeyInfo tecla;
            do
            {
                player.Display();

                while (Console.KeyAvailable) Console.ReadKey(true);

                tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.UpArrow:
                        player.Move(0, -1);
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                        player.Move(0, 1);
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.LeftArrow:
                        player.Move(-1, 0);
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.RightArrow:
                        player.Move(1, 0);
                        break;

                    case ConsoleKey.X:
                    case ConsoleKey.NumPad5:
                        player.DropItems();
                        break;

                    case ConsoleKey.C:
                    case ConsoleKey.NumPad0:
                        player.Healing();
                        break;
                }
            } while (player.IsExit == false && player.IsEntry == false && player.IsSide == false && Final.death);

            if (player.playerMap == map[3])
            {
                BossSelect(3);
            } 
        }

        private void BossSelect(int i)
        {
            Console.Clear();

            ConsoleKeyInfo tecla1;

            boss = new Bosses();
            boss.ShowBoss(i/3);

            player.playerMap = boss.table;

            tecla1 = Console.ReadKey(true);
            
            boss.BossMinigame(i/3, player);

            Console.Clear();
            player.playerMap = map[i+1];
            map[i+1].Display();
            player.InitialDisplay();
        }
    }
}