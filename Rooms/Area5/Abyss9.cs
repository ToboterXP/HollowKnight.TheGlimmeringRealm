using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area5
{
    internal class Abyss9 : Room
    {
        public Abyss9() : base("Abyss_09") { }

        public override void OnBeforeLoad()
        {
            SetDarkness(true);
            
            //spawn shade from final boss here
            if (HeroController.instance.playerData.shadeScene == "Room_Final_Boss_Atrium")
            {
                HeroController.instance.playerData.shadeScene = "Abyss_09";
                HeroController.instance.playerData.shadePositionX = 240;
                HeroController.instance.playerData.shadePositionY = 26;
            }
        }
    }
}
