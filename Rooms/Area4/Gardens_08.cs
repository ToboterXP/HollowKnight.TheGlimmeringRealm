using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area4
{
    internal class Gardens_08 : Room
    {
        public Gardens_08() : base("Fungus3_08") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 6, 22);
            DestroyGO("Royal Gardens Plat S (2)");
        }
    }
}
