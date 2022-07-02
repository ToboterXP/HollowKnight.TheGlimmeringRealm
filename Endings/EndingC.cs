using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Endings
{
    internal class EndingC : Room
    {
        public EndingC() : base("Cinematic_Ending_C") { }

        public override void OnLoad()
        {
            GameObject.Find("Cinematic Player").AddComponent<CutsceneChanger>().Cutscene = "Ending2.mp4";

        }
    }
}
