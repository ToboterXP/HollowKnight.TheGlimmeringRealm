using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area6
{
    internal class RestingGrounds2 : Room
    {
        public RestingGrounds2() : base("RestingGrounds_02") { IsFlipped = true; }
        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 127, 6, Quaternion.Euler(0, 0, 90));
        }
    }
}
