using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village2
{
    internal class Crossroads22 : Room
    {
        public static string NAME = "Crossroads_22";
        public Crossroads22() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 6, 15);
        }
    }
}
