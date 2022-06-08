using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Cliff01 : Room
    {
        public static string NAME = "Cliffs_01";

        public Cliff01() : base(NAME) {}

        public override void OnInit()
        {

        }

        public override void OnWorldInit()
        {
        }

        public override void OnBeforeLoad()
        {
            //Add left transition
            GameObject left1 = GameObject.Instantiate(Prefabs.LEFT_TRANSITION.Object, new Vector3(21, 4, 0), Quaternion.identity);
            left1.transform.SetScaleY(1000);
            left1.SetActive(true);
            left1.name = "left1";
            left1.transform.GetChild(2).gameObject.SetActive(false);
        }

        public override void OnLoad()
        {
            //Add helper plats
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 79, 28);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 80, 40);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 63, 44);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 91, 60);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 102, 72);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 73, 88);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 53, 109);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 80, 128);
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 69, 132);
        }
    }
}
