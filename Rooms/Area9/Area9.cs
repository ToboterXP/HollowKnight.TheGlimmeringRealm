using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area9
{
    class Area9 : Room
    {
        public Area9() : base("Area 9") { }

        public override void OnWorldInit()
        {
            SetTransition("Ruins1_05b", "left1", "Ruins1_01", "left1");
            SetTransition("Ruins1_01", "bot1", "Waterways_01", "top1");
            SetTransition("Waterways_01", "bot1", "Deepenest_35", "top1");
            SetTransition("Deepenest_35", "left1", "Deepnest_36", "left1");
            SetTransition("Deepenest_35", "bot1", "Fungus3_01", "top1");
            SetTransition("Fungus3_01", "right2", "Waterways_13", "left1");
            SetTransition("Waterways_13", "left2", "Crossroads_50", "left1");
            SetTransition("Crossroads_50", "right1", "Fungus2_06", "left2");
        }
    }
}
