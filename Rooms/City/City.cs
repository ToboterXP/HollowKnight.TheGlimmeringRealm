using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.City
{
    internal class City : Room
    {
        public City() : base("City") { }

        public override void OnWorldInit()
        {
            SetTransition("Crossroads_49", "left1", "Ruins1_05b", "right1");
            SetTransition("Ruins1_05b", "bot1", "Waterways_12", "right1");
            SetTransition("Crossroads_49", "right1", "Ruins1_18", "left1");
            SetTransition("Ruins1_18", "right1", "Ruins2_04", "left1");
            SetTransition("Ruins2_04", "left2", "Room_nailsmith", "left1");
            SetTransition("Ruins2_04", "right1", "Ruins2_08", "left1");
            SetTransition("Ruins2_04", "right2", "Ruins1_06", "left1");
            SetTransition("Ruins1_06", "right1", "Ruins1_31", "left1");
            SetTransition("Ruins1_31", "left3", "Crossroads_10", "right1");
            SetTransition("Ruins1_31", "right1", "Ruins2_10", "left1");

            SetTransition("Ruins2_04", "door_Ruin_House_03", "Room_Mask_Maker", "right1");
            SetTransition("Ruins2_04", "door_Ruin_House_02", "Ruins_House_01", "left1");
            SetTransition("Ruins2_04", "door_Ruin_House_01", "Room_temple", "left1");

            SetTransition("Ruins_Bathhouse", "right1", "Room_Mansion", "left1");

            SetItem(LocationNames.Flukenest, ItemNames.Desolate_Dive);
            SetItem(LocationNames.Wanderers_Journal_Pleasure_House, ItemNames.Dream_Nail);
            SetItem(LocationNames.Kings_Station_Stag, ItemNames.Geo_Rock_Default);
            SetItem(LocationNames.Hallownest_Seal_Kings_Station, ItemNames.Wanderers_Journal);
            SetItem(LocationNames.City_Crest, ItemNames.Vengeful_Spirit);
            SetItem(LocationNames.City_of_Tears_Map, ItemNames.Kings_Station_Stag);
            SetItem(LocationNames.World_Sense, ItemNames.Kings_Brand);
            SetItem(LocationNames.Grub_City_of_Tears_Guarded, ItemNames.Grub);

            SetItem(LocationNames.Mask_Shard_Grey_Mourner, ItemNames.Shaman_Stone);
        }

        public override void OnInit()
        {
            ReplaceText("RUINS_MAIN", "The Gray City");
            ReplaceText("MAP_NAME_CITY", "The Gray City");
            ReplaceText("CITY", "The Gray City");
            ReplaceText("KINGS_STATION", "The Gray City");
            ReplaceText("EGGTEMPLE_SUPER", "Mask Maker's");
            ReplaceText("EGGTEMPLE_MAIN", "Vault");
            ReplaceText("FINAL_BOSS", "Mask Maker's Vault");


            //Lemm
            ReplaceText("RELICDEALER_SUPER", "Souvenir Seeker");
            ReplaceText("RELICDEALER_SHOP_INTRO", "Good day to you, pale visitor! And welcome to my little store. I sell little souvenirs to the hordes of foreign visitors who can afford these exclusive trinkets.<page>But my stocks have dried up for a while, so any help would be truly appreciated!");
            ReplaceText("RELICDEALER_DREAM", "Some day... I'm gonna be selling microwaves or dishwashers! Not this useless crap. But I guess a bug's gotta earn their dreams.");
            ReplaceText("RELICDEALER_TALK", "You know, no foreign visitors have come here in years. Everything has gone to crap a little bit.<page>But always keeping up appearances is important! Who knows, the Prince of Hallownest might just come walking in tomorrow! One should never loose Hope.");
            ReplaceText("RELICDEALER_TALK_2", "Where are you getting all these souvenirs from by the way? I hope you aren't stealing them from any loving homes?! My reputation could never survive that!");
            ReplaceText("RELICDEALER_TALK_REPEAT", "If you find any souvenirs, please bring them over!");
            ReplaceText("RELICDEALER_CONVO_1", "My stocks have dried up for a while, so any help would be truly appreciated!");
            ReplaceText("RELICDEALER_JOURNAL_1", "Ah, one of my commemorative journals! They have little stories from wanderers of the kingdom in them!");
            ReplaceText("RELICDEALER_JOURNAL_2", "These aren't actually written by wanderers. Their stories just aren't captivating enough.");
            ReplaceText("RELICDEALER_JOURNAL_3", "You know, these were quite the rage for a while in Hallownest. No idea what happened with all those journals there.");
            ReplaceText("RELICDEALER_JOURNAL_4", "Oh, I really liked this one! It's about a slug warrior who carries his son with him in his house. Fantastic lore!");
            ReplaceText("RELICDEALER_JOURNAL_5", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_JOURNAL_6", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_JOURNAL_7", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_JOURNAL_8", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_SEAL_1", "A glimmering seal! These were very popular until recently!");
            ReplaceText("RELICDEALER_SEAL_2", "These little trinkets are in the shape of Glimmering King's coat of arms. It's even got the little fork at the top!");
            ReplaceText("RELICDEALER_SEAL_3", "You may think these look quite similar to the Seal of Hallownest, but you'd be wrong. They are actually a different shade of purple.");
            ReplaceText("RELICDEALER_SEAL_4", "You know, I heard of a land far away, called the land of storms. It's inhabitants are supposed to have myterious and arcane powers. Perhaps some will come and visit one day?");
            ReplaceText("RELICDEALER_SEAL_5", "Ah, another seal! Thanks for that!");
            ReplaceText("RELICDEALER_SEAL_6", "Ah, another seal! Thanks for that!");
            ReplaceText("RELICDEALER_SEAL_7", "Ah, another seal! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_1", "A king's idol. These are a small effigy of the Glimmering King. The old man sadly isn't around anymore these days, but he was quite the figure. Children loved these. Always kept chewing the heads of.");
            ReplaceText("RELICDEALER_IDOL_2", "Did you know, with the prongs on the end, these can be used as forks in a pinch!<page>Although that's probably treason.");
            ReplaceText("RELICDEALER_IDOL_3", "After the coup, the king fled deep into the mountain. No idea what happened to him there. Kingdom has never been the same, though.");
            ReplaceText("RELICDEALER_IDOL_4", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_5", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_6", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_7", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_EGG_1", "Oh, an Arcane Egg! These were very much an upper class thing. I used to talk for hours about the perils of the hunters that collected them.<page>All rubbish, of course. They're made just down the road.");
            ReplaceText("RELICDEALER_EGG_2", "The guy who made these eggs sadly doesn't work in the business anymore. He's kinda busy being a king these days. I guess it's proof you can still move up in the world.");
            ReplaceText("RELICDEALER_EGG_3", "Ah, another egg! Thanks!");
            ReplaceText("RELICDEALER_EGG_4", "Ah, another egg! Thanks!");
            ReplaceText("RELICDEALER_NO_RELICS", "Hmm, looks like you don't have any souvenirs for me? Would you like to buy some? Although you don't really seem the commemorative type.");
            ReplaceText("RELICDEALER_NAILSMITH", "Oooh, you've got a really wrecked looking sword there! That would sell for a fortune with a good story!<page>The Nailsmith just down the road might be much more interested, though.");
            ReplaceText("RELICDEALER_DUNG", "*Sniff* *Sniff* Did you fart? That's interesting, I didn't even know bugs could do that!");
            ReplaceText("SHOP_DESC_TRINKET1", "A journal of a wanderer's travels. Did you read it? The stories are quite a treat!");
            ReplaceText("SHOP_DESC_TRINKET2", "The seal of the Glimmering Realm. It has a little needle at the back, to affix it to your shirt.");
            ReplaceText("SHOP_DESC_TRINKET3", "An effigy of the Glimmering King. The old man is looking rather worse for wear these days, though.");
            ReplaceText("SHOP_DESC_TRINKET4", "A really shiny pretty egg. Used to sell for a lot, but high end customers are rare these days.");


            //Cornifer
            ReplaceText("CITY_GREET", "Ah, the little wanderer! This city is quite nice, once you get out of the rain, isn't it? Used to be a lot brighter and happier, but that was long ago.<page>I just got finished repairing the signaling system up here, so the stags are good to go here. Care for a ticket?");
            ReplaceText("CITY_BOUGHT", "There used to be a little meat-and-mushroom pie shop down the road, called \"The Fungal Waists\". I wonder what happened to it?");

            //Mask Maker
            ReplaceText("MASK_MAKER_UNMASK3", "How does it dare to remove my beautiful mask?!");
            ReplaceText("MASK_MAKER_UNMASK", "How does it dare to remove my beautiful mask?!");
            ReplaceText("MASK_MAKER_UNMASK4", "How does it dare to remove my beautiful mask?!"); 
            ReplaceText("MASK_MAKER_UNMASK_REPEAT", "How does it dare to remove my beautiful mask?!");
            ReplaceText("MASK_MAKER_REPEAT2", "The key to the prison?! Secured deep in my vault!");
            ReplaceText("MASK_MAKER_DREAM", "To be king is such joy! Look at my happy city! Its frollicking subjects!");
            ReplaceText("MASK_MAKER_UNMASK2", "How does it dare to remove my beautiful mask?!");
            ReplaceText("MASK_MAKER_REPEAT3", "The keys to the vault?! Securely guarded in the towns of the kingdom!");
            ReplaceText("MASK_MAKER_REPEAT", "The old king, you ask?! He is gone! Sealed away, the mad fool!");
            ReplaceText("MASK_MAKER_GREET", "My loyal subject intrudes on my work?! What does it want?!");
        
        }
    }
}
