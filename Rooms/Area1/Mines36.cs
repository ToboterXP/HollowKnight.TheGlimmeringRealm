using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines36 : Room
    {
        public static string NAME = "Mines_36";
        public Mines36() : base(NAME) { 
            IsFlipped = true;
        }

        public override void OnBeforeLoad()
        {
            HKSecondQuest.Instance.RoomMirrorer.AddExcludedObject("Inspect");
        }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 21, 13);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 23, 18);
        }
    }
}
