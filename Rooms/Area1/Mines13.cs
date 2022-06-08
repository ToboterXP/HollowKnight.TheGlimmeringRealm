using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines13 : Room
    {
        public static string NAME = "Mines_13";

        public Mines13() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 49, 9);
        }
    }
}
