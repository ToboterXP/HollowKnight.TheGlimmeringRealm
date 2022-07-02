using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area7
{
    internal class Edge4 : Room
    {
        public Edge4() : base("Deepnest_East_04") { }
        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 14, 3, Quaternion.Euler(0, 0, 90));
        }
    }
}
