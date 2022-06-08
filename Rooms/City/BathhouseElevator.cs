using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.City
{
    internal class BathhouseElevator : Room
    {
        public BathhouseElevator() : base("Ruins_Elevator") { }

        public override void OnLoad()
        { 
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 66, 98, Quaternion.Euler(0, 0, 90));
        }
    }
}
