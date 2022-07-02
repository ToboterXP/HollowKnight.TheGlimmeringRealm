using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area7
{
    internal class Edge3 : Room
    {

        public Edge3() : base("Deepnest_East_03") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 4, 101, Quaternion.Euler(0, 0, 90));

        }
    }
}
