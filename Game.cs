using System;
using System.Collections.Generic;

namespace GuessNumberGame
{
    public static class Game
    {
        public static void Start()
        {
            List<UserNumberModel> userGuessList = new();
            int randomNumber = GetRandomNumber();
            int userNumber = -1;
            int counter = 0;

            Program.WriteLineInColor(ConsoleColor.Red, "If you want to give up then select: -2");
            do
            {
                try
                {
                    userNumber = EnterNumber();
                    counter++;
                    string information = GetInformationAboutQuessNumber(randomNumber, userNumber);

                    userGuessList.Add(new UserNumberModel()
                    {
                        NumberOfGuess = counter,
                        Information = information,
                        Value = userNumber
                    });

                }
                catch (Exception e)
                {
                    Program.WriteLineInColor(ConsoleColor.Red, e.Message);
                }

            } while ((randomNumber != userNumber) && (userNumber != -2));

            ShowInformationAboutCurrentGame(userGuessList);
        }

        private static void ShowInformationAboutCurrentGame(List<UserNumberModel> userGuessList)
        {
            Program.WriteLineInColor(ConsoleColor.Blue, "Information about game: ");
            Program.WriteLineInColor(ConsoleColor.Blue, "| Guess number | value | information |");
            Console.WriteLine("------------------------------------");
            foreach (var quess in userGuessList)
            {
                Console.WriteLine($"| {quess.NumberOfGuess} | {quess.Value} | {quess.Information} ");
            }
        }

        private static string GetInformationAboutQuessNumber(int randomNumber, int userNumber)
        {
            if (userNumber > 100 || userNumber < 1)
            {
                if (userNumber == -2)
                {
                    Program.WriteLineInColor(ConsoleColor.Red, "Game over.");
                    Program.WriteLineInColor(ConsoleColor.DarkMagenta, $"The number was: {randomNumber}");
                    return $"Give up. Number was {randomNumber}";
                }
                else
                {
                    Program.WriteLineInColor(ConsoleColor.Blue, "Your number should be from 1 to 100.");
                    return "Number out of range.";
                }
            }
            else if (randomNumber == userNumber)
            {
                Program.WriteLineInColor(ConsoleColor.Green, "Congratulations, you found the number.");
                return "User found number.";
            }
            else if (randomNumber > userNumber)
            {
                Program.WriteLineInColor(ConsoleColor.Blue, "Your number is lower.");
                return "User number is lower";
            }
            else
            {
                Program.WriteLineInColor(ConsoleColor.Blue, "Your number is higher.");
                return "User number is higher.";
            }
        }

        private static int EnterNumber()
        {
            int userNumber;
            Console.WriteLine("Please enter a number");
            Console.Write(">> ");
            userNumber = Convert.ToInt32(Console.ReadLine().Trim());
            return userNumber;
        }

        private static int GetRandomNumber()
        {
            Random random = new();
            int randomNumber = random.Next(1, 100);
            return randomNumber;
        }
    }
}
