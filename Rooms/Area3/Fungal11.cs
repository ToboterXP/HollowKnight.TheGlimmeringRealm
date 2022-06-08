using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area3
{
    internal class Fungal11 : Room
    {
        public Fungal11() : base("Fungus2_11") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 5, 8);
        }
    }
}
