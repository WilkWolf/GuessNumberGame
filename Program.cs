using System;

namespace GuessNumberGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the guess the number game!");
            do
            {
                WriteLineInColor(ConsoleColor.Green, "Menu \r\n 1. Start game \r\n 2. Exit \r\n 3. Clear window");
                try
                {
                    Console.Write(">> ");
                    string selectedOption = Console.ReadLine();
                    switch (selectedOption)
                    {
                        case "1":
                            Console.Clear();
                            Game.Start();
                            break;
                        case "2":
                            Console.Clear();
                            Exit();
                            break;
                        case "3":
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            WriteLineInColor(ConsoleColor.Red, "You have selected the wrong option, try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        private static void Exit()
        {
            WriteLineInColor(ConsoleColor.Red, "Are you sure you want to leave?");
            Console.WriteLine("y - yes, n - no");
            do
            {
                Console.Write(">>");
                string key = Console.ReadLine();
                if (key == "y")
                {
                    Environment.Exit(0);
                }
                if (key == "n")
                {
                    break;
                }
            } while (true);
        }

        public static void WriteLineInColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
