using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area7
{
    internal class Area7 : Room
    {
        public Area7() : base("Area 7") { Revision = 2; }

        public override void OnWorldInit()
        {
            SetTransition("Deepnest_East_13", "bot1", "Deepnest_East_06", "top1");
            SetTransition("Deepnest_East_06", "left1", "Deepnest_East_04", "right1");
            SetTransition("Deepnest_East_06", "door1", "Deepnest_East_17", "left1");
            SetTransition("Deepnest_East_06", "right1", "Deepnest_East_14b", "right1");
            SetTransition("Deepnest_East_14b", "top1", "Deepnest_East_12", "right1");
            SetTransition("Deepnest_East_12", "left1", "Deepnest_East_08", "right1");
            SetTransition("Deepnest_East_08", "top1", "Deepnest_East_03", "right2");
            SetTransition("Deepnest_East_03", "left2", "Deepnest_East_04", "right2");
            SetTransition("Deepnest_East_04", "left2", "Deepnest_East_15", "left1");

            SetItem(LocationNames.Wanderers_Journal_Kingdoms_Edge_Camp, ItemNames.Soul_Totem_B);
            SetItem(LocationNames.Quick_Slash, ItemNames.Mask_Shard);
            SetItem(LocationNames.Wanderers_Journal_Kingdoms_Edge_Entrance, ItemNames.Hallownest_Seal);
            SetItem(LocationNames.Kingdoms_Edge_Map, ItemNames.Mask_Shard, geoCost: 150);
            SetItem(LocationNames.Wanderers_Journal_Kingdoms_Edge_Requires_Dive, ItemNames.Dreamshield);
        }

        public override void OnInit()
        {
            //Bardoon Text
            ReplaceText("BIG_CATERPILLAR_SUPER", "Dream Worm");
            ReplaceText("BIGCAT_INTRO", "Huu, another one who wanders dreams. Sit with me and chat a little, will you?");
            ReplaceText("BIGCAT_KING_BRAND", "You see, I am a Dream Worm. Like a book worm wanders through the pages of the books in a library, I wander through the dreams of the world.");
            ReplaceText("BIGCAT_TALK_01", "I see you carry an instrument to enter dreams yourself. But how crudely made.");
            ReplaceText("BIGCAT_TALK_02", "When our kind roamed the material plane, we used to be hunted for our bones. They carved them into powerful weapons like the one you wield. <page>Now we rarely leave the safety of dreams.");
            ReplaceText("BIGCAT_TALK_03", "I wonder whose dream this is? How powerful they must be, to dream such grand a place, and how tortured, that all these hideous beasts invaded these gardens.");
            ReplaceText("BIGCAT_REPEAT", "Have you seen the thick patches of white flowers growing everywhere? True beauty...");
            ReplaceText("BIGCAT_TAIL_HIT", "You hit my tail? Oh, my tail that is not. Another must have passed by, burrowing somewhere else now.");
            ReplaceText("BIGCAT_DREAM", "Your little toothpick is no match for me. Leave it.");

            //Cornifer
            ReplaceText("OUTSKIRTS_GREET", "Oh dear, the Mask Makers mob is coming ever closer. They baricaded the gate, but I hear there's a lot of fighting.<page>I hope I'll be safe here. If not I'll flee deeper into the waterways. Those bastards already cut the signaling wires to the palace. They'll take ages to replace!<page>Oh, by the way, on my way through these pipes I found this. Would you be interested?");
            
            //Area text
            ReplaceText("OUTSKIRTS", "Palace Gardens");
            ReplaceText("OUTSKIRTS_SUPER", "Blooming");
            ReplaceText("OUTSKIRTS_MAIN", "Palace Gardens");
        }
    }
}
