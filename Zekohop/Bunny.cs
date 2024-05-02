using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Bunny
    {
        int _id;

        (int x, int y) _startPos;
        (int x, int y) _currentPos;

        private static int bunnyCount;

        public Bunny((int x, int y) startPos)
        {
            StartPos = startPos;
            _currentPos = startPos;
            bunnyCount++;
            _id = BunnyCount;
        }

        public (int row, int col) CurrentPos { get => _currentPos; set => _currentPos = value; }
        public int Id { get => _id;}
        public (int row, int col) StartPos { get => _startPos; set => _startPos = value; }
        public static int BunnyCount { get => bunnyCount; set => bunnyCount = value; }

        public static void ResetBunniesCount()
        {
            BunnyCount = 0;
        }
    }
}
