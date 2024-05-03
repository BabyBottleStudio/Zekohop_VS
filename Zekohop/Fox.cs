using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Fox
    {

        private static int foxCount;
        int foxId;
        (int row, int col) _headPos;
        (int row, int col) _tailPos;
        string _orientation;

        private static List<ConsoleColor> foxInterfaceColors = new List<ConsoleColor>
        {
            ConsoleColor.Red,
            ConsoleColor.DarkYellow
        };

        private ConsoleColor interfaceColor;


        public Fox((int row, int col) headPos, string orientation)
        {
            HeadPos = headPos;
            Orientation = orientation;
            switch (orientation)
            {
                case "Horizontal Left":                             // glava gleda u negativan x
                    TailPos = (HeadPos.row, HeadPos.col + 1);
                    break;
                case "Horizontal Right":                            // glava gleda u pozitivan x           
                    TailPos = (HeadPos.row, HeadPos.col - 1);
                    break;
                case "Vertical Up":                                 // glava gleda na gore            
                    TailPos = (HeadPos.row + 1, HeadPos.col);
                    break;
                case "Vertical Down":                               // glava gleda na dole           
                    TailPos = (HeadPos.row - 1, HeadPos.col);
                    break;
            }


            FoxCount++;
            FoxId = FoxCount + 3;
            InterfaceColor = foxInterfaceColors[FoxCount - 1];
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
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (GameGrid.Grid[theFox.TailPos.row, theFox.TailPos.col - 1] == 0) // ako polje sa desne strane je prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje!");
                                //var temp = new Tuple<int, int>(0, -1);
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
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
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
