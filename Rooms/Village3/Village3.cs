using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village3
{
    internal class Village3 : Room
    {
        public Village3() : base("Village 3") { }

        public override void OnWorldInit()
        {
            SetTransition("Deepnest_43", "bot1", "Deepnest_10", "right1");
            SetTransition("Fungus1_07", "right1", "Crossroads_46", "left1");
            SetTransition("Crossroads_46b", "right1", "Deepnest_10", "right2");
            SetTransition("Deepnest_10", "right3", "Abyss_06_Core", "top1");

            SetTransition("Deepnest_10", "door1", "Deepnest_41", "left2");
            SetTransition("Deepnest_41", "left1", "Room_Jinn", "left1");
            SetTransition("Deepnest_41", "right1", "Deepnest_32", "left1");

            SetTransition("Deepnest_10", "door2", "Deepnest_30", "left1");
            SetTransition("Deepnest_30", "right1", "Deepnest_45_v02", "left1");

            SetItem(LocationNames.Pale_Ore_Nosk, ItemNames.Herrah, alternateName: "Mask of Power");
            SetItem(LocationNames.Rancid_Egg_Weavers_Den, ItemNames.Stag_Nest_Stag, alternateName: "???");
            SetItem(LocationNames.Weaversong, ItemNames.Simple_Key);
            SetItem(LocationNames.Geo_Chest_Weavers_Den, ItemNames.Grub);
        }

        public override void OnInit()
        {
            ReplaceText("DISTANT_VILLAGE", "Den of Twilight");
            ReplaceText("DEEPNEST", "Cocooned Inn");
            ReplaceText("SPIDER_VILLAGE_SUPER", "Den of");
            ReplaceText("SPIDER_VILLAGE_MAIN", "Twilight");
            ReplaceText("WEAVERS_DEN_SUPER", "Cocooned");
            ReplaceText("WEAVERS_DEN_MAIN", "Inn");

            ReplaceText("MIDWIFE_MAIN", "The Mayoress");
            ReplaceText("SPIDER_MEET", "Weeeelcome! Isn't this a quaint little villageee? Sooo peaceful, far away from the kingdom's toils and troubles! You simply must meet my husband upstairs, he's a true gourmand! <page>... though perhaps I might have a little bite as well?");
            ReplaceText("SPIDER_GREET", "Oh I simply must apologize, my mannerssss! The traders from the City haven't come by in a loooong time... Everyone here is absolutely starving!");
            ReplaceText("SPIDER_REPEAT", "The new kinggg locked someone in the tunnels below, long agooo! We neveer go therrrre. Even when the hunger grooows... too large...");
            ReplaceText("SPIDER_GREET2", "Aaaah, the keeeey to below?! Keeep your fingers from there. Nothing good will come of it! I must stop you!"); //only after kings brand
            ReplaceText("SPIDER_DREAM", "When was the last time I've eaten? As a mayoress I should live like a queen!");

            ReplaceText("JINN_SUPER", "Famished Lodger");
            ReplaceText("JINN_MAIN", "Jinn");
            ReplaceText("JINN_MEET", "Huh, a little man! Another lodger perhaps? Or a trader? I will pay for food, any food!");
            ReplaceText("JINN_RETURN", "Ah, the little man returns! Has it met the mayor and his wife yet?");
            ReplaceText("JINN_TALK_01", "You should really meet the mayor and his wife. They are quite delightful... although being inedible helps in that regard.");
            ReplaceText("JINN_TALK_02", "The mayor is an absolute blast at charades night, let me tell you. You can hardly tell it's him!");
            ReplaceText("JINN_TALK_03", "I was a guard at the King's Pass once. But then the king started going mad, so I left and went here. It's much nicer here.");
            ReplaceText("JINN_TALK_GENERIC", "I heard the mayor is guarding something important for the new king. But he hasn't told me what.");

            ReplaceText("JINN_OFFER", "That smell... may I eat EGG?!");
            ReplaceText("JINN_ACCEPT", "I will feast on this beautiful egg! Thank you so much!");
            ReplaceText("JINN_ACCEPT_REPEAT", "My stores... they grow... soon I may start an egg-emporium!");
            ReplaceText("JINN_NOEGG", "You have no food... how disappointing. Perhaps stay and chat a little?");
            ReplaceText("JONN_NOEGG_REPEAT", "Still no food... but maybe another chat?");
            ReplaceText("JINN_REFUSE", "You need food yourself? That's okay... you look very thin.");
            ReplaceText("JINN_REOFFER", "Are you offering me egg again?");
            
            ReplaceText("JINN_DREAM", "Such a quiet place... such nice company... what else is there to want in life?");
            
            ReplaceText("JINN_KING_BRAND", "You have the key to down below? Tread carefully. The mad king is waiting.");

            ReplaceText("MIMIC_SPIDER_MAIN", "The Mayor");
        }
    }
}
