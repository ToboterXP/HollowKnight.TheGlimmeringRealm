using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area8
{
    internal class WhitePalace11 : Room
    {
        public WhitePalace11() : base("White_Palace_11") { }

        public override void OnBeforeLoad()
        {
            GameObject left1 = PlaceGO(Prefabs.LEFT_TRANSITION.Object, 11, 18, Quaternion.identity);
            left1.SetActive(true);
            left1.name = "left1";
            left1.transform.GetChild(2).gameObject.SetActive(false);
        }

        public override void OnLoad()
        {
            DestroyGO("dream_nail_base");
            DestroyGO("dream_beam_animation");
            DestroyGO("doorWarp");
        }
    }
}
