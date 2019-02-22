using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Console = System.Console;

namespace ConsoleBowling
{
    internal static class Program
    {
        private const string HighScorePath = "highScore.txt";
        private static Random Random { get; set; } = new Random();

        private static string IsAre(this int value) => value == 1 ? "is" : "are";
        private static string S(this int value) => value == 1 ? "" : "s";

        private static void Main()
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

            Console.WriteLine("It's time to bowl!");
            Console.WriteLine();

            var game = new Game();
            while (game.FrameNumber.HasValue)
            {
                Console.WriteLine($"It's frame {game.FrameNumber}, roll {game.CurrentFrame.RollNumber}.");
                Console.Write("Press any key to roll the ball...");
                Console.ReadKey();
                Console.WriteLine();
                var pinsHit = Random.Next(game.PinsUp + 1);
                Console.Write($"You knocked down {pinsHit} pin{pinsHit.S()}. ");
                game.ApplyRoll(pinsHit);
                Console.WriteLine($"Now there {game.PinsUp.IsAre()} {game.PinsUp} pin{game.PinsUp.S()} standing.");
                Console.WriteLine($"The score is {game.Score}");
            }
            Console.WriteLine("All done!");
            Console.WriteLine($"Your score was {game.Score}.");
            if (game.Score > highScore)
            {
                Console.WriteLine("That's a new high score!");
                File.WriteAllText(HighScorePath, game.Score.ToString());
            }
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine();

        }
    }
}