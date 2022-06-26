using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Area7
{
    internal class Edge13 : Room
    {
        public Edge13() : base("Deepnest_East_13") { }
        public override void OnBeforeLoad()
        {
            GameObject dreamEntrance = PlaceGO(Prefabs.WHITE_PALACE_ENTRANCE.Object, 27, 10);
            dreamEntrance.GetComponent<TransitionPoint>().name = "door1";
            dreamEntrance.SetActive(true);

            PlaceGO(Prefabs.DREAM_ENTRY.Object, 30, 10).name = "Dream Entrance";
        }

        public override void OnLoad()
        {
            DestroyGO("RestBench");
            DestroyGO("outskirts__0005_camp (1)");
            DestroyGO("outskirts__0002_camp");
            GameObject.Find("Soul Totem-Wanderer's_Journal-Kingdom's_Edge_Camp").transform.SetPositionZ(0.1f);
        }
    }
}
