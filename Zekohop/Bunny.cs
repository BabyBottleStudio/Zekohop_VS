using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Bunny
    {
        string _name;
        int _id;
        private readonly string spicies = "Bunny";


        (int x, int y) _startPos;

        (int x, int y) _currentPos;

        private static int bunnyCount;
        //private List<int> bunniesList;





        public Bunny((int x, int y) startPos, string name = "Bunny")
        {
            StartPos = startPos;
            _currentPos = startPos;
            _name = name + $"{_id}";
            bunnyCount++;
            _id = BunnyCount;
            _name = name + $"{_id}";
            //bunniesList.Add(Id);
        }

        public (int row, int col) CurrentPos { get => _currentPos; set => _currentPos = value; }
        public int Id { get => _id;}
        public (int row, int col) StartPos { get => _startPos; set => _startPos = value; }
        public static int BunnyCount { get => bunnyCount; set => bunnyCount = value; }

        public string Spicies => spicies;

        public static void ResetBunniesCount()
        {
            BunnyCount = 0;
        }
    }
}
