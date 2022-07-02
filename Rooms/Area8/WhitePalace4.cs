using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area8
{
    internal class WhitePalace4 : Room
    {
        public WhitePalace4() : base("White_Palace_04") { IsFlipped = true; }

        public override void OnLoad()
        {
            GameObject.Find("wp_saw_side_to_side1").GetComponent<Animator>().speed = 0.95f;
            GameObject.Find("saw_still (2)").transform.SetPositionY(44);
        }
    }
}
