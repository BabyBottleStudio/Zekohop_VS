using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class GameGrid
    {
        private const int gridSize = 5; // defines the size of the grid
        static int[,] _grid; // game grid 5x5

        private static int movesCount = 0; // how many moves has player used to solve the puzzle

        static List<(int row, int col)> holeList; // hole list treba da bude fleksibilna lista

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

        public void ResetLevel()
        {
            //ResetBunniesFoxesCount();
            HoleList = new List<(int row, int col)> { (0, 0), (0, 4), (2, 2), (4, 0), (4, 4) };

            for (int i = 0; i < GridSize; i--)
            {
                for (int j = 0; j < GridSize; j--)
                {
                    Grid[i, j] = 0;
                }
            }
        }

        public static void SetSelectedAnimal()
        {
            if (selectedAnimal > 3)
            {
                currentFox =  Level.FoxList[GameGrid.selectedAnimal - 1 - 3];
            }
            else if (GameGrid.selectedAnimal > 0 && GameGrid.selectedAnimal < 4)
            {
                currentBunny =  Level.BunnyList[GameGrid.selectedAnimal - 1];
            }
        }        

        public static void MoveSelectedAnimal()
        {
            if (selectedAnimal > 3)
            {
                // mrdas lisice
                MoveFox(Level.FoxList[GameGrid.selectedAnimal - 1 - 3], userInput);
            }
            else if (GameGrid.selectedAnimal > 0 && GameGrid.selectedAnimal < 4)
            {
                Bunny.MoveBunny(Level.BunnyList[GameGrid.selectedAnimal - 1], userInput);
                //mrdas zeceve
            }
        }

 
     
        /*
        public static void AddMushroom(Mushroom theMushroom)
        {
            // if the hole is covered with the mushroom, remove it from the list
            (int row, int col) mushroomPos = (theMushroom.Position.row, theMushroom.Position.col);
            Grid[mushroomPos.row, mushroomPos.col] = 9;

            HoleList.Remove(mushroomPos); // if mushroom covers the hole, delete the hole from the list
        }
        /*


        /***************************
         ***   B U N N Y ! ! !   ***
         ***************************/

        /*
        public static  void WriteBunnyIdToTheGridInitial(Bunny theBunny)
        {
            Grid[theBunny.StartPos.row, theBunny.StartPos.col] = theBunny.Id;

            //BunnyList.Add(theBunny);
        }

        private static bool IsBunnyGoingToJupmOutOfTheGrid(int direction) // da li je ovaj test neophodan ili samo mi treba bolja logika dole u funkcijijijiji. Ili ovaj test sprecava dalje proracune ako se nije ispunio
        {
            //SetSelectedAnimal();
            // Initial test if the bunny is going to jump out of the grid
            (int y, int x) = currentBunny.CurrentPos;

            switch (direction)
            {
                case -1:
                    if (x <= 1) // if a bunny jumps from here to the left, it will jump out of the grid; odavde ako preskoci nesto na levo, ispada iz grida
                    {
                        return false;
                    }
                    break;

                case 1:

                    if (x >= GridSize - 1) // if a bunny jumps from here to the right, it will jump out of the grid; odavde ako preskoci nesto na desno, ispada iz grida
                    {
                        return false;
                    }
                    break;

                case -2:

                    if (y <= 1) // if a bunny jumps up from here, it will jump out of the grid; odavde ako preskoci nesto na gore, ispada iz grida
                    {
                        return false;
                    }
                    break;

                case 2:

                    if (y >= GridSize - 1) //  if a bunny jumps down from here, it will jump out of the grid; odavde ako preskoci nesto na dole, ispada iz grida
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        private static bool IsBunnyLegitToJump(Bunny theBunny, int direction) // this method checks if the selected bunny is going to jump over the fox, mushroom or another bunny and retunrs bool
        {
            // values are inverted because they have more logic that way. 
            (int y, int x) = theBunny.CurrentPos; // ovo isto napraviti kao public parametar 

            switch (direction)
            {
                case -1:
                    if (Grid[y, x - 1] > 0) // if it jumps to the left, will it jump over something or not
                    {
                        return true;
                    }
                    break;

                case 1:
                    if (Grid[y, x + 1] > 0)  // if it jumps to the right, will it jump over something or not
                    {
                        return true;
                    }
                    break;

                case -2:
                    if (Grid[y - 1, x] > 0)  // if it jumps upwards, will it jump over something or not
                    {
                        return true;
                    }
                    break;

                case 2:
                    if (Grid[y + 1, x] > 0) // if it jumps downwards, will it jump over something or not
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        private static (int a, int b)? GetPlaceToHopTo(Bunny theBunny, int direction)
        {
            (int y, int x) = theBunny.CurrentPos; // ovo isto napraviti kao public parametar 

            switch (direction)
            {
                case -1:
                    for (int i = x; i >= 0; i--) // trazimo mesto doskoka kroz lup i+direction
                    {
                        if (Grid[y, i] == 0) // trazimo polje doskoka
                        {
                            return (y, i);
                        }
                    }
                    break;

                case 1:
                    for (int i = x; i < GridSize; i++) // trazimo mesto doskoka kroz lup 
                    {
                        if (Grid[y, i] == 0) // trazimo polje doskoka
                        {
                            return (y, i);
                        }
                    }
                    break;

                case -2:
                    for (int i = y; i >= 0; i--) // trazimo mesto doskoka kroz lup 
                    {
                        if (Grid[i, x] == 0) // trazimo polje doskoka
                        {
                            return (i, x);
                        }
                    }
                    break;

                case 2:
                    for (int i = y; i < GridSize; i++) // trazimo mesto doskoka kroz lup --- sta ako ga ne nadje!!!!!!!
                    {
                        if (Grid[i, x] == 0) // trazimo polje doskoka
                        {
                            return (i, x);
                        }
                    }
                    break;
            }
            return null;
        }

        public static void MoveBunny(Bunny theBunny, int direction)
        {
            // direction
            // <= -1  1 =>

            // -2 ^
            //  2 v

            int x = theBunny.CurrentPos.col;
            int y = theBunny.CurrentPos.row;

            (int a, int b)? hopTo = null;

            if (IsBunnyGoingToJupmOutOfTheGrid(direction) && IsBunnyLegitToJump(theBunny, direction))
            {

                // a da napravimo privremenu listu koju mozemo da testiramo
                // ubaci koordinate koje ispunjavaju kriterijum
                // yec je recimo na koord 1 1. Cim se selektuje, da se sakupe validna polja za kretanje
                // 

                hopTo = GetPlaceToHopTo(theBunny, direction);
            }

            if (HopToField(theBunny, hopTo)) // treba videti kako da se selekcija zeca iskoristi i ovde da se ne ubacuje kao paramtar
            {
                movesCount++;
            }
        }

        static bool HopToField(Bunny theBunny, (int a, int b)? hopTo)
        {
            if (hopTo.HasValue)
            {
                Grid[theBunny.CurrentPos.row, theBunny.CurrentPos.col] = 0; // Erasing the old Rabbit position from the grid
                theBunny.CurrentPos = (hopTo.Value.a, hopTo.Value.b); // write in the new position into the rabit instance
                Grid[theBunny.CurrentPos.row, theBunny.CurrentPos.col] = theBunny.Id; // write in the new position into the grid

                return true;
            }
            return false;
        }


*/


        /***********************
         ***   F O X ! ! !   ***
         ***********************/


        public static void WriteFoxIdToTheGridInitial(Fox theFox)
        {
            Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
            Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;

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
                            if (Grid[theFox.HeadPos.row, theFox.HeadPos.col - 1] == 0) // ako polje sa leve strane je prazno
                            {
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col - 1);
                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col - 1);

                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                MovesCount++;

                            }
                        }
                    }
                    else if (theFox.Orientation == "Horizontal Right") // glava gleda u pozitivan x
                    {
                        if (theFox.TailPos.col - 1 >= 0) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (Grid[theFox.TailPos.row, theFox.TailPos.col - 1] == 0) // ako polje sa desne strane je prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje!");
                                //var temp = new Tuple<int, int>(0, -1);
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col - 1);
                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col - 1);

                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                MovesCount++;
                            }
                        }
                    }

                    break;

                case 1:
                    if (theFox.Orientation == "Horizontal Left")  // glava gleda u negativan x
                    {
                        if (theFox.TailPos.col + 1 < GridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (Grid[theFox.TailPos.row, theFox.TailPos.col + 1] == 0) // ako polje sa desne strane je prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje!");
                                //var temp = new Tuple<int, int>(0, -1);
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;


                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col + 1);
                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col + 1);

                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                MovesCount++;
                            }
                        }
                    }
                    else if (theFox.Orientation == "Horizontal Right")
                    {
                        // mrda glavu u desno, rep prati
                        if (theFox.HeadPos.col + 1 < GridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds!");

                            if (Grid[theFox.HeadPos.row, theFox.HeadPos.col + 1] == 0) // ukoliko je polje sa desne strane prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje! mrda glavu rep prati");
                                // prepravi vrednost grida na nulu 
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col + 1);
                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col + 1);

                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                MovesCount++;
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
                            if (Grid[theFox.HeadPos.row - 1, theFox.HeadPos.col] == 0) // ako polje je polje iznad prazno
                            {
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row - 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row - 1, theFox.TailPos.col);

                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                MovesCount++;

                            }
                        }
                    }
                    else if (theFox.Orientation == "Vertical Down") // gleda na dole
                    {
                        // ide dupetom na gore
                        if (theFox.TailPos.row - 1 >= 0) // ako nije out of bounds
                        {
                            if (Grid[theFox.TailPos.row - 1, theFox.TailPos.col] == 0) // ako polje sa desne strane je prazno
                            {
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row - 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row - 1, theFox.TailPos.col);

                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                MovesCount++;
                            }
                        }
                    }

                    break;

                case 2: // ide na dole ka pozitivnim vrednostima redova

                    if (theFox.Orientation == "Vertical Up") // gleda na gore
                    {
                        // ide dupetom na dole
                        if (theFox.TailPos.row + 1 < GridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (Grid[theFox.TailPos.row + 1, theFox.TailPos.col] == 0) // ako polje sa desne strane je prazno
                            {
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;


                                theFox.HeadPos = (theFox.HeadPos.row + 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row + 1, theFox.TailPos.col);

                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;

                                MovesCount++;
                            }
                        }
                    }
                    else if (theFox.Orientation == "Vertical Down") // gleda na dole
                    {
                        // ide glavom na dole

                        // mrda glavu u desno, rep prati
                        if (theFox.HeadPos.row + 1 < GridSize) // ako nije out of bounds
                        {

                            if (Grid[theFox.HeadPos.row + 1, theFox.HeadPos.col] == 0) // ukoliko je polje sa desne strane prazno
                            {
                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row + 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row + 1, theFox.TailPos.col);

                                Grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                Grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                MovesCount++;
                            }
                        }
                    }
                    break;
            }

        }

        public static bool IsThereAWin()
        {
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
        }

        public static void ResetBunniesFoxesCount()
        {
            Fox.ResetFoxCount();
            Bunny.ResetBunniesCount();
            MovesCount = 0;
        }
    }
}
