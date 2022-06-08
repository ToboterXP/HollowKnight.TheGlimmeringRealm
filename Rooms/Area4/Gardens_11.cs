using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area4
{
    internal class Gardens_11 : Room
    {
        public Gardens_11() : base("Fungus3_11") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.GARDENS_PLATFORM.Object, 16.5f, 21);
            PlaceGO(Prefabs.GARDENS_PLATFORM.Object, 19, 46);
        }
    }
}
