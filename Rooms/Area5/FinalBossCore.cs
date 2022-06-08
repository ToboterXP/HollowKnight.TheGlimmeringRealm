using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area5
{
    internal class FinalBossCore : Room
    {
        public FinalBossCore() : base("Room_Final_Boss_Core") { MinDamage = 2;  }

        public override void OnBeforeLoad()
        {
            SetDarkness(true);
        }
    }
}
