using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    public static class Level
    {
        // this class handles the data levels contain
        // it has 3 lists, for each type of objects in the game. Set level data handles the lists and creates instances with the proper coordinates. Impossible stuff like havint two objects on the same coordinate is not handled. Maybe if a level creator is added later :)

        private static List<Mushroom> mushroomList = new List<Mushroom>();
        private static List<Bunny> bunnyList = new List<Bunny>();
        private static List<Fox> foxList = new List<Fox>();

        private static int levelIndex;
        private static int numberOfMOves;

        internal static List<Mushroom> MushroomList { get => mushroomList; set => mushroomList = value; }
        internal static List<Bunny> BunnyList { get => bunnyList; set => bunnyList = value; }
        internal static List<Fox> FoxList { get => foxList; set => foxList = value; }
        
        
        internal static int LevelIndex { get => levelIndex; set => levelIndex = value; } // handles the current level
        internal static int NumberOfMOves { get => numberOfMOves; set => numberOfMOves = value; } // represents the number of minimal moves neededt to solve the level








        internal static void SetLevelData()
        {
            // cleaning up the data before generating the level
            mushroomList.Clear();
            bunnyList.Clear();
            foxList.Clear();

            // levels are hardcoded data taken from the game booklet
            switch (LevelIndex)
            {
                case 1:
                    NumberOfMOves = 2;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((1, 3)));
                    bunnyList.Add(new Bunny((2, 3)));
                    break;

                case 2:
                    NumberOfMOves = 3;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((1, 4)));
                    mushroomList.Add(new Mushroom((2, 3)));
                    bunnyList.Add(new Bunny((0, 4)));
                    bunnyList.Add(new Bunny((0, 2)));
                    break;

                case 3:
                    NumberOfMOves = 4;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((3, 2)));
                    bunnyList.Add(new Bunny((0, 1)));
                    bunnyList.Add(new Bunny((4, 2)));
                    break;

                case 4:
                    NumberOfMOves = 4;
                    mushroomList.Add(new Mushroom((3, 0)));
                    mushroomList.Add(new Mushroom((3, 2)));
                    mushroomList.Add(new Mushroom((4, 3)));
                    bunnyList.Add(new Bunny((4, 1)));
                    bunnyList.Add(new Bunny((2, 0)));
                    break;

                case 5:
                    NumberOfMOves = 5;
                    mushroomList.Add(new Mushroom((1, 1)));
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((3, 0)));
                    bunnyList.Add(new Bunny((4, 0)));
                    bunnyList.Add(new Bunny((0, 2)));
                    break;

                case 6:
                    NumberOfMOves = 6;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((2, 1)));
                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((2, 3)));
                    break;

                case 7:
                    NumberOfMOves = 7;
                    mushroomList.Add(new Mushroom((3, 1)));
                    mushroomList.Add(new Mushroom((3, 2)));
                    mushroomList.Add(new Mushroom((4, 3)));
                    bunnyList.Add(new Bunny((4, 4)));
                    bunnyList.Add(new Bunny((2, 3)));
                    break;

                case 8:
                    NumberOfMOves = 7;
                    mushroomList.Add(new Mushroom((1, 4)));
                    mushroomList.Add(new Mushroom((2, 1)));
                    mushroomList.Add(new Mushroom((2, 3)));
                    bunnyList.Add(new Bunny((2, 2)));
                    bunnyList.Add(new Bunny((2, 4)));
                    bunnyList.Add(new Bunny((2, 0)));

                    break;

                case 9:
                    NumberOfMOves = 8;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    bunnyList.Add(new Bunny((4, 2)));
                    bunnyList.Add(new Bunny((0, 4)));
                    bunnyList.Add(new Bunny((0, 0)));
                    break;

                case 10:
                    NumberOfMOves = 9;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((1, 0)));
                    bunnyList.Add(new Bunny((0, 4)));
                    bunnyList.Add(new Bunny((0, 2)));
                    bunnyList.Add(new Bunny((0, 0)));
                    break;

                case 11:

                    NumberOfMOves = 10;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((3, 3)));
                    bunnyList.Add(new Bunny((2, 4)));
                    bunnyList.Add(new Bunny((0, 3)));
                    bunnyList.Add(new Bunny((0, 0)));
                    break;

                case 12:
                    NumberOfMOves = 9;
                    mushroomList.Add(new Mushroom((3, 1)));
                    mushroomList.Add(new Mushroom((4, 2)));
                    mushroomList.Add(new Mushroom((4, 3)));
                    bunnyList.Add(new Bunny((2, 4)));
                    bunnyList.Add(new Bunny((2, 1)));
                    bunnyList.Add(new Bunny((2, 0)));
                    break;

                case 13:
                    NumberOfMOves = 4;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((1, 1)));
                    mushroomList.Add(new Mushroom((2, 2)));

                    bunnyList.Add(new Bunny((1, 2)));
                    foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 14:
                    NumberOfMOves = 6;
                    mushroomList.Add(new Mushroom((2, 1)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((2, 4)));

                    bunnyList.Add(new Bunny((0, 3)));

                    foxList.Add(new Fox((1, 2), "Horizontal Right"));
                    break;

                case 15:
                    NumberOfMOves = 9;
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((3, 2)));

                    bunnyList.Add(new Bunny((3, 4)));

                    foxList.Add(new Fox((1, 3), "Vertical Down"));
                    break;

                case 16:
                    NumberOfMOves = 7;
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((3, 2)));

                    bunnyList.Add(new Bunny((0, 1)));

                    foxList.Add(new Fox((3, 1), "Vertical Up"));
                    break;

                case 17:
                    NumberOfMOves = 7;
                    mushroomList.Add(new Mushroom((1, 4)));
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((2, 4)));

                    bunnyList.Add(new Bunny((3, 0)));

                    foxList.Add(new Fox((0, 1), "Vertical Up"));
                    foxList.Add(new Fox((1, 3), "Vertical Down"));
                    break;

                case 18:
                    NumberOfMOves = 8;
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((2, 3)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((4, 3)));

                    foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    break;

                case 19:
                    NumberOfMOves = 11;
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((2, 4)));
                    mushroomList.Add(new Mushroom((3, 2)));

                    bunnyList.Add(new Bunny((1, 2)));

                    foxList.Add(new Fox((3, 3), "Vertical Down"));
                    break;

                case 20:
                    NumberOfMOves = 13;
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((3, 2)));

                    bunnyList.Add(new Bunny((0, 1)));

                    foxList.Add(new Fox((3, 1), "Vertical Up"));
                    break;

                case 21:
                    NumberOfMOves = 9;
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((2, 3)));
                    mushroomList.Add(new Mushroom((3, 2)));

                    bunnyList.Add(new Bunny((0, 3)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    break;

                case 22:
                    NumberOfMOves = 11;
                    mushroomList.Add(new Mushroom((4, 1)));
                    mushroomList.Add(new Mushroom((4, 2)));
                    mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((3, 1)));

                    foxList.Add(new Fox((2, 3), "Vertical Down"));
                    foxList.Add(new Fox((3, 3), "Horizontal Left"));
                    break;

                case 23:
                    NumberOfMOves = 16;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((2, 3)));
                    mushroomList.Add(new Mushroom((4, 2)));

                    bunnyList.Add(new Bunny((0, 3)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((3, 1), "Vertical Up"));
                    break;

                case 24:
                    NumberOfMOves = 15;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((2, 2)));

                    bunnyList.Add(new Bunny((1, 4)));

                    foxList.Add(new Fox((2, 3), "Vertical Down"));
                    foxList.Add(new Fox((3, 3), "Horizontal Left"));
                    break;

                case 25:
                    NumberOfMOves = 13;
                    mushroomList.Add(new Mushroom((1, 4)));
                    mushroomList.Add(new Mushroom((2, 4)));
                    mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((3, 3)));

                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 26:
                    NumberOfMOves = 12;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((3, 1)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((2, 2)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    break;

                case 27:
                    NumberOfMOves = 13;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((3, 0)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((1, 3)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Left"));
                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((1, 1), "Vertical Up"));
                    foxList.Add(new Fox((3, 1), "Vertical Down"));
                    break;

                case 28:
                    NumberOfMOves = 12;
                    mushroomList.Add(new Mushroom((2, 3)));
                    mushroomList.Add(new Mushroom((3, 0)));
                    //mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((1, 1)));
                    bunnyList.Add(new Bunny((2, 4)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Left"));
                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((2, 1), "Vertical Up"));
                    //foxList.Add(new Fox((3, 1), "Vertical Down"));
                    break;

                case 29:
                    NumberOfMOves = 13;
                    mushroomList.Add(new Mushroom((4, 2)));
                    //mushroomList.Add(new Mushroom((3, 0)));
                    //mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((3, 3)));
                    bunnyList.Add(new Bunny((4, 4)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Left"));
                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((2, 1), "Vertical Up"));
                    foxList.Add(new Fox((2, 3), "Vertical Down"));
                    break;

                case 30:
                    NumberOfMOves = 13;
                    mushroomList.Add(new Mushroom((2, 4)));
                    //mushroomList.Add(new Mushroom((3, 0)));
                    //mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((3, 1)));
                    bunnyList.Add(new Bunny((4, 2)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((2, 1), "Vertical Up"));
                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 31:
                    NumberOfMOves = 17;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((2, 2)));

                    bunnyList.Add(new Bunny((0, 4)));
                    bunnyList.Add(new Bunny((2, 3)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((2, 1), "Vertical Up"));
                    foxList.Add(new Fox((4, 3), "Vertical Down"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 32:
                    NumberOfMOves = 15;
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((1, 4)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((4, 4)));


                    //foxList.Add(new Fox((2, 1), "Vertical Up"));
                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    foxList.Add(new Fox((3, 2), "Horizontal Right"));
                    break;

                case 33:
                    NumberOfMOves = 13;
                    mushroomList.Add(new Mushroom((2, 3)));
                    mushroomList.Add(new Mushroom((3, 3)));
                    mushroomList.Add(new Mushroom((4, 3)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((4, 4)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((3, 1), "Vertical Up"));
                    //foxList.Add(new Fox((1, 1), "Vertical Down"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));

                    break;

                case 34:
                    NumberOfMOves = 15;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    //mushroomList.Add(new Mushroom((4, 3)));

                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((4, 1)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    foxList.Add(new Fox((0, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 35:
                    NumberOfMOves = 14;
                    mushroomList.Add(new Mushroom((1, 1)));
                    mushroomList.Add(new Mushroom((2, 0)));
                    //mushroomList.Add(new Mushroom((4, 3)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((2, 3)));

                    foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 1), "Vertical Down"));
                    foxList.Add(new Fox((3, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 36:
                    NumberOfMOves = 19;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((2, 1)));
                    mushroomList.Add(new Mushroom((2, 2)));

                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((3, 3)));

                    foxList.Add(new Fox((1, 2), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 1), "Vertical Down"));
                    //foxList.Add(new Fox((3, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 37:
                    NumberOfMOves = 21;
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((4, 2)));

                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 38:
                    NumberOfMOves = 21;
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((2, 2)));

                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((4, 4)));

                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    foxList.Add(new Fox((0, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 39:
                    NumberOfMOves = 7;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((2, 4)));
                    mushroomList.Add(new Mushroom((3, 3)));

                    bunnyList.Add(new Bunny((2, 1)));
                    bunnyList.Add(new Bunny((2, 2)));
                    bunnyList.Add(new Bunny((2, 3)));

                    //foxList.Add(new Fox((1, 1), "Vertical Down"));
                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 40:
                    NumberOfMOves = 19;
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((2, 1)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((4, 1)));
                    //bunnyList.Add(new Bunny((2, 3)));

                    //foxList.Add(new Fox((1, 1), "Vertical Down"));
                    foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    foxList.Add(new Fox((3, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 41:
                    NumberOfMOves = 20;
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((3, 2)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((4, 2)));
                    bunnyList.Add(new Bunny((4, 1)));
                    //bunnyList.Add(new Bunny((2, 3)));

                    foxList.Add(new Fox((1, 1), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 42:
                    NumberOfMOves = 17;
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((1, 3)));
                    mushroomList.Add(new Mushroom((2, 3)));

                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((3, 4)));
                    //bunnyList.Add(new Bunny((2, 3)));

                    foxList.Add(new Fox((2, 1), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 3), "Vertical Up"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    break;

                case 43:
                    NumberOfMOves = 26;
                    mushroomList.Add(new Mushroom((2, 1)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((2, 3)));

                    bunnyList.Add(new Bunny((1, 1)));
                    bunnyList.Add(new Bunny((1, 4)));
                    //bunnyList.Add(new Bunny((2, 3)));

                    //foxList.Add(new Fox((2, 1), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 3), "Vertical Up"));
                    foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    break;

                case 44:
                    NumberOfMOves = 19;
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((3, 3)));
                    mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((3, 1)));
                    bunnyList.Add(new Bunny((4, 1)));
                    bunnyList.Add(new Bunny((1, 4)));

                    //foxList.Add(new Fox((2, 1), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    foxList.Add(new Fox((1, 1), "Vertical Up"));
                    foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    break;

                case 45:
                    NumberOfMOves = 21;
                    mushroomList.Add(new Mushroom((0, 0)));
                    //mushroomList.Add(new Mushroom((3, 3)));
                    //mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((2, 4)));
                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((3, 2)));

                    foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    foxList.Add(new Fox((4, 3), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((1, 1), "Vertical Up"));
                    break;

                case 46:
                    NumberOfMOves = 19;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((1, 1)));

                    bunnyList.Add(new Bunny((2, 0)));
                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((4, 3)));

                    //foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    //foxList.Add(new Fox((4, 3), "Vertical Down"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Right"));
                    foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 47:
                    NumberOfMOves = 24;
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((2, 3)));
                    mushroomList.Add(new Mushroom((3, 2)));

                    bunnyList.Add(new Bunny((4, 2)));
                    bunnyList.Add(new Bunny((1, 4)));
                    //bunnyList.Add(new Bunny((4, 3)));

                    //foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    //foxList.Add(new Fox((4, 3), "Vertical Down"));
                    foxList.Add(new Fox((1, 3), "Horizontal Right"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 48:
                    NumberOfMOves = 28;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((1, 1)));
                    mushroomList.Add(new Mushroom((1, 2)));

                    bunnyList.Add(new Bunny((0, 2)));
                    bunnyList.Add(new Bunny((0, 4)));
                    bunnyList.Add(new Bunny((3, 0)));

                    //foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    //foxList.Add(new Fox((4, 3), "Vertical Down"));
                    //foxList.Add(new Fox((1, 3), "Horizontal Right"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 49:
                    NumberOfMOves = 36;
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((4, 4)));
                    //mushroomList.Add(new Mushroom((1, 2)));

                    bunnyList.Add(new Bunny((0, 4)));
                    bunnyList.Add(new Bunny((4, 3)));
                    bunnyList.Add(new Bunny((1, 3)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((1, 2), "Horizontal Left"));
                    foxList.Add(new Fox((3, 1), "Vertical Down"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 50:
                    NumberOfMOves = 23;
                    mushroomList.Add(new Mushroom((0, 1)));
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((2, 2)));

                    bunnyList.Add(new Bunny((0, 3)));
                    bunnyList.Add(new Bunny((0, 2)));
                    bunnyList.Add(new Bunny((1, 2)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((3, 0), "Horizontal Left"));
                    //foxList.Add(new Fox((3, 1), "Vertical Down"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 51:
                    NumberOfMOves = 27;
                    mushroomList.Add(new Mushroom((4, 0)));
                    mushroomList.Add(new Mushroom((4, 2)));
                    mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((1, 0)));
                    bunnyList.Add(new Bunny((3, 2)));

                    foxList.Add(new Fox((1, 2), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 0), "Horizontal Left"));
                    foxList.Add(new Fox((2, 3), "Vertical Down"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 52:
                    NumberOfMOves = 34;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((3, 2)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((2, 4)));
                    bunnyList.Add(new Bunny((4, 3)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 0), "Horizontal Left"));
                    foxList.Add(new Fox((3, 1), "Vertical Down"));
                    //foxList.Add(new Fox((0, 3), "Vertical Up"));
                    break;

                case 53:
                    NumberOfMOves = 33;
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((2, 0)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((1, 4)));
                    bunnyList.Add(new Bunny((0, 1)));
                    bunnyList.Add(new Bunny((0, 3)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((3, 1), "Horizontal Left"));
                    //foxList.Add(new Fox((3, 1), "Vertical Down"));
                    foxList.Add(new Fox((1, 1), "Vertical Up"));
                    break;

                case 54:
                    NumberOfMOves = 22;
                    mushroomList.Add(new Mushroom((0, 2)));
                    mushroomList.Add(new Mushroom((1, 0)));
                    mushroomList.Add(new Mushroom((3, 1)));

                    bunnyList.Add(new Bunny((0, 1)));
                    bunnyList.Add(new Bunny((4, 1)));
                    bunnyList.Add(new Bunny((4, 3)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Left"));
                    foxList.Add(new Fox((1, 3), "Vertical Down"));
                    //foxList.Add(new Fox((1, 1), "Vertical Up"));
                    break;

                case 55:
                    NumberOfMOves = 32;
                    mushroomList.Add(new Mushroom((1, 2)));
                    mushroomList.Add(new Mushroom((4, 0)));
                    mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((2, 2)));
                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((3, 2)));

                    //foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Left"));
                    foxList.Add(new Fox((3, 3), "Vertical Down"));
                    //foxList.Add(new Fox((1, 1), "Vertical Up"));
                    break;

                case 56:
                    NumberOfMOves = 43;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((3, 4)));

                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((1, 4)));
                    bunnyList.Add(new Bunny((4, 1)));

                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 1), "Horizontal Left"));
                    //foxList.Add(new Fox((3, 3), "Vertical Down"));
                    foxList.Add(new Fox((1, 3), "Vertical Up"));
                    break;

                case 57:
                    NumberOfMOves = 55;
                    mushroomList.Add(new Mushroom((4, 4)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((4, 1)));

                    bunnyList.Add(new Bunny((0, 0)));
                    bunnyList.Add(new Bunny((3, 1)));
                    bunnyList.Add(new Bunny((1, 1)));

                    foxList.Add(new Fox((1, 3), "Horizontal Left"));
                    foxList.Add(new Fox((3, 4), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 3), "Vertical Down"));
                    //foxList.Add(new Fox((1, 3), "Vertical Up"));
                    break;

                case 58:
                    NumberOfMOves = 67;
                    mushroomList.Add(new Mushroom((0, 4)));
                    mushroomList.Add(new Mushroom((2, 4)));
                    mushroomList.Add(new Mushroom((4, 0)));

                    bunnyList.Add(new Bunny((2, 2)));
                    bunnyList.Add(new Bunny((0, 1)));
                    bunnyList.Add(new Bunny((2, 0)));

                    foxList.Add(new Fox((1, 3), "Vertical Up"));
                    foxList.Add(new Fox((3, 3), "Horizontal Left"));
                    //foxList.Add(new Fox((3, 4), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 3), "Vertical Down"));
                    break;

                case 59:
                    NumberOfMOves = 63;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((4, 4)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((3, 0)));
                    bunnyList.Add(new Bunny((2, 4)));

                    //foxList.Add(new Fox((1, 3), "Vertical Up"));
                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    foxList.Add(new Fox((3, 2), "Horizontal Left"));
                    //foxList.Add(new Fox((3, 3), "Vertical Down"));
                    break;

                case 60:
                    NumberOfMOves = 87;
                    mushroomList.Add(new Mushroom((0, 3)));
                    mushroomList.Add(new Mushroom((2, 2)));
                    mushroomList.Add(new Mushroom((3, 0)));

                    bunnyList.Add(new Bunny((1, 3)));
                    bunnyList.Add(new Bunny((4, 3)));
                    bunnyList.Add(new Bunny((2, 4)));

                    //foxList.Add(new Fox((1, 3), "Vertical Up"));
                    foxList.Add(new Fox((1, 1), "Horizontal Right"));
                    //foxList.Add(new Fox((3, 2), "Horizontal Left"));
                    //foxList.Add(new Fox((3, 3), "Vertical Down"));
                    break;


            }
        }
    }
}
