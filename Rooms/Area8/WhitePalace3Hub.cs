using GlobalEnums;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area8
{
    internal class PVGate : MonoBehaviour
    {
        bool startedTransition = false;
        public static GameObject pvStatue;


        private void OnTriggerEnter2D(Collider2D movingObj)
        {
            if (!startedTransition && movingObj.gameObject.layer == 9 && GameManager.instance.gameState == GameState.PLAYING)
            {
                startedTransition = true;
                Fsm statueControl = pvStatue.transform.GetChild(0).gameObject.LocateMyFSM("GG Boss UI").Fsm;

                statueControl.GetState("Take Control").Transitions[0].ToFsmState = statueControl.GetState("Impact");
                statueControl.Variables.FindFsmString("Return Scene").Value = "White_Palace_03_hub";
                statueControl.Variables.FindFsmString("To Scene").Value = "GG_Hollow_Knight";
                statueControl.SetState("Take Control");


            }
        }
    }

    internal class WhitePalace3Hub : Room
    {
        GameObject pvStatue;
        public WhitePalace3Hub() : base("White_Palace_03_hub") { }

        public override void OnBeforeLoad()
        {
            pvStatue = PlaceGO(Prefabs.PURE_VESSEL_STATUE.Object, 56, 46);
            pvStatue.transform.GetChild(7).gameObject.name = "door_dreamReturn";
            PlayerData.instance.statueStateHollowKnight = new BossStatue.Completion { isUnlocked = true, hasBeenSeen = true };
            
            PVGate.pvStatue = pvStatue; 
             
        }
        public override void OnLoad()
        {
            PlaceGO(Prefabs.WHITE_PALACE_LEVER.Object, 7.9f, 97.4f);
            pvStatue.transform.GetChild(0).gameObject.LocateMyFSM("npc_control").enabled = false;
            pvStatue.transform.GetChild(0).gameObject.SetActive(true);
            pvStatue.transform.GetChild(1).gameObject.LocateMyFSM("inspect_region").enabled = false;

            GameObject gate = GameObject.Find("top1");
            GameObject.Destroy(gate.GetComponent<TransitionPoint>());
            GameObject.Destroy(gate.GetComponent<GateSnap>());
            gate.AddComponent<PVGate>(); 

            GameObject.Find("top1").transform.position = new Vector3(53, 104, 0);
        }
    }
}
