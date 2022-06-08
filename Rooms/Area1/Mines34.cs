using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Mines34 : Room
    {
        public Mines34() : base("Mines_34") { }

        public override void OnLoad()
        {
            HeroController.instance.gameObject.transform.SetPositionY(56);
            PlaceGO(Prefabs.LARGE_PLATFORM.Object, 139.5f, 45).transform.SetScaleX(1.3f);
        }
    }
}
