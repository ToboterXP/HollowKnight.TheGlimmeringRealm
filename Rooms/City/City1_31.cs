using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.City
{
    internal class City1_31 : Room
    {
        public City1_31() : base("Ruins1_31") { }

        public override void OnLoad()
        {
            //PlaceGO(Prefabs.LARGE_PLATFORM.Object, 7, 2);
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 57, 53);
            DestroyGO("Breakable Wall Ruin Lift");
        }
    }
}
