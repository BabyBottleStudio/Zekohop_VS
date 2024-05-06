﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class GameGrid
    {
        private const int gridSize = 5; // defines the size of the grid. Odd numbers recomended
        static int[,] _grid; // game grid 5x5

        private static int movesCount = 0; // how many moves has player used to solve the puzzle

        /// <summary>
        /// Hole list is a flexibile. It contains the coordinates of all possible holes in the game. If mushroom is spawned ower the hole, then the coordinates for this hole are deleted.
        /// </summary>
        static List<(int row, int col)> holeList;
        public static readonly string HoleIconLeftHalf = "(";
        public static readonly string HoleIconRightHalf = ")";

        public static readonly ConsoleColor HoleColorIfEmpty = ConsoleColor.DarkGreen;
        public static readonly ConsoleColor HoleColorIfFull = ConsoleColor.Green;

        public static int selectedAnimal;
        public static Bunny currentBunny;
        public static Fox currentFox;
        public static int userInput;

        public static int GridSize => gridSize;

        public static List<(int row, int col)> HoleList { get => holeList; set => holeList = value; }
        public static int[,] Grid { get => _grid; set => _grid = value; }
        public static int MovesCount { get => movesCount; set => movesCount = value; }

        /*
        00 01 02 03 04
        10 11 12 13 14
        20 21 22 23 24
        30 31 32 33 34
        40 41 42 43 44
        */


        public static void IncreaseMovesCount()
        {
            MovesCount++;
        }

        public GameGrid()
        {
            Grid = new int[GridSize, GridSize];
            Grid.Initialize();
            HoleList = new List<(int row, int col)> { (0, 0), (0, 4), (2, 2), (4, 0), (4, 4) };
        }



        public static void SetSelectedAnimal()
        {
            if (selectedAnimal > 3)
            {
                currentFox = Level.FoxList[selectedAnimal - 1 - 3];
            }
            else if (selectedAnimal > 0 && selectedAnimal < 4)
            {
                currentBunny = Level.BunnyList[selectedAnimal - 1];
            }
        }

        public static void MoveSelectedAnimal()
        {
            if (selectedAnimal > 3)
            {
                // mrdas lisice
                Fox.MoveFox();
            }
            else if (selectedAnimal > 0 && selectedAnimal < 4)
            {
                Bunny.MoveBunny();
                //mrdas zeceve
            }
        }

        public static bool IsThereAWin()
        {
            int count = Level.BunnyList.Count(bunny => HoleList.Contains(bunny.CurrentPos));
            return count == Bunny.BunnyCount;


/*
            var count = 0;
            for (int i = 0; i < Level.BunnyList.Count; i++)
            {
                if (HoleList.Contains(Level.BunnyList[i].CurrentPos))
                {
                    count++;
                }
            }

            if (count == Bunny.BunnyCount)
            {
                return true;
            }
            return false;
*/
        }

        public static void ResetBunniesFoxesCount()
        {
            Fox.ResetFoxCount();
            Bunny.ResetBunniesCount();
            MovesCount = 0;
        }
    }
}
