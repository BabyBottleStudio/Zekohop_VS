using System;
using System.Collections.Generic;

namespace Zekohop
{
    class Bunny
    {
        int _id;

        (int x, int y) _startPos;
        (int x, int y) _currentPos;

        private static int bunnyCount;
        private static List<ConsoleColor> bunnyInterfaceColors = new List<ConsoleColor>
        {
            ConsoleColor.White,
            ConsoleColor.DarkGray,
            ConsoleColor.Yellow,
        };

        private ConsoleColor interfaceColor;


        public Bunny((int x, int y) startPos)
        {
            StartPos = startPos;
            _currentPos = startPos;
            bunnyCount++;
            _id = BunnyCount;
            InterfaceColor = bunnyInterfaceColors[Id-1];

        }

        public (int row, int col) CurrentPos { get => _currentPos; set => _currentPos = value; }
        public int Id { get => _id;}
        public (int row, int col) StartPos { get => _startPos; set => _startPos = value; }
        public static int BunnyCount { get => bunnyCount; set => bunnyCount = value; }
        public ConsoleColor InterfaceColor { get => interfaceColor; set => interfaceColor = value; }

        public static void ResetBunniesCount()
        {
            BunnyCount = 0;
        }




        /***************************
 ***   B U N N Y ! ! !   ***
 ***************************/

        public static void WriteBunnyIdToTheGridInitial(Bunny theBunny)
        {
            GameGrid.Grid[theBunny.StartPos.row, theBunny.StartPos.col] = theBunny.Id;

            //BunnyList.Add(theBunny);
        }

        private static bool IsBunnyGoingToJupmOutOfTheGrid(int direction) // da li je ovaj test neophodan ili samo mi treba bolja logika dole u funkcijijijiji. Ili ovaj test sprecava dalje proracune ako se nije ispunio
        {
            //SetSelectedAnimal();
            // Initial test if the bunny is going to jump out of the grid
            (int y, int x) = GameGrid.currentBunny.CurrentPos;

            switch (direction)
            {
                case -1:
                    if (x <= 1) // if a bunny jumps from here to the left, it will jump out of the grid; odavde ako preskoci nesto na levo, ispada iz grida
                    {
                        return false;
                    }
                    break;

                case 1:

                    if (x >= GameGrid.GridSize - 1) // if a bunny jumps from here to the right, it will jump out of the grid; odavde ako preskoci nesto na desno, ispada iz grida
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

                    if (y >= GameGrid.GridSize - 1) //  if a bunny jumps down from here, it will jump out of the grid; odavde ako preskoci nesto na dole, ispada iz grida
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
                    if (GameGrid.Grid[y, x - 1] > 0) // if it jumps to the left, will it jump over something or not
                    {
                        return true;
                    }
                    break;

                case 1:
                    if (GameGrid.Grid[y, x + 1] > 0)  // if it jumps to the right, will it jump over something or not
                    {
                        return true;
                    }
                    break;

                case -2:
                    if (GameGrid.Grid[y - 1, x] > 0)  // if it jumps upwards, will it jump over something or not
                    {
                        return true;
                    }
                    break;

                case 2:
                    if (GameGrid.Grid[y + 1, x] > 0) // if it jumps downwards, will it jump over something or not
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
                        if (GameGrid.Grid[y, i] == 0) // trazimo polje doskoka
                        {
                            return (y, i);
                        }
                    }
                    break;

                case 1:
                    for (int i = x; i < GameGrid.GridSize; i++) // trazimo mesto doskoka kroz lup 
                    {
                        if (GameGrid.Grid[y, i] == 0) // trazimo polje doskoka
                        {
                            return (y, i);
                        }
                    }
                    break;

                case -2:
                    for (int i = y; i >= 0; i--) // trazimo mesto doskoka kroz lup 
                    {
                        if (GameGrid.Grid[i, x] == 0) // trazimo polje doskoka
                        {
                            return (i, x);
                        }
                    }
                    break;

                case 2:
                    for (int i = y; i < GameGrid.GridSize; i++) // trazimo mesto doskoka kroz lup --- sta ako ga ne nadje!!!!!!!
                    {
                        if (GameGrid.Grid[i, x] == 0) // trazimo polje doskoka
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
                GameGrid.IncreaseMovesCount();
            }
        }

        static bool HopToField(Bunny theBunny, (int a, int b)? hopTo)
        {
            if (hopTo.HasValue)
            {
                GameGrid.Grid[theBunny.CurrentPos.row, theBunny.CurrentPos.col] = 0; // Erasing the old Rabbit position from the grid
                theBunny.CurrentPos = (hopTo.Value.a, hopTo.Value.b); // write in the new position into the rabit instance
                GameGrid.Grid[theBunny.CurrentPos.row, theBunny.CurrentPos.col] = theBunny.Id; // write in the new position into the grid

                return true;
            }
            return false;
        }









    }
}
