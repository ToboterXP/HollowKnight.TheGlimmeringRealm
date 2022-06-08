using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village2
{
    internal class Crossroads4 : Room
    {
        public static string NAME = "Crossroads_04";
        public Crossroads4() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 106, 21);
        }
    }
}
