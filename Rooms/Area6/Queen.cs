using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area6
{
    internal class Queen : Room
    {
        public Queen() : base("Room_Queen") { 
            IsFlipped = true;
        }

        public override void OnLoad()
        {
            GameObject.Find("Queen Item").transform.SetScaleX(-1); 
        }
    }
}
