using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area6
{
    internal class QueenItemComponent : MonoBehaviour
    {
        void Update()
        {
            transform.GetChild(0).SetScaleX(-1.5f);
            foreach (var comp in GetComponentsInChildren<TextMeshPro>())
            {
                if (comp.gameObject.name == "Inspect") comp.transform.SetScaleX(-1);
            }
        }
    }
    internal class Queen : Room
    {
        public Queen() : base("Room_Queen") { 
            IsFlipped = true;
        }

        public override void OnLoad()
        {
            GameObject.Find("Queen Item").AddComponent<QueenItemComponent>();
        }
    }
}
