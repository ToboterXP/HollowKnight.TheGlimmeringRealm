using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area6
{
    internal class Abyss4 : Room
    {
        public Abyss4() : base("Abyss_04") { }
        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 55, 9.5f, Quaternion.Euler(0, 0, 90));
        }
    }
}
