using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.City
{
    internal class Temple : Room
    {
        public Temple() : base("Room_Final_Boss_Atrium") { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 241, 6, Quaternion.Euler(0, 0, 100)).transform.SetScaleX(500);
            GameObject.Find("SceneBorder(Clone)").transform.SetPositionX(251);
        }
    }
}
