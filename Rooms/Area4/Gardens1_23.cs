using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area4
{
    internal class Gardens1_23 : Room
    {
        public Gardens1_23() : base("Fungus1_23") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 29, 7, Quaternion.Euler(new Vector3(0, 0, 90)));
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 29, 10, Quaternion.Euler(new Vector3(0, 0, 90)));
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 29, 12, Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
