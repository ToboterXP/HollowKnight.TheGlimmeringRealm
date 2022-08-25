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

            SetTransition("Ruins1_31", "bot1", "Room_GG_Shortcut", "top1");
            SetTransition("Room_GG_Shortcut", "left1", "Ruins2_10b", "right1");

            SetItem(LocationNames.Flukenest, ItemNames.Desolate_Dive);
            SetItem(LocationNames.Wanderers_Journal_Pleasure_House, ItemNames.Dream_Nail);
            SetItem(LocationNames.Kings_Station_Stag, ItemNames.Geo_Rock_Default);
            SetItem(LocationNames.Hallownest_Seal_Kings_Station, ItemNames.Wanderers_Journal);
            SetItem(LocationNames.City_Crest, ItemNames.Shade_Soul, nonIncremental: true);
            SetItem(LocationNames.City_of_Tears_Map, ItemNames.Kings_Station_Stag);
            SetItem(LocationNames.World_Sense, ItemNames.Kings_Brand);
            SetItem(LocationNames.Grub_City_of_Tears_Guarded, ItemNames.Grub);

            SetItem(LocationNames.Mask_Shard_Grey_Mourner, ItemNames.Shaman_Stone);
        }

        public override void OnInit()
        {
            ReplaceText("RUINS_MAIN", "The Gray City");
            ReplaceText("MAP_NAME_CITY", "The Gray City");
            ReplaceText("CITY", "The City");
            ReplaceText("KINGS_STATION", "The Gray City");
            ReplaceText("EGGTEMPLE_SUPER", "Mask Maker's");
            ReplaceText("EGGTEMPLE_MAIN", "Vault");
            ReplaceText("FINAL_BOSS", "Mask Maker's Vault");


            //Lemm
            ReplaceText("RELICDEALER_SUPER", "Souvenir Seeker");
            ReplaceText("RELICDEALER_SHOP_INTRO", "Good day to you, pale visitor! And welcome to my little store. I sell little souvenirs to the hordes of foreign visitors who can afford these exclusive trinkets.<page>But my stocks have dried up for a while, so any help would be truly appreciated!");
            ReplaceText("RELICDEALER_DREAM", "Some day... I'm gonna be selling microwaves or dishwashers! Not this useless crap. But I guess a bug's gotta earn their dreams.");
            ReplaceText("RELICDEALER_TALK", "You know, no foreign visitors have come here in years. Everything has gone to crap a little bit.<page>But always keeping up appearances is important! Who knows, the Prince of Hallownest might just come walking in tomorrow! One should never lose Hope.");
            ReplaceText("RELICDEALER_TALK_2", "Where are you getting all these souvenirs from by the way? I hope you aren't stealing them from any loving homes?! My reputation could never survive that!");
            ReplaceText("RELICDEALER_TALK_REPEAT", "If you find any souvenirs, please bring them over!");
            ReplaceText("RELICDEALER_CONVO_1", "My stocks have dried up for a while, so any help would be truly appreciated!");
            ReplaceText("RELICDEALER_JOURNAL_1", "Ah, one of my commemorative journals! They have little stories from wanderers of the kingdom in them!");
            ReplaceText("RELICDEALER_JOURNAL_2", "These aren't actually written by wanderers. Their stories just aren't captivating enough.");
            ReplaceText("RELICDEALER_JOURNAL_3", "You know, these were quite the rage for a while in Hallownest. No idea what happened with all those journals there.");
            ReplaceText("RELICDEALER_JOURNAL_4", "Oh, I really liked this one! It's about a slug warrior who carries his son with him in his house. Fantastic lore!");
            ReplaceText("RELICDEALER_JOURNAL_5", "Hmm, this is a curious story. It seems to be written by a bug called Elinna, about the depths of a derelict kingdom. Strange, I can't remember ever writing this.");
            ReplaceText("RELICDEALER_JOURNAL_6", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_JOURNAL_7", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_JOURNAL_8", "Ah, another journal. Thanks!");
            ReplaceText("RELICDEALER_SEAL_1", "A glimmering seal! These were very popular until recently!");
            ReplaceText("RELICDEALER_SEAL_2", "These little trinkets are in the shape of the Glimmering King's coat of arms. It's even got the little fork at the top!");
            ReplaceText("RELICDEALER_SEAL_3", "You may think these look quite similar to the Seal of Hallownest, but you'd be wrong. They are actually a different shade of purple.");
            ReplaceText("RELICDEALER_SEAL_4", "You know, I heard of a land far away, called the land of storms. Its inhabitants are supposed to have mysterious and arcane powers. Perhaps some will come and visit one day?");
            ReplaceText("RELICDEALER_SEAL_5", "These seals are supposedly a charm against evil spirits entering your dreams. That said, they are little more than a small slab of fungiwood, so probably not.");
            ReplaceText("RELICDEALER_SEAL_6", "Ah, another seal! Thanks for that!");
            ReplaceText("RELICDEALER_SEAL_7", "Ah, another seal! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_1", "A king's idol. These are a small effigy of the Glimmering King. The old man sadly isn't around anymore these days, but he was quite the figure. Children loved these. Always kept chewing the heads off.");
            ReplaceText("RELICDEALER_IDOL_2", "Did you know, with the prongs on the end, these can be used as forks in a pinch!<page>Although that's probably treason.");
            ReplaceText("RELICDEALER_IDOL_3", "After the coup, the king fled deep into the mountain. No idea what happened to him there. Kingdom has never been the same, though.");
            ReplaceText("RELICDEALER_IDOL_4", "There was a great battle at the gates of the palace, you know? But in the end, the Mask Maker's forces prevailed, and burned the palace to the ground.<page>A shame really. It was a beautiful piece of architecture.");
            ReplaceText("RELICDEALER_IDOL_5", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_6", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_IDOL_7", "Ah, another idol! Thanks for that!");
            ReplaceText("RELICDEALER_EGG_1", "Oh, an Arcane Egg! These were very much an upper class thing. I used to talk for hours about the perils of the hunters that collected them.<page>All rubbish, of course. They're made just down the road.");
            ReplaceText("RELICDEALER_EGG_2", "The guy who made these eggs sadly doesn't work in the business anymore. He's kinda busy being a king these days. I guess it's proof you can still move up in the world.");
            ReplaceText("RELICDEALER_EGG_3", "I once had a request from a local restaurant that wanted to license these for their arcane omelettes. I sadly had to decline the offer. Professionals have standards!");
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

            //Nailsmith
            ReplaceText("NAILSMITH_MEET_1", "Yes sir, the nails will be ready tomorrow. I promise.");
            ReplaceText("NAILSMITH_MEET_2", "Hmm?<page>Oh, a visitor. How nice to see a friendly face for once.");
            ReplaceText("NAILSMITH_MEET_3", "I make nails. Didn't always, but now I do apparently.");
            ReplaceText("NAILSMITH_DREAM_INTERIOR", "More and more blades... how I miss making fences and signposts... much more beautiful...");
            ReplaceText("NAILSMITH_DECLINE", "No? A pitty. I was looking forward to making a nail for someone else - for once.");
            ReplaceText("NAILSMITH_OFFER", "Your blade looks fairly beaten up. Want me to take a look?");
            ReplaceText("NAILSMITH_COMPLETE_1", "There we go. That blade was barely holding an edge anymore. Now it should be at least serviceable<page>If you bring me some ore, I could improve it a little more. But almost all has been mined for the war already.");
            ReplaceText("NAILSMITH_COMPLETE_2", "Beautiful. The Pale metal makes a little band along the blade, holding quite a sharper edge than the old metal ever could.");
            ReplaceText("NAILSMITH_COMPLETE_3", "Wonderful! I put in some structural members of Pale metal, the blade should be much more stable yet flexible now. Good luck on your travels. It's one of my best ones yet.");
            ReplaceText("NAILSMITH_GREET", "The little warrior returns. How are your travels going?");
            ReplaceText("NAILSMITH_REGREET", "Still here? At least I'll have a reason to rest my claws a little, then.");
            ReplaceText("NAILSMITH_ACCEPT", "Alright, hand it over and I'll get the forge going.");
            ReplaceText("NAILSMITH_NEED_ORE1", "I'll need one more Pale Ore. It was once mined in the Crystal Depths, but it I doubt it'll be easy to come by there.");
            ReplaceText("NAILSMITH_NEED_ORE2", "I'll need two more Pale Ore. Taking control of the mines was one of the biggest battles, but when they fell to the Mask Maker, the war was basically decided.");
            ReplaceText("NAILSMITH_NOT_ENOUGH_GEO", "You don't have enough to pay? That's okay, you can return later.");
            ReplaceText("NAILSMITH_OFFER_ORE", "Ah, you got your hands on some ore? I'd love to hear how you got it. Why don't you tell me while I go to work?");

            //Quirrel
            ReplaceText("QUIRREL_MEET_TEMPLE", "Ah, the traveler returns! This is quite an impressive city, isn't it?");
            ReplaceText("QUIRREL_MEET_TEMPLE_B", "It seems to have gone down a drain in recent years though, not just because of the rain.");
            ReplaceText("QUIRREL_MEET_TEMPLE_C", "There are scars of battle everywhere. And the guards are extremely touchy. Keep your distance from them, their nails are exceedingly sharp.");
            ReplaceText("QUIRREL_TEMPLE_1", "They say this is the kings personal vault. I wonder what he's keeping in here that's so important?");
            ReplaceText("QUIRREL_TEMPLE_4", "Strange, the masks that line the door remind me of something. But I'm not sure what.<page>I guess the art of mask making just has its common patterns. A real headscratcher.");
            ReplaceText("QUIRREL_TEMPLE_5", "There's a strange old chap in the west of the city. Says he runs a souvenir shop.<page>As we got talking, he talked about how one of his favorite fountains nearby got demolished recently.<page>Apparently the king took umbrage at the statue.<page>I wonder why?");
            ReplaceText("QUIRREL_TEMPLE_6", "They really are quite strange fellows here. Or maybe everyone but them has just left?");

            //Fluke Hermit
            ReplaceText("FLUKE_HERMIT_DREAM", "Must ... improve ... maggot crop!");
            /*ReplaceText("FLUKE_HERMIT_PRAY"
            ReplaceText("FLUKE_HERMIT_PRAY_REPEAT", ""); Only accesible with Flukenest*/
            ReplaceText("FLUKE_HERMIT_MAIN", "Farmer");
            ReplaceText("FLUKE_HERMIT_IDLE_1", "Careful! They must grow! Meat is precious!");
            ReplaceText("FLUKE_HERMIT_IDLE_2", "They grow fast! So many hunger!");
            ReplaceText("FLUKE_HERMIT_IDLE_3", "Riches will be mine! I will be a Hero!");
            ReplaceText("FLUKE_HERMIT_IDLE_4", "They grow fast in theses tunnels. It will take weeks till the fungi sprout again!");
            ReplaceText("FLUKE_HERMIT_IDLE_5", "Till then, I'm the only one...");
            ReplaceText("FLUKE_HERMIT_PEERING", "");
            ReplaceText("FLUKE_HERMIT_PEERING_DREAM", "So much money! I'll finally buy that little house in Ditrmouth! Far away from this!");

            //Zemeer
            ReplaceText("XUN_MEET", "Bonjour! May I offer you a beautiful flower? No? Then perhaps you might aid in the delivery of one?<page>Be careful, it is extremely fragile, one of a kind, and ordered by the king himself!<page>I even have a little token of gratitude if you complete the delivery.");
            ReplaceText("XUN_ACCEPT", "Fantastic! It needs to be delivered to a grave in the Crystal Depths. Remember, it's extremely fragile and one of a kind!");
            ReplaceText("XUN_REFUSE", "No? Fair enough. I'll ask the next guy who passes through.");
            ReplaceText("XUN_REOFFER", "Wanna take a shot at the delivery anyways?");
            ReplaceText("XUN_SUCCESS1", "You did it! Fantastic! I knew I could count on you! Now... what did we agree to again?<page>What? Money? No, you must be mistaken! Here have a random medal!");
            ReplaceText("XUN_FAILED", "Oh, you broke it? No problem. Just between us: I've got dozens of the things. Just don't tell the king, or he'll want a lower price.");
            ReplaceText("XUN_REOFFER2", "Would you try the delivery again?");
            ReplaceText("XUN_ACCEPT2", "Fantastic! It needs to be delivered to a grave in the Crystal Depths. Good luck!");
            ReplaceText("XUN_FAILED2", "That one broke as well? No worried, I can use the sticks as supports for my roses.");
            ReplaceText("XUN_SUCCESS2", "You did it! Fantastic! I knew I could count on you! Now... what did we agree to again?<page>What? Money? No, you must be mistaken! Here have a random medal!");
            ReplaceText("XUN_HAVE_FLOWER", "Just... take the first turn right... then left ...<page>Something like that. You can't miss it, it's green.");
            ReplaceText("XUN_HAVE_FLOWER2", "Just... take the first turn right... then left ...<page>Something like that. You can't miss it, it's green.");
            ReplaceText("XUN_GRAVE_INSPECT", "Here rests the masked child");
            ReplaceText("XUN_GRAVE_INSPECT2", "Here rests the masked child");
            ReplaceText("XUN_DREAM", "Flower vendor is such a wonderful and fullfilling job! Now I even get to boss around heavily armed children!");
            ReplaceText("XUN_KING_BRAND", "Oh, you stole the Mask Maker's key? What a delightful story! You'll have to tell me all about your heist at some point!");
            ReplaceText("XUN_GRAVE_FLOWER", "A flower has been placed");
            ReplaceText("XUN_NC_MAIN", "Vendor"); 
             
            ReplaceText("POGGY_TALK", "Ah, welcome to my butcher's shop! I might be a little see through, but I guarantee you, my meat is not!<page>Except the aspic.<page>Can I interest you in a lovely slice of crawling ham?");
            ReplaceText("POGGY_REPEAT", "I can guarantee you, it's fresher than it looks! And you won't get it cheaper anywhere else!");

            ReplaceText("RUINS_MARISSA_POSTER", "And now on stage, the delightful Sylas and Delilah!<br>The best hits from last year and the year before that!");
            ReplaceText("MARISSA_TALK", "Oh dear, an audience! Sadly, my dear friend Sylas has departed, so it won't be the same. But an aria should still be possible!");
            ReplaceText("MARISSA_REPEAT", "He truely was a dear friend... Maybe I should follow? ... One day maybe.");
            ReplaceText("BATHHOUSE_CORPSE", "...Sylas!...Delilah!...");
            ReplaceText("GH_MARISSA_NC_MAIN", "Delilah");

            ReplaceText("FALSE_KNIGHT", "He told me I would be revered! I even became his General!<page>But then he just locked me in here. Said it was the best for the kingdom.<page>I won this war for him, how could he do such a thing?!");
        }
    }
}
