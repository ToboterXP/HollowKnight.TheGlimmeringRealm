using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area4
{
    internal class SlugShrine : Room
    {
        public SlugShrine() : base("Room_Slug_Shrine") {}

        public override void OnBeforeLoad()
        {
            GameObject.Find("Quirrel Slug Shrine").LocateMyFSM("deactivate").enabled = false;
        }
    }
}
