using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village3
{
    internal class Deepnest10 : Room
    {
        public Deepnest10() : base("Deepnest_10") { IsFlipped = true; }

        public override void OnLoad()
        { 
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 49, 87);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 24, 106);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 56, 7);

            for (int y = 8; y < 90; y += 6) PlaceGO(Prefabs.BOUNCE_MUSHROOM.Object, 12 - (y*y*y % 5), y);
        }
    }
}
