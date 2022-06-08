using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area5
{
    internal class Abyss6 : Room
    {
        public Abyss6() : base("Abyss_06_Core") { }

        public override void OnBeforeLoad()
        {
            SetDarkness(true);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 90, 264);
        }
    }
}
