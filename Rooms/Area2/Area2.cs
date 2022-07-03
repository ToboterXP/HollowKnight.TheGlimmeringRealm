using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area2
{
    internal class Area2 : Room
    {
        public Area2() : base("Area 2") { }

        public override void OnInit()
        {
            //Cornifer
            ReplaceText("MINES_GREET", "Ah, heading deeper into the kingdom? There's a stag station further up, I just replaced the gate pullies.<br>Interested in a ticket?");
            ReplaceText("MINES_BOUGHT", "Good travels! Oh, and be gentle with the station's bell, it's almost coming apart and you can't imagine how difficult it is to get some proper brass these days.");

            ReplaceText("GREEN_TABLET_03", "Looking for gardener<br>Must be of reputable standing, and experienced with murdering shrubbery.<br><br>Pay 30 geo per hour");
            ReplaceText("GREEN_TABLET_05", "Visit Unn's flower shop, now!<br>Discounts on all flesh eating plants!<br>Take two, get two for free!");
            ReplaceText("GREEN_TABLET_07", "Keep off the pasture. It's full of Durandoo dung.");
            ReplaceText("GREEN_TABLET_02", "Elderly mossknight seeks Vengefly<page>Bush trimming experience required<page>Paid in exposure");


            ReplaceText("GREENPATH_MAIN", "Overgrown");
            ReplaceText("GREENPATH_SUB", "Pastures");
            ReplaceText("GREENPATH", "Overgrown Pastures");
            ReplaceText("GREEN_PATH", "Overgrown Pastures");
        }

        public override void OnWorldInit()
        {
            SetTransition("Mines_23", "right2", "Fungus1_13", "left1");
            SetTransition("Mines_30", "right1", "Fungus1_31", "bot1");
            SetTransition("Fungus1_13", "right1", "Fungus1_21", "left1");
            SetTransition("Fungus1_31", "top1", "Fungus1_21", "bot1");
            SetTransition("Fungus1_31", "right1", "Fungus1_07", "left1");
            SetTransition("Fungus1_07", "top1", "Fungus1_32", "bot1");
            SetTransition("Fungus1_21", "right1", "Fungus1_32", "left1");
            SetTransition("Fungus1_21", "top1", "Fungus1_05", "bot1");
            SetTransition("Fungus1_05", "right1", "Fungus1_37", "left1"); 
            SetTransition("Fungus1_32", "top1", "Fungus1_22", "bot1");
            SetTransition("Fungus1_22", "left1", "Fungus1_16_alt", "right1");
            SetTransition("Fungus1_05", "top1", "Fungus1_03", "bot1");
            SetTransition("Fungus1_03", "left1", "Fungus1_02", "right2");
            SetTransition("Fungus1_03", "right1", "Fungus1_29", "left1");
            SetTransition("Fungus1_29", "right1", "Fungus1_19", "left1");
            SetTransition("Fungus1_19", "bot1", "Fungus1_22", "top1");

            SetItem(LocationNames.Vessel_Fragment_Greenpath, ItemNames.Charm_Notch);
            SetItem(LocationNames.Grub_Greenpath_MMC, ItemNames.Wanderers_Journal);
            SetItem(LocationNames.Grub_Greenpath_Journal, ItemNames.Wanderers_Journal);
            SetItem(LocationNames.Grub_Greenpath_Stag, ItemNames.Vessel_Fragment);
            SetItem(LocationNames.Wanderers_Journal_Greenpath_Stag, ItemNames.Grub);
            SetItem(LocationNames.Greenpath_Stag, ItemNames.Geo_Rock_Default);

            SetItem(LocationNames.Crystal_Peak_Map, ItemNames.Greenpath_Stag);
        }
    }
}
