using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area6
{
    internal class Abyss5 : Room
    {
        public Abyss5() : base("Abyss_05") { }
        public override void OnLoad()
        {
            DestroyGO("Dusk Knight");
        }
    }
}
