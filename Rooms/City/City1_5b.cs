using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.City
{
    internal class City1_5b : Room
    {
        public City1_5b() : base("Ruins1_05b") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 29, 30);
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 0, 6, Quaternion.Euler(0, 0, 90));
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 0, 8, Quaternion.Euler(0, 0, 90));

            DestroyGO("Ruins Gate 1");
            DestroyGO("Ruins Lever 1");
        }
    }
}
