using System;
using System.IO;
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
            }


            Console.WriteLine();
            Console.Write("Press the any key to begin...");

            Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("It's time to bowl!");
            Console.WriteLine();

            var thisRollMultiplier = 1;
            var nextRollMultiplier = 1;
            var nextNextRollMultiplier = 1;
            var frame = 1;
            var frameRoll = 1;
            var pinsUp = 10;
            var points = 0;

            while (true)
            {
                var maxFrameRolls = frame == 10 ? 3 : 2;
                Console.Write($"It's frame {frame}, roll {frameRoll}/{maxFrameRolls}! ");
                Console.Write($"{pinsUp} pin{pinsUp.S()} {pinsUp.IsAre()} standing. ");
                Console.WriteLine($"You have {points} point{points.S()}.");
                if (thisRollMultiplier != 1)
                    Console.WriteLine($"This roll is worth {thisRollMultiplier}x!");
                Console.Write("Press any key to roll the ball...");
                Console.ReadKey();
                Console.WriteLine();
                var pinsHit = Random.Next(pinsUp+1);



                pinsUp -= pinsHit;
                var newPoints = pinsHit * thisRollMultiplier;
                Console.Write($"You knocked down {pinsHit} pin{pinsHit.S()}. ");
                Console.WriteLine($"Now there {pinsUp.IsAre()} {pinsUp} pin{pinsUp.S()} standing.");
                if (thisRollMultiplier != 1 && pinsHit != 0)
                    Console.WriteLine($"This roll was worth {thisRollMultiplier}x, " +
                                      $"so it's worth {newPoints} points instead of {pinsHit}");
                points += newPoints;

                if (frame == 10 && frameRoll == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("You're all done!");
                    Console.WriteLine($"Your final score was {points}");
                    Console.Write("Press the any key to quit...");
                    Console.ReadKey();
                    Console.WriteLine();
                    return;
                }

                if (frameRoll >= maxFrameRolls || pinsUp == 0)
                {
                    if (pinsUp == 0)
                    {
                        nextRollMultiplier += 1;
                        if (frameRoll == 1)
                        {
                            Console.WriteLine("That means you got a strike!");
                            nextNextRollMultiplier += 1;
                        }
                        else
                        {
                            Console.WriteLine("That means you got a spare!");
                        }
                    }

                    frame++;
                    frameRoll = 1;
                    pinsUp = 10;
                }
                else
                {
                    frameRoll++;
                }


                thisRollMultiplier = nextRollMultiplier;
                nextRollMultiplier = nextNextRollMultiplier;
                nextNextRollMultiplier = 1;
                Console.WriteLine();
            }
        }
    }
}