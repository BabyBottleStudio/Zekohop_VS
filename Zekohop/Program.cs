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
            Level.LevelIndex = 1;

            while (true)
            {
                Console.Clear();
                GameGrid grid = new GameGrid(); // ovo je pravilo bagove

                GameGrid.ResetBunniesFoxesCount();

                Level.LoadLevel();

                GameGrid.selectedAnimal = 1;

                Display.GridAdvanced();



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
                            Console.WriteLine($"Enter the level you want to play! (1 - {Level.AllLevelsCount})");
                        }
                        while (!int.TryParse(Console.ReadLine(), out userChoice));

                        if (userChoice < 0)
                        {
                            userChoice = 1;
                        }
                        else if (userChoice > Level.AllLevelsCount)
                        {
                            userChoice = Level.AllLevelsCount;
                        }

                        Level.LevelIndex = userChoice;
                        break;
                    }
                    else if (userInput == -22) // a
                    {
                        Level.LevelIndex--;
                        if (Level.LevelIndex < 1)
                        {
                            Level.LevelIndex = Level.AllLevelsCount;
                        }
                        break;
                    }
                    else if (userInput == -24) // d
                    {
                        Level.LevelIndex++;
                        if (Level.LevelIndex > Level.AllLevelsCount)
                        {
                            Level.LevelIndex = 1;
                        }
                        break;
                    }

                    GameGrid.SetSelectedAnimal();
                    GameGrid.MoveSelectedAnimal();

                    Console.WriteLine($"{userInput}");

                    Console.Clear();
                    Display.GridAdvanced();

                    if (GameGrid.IsThereAWin())
                    {
                        Display.LevelWin();
                        Level.LevelIndex++;
                        break;
                    }
                }

            }
        }

        static int UserInput(int currentAnimal, out int selectedAnimal)
        {
            Display.GameMenu();

            // User can input arrow keys, number keys 1 - 5, A,S,D 
            // numbers are changing the selection of a current animal in the scene
            // arrow keys are moving the selection
            // a - loads the previous level
            // s - opens the menu where you type in the level number you want to play.
            // d - loads the next level

            selectedAnimal = currentAnimal; // this way we change the current selection and it changes only if user enters a new number.; na ovaj nacin se unosi koja je trenutna selekcija, i menja se samo ako korisnik unese broj.

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    return -2;

                case ConsoleKey.DownArrow:
                    return 2;

                case ConsoleKey.LeftArrow:
                    return -1;

                case ConsoleKey.RightArrow:
                    return 1;

                case ConsoleKey.D1:
                    selectedAnimal = 1;
                    break;

                case ConsoleKey.D2:
                    selectedAnimal = 2;
                    break;

                case ConsoleKey.D3:
                    selectedAnimal = 3;
                    break;

                case ConsoleKey.D4:
                    selectedAnimal = 4;
                    break;

                case ConsoleKey.D5:
                    selectedAnimal = 5;
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

