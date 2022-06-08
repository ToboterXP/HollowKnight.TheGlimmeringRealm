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
        }
    }
}
