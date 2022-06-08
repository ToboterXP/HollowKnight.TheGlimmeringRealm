using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village1
{
    internal class Iselda : Room
    {
        public static string NAME = "Room_mapper";
        public Iselda() : base(NAME) { }

        public override void OnInit()
        {
            ReplaceText("ISELDA_SUB", "Station Keeper");
            ReplaceText("ISELDA_MEET", "A traveler? Well you're in luck, we've got this fantastic stag network running all throughout the kingdom!<page>Unfortunately, it's mostly broken. Usually.<page>My husband spends most of his time fixing up the old nail signaling system. If you meet him, maybe he'll let you use it.<page>I'm just selling souvenirs these days.");
            ReplaceText("ISELDA_REPEAT", "Are you having a nice time exploring our beautiful, peaceful kingdom?<br>I heard the vegetation is paticularly murderous this time of the year!");
            ReplaceText("ISELDA_DREAM", "I love my husband so much... and the old stag.<br>First place probably going to the stag.");
            ReplaceText("ISELDA_GREET1", "I studied under the head station keeper of the Glimmering City, you know? Station keeping used to be a real job in those days. Now I just sell this stupid stuff, to fund repairs.");
            ReplaceText("ISELDA_CORNIFER_HOME", "Corny is home at last. You should have seen his face, I couldn't even kiss him welcome through the grease. But at least the network seems to be back in reasonable order.<page>I hope it stays that way.");
            ReplaceText("ISELDA_NOSTOCK", "Sorry, I'm all out. Maybe check with the little guy next door, if he's back. Heard he got himself into some trouble on a vacation. He's a good soul. Always complemented my cooking skill.");
        }

        public override void OnWorldInit()
        {
            SetItem(LocationNames.Iselda, ItemNames.Pale_Ore, true, 1000, alternateDesc: "A glimmering chunk of fairly average looking rock. Probably completely unnecessary for your journey.");
            SetItem(LocationNames.Iselda, ItemNames.Hallownest_Seal, true, 320, alternateDesc: "A seal bearing the sigil of the Glimmering City. Held in high regard by some.");
            SetItem(LocationNames.Iselda, ItemNames.Mask_Shard, true, 250, alternateDesc: "A cracked fragment of white, pale shell. Just like your own.");
            SetItem(LocationNames.Iselda, ItemNames.Mask_Shard, true, 150, alternateDesc: "A cracked fragment of white, pale shell. Just like your own.");
            SetItem(LocationNames.Iselda, ItemNames.Vessel_Fragment, true, 400, alternateDesc: "A cracked fragment of white, pale shell. Just like your own.");
            SetItem(LocationNames.Iselda, ItemNames.Lifeblood_Heart, true, 210, alternateDesc: "A small medal, filled with a drop of pulsing blue liquid.");
            SetItem(LocationNames.Iselda, ItemNames.Charm_Notch, true, 310, alternateDesc: "A small carved notch. It looks like it attaches to your belt. Maybe you could use more charms with it?");
        }
    }
}
