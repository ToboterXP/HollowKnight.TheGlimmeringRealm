using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Village1
{
    internal class Crossroads38 : Room
    {
        public Crossroads38() : base("Crossroads_38") { }

        public override void OnLoad()
        {
            GameObject.Find("Lore Tablet-Grubfather").SetActive(false);
        }
    }
}
