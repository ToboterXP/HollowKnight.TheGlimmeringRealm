using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area7
{
    internal class Edge12 : Room
    {
        public Edge12() : base("Deepnest_East_12") { }
        public override void OnLoad()
        {
            DestroyGO("Hornet Encounter Outskirts");
        }
    }
}
