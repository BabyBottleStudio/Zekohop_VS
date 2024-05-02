using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class GameGrid
    {
        int gridSize = 5;
        int[,] _grid;

        public static int movesCount = 0;

        List<(int row, int col)> holeList;
        List<Bunny> bunnyList = new List<Bunny>();
        List<Fox> foxList = new List<Fox>();

        internal List<Fox> FoxList { get => foxList; set => foxList = value; }
        internal List<Bunny> BunnyList { get => bunnyList; set => bunnyList = value; }


        /*
        00 01 02 03 04
        10 11 12 13 14
        20 21 22 23 24
        30 31 32 33 34
        40 41 42 43 44
        */

        public GameGrid()
        {
            _grid = new int[gridSize, gridSize];
            _grid.Initialize();
            holeList = new List<(int row, int col)> { (0, 0), (0, 4), (2, 2), (4, 0), (4, 4) };
        }




        public void DisplayGrid()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write($"{_grid[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        public void DisplayGridAdv()
        {
            Console.WriteLine($"Level {Levels.LevelIndex}. >>{Levels.NumberOfMOves}.");
            for (int i = 0; i < gridSize; i++)
            {
                
                if (i == 0)
                {
                    Console.WriteLine(" --- --- --- --- --- ");
                }
                
                else
                {
                    Console.WriteLine("|---| - |---| - |---|");
                }



                for (int j = 0; j < gridSize; j++)
                {
                    // test da li je rupa u pitanju
                    // kako resiti kad je zec u rupi?
                    var hole = (i, j);

                    //Enumerable(0, bunnyList.Count).Select
                    int bunnieInTheHoleIndex = 0;

                    for (int k = 0; k < bunnyList.Count; k++)
                    {
                        if (bunnyList[k].CurrentPos == hole)
                        {
                            bunnieInTheHoleIndex = bunnyList[k].Id;
                            break;
                        }
                    }
                    if (bunnieInTheHoleIndex != 0 && holeList.Contains(hole))
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
                    else if (holeList.Contains(hole))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" ()");
                        Console.ResetColor();
                        //Console.Write("|");
                        continue;
                    }

                    switch (_grid[i, j])
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
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" V ");
                            Console.ResetColor();
                            break;
                        case 5:
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" X ");
                            Console.ResetColor();
                            break;

                        case 9:
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" @ ");
                            Console.ResetColor();
                            break;
                    }

                }
                Console.WriteLine();
                if (i == gridSize - 1)
                {
                    Console.WriteLine(" --- --- --- --- --- ");
                }

                

            }
            Console.WriteLine($"Number of moves {movesCount}");
        }

        public void AddMushroom(Mushroom theMushroom)
        {
            // ako je rupa prekrivena pecurkom, treba je skloniti sa liste
            (int row, int col) mushroomPos = (theMushroom.GetPos.row, theMushroom.GetPos.col);
            _grid[mushroomPos.row, mushroomPos.col] = 9;

            holeList.Remove(mushroomPos); // ako ga nadje, izbrisace ga, ako ne.. nikom nista
        }

        public void AddBunny(Bunny theBunny)
        {
            _grid[theBunny.StartPos.row, theBunny.StartPos.col] = theBunny.Id;
            BunnyList.Add(theBunny);
        }

        public void MoveBunny(Bunny theBunny, int direction)
        {
            // direction
            // <= -1  1 =>

            // -2 ^
            //  2 v

            int x = theBunny.CurrentPos.col;
            int y = theBunny.CurrentPos.row;

            (int a, int b)? hopTo = null;

            switch (direction)
            {
                case -1:
                    if (x <= 1) // odavde ako preskoci nesto na levo, ispada iz grida
                    {
                        break;
                    }
                    else
                    {
                        if (_grid[y, x - 1] > 0)  // proveravamo da li je vrednostg prvog susednog polja > 0 i da li je uslov za preskok ispunjen
                        {
                            for (int i = x; i >= 0; i--) // trazimo mesto doskoka kroz lup --- sta ako ga ne nadje!!!!!!!
                            {
                                if (_grid[y, i] == 0) // trazimo polje doskoka
                                {
                                    hopTo = (y, i);
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 1:

                    if (x >= gridSize - 1) // odavde ako preskoci nesto na desno, ispada iz grida
                    {
                        break;
                    }
                    else
                    {
                        if (_grid[y, x + 1] > 0)  // proveravamo da li je vrednostg prvog susednog polja > 0 i da li je uslov za preskok ispunjen
                        {
                            for (int i = x; i < gridSize; i++) // trazimo mesto doskoka kroz lup --- sta ako ga ne nadje!!!!!!!
                            {
                                if (_grid[y, i] == 0) // trazimo polje doskoka
                                {
                                    hopTo = (y, i);
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case -2:

                    if (y <= 1) // odavde ako preskoci nesto na gore, ispada iz grida
                    {
                        break;
                    }
                    else
                    {
                        if (_grid[y - 1, x] > 0)  // proveravamo da li je vrednostg prvog susednog polja > 0 i da li je uslov za preskok ispunjen
                        {
                            for (int i = y; i >= 0; i--) // trazimo mesto doskoka kroz lup --- sta ako ga ne nadje!!!!!!!
                            {
                                if (_grid[i, x] == 0) // trazimo polje doskoka
                                {
                                    hopTo = (i, x);
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case 2:

                    if (y >= gridSize - 1) // odavde ako preskoci nesto na dole, ispada iz grida
                    {
                        break;
                    }
                    else
                    {
                        if (_grid[y + 1, x] > 0)  // proveravamo da li je vrednostg prvog susednog polja > 0 i da li je uslov za preskok ispunjen
                        {
                            for (int i = y; i < gridSize; i++) // trazimo mesto doskoka kroz lup --- sta ako ga ne nadje!!!!!!!
                            {
                                if (_grid[i, x] == 0) // trazimo polje doskoka
                                {
                                    hopTo = (i, x);
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }

            if (hopTo.HasValue)
            {
                _grid[theBunny.CurrentPos.row, theBunny.CurrentPos.col] = 0; // // brisemo staru poziciju
                                                                             //theBunny.CurrentPos = (theBunny.CurrentPos.row, theBunny.CurrentPos.col - i); // upisujemo novu poziciju u instancu zeca
                theBunny.CurrentPos = (hopTo.Value.a, hopTo.Value.b); // upisujemo novu poziciju u instancu zeca
                _grid[theBunny.CurrentPos.row, theBunny.CurrentPos.col] = theBunny.Id; // upisujemo novu poziciju u grid

                movesCount++;
            }
        }

        public void AddFox(Fox theFox)
        {
            _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
            _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;

            FoxList.Add(theFox);
        }

        public void MoveFox(Fox theFox, int direction)
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
                            if (_grid[theFox.HeadPos.row, theFox.HeadPos.col - 1] == 0) // ako polje sa leve strane je prazno
                            {
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col - 1);
                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col - 1);

                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                movesCount++;

                            }
                        }
                    }
                    else if (theFox.Orientation == "Horizontal Right") // glava gleda u pozitivan x
                    {
                        if (theFox.TailPos.col - 1 >= 0) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (_grid[theFox.TailPos.row, theFox.TailPos.col - 1] == 0) // ako polje sa desne strane je prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje!");
                                //var temp = new Tuple<int, int>(0, -1);
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col - 1);
                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col - 1);

                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                movesCount++;
                            }
                        }
                    }

                    break;

                case 1:
                    if (theFox.Orientation == "Horizontal Left")  // glava gleda u negativan x
                    {
                        if (theFox.TailPos.col + 1 < gridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (_grid[theFox.TailPos.row, theFox.TailPos.col + 1] == 0) // ako polje sa desne strane je prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje!");
                                //var temp = new Tuple<int, int>(0, -1);
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;


                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col + 1);
                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col + 1);

                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                movesCount++;
                            }
                        }
                    }
                    else if (theFox.Orientation == "Horizontal Right")
                    {
                        // mrda glavu u desno, rep prati
                        if (theFox.HeadPos.col + 1 < gridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds!");

                            if (_grid[theFox.HeadPos.row, theFox.HeadPos.col + 1] == 0) // ukoliko je polje sa desne strane prazno
                            {
                                Console.WriteLine($"Ispunjeni uslovi za pomeranje! mrda glavu rep prati");
                                // prepravi vrednost grida na nulu 
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row, theFox.HeadPos.col + 1);
                                theFox.TailPos = (theFox.TailPos.row, theFox.TailPos.col + 1);

                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                movesCount++;
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
                            if (_grid[theFox.HeadPos.row - 1, theFox.HeadPos.col] == 0) // ako polje je polje iznad prazno
                            {
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row - 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row - 1, theFox.TailPos.col);

                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                movesCount++;

                            }
                        }
                    }
                    else if (theFox.Orientation == "Vertical Down") // gleda na dole
                    {
                        // ide dupetom na gore
                        if (theFox.TailPos.row - 1 >= 0) // ako nije out of bounds
                        {
                            if (_grid[theFox.TailPos.row - 1, theFox.TailPos.col] == 0) // ako polje sa desne strane je prazno
                            {
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row - 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row - 1, theFox.TailPos.col);

                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                movesCount++;
                            }
                        }
                    }

                    break;

                case 2: // ide na dole ka pozitivnim vrednostima redova

                    if (theFox.Orientation == "Vertical Up") // gleda na gore
                    {
                        // ide dupetom na dole
                        if (theFox.TailPos.row + 1 < gridSize) // ako nije out of bounds
                        {
                            Console.WriteLine($"Direction = {direction}. Nisam out of bounds! mrda rep glava prati");
                            if (_grid[theFox.TailPos.row + 1, theFox.TailPos.col] == 0) // ako polje sa desne strane je prazno
                            {
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;


                                theFox.HeadPos = (theFox.HeadPos.row + 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row + 1, theFox.TailPos.col);

                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;

                                movesCount++;
                            }
                        }
                    }
                    else if (theFox.Orientation == "Vertical Down") // gleda na dole
                    {
                        // ide glavom na dole

                        // mrda glavu u desno, rep prati
                        if (theFox.HeadPos.row + 1 < gridSize) // ako nije out of bounds
                        {

                            if (_grid[theFox.HeadPos.row + 1, theFox.HeadPos.col] == 0) // ukoliko je polje sa desne strane prazno
                            {
                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = 0;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = 0;

                                theFox.HeadPos = (theFox.HeadPos.row + 1, theFox.HeadPos.col);
                                theFox.TailPos = (theFox.TailPos.row + 1, theFox.TailPos.col);

                                _grid[theFox.HeadPos.row, theFox.HeadPos.col] = theFox.FoxId;
                                _grid[theFox.TailPos.row, theFox.TailPos.col] = theFox.FoxId;
                                movesCount++;
                            }
                        }
                    }
                    break;
            }

        }

        public bool IsThereAWin()
        {
            var count = 0;
            for (int i = 0; i < bunnyList.Count; i++)
            {
                if (holeList.Contains(bunnyList[i].CurrentPos))
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

        public void ResetBunniesFoxesCount()
        {
            Fox.ResetFoxCount();
            Bunny.ResetBunniesCount();
            movesCount = 0;
        }
    }
}
