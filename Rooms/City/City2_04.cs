using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.City
{
    internal class City2_04 : Room
    {
        public City2_04() : base("Ruins2_04") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 14, 11);
        }
    }
}
