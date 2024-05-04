using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Fox
    {

        private static int foxCount; // static variable carved into the class rather than into the instance
        int foxId; // each instance of the fox has unique ID
        (int row, int col) _headPos; // position of a head
        (int row, int col) _tailPos; // position of a tail
        string _orientation; // defines how the fox is oriented. It makes a difference if it is horisontal L to R or R to L. I wanted to make it more fun and diverse, like in the original board game Jump In' by Smart Games.
        string displayIcon; // this is a display icon carved into the instance of the fox. Display script uses this to, well..., display the fox properly. This  can't be static.

        public readonly static List<string> DisplayIconsList = new List<string> {"<", ">", "^", "V" };

        public readonly static List<ConsoleColor> InterfaceColors = new List<ConsoleColor>
        {
            ConsoleColor.Red,
            ConsoleColor.DarkYellow
        };

        private ConsoleColor interfaceColor; // this info is part of the instance. It is used by the display script to access the color info.

        /// <summary>
        /// Constructor activated when Fox instance is created. Head Position is a tupple value reprsenting the row and column of the grid. Orentatnion is a string and it must be provided exactly => "Horizontal Left", "Horizontal Right", "Vertical Up", "Vertical Down". I used it that way so I can figure out what's going on while programing.
        /// </summary>
        /// <param name="headPos"></param>
        /// <param name="orientation"></param>
        public Fox((int row, int col) headPos, string orientation)
        {
            HeadPos = headPos;
            Orientation = orientation;
            switch (orientation)
            {
                case "Horizontal Left":                             // glava gleda u negativan x
                    TailPos = (HeadPos.row, HeadPos.col + 1);
                    DisplayIcon = DisplayIconsList[0];
                    break;
                case "Horizontal Right":                            // glava gleda u pozitivan x           
                    TailPos = (HeadPos.row, HeadPos.col - 1);
                    DisplayIcon = DisplayIconsList[1];
                    break;
                case "Vertical Up":                                 // glava gleda na gore            
                    TailPos = (HeadPos.row + 1, HeadPos.col);
                    DisplayIcon = DisplayIconsList[2];
                    break;
                case "Vertical Down":                               // glava gleda na dole           
                    TailPos = (HeadPos.row - 1, HeadPos.col);
                    DisplayIcon = DisplayIconsList[3];
                    break;
            }


            FoxCount++;
            FoxId = FoxCount + 3;
            InterfaceColor = InterfaceColors[FoxCount - 1];
        }

        public static int FoxCount
        { get => foxCount; set => foxCount = value; }

        public (int row, int col) HeadPos
        { get => _headPos; set => _headPos = value; }

        public (int row, int col) TailPos
        { get => _tailPos; set => _tailPos = value; }

        public int FoxId
        { get => foxId; set => foxId = value; }

        public string Orientation
        { get => _orientation; set => _orientation = value; }
        public ConsoleColor InterfaceColor { get => interfaceColor; set => interfaceColor = value; }
        public string DisplayIcon { get => displayIcon; set => displayIcon = value; }

        public static void ResetFoxCount()
        {
            FoxCount = 0;
        }




        /***********************
 ***   F O X ! ! !   ***
 ***********************/


        public static void WriteFoxIdToTheGridInitial(Fox theFox)
        {
            GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
            GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;

            // FoxList.Add(theFox);
        }


        public static void MoveFox(Fox theFox, int direction)
        {
            // horizontalne lisice

            // gleda da li je susedno polje 0
            // ako jeste pomera se

            switch (direction)
            {
                case -1:
                    if (theFox.Orientation == "Horizontal Left")  // glava gleda u negativan x
                    {
                        // mrda glavu u levo, rep prati
                        if (theFox.HeadPos.col - 1 >= 0) // ako nije out of bounds
                        {
                            if (GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col - 1] == 0) // ako polje sa leve strane je prazno
                            {
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col - 1);
                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col - 1);

                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;

                                GameGrid.IncreaseMovesCount();

                            }
                        }
                    }
                    else if (theFox.Orientation == "Horizontal Right") // glava gleda u pozitivan x
                    {
                        if (theFox.TailPos.col - 1 >= 0) // ako nije out of bounds
                        {
                            if (GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col - 1] == 0) // ako polje sa desne strane je prazno
                            {
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col - 1);
                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col - 1);

                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }
                    break;

                case 1:
                    if (theFox.Orientation == "Horizontal Left")  // glava gleda u negativan x
                    {
                        if (theFox.TailPos.col + 1 < GameGrid.GridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col + 1] == 0) // ako polje sa desne strane je prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje!");
                                //var temp = new Tuple<int, int>(0, -1);
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col + 1);
                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col + 1);

                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }
                    else if (theFox.Orientation == "Horizontal Right")
                    {
                        // mrda glavu u desno, rep prati
                        if (theFox.HeadPos.col + 1 < GameGrid.GridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds!");

                            if (GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col + 1] == 0) // ukoliko je polje sa desne strane prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje! mrda glavu rep prati");
                                // prepravi vrednost grida na nulu 
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col + 1);
                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col + 1);

                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }

                    break;

                case -2: // ide na gore, ka negativnim vrednostima redova

                    if (theFox.Orientation == "Vertical Up") // gleda na gore
                    {
                        // ide glavom na gore
                        if (theFox.HeadPos.row - 1 >= 0) // ako nije out of bounds
                        {
                            if (GameGrid.Grid[theFox.HeadPos.row - 1, theFox.HeadPos.col] == 0) // ako polje je polje iznad prazno
                            {
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row - 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row - 1, theFox.TailPos.col);

                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }
                    else if (theFox.Orientation == "Vertical Down") // gleda na dole
                    {
                        // ide dupetom na gore
                        if (theFox.TailPos.row - 1 >= 0) // ako nije out of bounds
                        {
                            if (GameGrid.Grid[theFox.TailPos.row - 1, theFox.TailPos.col] == 0) // ako polje sa desne strane je prazno
                            {
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row - 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row - 1, theFox.TailPos.col);

                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }

                    break;

                case 2: // ide na dole ka pozitivnim vrednostima redova

                    if (theFox.Orientation == "Vertical Up") // gleda na gore
                    {
                        // ide dupetom na dole
                        if (theFox.TailPos.row + 1 < GameGrid.GridSize) // ako nije out of bounds
                        {
                            if (GameGrid.Grid[theFox.TailPos.row + 1, theFox.TailPos.col] == 0) // ako polje sa desne strane je prazno
                            {
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row + 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row + 1, theFox.TailPos.col);

                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;

                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }
                    else if (theFox.Orientation == "Vertical Down") // gleda na dole
                    {
                        // ide glavom na dole

                        // mrda glavu u desno, rep prati
                        if (theFox.HeadPos.row + 1 < GameGrid.GridSize) // ako nije out of bounds
                        {
                            if (GameGrid.Grid[theFox.HeadPos.row + 1, theFox.HeadPos.col] == 0) // ukoliko je polje sa desne strane prazno
                            {
                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row + 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row + 1, theFox.TailPos.col);

                                GameGrid.Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                GameGrid.IncreaseMovesCount();
                            }
                        }
                    }
                    break;
            }

        }


    }
}
