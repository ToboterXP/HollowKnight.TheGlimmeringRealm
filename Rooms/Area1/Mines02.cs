using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines02 : Room
    {
        public static string NAME = "Mines_02";

        public Mines02() : base(NAME) {}

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 21, 34);
        }
    }
}
