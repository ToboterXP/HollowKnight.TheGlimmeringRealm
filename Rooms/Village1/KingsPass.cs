using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village1
{
    internal class KingsPass : Room
    {
        public static string NAME = "Tutorial_01";
        public KingsPass() : base(NAME) { }

        public override void OnWorldInit()
        {
            SetItem(LocationNames.Fury_of_the_Fallen, ItemNames.Rancid_Egg);

        }

        public override void OnInit()
        {
            HKSecondQuest.Instance.TextChanger.AddReplacement("TUT_TAB_01", "Welcome, traveler<br>You are now approaching the gates<br>Be mindful of queue times");
            HKSecondQuest.Instance.TextChanger.AddReplacement("TUT_TAB_02", "The King of Light welcomes you, Traveler<br>His blessing is with you while you obey his law<br><page>Now step forth, into the glory of his creation<br><br>The Glimmering Realm");
            HKSecondQuest.Instance.TextChanger.AddReplacement("TUT_TAB_03", "Western Guard House<br>Only authorized bugs may enter<br><br>--Signed: Guard Captain Jinn");
        }

        public override void OnLoad()
        {
        }
    }
}
