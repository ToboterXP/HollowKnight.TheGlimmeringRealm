using ItemChanger;
using ItemChanger.UIDefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village2
{
    internal class Village2 : Room
    {
        public Village2() : base("Village 2") { }

        public override void OnWorldInit()
        {
            SetTransition("Fungus1_02", "left1", "Crossroads_04", "right1");
            //SetTransition("Crossroads_04", "Door1","","");
            //SetTransition("Crossroads_04", "Door_CharmShop", "", "");
            SetTransition("Crossroads_04", "door_Mender_House", "Crossroads_52", "left1");
            SetTransition("Crossroads_04", "left1", "Crossroads_47", "right1");
            SetTransition("Crossroads_04", "top1", "Crossroads_22", "bot1");

            SetItem(LocationNames.Glowing_Womb, ItemNames.Monarch_Wings);

            SetItem(LocationNames.Journal_Entry_Goam, ItemNames.Lurien, alternateName: "Mask of Courage" );

            SetItem(LocationNames.Salubra, ItemNames.Wayward_Compass, true, 10, alternateDesc: "A small compass, spinning aimlessly. Probably completely useless.");
            SetItem(LocationNames.Salubra, ItemNames.Sprintmaster, true, 150, alternateDesc: "A small medal, awarded for the \"Hallownest Marathon 143\"");
            SetItem(LocationNames.Salubra, ItemNames.Spell_Twister, true, 450, alternateDesc: "A glimmering medal, weaving intricate patterns from fine threads of soul when held.");
            SetItem(LocationNames.Salubra, ItemNames.Glowing_Womb, true, 250, alternateDesc: "An effigy of a pregnant Aspid. Something is moving the pouch.");
            SetItem(LocationNames.Salubra, ItemNames.Defenders_Crest, true, 140, alternateDesc: "You have no idea what this is, but it smells like shit.");
            SetItem(LocationNames.Salubra, ItemNames.Crossroads_Stag, true, 105, alternateName: "Forlorn Village Ticket" ,alternateDesc: "A small paper ticket, permitting the wearer to travel to the Forlorn Village via stag");
            SetItem(LocationNames.Crossroads_Stag, ItemNames.Geo_Rock_Default);
        }

        public override void OnInit()
        {
            ReplaceText("CHARMSLUG_MEET_1", "Oooooh, a customer, how delightful! Can I interest you in my charming services?");
            ReplaceText("CHARMSLUG_MEET_2", "You may call me Salubra, and I run this ... ahem ... Charm Shop.<page>Now, what kind of services may I provide to such strapping young bug such as you?");
            ReplaceText("CHARMSLUG_MEET_3A", "You know dear old Gruzmother, up in the old store room?<br>She used to be my business partner. But then she got pregnant, so I had to continue my business alone.<page>A pitty really, she was quite the talent. Send her my regard!");
            ReplaceText("CHARMSLUG_MEET_3B", "A little bug came by a little while ago. Paid quite well, but he seemed slightly dazed afterwards.<page>Too much mushroom wine perhaps? Maybe you'll meet him if you take a look around.");
            ReplaceText("CHARMSLUG_REPEAT", "Ooooh, a repeat customer? Well, my services are always at your ready if you have Geo to spare!");
            ReplaceText("CHARMSLUG_OVERCHARM", "Oh my, such a well decorated fella you are! Surely, you must be a strapping young army bug to collect such a charming collection!");
            ReplaceText("CHARMSLUG_COMBO", "How charming, to meet someone with such an alluring combination of charms on him.<br>You must be an excellent fighter with such distinguished medals on your chest!");
            ReplaceText("CHARMSLUG_NOSTOCK", "Oh dear, oh my! I'm afraid I can't be providing my charming services to you today - a terrible headache, you see?");
            ReplaceText("CHARMSLUG_DREAM", "Oh my, a customer! Maybe that rotund bug who fixed the station actually was right,<br>that traffic would return to the village.<page>A pitty he seemed so uninterested in my services - he looked like he had such skillful hands!");
            ReplaceText("CHARMSLUG_TRUTH", "This village you used to have quite the traffic you know? Travelers coming in and out constantly, on their way to the Glimmering City. But travel has dried up quite a bit it seems, and so has my patronage.<br>I wonder what was responsible for that?");
            ReplaceText("CHARM_SLUG_SUPER", "Charming Hostess");

            ReplaceText("SLY_RESCUE_3", "My name is Sly. I usually run a small store in Dirtmouth, but it gets a little lonely and boring there sometimes, you know.");
            ReplaceText("SLY_RESCUE_REPEAT", "Please don't tell Iselda that you saw me up here. She's such a lovely innocent girl.");
            ReplaceText("SLY_DREAM_RUINS", "My dear Salubra, that was more than enough. Perhaps one day again... one day...");

            ReplaceText("JOURNAL_GOAM", "There's a very pretty mask hanging from the wall. You should probably take it, it's just catching dust down here.");

            ReplaceText("CROSSROADS", "Forlorn Village");
            ReplaceText("MAP_NAME_CROSSROADS", "Forlorn Village");
            ReplaceText("CROSSROADS_SUPER", "Forlorn");
            ReplaceText("CROSSROADS_MAIN", "Village");
            ReplaceText("CROSSROADS_INF_SUPER", "Forlorn");
            ReplaceText("CROSSROADS_INF_MAIN", "Village");
        }
    }
}
