using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Program
    {
        static void Main(string[] args)
        {
            Levels.LevelIndex = 1;

            while (true)
            {
                Console.Clear();
                GameGrid grid = new GameGrid();

                grid.ResetBunniesFoxesCount();

                LoadLevel(grid);

                GameGrid.selectedAnimal = 1;

                grid.DisplayGridAdv();



                while (true)
                {
                    int userInput = UserInput(GameGrid.selectedAnimal, out GameGrid.selectedAnimal);

                    GameGrid.userInput = userInput;

                    if (userInput == -66) // r
                    {
                        Console.WriteLine("Restart current level! y/n");

                        ConsoleKeyInfo userChoice = Console.ReadKey();

                        if (userChoice.Key == ConsoleKey.Y)
                        {
                            break;
                        }
                        else if (userChoice.Key == ConsoleKey.N)
                        {
                            continue;
                        }
                    }
                    else if (userInput == -23) // s
                    {
                        int userChoice;
                        do
                        {
                            Console.WriteLine("Enter the level you want to play! (1 - 60)");
                        }
                        while (!int.TryParse(Console.ReadLine(), out userChoice));

                        if (userChoice < 0)
                        {
                            userChoice = 1;
                        }
                        else if (userChoice > 60)
                        {
                            userChoice = 60;
                        }

                        Levels.LevelIndex = userChoice;
                        break;
                    }
                    else if (userInput == -22) // a
                    {
                        Levels.LevelIndex--;
                        if (Levels.LevelIndex < 1)
                        {
                            Levels.LevelIndex = 60;
                        }
                        break;
                    }
                    else if (userInput == -24) // d
                    {
                        Levels.LevelIndex++;
                        if (Levels.LevelIndex > 60)
                        {
                            Levels.LevelIndex = 1;
                        }
                        break;
                    }

                    GameGrid.SetSelectedAnimal();
                    GameGrid.MoveSelectedAnimal();

                    Console.WriteLine($"{userInput}");

                    Console.Clear();
                    grid.DisplayGridAdv();

                    if (grid.IsThereAWin())
                    {
                        Console.WriteLine($"Level {Levels.LevelIndex} solved!!! Press any key to proceed to the level {Levels.LevelIndex + 1}.");
                        Console.ReadKey();

                        Levels.LevelIndex++;

                        break;
                    }
                }

            }







        }

        static int UserInput(int currentAnimal, out int selectedAnimal)
        {
            Interface.GameMenu();

            // Korisnik unosi broj ili strelice.
            // kad unese broj, ta figura ostaje selektovana dok se ne unese drugi broj. Strelice u medjuvremenu pomeraju selektovane objekte.

            selectedAnimal = currentAnimal; // na ovaj nacin se unosi koja je trenutna selekcija, i menja se samo ako korisnik unese broj.

            ConsoleKeyInfo keyInfo = Console.ReadKey();


            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    //Console.WriteLine();
                    //Console.WriteLine($"I dalje je selektovana zivotinja broj {selectedAnimal}");
                    return -2;

                case ConsoleKey.DownArrow:
                    //Console.WriteLine();
                    //Console.WriteLine($"I dalje je selektovana zivotinja broj {selectedAnimal}");
                    return 2;

                case ConsoleKey.LeftArrow:
                    //Console.WriteLine();
                    //Console.WriteLine($"I dalje je selektovana zivotinja broj {selectedAnimal}");
                    return -1;

                case ConsoleKey.RightArrow:
                    //Console.WriteLine();
                    //Console.WriteLine($"I dalje je selektovana zivotinja broj {selectedAnimal}");
                    return 1;

                case ConsoleKey.D1:
                    if (Bunny.BunnyCount > 0)
                    {
                        selectedAnimal = 1;
                        //Console.WriteLine();
                        //Console.WriteLine($"Selektovan zec 1!");
                    }
                    else
                    {
                        //Console.WriteLine();
                        //Console.WriteLine("Not enough bunnies!!!");
                    }
                    break;
                case ConsoleKey.D2:
                    if (Bunny.BunnyCount > 1)
                    {
                        selectedAnimal = 2;
                        //Console.WriteLine();
                        //Console.WriteLine($"Selektovan zec 2!");
                    }
                    else
                    {
                        //Console.WriteLine();
                        //Console.WriteLine("Not enough bunnies!!!");
                    }

                    break;
                case ConsoleKey.D3:
                    if (Bunny.BunnyCount > 2)
                    {
                        selectedAnimal = 3;
                        //Console.WriteLine();
                        //Console.WriteLine($"Selektovan zec 3!");
                    }
                    else
                    {
                        //Console.WriteLine();
                        //Console.WriteLine("Not enough bunnies!!!");
                    }

                    break;
                case ConsoleKey.D4:
                    if (Fox.FoxCount > 0)
                    {
                        selectedAnimal = 4;
                        //Console.WriteLine();
                        //Console.WriteLine($"Selektovana lisica 1!");
                    }
                    else
                    {
                        //Console.WriteLine();
                        //Console.WriteLine("Not enough foxes!!!");
                    }

                    break;
                case ConsoleKey.D5:
                    if (Fox.FoxCount > 1)
                    {
                        selectedAnimal = 5;
                        //Console.WriteLine();
                        //Console.WriteLine($"Selektovana lisica 2!");
                    }
                    else
                    {
                        //Console.WriteLine();
                        //Console.WriteLine("Not enough foxes!!!");
                    }
                    break;

                case ConsoleKey.R:
                    return -66;
                case ConsoleKey.S:
                    return -23;
                case ConsoleKey.A:
                    return -22;
                case ConsoleKey.D:
                    return -24;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!");
                    break;
            }
            return 0;
        }


        static void LoadLevel(GameGrid grid)
        {
            Levels.SetLevelData();

            foreach (object obj in Levels.MushroomList)
            {
                grid.AddMushroom((Mushroom)obj);
            }

            foreach (object obj in Levels.BunnyList)
            {
                grid.WriteBunnyIdToTheGridInitial((Bunny)obj);
            }

            foreach (object obj in Levels.FoxList)
            {
                grid.WriteFoxIdToTheGridInitial((Fox)obj);
            }
        }
    }
}


/*
Grid je 5x5
fiksni elementi >   rupe => mogu biti i zatvorene pecurkama (imas listu pa je edituj ako treba)
                    pecurke (koje se menjaju od partije do partije)

mobilni elementi > 

lisice =>   krecu se samo napred, nazad. Udaraju u ivicu grida i udaraju u ostale elemente (zecevi i pecurke)
            Orjentacija lisice
            Zauzima dva polja

zecevi =>   mogu samo da preskacu objekte (lisice, pecurke i ostale zeceve)

sistem mora da prati koliko je zeceva na sceni i koliko je  u rupama. Win condition je kada su svi zecevi u rupama


/// sta treba dodati??? 
/// 
/// indikaciju šta je selektovano
/// prepravi boje za zeceve
/// ubaci boje za ispise nivoa
/// reset nesto hoce pa nece da radi - srpska tastatura
/// 
/// 
///  refaktoring
///  
/// bugs log
/// puca prilikom resetovanja

*/

