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
        private readonly string spicies = "Mushroom";


        public Mushroom((int row, int col) pos)
        {
            GetPos = pos;
        }

        public (int row, int col) GetPos { get => _pos; set => _pos = value; }

        public string Spicies => spicies;

    }
}
