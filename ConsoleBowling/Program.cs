using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace ConsoleBowling
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine(">>>>>        Do you have what it takes? (TM)           <<<<<");
            Console.WriteLine();
            Console.WriteLine("Press the any key to begin...");
            Console.ReadKey();

        }
    }
}
