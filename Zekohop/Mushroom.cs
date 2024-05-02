using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zekohop
{
    class Mushroom
    {
        (int row, int col) _pos;

        public Mushroom((int row, int col) pos)
        {
            Position = pos;
        }

        public (int row, int col) Position { get => _pos; set => _pos = value; }
    }
}
