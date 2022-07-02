using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area8
{
    internal class EndingController : MonoBehaviour
    {
        bool started = false;
        void Update()
        {
            GameObject pvCorpse = GameObject.Find("Corpse HK Prime(Clone)");
            if (pvCorpse != null)
            {
                Fsm control = pvCorpse.LocateMyFSM("corpse").Fsm;
                if (!started && control.ActiveStateName == "End Scene")
                {
                    started = true;
                    GameManager.instance.ChangeToScene("Cinematic_Ending_C", "door1", 0);
                }
            }
        }
    }
    internal class PureVessel : Room
    {
        public PureVessel() : base("GG_Hollow_Knight") { }
        public override void OnBeforeLoad()
        {

        }
        public override void OnLoad()
        {
            DestroyGO("Godseeker Crowd");
            GameObject.Find("HK Prime").GetComponent<HealthManager>().hp = 1000;
            GameObject.Find("Boss Scene Controller").AddComponent<EndingController>();
        }
    }
}
