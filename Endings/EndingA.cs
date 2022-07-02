using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

namespace HKSecondQuest.Endings
{
    internal class CutsceneChanger : MonoBehaviour
    {
        bool changed = false;
        public string Cutscene;
        void Update()
        {
            if (!changed && GetComponent<VideoPlayer>())
            {
                changed = true;
                string dir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Cutscenes", Cutscene);
                GetComponent<VideoPlayer>().Stop();
                GetComponent<VideoPlayer>().url = dir;
                GetComponent<VideoPlayer>().aspectRatio = VideoAspectRatio.FitInside;
                GetComponent<VideoPlayer>().Play(); 
            }
        }
    }
    internal class EndingA : Room
    {
        public EndingA() : base("Cinematic_Ending_A") { } 

        public override void OnLoad()
        {
            GameObject.Find("Cinematic Player").AddComponent<CutsceneChanger>().Cutscene = "Ending1.mp4";
        }
    }
}
