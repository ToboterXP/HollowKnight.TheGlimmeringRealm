using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.City
{
    internal class Crossroads10 : Room
    {
        public Crossroads10() : base("Crossroads_10") { MinDamage = 10; }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 2, 4, Quaternion.Euler(0, 0, 90));
        }
    }
}
