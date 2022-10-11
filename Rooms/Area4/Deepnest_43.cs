using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area4
{
    internal class Deepnest_43 : Room
    {
        public Deepnest_43() : base("Deepnest_43") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 6.5f, 77);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 31.5f, 90);

            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 3, 7);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 10, 16);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 7, 25);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 14, 51);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 8, 73);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 13, 86);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 29, 86);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 29, 94);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 12, 99);
        }
    }
}
