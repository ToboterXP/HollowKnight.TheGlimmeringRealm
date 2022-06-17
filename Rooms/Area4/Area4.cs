using ItemChanger;
using ItemChanger.Locations;
using ItemChanger.UIDefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area4
{
    internal class Area4 : Room
    {
        public Area4() : base("Area 4") { }

        public override void OnWorldInit()
        {
            SetTransition("Ruins2_10b", "right2", "Fungus3_22", "right1");
            SetTransition("Fungus3_22", "left1", "Fungus1_23", "right1");
            SetTransition("Fungus1_23", "left1", "Fungus2_05", "right1");
            SetTransition("Fungus3_22", "bot1", "Fungus3_11", "left1");
            SetTransition("Fungus3_11", "left2", "Fungus3_08", "right1");
            SetTransition("Fungus3_08", "left1", "Fungus2_11", "right1");
            SetTransition("Fungus3_11", "right1", "Deepnest_43", "left1");
            SetTransition("Deepnest_43", "right1", "Fungus1_26", "right1");

            //Create Mantis Claw Location
            AbstractLocation loc = new CoordinateLocation() { x = 58, y = 25, elevation = 0, name="newMantisClaw", sceneName="Fungus1_26" };
            AbstractPlacement pmt = loc.Wrap();
            AbstractItem item = Finder.GetItem(ItemNames.Mantis_Claw);
            ((MsgUIDef)item.UIDef).name = new BoxedString("Fisherman's Hook");
            pmt.Add(item);
            ItemChangerMod.AddPlacements(new AbstractPlacement[] { pmt });

            SetItem(LocationNames.Grub_Queens_Gardens_Top, ItemNames.Hallownest_Seal);
        }

        public override void OnInit()
        {
            ReplaceText("ROYAL_GARDENS_SUPER", "Mantis");
            ReplaceText("ROYAL_GARDENS_MAIN", "Ranch");
            ReplaceText("ROYAL_GARDENS", "Mantis Ranch");
            ReplaceText("ACID_LAKE", "Fisherman's Abode");
            ReplaceText("ACID_LAKE_SUPER", "Fisherman's");
            ReplaceText("ACID_LAKE_MAIN", "Abode");

            //Quirrel
            ReplaceText("QUIRREL_GREENPATH_1", "Oh, we meet again! This really is a lovely corner in this hostile kingdom, isn't it?<page>I came here after a weird little fella in the plantations tried to sneak up on me and steal my shoe laces.<page>Have you met him yet?");
            ReplaceText("QUIRREL_GREENPATH_2", "I think this will be the last time we meet. I'm feeling a strange pull eastward. Far, far away...");
            ReplaceText("QUIRREL_GREENPATH_3", "Perhaps it's one of the other fallen kingdoms calling? The Land of Storms maybe? Or Hallownest?");
            ReplaceText("QUIRREL_GREENPATH_REPEAT", "Maybe you can feel it too? Maybe you will follow it as well?");
        }
    }
}
