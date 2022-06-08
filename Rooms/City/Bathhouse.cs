using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.City
{
    internal class Bathhouse : Room
    {
        public Bathhouse() : base("Ruins_Bathhouse") { }

        public override void OnLoad()
        {
            /*PlaceGO(Prefabs.LARGE_PLATFORM.Object, 72, 35, Quaternion.Euler(0, 0, 90));
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 72, 33, Quaternion.Euler(0, 0, 90));*/
        }
    }
}
