using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area5
{
    internal class Abyss12 : Room
    {
        public Abyss12(): base("Abyss_12") { }

        public override void OnBeforeLoad()
        {
            SetDarkness(true);
        }
    }
}
