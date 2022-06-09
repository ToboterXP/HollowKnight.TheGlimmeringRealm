using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines23 : Room
    {
        public static string NAME = "Mines_23";
        public Mines23() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 15, 13);
            DestroyGO("plat_float_07");
        }
    }
}
