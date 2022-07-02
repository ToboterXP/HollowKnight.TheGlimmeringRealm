using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area6
{
    internal class RestingGrounds4 : Room
    {
        public RestingGrounds4() : base("RestingGrounds_04") { }
        public override void OnLoad()
        {
            DestroyGO("Binding Shield Activate");
            DestroyGO("Dreamer Plaque Inspect");
        }
    }
}
