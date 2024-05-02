using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Interface
    {
        public static void GameMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press the number keys to select.");

            Console.WriteLine("Bunnies:");
            for (int i = 0; i < Bunny.BunnyCount; i++)
            {
                Console.Write($"[{i + 1}] - ");
                WriteInColor("B", Levels.BunnyList[i].InterfaceColor, false);
                Console.WriteLine();
            }


            
            if (Fox.FoxCount > 0)
            {
                Console.WriteLine("Foxes:");
                for (int i = 0; i < Fox.FoxCount; i++)
                {
                    Console.Write($"[{i + 4}] - ");
                    WriteInColor("V", Levels.FoxList[i].InterfaceColor, false);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Use arrow keys to move!");
            Console.WriteLine();



        }



        /// <summary>
        /// Writes the text in color. If writeLine is provided as false, uses the Write command. Otherwise uses WriteLine.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="writeLine"></param>
        static void WriteInColor(string text, ConsoleColor color, bool writeLine = true)
        {
            Console.ForegroundColor = color;
            if (writeLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }

            Console.ResetColor();
        }
    }
}
