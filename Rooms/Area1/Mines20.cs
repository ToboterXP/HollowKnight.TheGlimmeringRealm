using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines20 : Room
    {
        public static string NAME = "Mines_20";

        public Mines20() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 67, 190);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 11, 157);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 13, 164);
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 38, 60).transform.SetScaleX(1.5f);
        }
    }
}
