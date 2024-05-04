﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Display
    {


        /// <summary>
        /// Draws the header of the game. It contains the info about the current level. Difficulty, current level index and least amount of moves to solve the puzzle.
        /// </summary>
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

        /// <summary>
        /// Menu that is displayed when the player wins the level.
        /// </summary>
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


        /// <summary>
        /// Responsive menu below the game screen. It informs the player about the current selection.
        /// </summary>
        public static void GameMenu() // treba ubaciti poruku kad korisnik pritisne pogresan broj
        {
            Console.WriteLine();
            Console.WriteLine("Press 'H' for Help.");
            Console.WriteLine("Use the number keys to select.");
            Console.WriteLine(" - Bunnies - ");


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
                Console.WriteLine(" - - Foxes - - ");
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
        private static void WriteInColor(string text, ConsoleColor color, bool writeLine = true)
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

        /// <summary>
        /// This method returns the bool if the current field is a Hole or not. Parameters are the coordinates of the current field.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>        
        private static bool IsFieldAHole(int rowIndex, int columnIndex)
        {
            // ova metoda treba da vrati informaciju da li je polje rupa ili ne
            var hole = (rowIndex, columnIndex);
            return GameGrid.HoleList.Contains(hole);
        }

        /// <summary>
        /// Returns the index of a Bunny that is in the current hole. Info important for correct drawing on the screen.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private static int GetBunnyInTheHoleIndex(int rowIndex, int columnIndex)
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

        private static void DrawTheSingleField(int rowIndex, int columnIndex)
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
                WriteInColor(" ()", ConsoleColor.DarkGreen, false);
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
                    DrawTheSingleField(i, j);
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

            WriteInColor($"{prefSufix}{Bunny.DisplayIcon}{prefSufix}", Level.BunnyList[colorIndex].InterfaceColor, false);
            // WriteInColor($"{prefSufix}{Level.BunnyList[colorIndex].DisplayIcon}{prefSufix}", Level.BunnyList[colorIndex].InterfaceColor, false);
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

        public static void HelpMenu()
        {
            List<ConsoleColor> bunnyColors = new List<ConsoleColor> { };

            foreach (ConsoleColor obj in Bunny.bunnyInterfaceColors)
            {
                bunnyColors.Add(obj);
            }

            Console.WriteLine("GAME RULES JUMP IN’");
            Console.WriteLine();
            Console.WriteLine($"The object of the game is to move the rabbits [{Bunny.DisplayIcon}] and foxes [{Fox.DisplayIconsList[0]}{Fox.DisplayIconsList[0]}] around the game board until all of the rabbits are safe in the holes [( )].");
            Console.WriteLine("Movement rules");
            Console.WriteLine("Foxes move by sliding forward or backward.Foxes cannot jump over obstacles.");
            Console.WriteLine($"Mushrooms [{Mushroom.Icon}] are stationary and cannot be moved.");
            Console.WriteLine("Rabbits move by jumping horizontally or vertically over one or more spaces with obstacles: other rabbits, foxes, mushrooms or a combination of these.");
            Console.WriteLine("Rabbits must land on the first empty space after a jump - they can never move over empty spaces.");
            Console.WriteLine("Rabbits can never move without jumping over at least 1 obstacle, thus they can never move to an adjacent space.");
            Console.WriteLine("A hole with a rabbit inside is an obstacle, while empty holes are not obstacles.");
            Console.WriteLine("A rabbit can jump into – but not over – an empty hole.");
            Console.WriteLine("If needed, rabbits can jump out of holes they are already sitting in.");
            Console.WriteLine("Rabbits can jump over a fox no matter the orientation of the fox: tail to front, front to tail, or over the side.");
            Console.WriteLine("You have found a solution when all of the rabbits are inside the holes! The end position of the foxes is not important.");
 
            Console.WriteLine();
            Console.WriteLine($"Bunnies: (select one and use arrows to jump over the obstacles)"); 
            Console.WriteLine();

            Console.Write($"Press [1] to select the {bunnyColors[0]} Bynny ");
            WriteInColor($"- {Bunny.DisplayIcon} -", bunnyColors[0]);

            Console.Write($"Press [2] to select the {bunnyColors[1]} Bynny ");
            WriteInColor($"- {Bunny.DisplayIcon} -", bunnyColors[1]);

            Console.Write($"Press [3] to select the {bunnyColors[2]} Bynny ");
            WriteInColor($"- {Bunny.DisplayIcon} -", bunnyColors[2]);
            Console.WriteLine();
            Console.WriteLine("Foxes: (select one and use arrow keys to slide them left and right or up and down)");
            Console.WriteLine($"Press [4] to select the {Fox.InterfaceColors[0]} Fox.");
            WriteInColor($"{Fox.DisplayIconsList[0]}{Fox.DisplayIconsList[0]} - {Fox.DisplayIconsList[2]} - {Fox.DisplayIconsList[3]}", Fox.InterfaceColors[0]);
            WriteInColor($"{Fox.DisplayIconsList[1]}{Fox.DisplayIconsList[1]} - {Fox.DisplayIconsList[2]} - {Fox.DisplayIconsList[3]}", Fox.InterfaceColors[0]);
            Console.WriteLine();
            Console.WriteLine($"Press [5] to select the {Fox.InterfaceColors[1]} Fox.");
            WriteInColor($"{Fox.DisplayIconsList[0]}{Fox.DisplayIconsList[0]} - {Fox.DisplayIconsList[2]} - {Fox.DisplayIconsList[3]}", Fox.InterfaceColors[1]);
            WriteInColor($"{Fox.DisplayIconsList[1]}{Fox.DisplayIconsList[1]} - {Fox.DisplayIconsList[2]} - {Fox.DisplayIconsList[3]}", Fox.InterfaceColors[1]);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press [S] to jump to the desired challenge.");
            Console.WriteLine("Press [D] to select the next challenge.");
            Console.WriteLine("Press [A] to select the previous challenge.");
            Console.WriteLine("Press [R] to reset the challenge.");
            Console.WriteLine();

            Console.WriteLine("Press any key to return to the game!");
        }
    }
}
