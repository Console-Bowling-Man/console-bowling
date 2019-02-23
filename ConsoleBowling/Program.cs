using System;
using System.IO;
using Console = System.Console;

namespace ConsoleBowling
{
    internal static class Program
    {
        private const string HighScorePath = "highScore.txt";
        private static Random Random { get; } = new Random();

        private static string IsAre(this int value) => value == 1 ? "is" : "are";
        private static string S(this int value) => value == 1 ? "" : "s";

        private static void Main()
        {
            Splash();

            int highScore;
            try
            {
                highScore = int.Parse(File.ReadAllText(HighScorePath));
                Console.WriteLine($"The high score is {highScore}");
            }
            catch (Exception)
            {
                Console.WriteLine("There is no high score currently,");
                Console.WriteLine("but don't let your guard down!");
                highScore = 0;
            }


            Console.WriteLine();
            Console.Write("Press the any key to begin...");

            Console.ReadKey();
            Console.WriteLine();
            ConsoleKeyInfo key;

            do
            {
                var score = PlayGame();
                if (score > highScore)
                {
                    Console.WriteLine("That's a new high score!");
                    File.WriteAllText(HighScorePath, score.ToString());
                }

                Console.WriteLine("Press \"A\" to play again, or any other key to exit.");
                key = Console.ReadKey();
            } while (key.Key == ConsoleKey.A);
        }

        private static void Splash()
        {
            var oldBackground = Console.BackgroundColor;
            var oldForeground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(" ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ ██╗     ███████╗");
            Console.WriteLine("██╔════╝██╔═══██╗████╗  ██║██╔════╝██╔═══██╗██║     ██╔════╝");
            Console.WriteLine("██║     ██║   ██║██╔██╗ ██║███████╗██║   ██║██║     █████╗  ");
            Console.WriteLine("██║     ██║   ██║██║╚██╗██║╚════██║██║   ██║██║     ██╔══╝  ");
            Console.WriteLine("╚██████╗╚██████╔╝██║ ╚████║███████║╚██████╔╝███████╗███████╗");
            Console.WriteLine(" ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝");
            Console.WriteLine("                                                            ");
            Console.WriteLine("     ██████╗  ██████╗ ██╗    ██╗██╗     ███████╗██████╗     ");
            Console.WriteLine("     ██╔══██╗██╔═══██╗██║    ██║██║     ██╔════╝██╔══██╗    ");
            Console.WriteLine("     ██████╔╝██║   ██║██║ █╗ ██║██║     █████╗  ██████╔╝    ");
            Console.WriteLine("     ██╔══██╗██║   ██║██║███╗██║██║     ██╔══╝  ██╔══██╗    ");
            Console.WriteLine("     ██████╔╝╚██████╔╝╚███╔███╔╝███████╗███████╗██║  ██║    ");
            Console.WriteLine("     ╚═════╝  ╚═════╝  ╚══╝╚══╝ ╚══════╝╚══════╝╚═╝  ╚═╝    ");
            Console.WriteLine("                                                            ");
            Console.WriteLine("                ██████╗  ██████╗  ██████╗                   ");
            Console.WriteLine("                ╚════██╗██╔═████╗██╔═████╗                  ");
            Console.WriteLine("                 █████╔╝██║██╔██║██║██╔██║                  ");
            Console.WriteLine("                 ╚═══██╗████╔╝██║████╔╝██║                  ");
            Console.WriteLine("                ██████╔╝╚██████╔╝╚██████╔╝                  ");
            Console.WriteLine("                ╚═════╝  ╚═════╝  ╚═════╝                   ");
            Console.BackgroundColor = oldBackground;
            Console.ForegroundColor = oldForeground;
            Console.WriteLine();
            Console.WriteLine(">>>>>         Do you have what it takes? (TM)          <<<<<");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int PlayGame()
        {
            Console.WriteLine("It's time to bowl!");
            Console.WriteLine();
            var game = new Game();
            while (game.FrameNumber.HasValue)
            {
                Console.Write($"It's frame {game.FrameNumber}, roll {game.CurrentFrame.RollNumber}. ");
                Console.WriteLine($"The score is {game.Score}.");
                Console.WriteLine($"There are {game.PinsUp} pins standing. This roll is worth {game.NextRollWorth}x.");
                Console.Write("Press any key to roll the ball. " +
                              "Press C for Cheater, L for Loser, anything else for normal...");
                var key = Console.ReadKey();
                Console.WriteLine();
                int pinsHit;
                switch (key.Key)
                {
                    case ConsoleKey.C:
                        pinsHit = game.PinsUp;
                        break;
                    case ConsoleKey.L:
                        pinsHit = 0;
                        break;
                    default:
                        pinsHit = Random.Next(game.PinsUp + 1);
                        break;
                }
                Console.Write($"You knocked down {pinsHit} pin{pinsHit.S()}. ");
                game.ApplyRoll(pinsHit);
                Console.WriteLine($"Now there {game.PinsUp.IsAre()} {game.PinsUp} pin{game.PinsUp.S()} standing.");
                Console.WriteLine();
            }

            Console.WriteLine("All done!");
            Console.WriteLine($"Your score was {game.Score}.");
            return game.Score;
        }
    }
}