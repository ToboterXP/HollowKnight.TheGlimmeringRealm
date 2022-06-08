using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.City
{
    internal class City2_10b : Room
    {
        public City2_10b() : base("Ruins2_10b") { IsFlipped = true; }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 28, 138, Quaternion.Euler(0, 0, 90));
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 28, 140, Quaternion.Euler(0, 0, 90));
        }
    }
}
