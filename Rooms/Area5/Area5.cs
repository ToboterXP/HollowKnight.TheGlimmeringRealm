using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area5
{
    internal class Area5 : Room
    {
        public Area5() : base("Area 5") { }

        public override void OnWorldInit()
        {
            SetTransition("Abyss_09", "right1", "Room_Final_Boss_Core", "left1");

            SetItem(LocationNames.Abyss_Shriek, ItemNames.World_Sense);
            SetItem(LocationNames.Geo_Rock_Abyss_1, ItemNames.Arcane_Egg);
        }

        public override void OnInit()
        {
            ReplaceText("ABYSS_TUT_TAB_01", "Here lies the mad old king! Nobody may enter, on accounts of him being mad and old!<br><br>King Mask Maker");
            ReplaceText("HOLLOW_KNIGHT_MAIN", "Fallen King");
        }
    }
}
