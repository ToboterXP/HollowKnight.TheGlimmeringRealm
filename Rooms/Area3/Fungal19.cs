using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area3
{
    internal class Fungal19 : Room
    {
        public Fungal19() : base("Fungus2_19") { }
        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 5, 14);
        }
    }
}
