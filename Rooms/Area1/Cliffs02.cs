using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area1
{
    internal class Cliffs02 : Room
    {
        public static string NAME = "Cliffs_02";
        public Cliffs02() : base(NAME) { }

        public override void OnLoad()
        {
            PlaceGO(Prefabs.SMALL_PLATFORM.Object, 41, 26);

            Transform hero = HeroController.instance.transform;
            if (hero.GetPositionX() >= 205) hero.SetPositionY(30); //In case the player dashes in from the crown
        }
    }
}
