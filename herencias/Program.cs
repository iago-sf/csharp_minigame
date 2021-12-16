using System;
using System.IO;

namespace herencias
{
    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            String initium = "addons\\iniDisplay.txt";
            
            do
            {
                Final.death = true;
                Final.end = true;

                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 0);
                    StreamReader initiumR = new StreamReader(initium);
                    Console.WriteLine(initiumR.ReadToEnd());

                    do
                    {
                        key = Console.ReadKey(true);
                    } while (key.Key != ConsoleKey.S && key.Key != ConsoleKey.I);

                    if (key.Key == ConsoleKey.I)
                    {
                        Console.Clear();
                        String instructions = "addons\\instruct.txt";
                        StreamReader instructionsR = new StreamReader(instructions);

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine(instructionsR.ReadToEnd());

                        key = Console.ReadKey(true);
                    }

                    if (key.Key == ConsoleKey.S)
                    {
                        Game game = new Game();

                        do
                        {
                            game.Controls();
                            game.Screens();
                        }
                        while (Final.death && Final.end);
                    }

                    if (Final.death == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Moriste");
                    }
                    if (Final.end == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Ganaste");
                    }

                    Console.SetCursorPosition(1, 25);
                    Console.WriteLine("Press R to restart");
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.R);

            } while (key.Key != ConsoleKey.Escape);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Jueguito cerrado");
        }
    }
}
