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
            if (Level.LevelIndex < 13)
            {
                WriteInColor("+--- - Starter - ---+", ConsoleColor.DarkGreen);
                //Console.WriteLine("Starter");
            }
            else if (Level.LevelIndex < 25)
            {
                WriteInColor("+--- - Junior  - ---+", ConsoleColor.DarkYellow);
                //Console.WriteLine("Junior");
            }
            else if (Level.LevelIndex < 37)
            {

                WriteInColor("+--- - Expert  - ---+", ConsoleColor.DarkRed);
                //Console.WriteLine("Expert");
            }
            else if (Level.LevelIndex < 49)
            {
                WriteInColor("+--- - Master  - ---+", ConsoleColor.DarkMagenta);
                //Console.WriteLine("Master");
            }
            else
            {
                WriteInColor("+--- - Wizard  - ---+", ConsoleColor.DarkBlue);
                //Console.WriteLine("Wizard");
            }
            Console.WriteLine($"  Level {Level.LevelIndex}.    >>{Level.NumberOfMOves}.");
            Console.WriteLine();
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

        public static void GameMenu() // treba ubaciti poruku kad korisnik pritisne pogresan broj
        {
            Console.WriteLine();
            Console.WriteLine("Use the number keys to select.");
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
                    WriteInColor($"{Level.FoxList[i].DisplayIcon}", Level.FoxList[i].InterfaceColor, false);
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

        static bool IsFieldAHole(int rowIndex, int columnIndex)
        {
            // ova metoda treba da vrati informaciju da li je polje rupa ili ne
            var hole = (rowIndex, columnIndex);
            return GameGrid.HoleList.Contains(hole);
        }

        static int GetBunnyInTheHoleIndex(int rowIndex, int columnIndex)
        {
            var hole = (rowIndex, columnIndex);

            for (int k = 0; k < Level.BunnyList.Count; k++)
            {
                if (Level.BunnyList[k].CurrentPos == hole)
                {
                    return Level.BunnyList[k].Id;
                }
            }
            return 0;
        }

        private static void DrawTheField(int rowIndex, int columnIndex)
        {
            string gridFieldToDrawPref = " ";
            string gridFieldToDrawSufx = "";

            if (columnIndex == 0) // ukoliko je pocetna kolona
            {
                gridFieldToDrawPref = "|";

            }
            else if (columnIndex == GameGrid.GridSize - 1) // ukoliko je krajnja
            {
                gridFieldToDrawSufx = "|";

                if (rowIndex % 2 == 0) // ako je red paran
                {
                    gridFieldToDrawPref = "|";
                }
            }
            else
            {
                if (rowIndex % 2 == 0)
                {
                    gridFieldToDrawPref = "|";
                }
            }


            var isBunnyIn = GetBunnyInTheHoleIndex(rowIndex, columnIndex) != 0;
            var isAHole = IsFieldAHole(rowIndex, columnIndex);

            Console.Write($"{gridFieldToDrawPref}");

            if (isAHole && isBunnyIn) // if the field is a hole with the rabbit in it
            {
                WriteInColor("(", ConsoleColor.Green, false);
                DrawBunny(GameGrid.Grid[rowIndex, columnIndex] - 1, "");
                WriteInColor(")", ConsoleColor.Green, false);
            }
            else if (isAHole) // empty hole
            {
                WriteInColor(" ()", ConsoleColor.Green, false);
            }
            else
            {
                switch (GameGrid.Grid[rowIndex, columnIndex])
                {
                    case 0:
                        Console.Write("   "); // empty field
                        break;

                    case 1:
                    case 2:
                    case 3:
                        DrawBunny(GameGrid.Grid[rowIndex, columnIndex] - 1, " ");
                        break;

                    case 4:
                    case 5:
                        DrawFox(GameGrid.Grid[rowIndex, columnIndex] - 4); // 
                        break;

                    case 9:
                        WriteInColor($" {Mushroom.Icon} ", Mushroom.IconColor, false);
                        break;
                }
            }
            Console.Write($"{gridFieldToDrawSufx}");
        }

        public static void GridAdvanced()
        {
            GameHeader();
            for (int i = 0; i < GameGrid.GridSize; i++)
            {

                if (i == 0)
                {
                    Console.WriteLine("+---+---+---+---+---+");
                }
                else
                {
                    Console.Write("+---+");

                    WriteInColor(" - ", ConsoleColor.DarkGray, false);

                    Console.Write("+---+");

                    WriteInColor(" - ", ConsoleColor.DarkGray, false);

                    Console.Write("+---+");

                    Console.WriteLine();
                }

                for (int j = 0; j < GameGrid.GridSize; j++)
                {
                    DrawTheField(i, j);
                }


                Console.WriteLine();
                if (i == GameGrid.GridSize - 1)
                {
                    Console.WriteLine("+---+---+---+---+---+");
                }
            }
            NumberOfMoves();
        }

        private static void DrawBunny(int colorIndex, string prefSufix)
        {
            WriteInColor($"{prefSufix}{Level.BunnyList[colorIndex].DisplayIcon}{prefSufix}", Level.BunnyList[colorIndex].InterfaceColor, false);
        }

        private static void DrawFox(int colorIndex)
        {
            //Console.BackgroundColor = Level.FoxList[colorIndex].InterfaceColor;
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.Write($" {Level.FoxList[colorIndex].DisplayIcon} ");

            //Console.ResetColor();
            WriteInColor($" {Level.FoxList[colorIndex].DisplayIcon} ", Level.FoxList[colorIndex].InterfaceColor, false);
        }

        public static void NumberOfMoves()
        {
            Console.WriteLine($"Number of moves {GameGrid.MovesCount}");
        }
    }
}
