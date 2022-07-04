using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area3
{
    internal class Fungal6 : Room
    {
        public Fungal6() : base("Fungus2_06") { }

        public override void OnLoad()
        {
            //PlaceGO(Prefabs.SMALL_PLATFORM.Object, 8, 57);
            DestroyGO("plat_float_08");
            DestroyGO("plat_float_02");
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 5, 147);
        }
    }
}
