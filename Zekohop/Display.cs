using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Display
    {



        public static void GameHeader()
        {
            Console.WriteLine($"Level {Level.LevelIndex}.   >>{Level.NumberOfMOves}.");
        }

        public static void LevelWin()
        {
            Console.WriteLine();
            Console.WriteLine($"> >  L E V E L  - {Level.LevelIndex} -  C L E A R  < < ");
            WriteInColor($"        Minimum moves needed: {Level.NumberOfMOves}.", ConsoleColor.DarkGray);
            WriteInColor($"             Moves used: {GameGrid.MovesCount}.", ConsoleColor.DarkGray);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for the LEVEL - {Level.LevelIndex + 1} -");
            Console.ReadKey();
        }



        public static void GameMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press the number keys to select.");

            Console.WriteLine("Bunnies:");
            for (int i = 0; i < Bunny.BunnyCount; i++)
            {
                if (i == GameGrid.selectedAnimal - 1)
                {
                    WriteInColor($"[{ i + 1}] - > ", ConsoleColor.DarkGreen, false);
                }
                else
                {
                    Console.Write($"[{ i + 1}] - ");
                }
                WriteInColor("B", Level.BunnyList[i].InterfaceColor, false);
                Console.WriteLine();
            }



            if (Fox.FoxCount > 0)
            {
                Console.WriteLine("Foxes:");
                for (int i = 0; i < Fox.FoxCount; i++)
                {
                    if (i + 4 == GameGrid.selectedAnimal)
                    {
                        WriteInColor($"[{ i + 4}] - > ", ConsoleColor.DarkGreen, false);
                    }
                    else
                    {
                        Console.Write($"[{i + 4}] - ");
                    }
                    WriteInColor("V", Level.FoxList[i].InterfaceColor, false);
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



        public static void GridAdvanced()
        {
            GameHeader();

            for (int i = 0; i < GameGrid.GridSize; i++)
            {

                if (i == 0)
                {
                    Console.WriteLine(" --- --- --- --- --- ");
                }

                else
                {
                    Console.WriteLine("|---| - |---| - |---|");
                }

                for (int j = 0; j < GameGrid.GridSize; j++)
                {

                    var hole = (i, j);

                    int bunnieInTheHoleIndex = 0;

                    for (int k = 0; k < Level.BunnyList.Count; k++)
                    {
                        if (Level.BunnyList[k].CurrentPos == hole)
                        {
                            bunnieInTheHoleIndex = Level.BunnyList[k].Id;
                            break;
                        }
                    }
                    if (bunnieInTheHoleIndex != 0 && GameGrid.HoleList.Contains(hole))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("(");
                        Console.ResetColor();

                        switch (bunnieInTheHoleIndex)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("B");
                                Console.ResetColor();
                                break;

                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("B");
                                Console.ResetColor();
                                break;

                            case 3:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("B");
                                Console.ResetColor();
                                break;
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(")");
                        Console.ResetColor();
                        //Console.Write("|");


                        continue;
                    }
                    else if (GameGrid.HoleList.Contains(hole))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" ()");
                        Console.ResetColor();
                        //Console.Write("|");
                        continue;
                    }

                    switch (GameGrid.Grid[i, j])
                    {
                        case 0:
                            Console.Write("|   ");
                            break;

                        case 1:
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" B ");
                            Console.ResetColor();
                            break;

                        case 2:
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" B ");
                            Console.ResetColor();
                            break;

                        case 3:
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" B ");
                            Console.ResetColor();
                            break;

                        case 4:
                            DrawFoxes(0);
                            break;
                        case 5:
                            DrawFoxes(Fox.FoxCount - 1);
                            break;

                        case 9:
                            Console.Write("|");
                            WriteInColor($" {Mushroom.Icon} ", Mushroom.IconColor, false);
                            break;
                    }

                }
                Console.WriteLine();
                if (i == GameGrid.GridSize - 1)
                {
                    Console.WriteLine(" --- --- --- --- --- ");
                }



            }
            NumberOfMoves();
        }



        private static void DrawFoxes(int colorIndex)
        {
            Console.Write("|");
            WriteInColor($"{Level.FoxList[colorIndex].DisplayIcon}", Level.FoxList[colorIndex].InterfaceColor, false);
        }

        public static void NumberOfMoves()
        {
            Console.WriteLine($"Number of moves {GameGrid.MovesCount}");
        }
    }
}
// ubaciti predefinisane boje u zeceve. Postoje definisani u klasama