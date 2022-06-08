using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Village1
{
    internal class RestingGrounds7 : Room
    {
        public RestingGrounds7() : base("RestingGrounds_07") { }

        public override void OnLoad()
        {
            GameObject.Find("Lore Tablet-Seer").SetActive(false);
        }
    }
}
