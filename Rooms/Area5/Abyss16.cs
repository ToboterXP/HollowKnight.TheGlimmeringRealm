using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area5
{
    internal class Abyss16 : Room
    {
        public Abyss16() : base("Abyss_16") { }

        public override void OnBeforeLoad()
        {
            SetDarkness(true);
        }
    }
}
