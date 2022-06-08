using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area4
{
    internal class Greenpath_26 : Room
    {
        public Greenpath_26() : base("Fungus1_26") { IsFlipped = true; }

        public override void OnBeforeLoad()
        {
            HKSecondQuest.Instance.RoomMirrorer.AddExcludedObject("Inspect");
        }
    }
}
