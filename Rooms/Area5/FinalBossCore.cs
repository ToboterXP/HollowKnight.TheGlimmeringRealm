using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area5
{
    internal class EndingTransitionController : MonoBehaviour
    {
        bool started = false;
        void Update()
        {
            if (!started && GameObject.Find("Boss Corpse") && GameObject.Find("Boss Corpse").LocateMyFSM("Corpse").ActiveStateName == "Idle")
            {
                started = true;
                GameManager.instance.ChangeToScene("Cinematic_Ending_A", "door1", 0);
            }
        }
    }
    //Activates the Dream Transition to the Palace Gardens in the last phase
    internal class DreamTransitionController : MonoBehaviour
    {
        GameObject dreamEntry;
        void Start()
        {
            dreamEntry = Instantiate(Prefabs.DUSK_KNIGHT.Object, transform  );
            dreamEntry.transform.localPosition = Vector3.zero;
            string newEntryScene = "Deepnest_East_13";

            dreamEntry.GetComponent<SpriteRenderer>().enabled = false;
            dreamEntry.transform.GetChild(0).gameObject.SetActive(false);//disable tendrils
            dreamEntry.transform.GetChild(2).gameObject.SetActive(false);
            dreamEntry.transform.GetChild(1).gameObject.SetActive(false);//disable inspect region

            PlayMakerFSM entryControl = dreamEntry.transform.GetChild(3).gameObject.LocateMyFSM("Control");
            entryControl.FsmVariables.FindFsmString("To Scene").Value = newEntryScene;

            dreamEntry.SetActive(false);
        }

        

        void Update()
        {
            if (gameObject.LocateMyFSM("Control").FsmVariables.FindFsmInt("Phase").Value == 4)
            {
                dreamEntry.SetActive(true);
            }
        }
    }

    //because Hollow Knight Boss doesn't exist on load
    internal class DreamTransitionAdder : MonoBehaviour
    {
        bool done = false;
        void Update()
        {
            if (!done)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject go = transform.GetChild(i).gameObject;
                    if (go.name == "Hollow Knight Boss")
                    {
                        done = true;
                        go.AddComponent<DreamTransitionController>();
                    }
                }
            }
        }
    }

    internal class FinalBossCore : Room
    {
        public FinalBossCore() : base("Room_Final_Boss_Core") {  }

        public override void OnBeforeLoad()
        {
            SetDarkness(true);
        }

        public override void OnLoad()
        {
            GameObject.Find("Boss Control").AddComponent<DreamTransitionAdder>();
            GameObject.Find("Boss Control").AddComponent<EndingTransitionController>();
        }



    }
}
