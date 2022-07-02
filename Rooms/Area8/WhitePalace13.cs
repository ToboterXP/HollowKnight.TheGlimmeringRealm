using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area8
{
    internal class WhitePalace13 : Room
    {
        public WhitePalace13() : base("White_Palace_13") { IsFlipped = true; }
        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 105, 212);
        }
    }
}
