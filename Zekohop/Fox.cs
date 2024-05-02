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
                    TailPos = (HeadPos.row , HeadPos.col + 1);
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
    }
}
