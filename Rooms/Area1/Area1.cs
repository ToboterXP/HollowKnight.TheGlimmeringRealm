using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;

namespace HKSecondQuest.Rooms.Area1
{
    //overarching class for changes to the first area
    internal class Area1 : Room
    {
        public Area1() : base("Area 1") { }

        public override void OnInit()
        {
            //change area name
            ReplaceText("MINES_SUB", "Depths");

            //override Quirrel dialog in mines
            ReplaceText("QUIRREL_MINES_1", "Oh, a fellow traveler. How nice to meet a friendly face in these hostile tunnels.");
            ReplaceText("QUIRREL_MINES_2", "These caves are quite the attraction, aren't they? Though the miners seem less than hospitable.<page>I wonder what befell them?");
            ReplaceText("QUIRREL_MINES_3", "But then again, I'm not sure what everyone would need all these crystals for anyways.<br>They don't seem terribly useful.");
            ReplaceText("QUIRREL_MINES_4", "Perhaps they are absolutely crazy for crystaline wine glasses?");

            //override Cornifer dialog in cliffs
            ReplaceText("CORNIFER_ISELDA", "My wife is the station master of Dirtmouth, you know? If you drop by, send her my regards!");
            ReplaceText("CLIFFS_GREET", "Good morning, quite a place to be meeting someone, isn't it?<page>Since you're out here all alone, might I interest you in a ticket for the local stag station?");
            ReplaceText("CORNIFER_REFUSE", "Not interested? A pitty, the stags are a real marvel. If you're nice, they'll even let you pet them.");
            ReplaceText("CLIFFS_BOUGHT", "If you're looking for respite, there's a small hut further up. Friendly guy. Used to be a cook.");
            ReplaceText("CORNIFER_AGAIN", "Oh, back again? Might I interest you in a ticket after all?");
            ReplaceText("CORNIFER_NOT_ENOUGH", "Not enough money? I thought so, that's probably the reason why no one is using it anymore. Too expensive, you see? But maintenance is costly.");
            ReplaceText("CORNIFER_INTRO_1", "Oh dear, I haven't even introduced myself, have I? The name's Cornifer. I'm an engineer for the stag network.<br>The only one left by now, probably. I'm currently on a journey to repair the stations out here, they are in quite a state, you know?");
            ReplaceText("CORNIFER_INTRO_2", "Orders from the head stag masters are really getting sparse these days. No idea why, they used to be so hectic all the time. Couldn't happen to me if I tried.");
            ReplaceText("DREAM", "Being an engineer really is the best profession, isn't it?<br>Although I always wanted to be a cartographer. We'll see.");
            ReplaceText("CORNIFER_SUB", "The Engineer");
            ReplaceText("CORNIFER_MEET", "Quite a place to be meeting someone, isn't it?<page>Since you're out here all alone, might I interest you in a ticket for Dirtmouth station?");

            ReplaceText("MATO_REFUSE", "Fair enough, come back later if you're interested.");
            ReplaceText("MATO_REPEAT", "Charms are really rewarding to make! It's a shame it's a dying art.");
            ReplaceText("MATO_ART", "Ah, you're back, are you interested in one of my charms now?");
            ReplaceText("MATO_SHEO", "Oh, you met my brother, the old artist? I always thought he was too ambitious with his art. Never taking a moment to relax.");
            ReplaceText("MATO_BOW", "Best of luck!");
            ReplaceText("MATO_GREET", "Oh, it's my little customer! How is my old charm coming along?");
            ReplaceText("MATO_DREAM", "Maybe I should pay a visit to the old village at the foot of the hill again?<page>But no... they'll just be staring at me, as usual.");
            ReplaceText("MATO_SLY", "That's a truly exquisit little charm you are wearing there! Where did you get it? The village to the west? ... Perhaps I'll have to pay them a visit at some point...");
            ReplaceText("MATO_MEET", "Oh, a visitor! That's quite unusual, all the way up here. Unless you count the bugs that try to kill you, of course.<page>I make little charms as a hobby, do you want one?");
            ReplaceText("MATO_TAUGHT", "I hope you'll have much success with my little charm! Just polish it regularly with some Durandoo fat!");
            ReplaceText("NM_MATO_SUPER", "Charm Maker");

            ReplaceText("CLIFF_TAB_02", "Please do not scale the outer walls. It is ill advised, and the archers may shoot you on sight.");
            ReplaceText("CLIFFS_SUPER", "Outer");
            ReplaceText("CLIFFS_MAIN", "Fortifications");

            ReplaceText("MINES", "Crystal<br>Depths");
            ReplaceText("CLIFFS", "Outer<br>Fortifications");
            ReplaceText("PEAK_MAIN", "Altar");
            ReplaceText("PEAK_SUPER", "Ruined");

            ReplaceText("STAG_NEST", "???", "StagMenu");
            ReplaceText("STAG_EGG_INSPECT", "An empty eggshell. Someone had a delicious breakfast.<page>Probably Leg Eater.");
        }

        public override void OnWorldInit()
        {
            //transitions
            SetTransition("Cliffs_01", "right1", "Cliffs_02", "left1");
            SetTransition("Cliffs_01", "right2", "Mines_05", "left1");
            SetTransition("Cliffs_01", "right4", "Mines_05", "left2");
            SetTransition("Cliffs_01", "right3", "Mines_05", "bot1");

            SetTransition("Mines_05", "top1", "Mines_17", "left1");
            SetTransition("Mines_05", "right1", "Mines_02", "left1");

            SetTransition("Mines_17", "right1", "Mines_23", "left1");

            SetTransition("Mines_02", "top1", "Mines_13", "bot1");
            SetTransition("Mines_13", "right1", "Mines_18", "left1");
            SetTransition("Mines_18", "right1", "Mines_20", "left1");

            SetTransition("Mines_02", "top2", "Mines_20", "left2");
            SetTransition("Mines_02", "right1", "Mines_20", "left3");

            SetTransition("Cliffs_02", "bot1", "Mines_23", "top1");
            SetTransition("Cliffs_02", "bot2", "Mines_23", "top1", true);
            SetTransition("Mines_20", "right1", "Mines_36", "right1");
            SetTransition("Mines_20", "right2", "Mines_30", "left1");

            SetTransition("Cliffs_02", "right1", "Mines_34", "left1");
            SetTransition("Mines_23", "right1", "Fungus3_49", "right1");

            //place items
            SetItem(LocationNames.Kings_Idol_Cliffs, ItemNames.Geo_Rock_Default);
            SetItem(LocationNames.Howling_Cliffs_Map, ItemNames.Dirtmouth_Stag);
            SetItem(LocationNames.Cyclone_Slash, ItemNames.Longnail);
            SetItem(LocationNames.Wanderers_Journal_Crystal_Peak_Crawlers, ItemNames.Quick_Focus);
            SetItem(LocationNames.Deep_Focus, ItemNames.Crystal_Heart);
            SetItem(LocationNames.Pale_Ore_Crystal_Peak, ItemNames.Howling_Wraiths);
            SetItem(LocationNames.Mask_Shard_Enraged_Guardian, ItemNames.Mask_Shard);
            SetItem(LocationNames.Vessel_Fragment_Stag_Nest, ItemNames.Quick_Slash);
        }
    }
}
