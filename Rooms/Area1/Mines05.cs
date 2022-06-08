using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines05 : Room
    {
        public static string NAME = "Mines_05";
        public Mines05() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 3, 25);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 6, 30);

            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 3, 41);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 6, 46);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 17, 50);
        }
    }
}
