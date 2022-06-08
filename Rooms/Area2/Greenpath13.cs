using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Modding.Utils;

namespace HKSecondQuest.Rooms.Area2
{
    internal class Greenpath13 : Room
    {
        public static string NAME = "Fungus1_13";
        public Greenpath13() : base(NAME) { }

        public override void OnLoad() 
        {
            GameObject.Destroy(GameObject.Find("Vine Platform (1)"));
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 99, 18);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 59, 13);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 63, 18);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 68, 26);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 65, 30);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 67, 34);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 74, 14);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 94, 10);
        }
    }
}
