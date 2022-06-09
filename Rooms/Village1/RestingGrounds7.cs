using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Modding;
using HutongGames.PlayMaker;

namespace HKSecondQuest.Rooms.Village1
{
    internal class RestingGrounds7 : Room
    {
        public RestingGrounds7() : base("RestingGrounds_07") { }

        public override void OnLoad()
        {
            GameObject.Find("Lore Tablet-Seer").SetActive(false);

            Fsm fsm = GameObject.Find("Dream Moth").LocateMyFSM("Conversation Control").Fsm;
            fsm.GetState("Reward 2").Transitions[0].ToFsmState = fsm.GetState("Talk Finish");
        }
    }
}
