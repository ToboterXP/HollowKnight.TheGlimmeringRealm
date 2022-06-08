using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village2
{
    internal class Crossroads_52 : Room
    {
        public Crossroads_52() : base("Crossroads_52") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 31, 40);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 17.5f, 53);
        }
    }
}
