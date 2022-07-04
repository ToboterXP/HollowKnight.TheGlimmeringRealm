using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest.Rooms.Village1
{
    internal class Village1 : Room
    {
        public static string NAME = "Town";

        public Village1() : base(NAME) { }

        public override void OnInit()
        {
            ReplaceText("DIRTMOUTH_SUB", "The Fading Frontier");

            //new Elderbug dialog
            ReplaceText("ELDERBUG_DREAM", "I'd love to visit the Glimmering City again, one day.");
            ReplaceText("ELDERBUG_JIJI_DOOR", "The easterly winds blow strong today. Is good for the heart, my father always used to say.");
            ReplaceText("ELDERBUG_GOSSIP_HINT", "The Realm's roads have become treacherous in recent years.<br>You'd be well advised to always carry that little sword of yours close at hand.");
            ReplaceText("ELDERBUG_HINT_ANCIENT_BASIN", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_HINT_CRYSTAL_PEAK", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_BLACK_EGG_OPENED", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_INTRO_VISITEDCROSSROAD", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_STAG_STATION_REOPENED", "Looks like the young station keeper finally opened the station again.<br>Never seen anyone who's more proud of their husband before.");
            ReplaceText("ELDERBUG_INTRO_NORMAL", "Oh, a traveler. No one has come this way for a long time, you know. The roads have gotten more and more dangerous.<page>But do make yourself at home. Sadly, most of our town isn't in great shape, with most of the people missing, or stuck down below.");
            ReplaceText("ELDERBUG_GENERIC_2", "Have you heard of the Glimmering City? It sits at the top of the Realm, proud and tall.<br>I'd love to visit again one day, it's a sight to behold!");
            ReplaceText("ELDERBUG_HINT_FUNGAL_WASTES", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_HISTORY_2", "You know, a few years ago an emissary from hallownest arrived, on his way through to the king.<br>Strange fellow. Looked a little like you. Big white shoulder paldrons.<br>Thought you might know him maybe. Real Buzz Saw enthusiast.");
            ReplaceText("ELDERBUG_HISTORY_1", "This town was once quite the bustling trade outpost, you know? We'd get carts after carts of the best Hegemolian dung,<br>the most rancid of eggs from as far away as Hallownest,<br>and silk from Farloom so fine you could see your reflection in it.<page>But since the guards left, closing the gate forever, not much has happened.");
            ReplaceText("ELDERBUG_HINT_GREENPATH", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_BRETTA_RETURNED", "I saw little Bretta return, just recently. She still hasn't told anyone why she was away for so long.<page>Poor little thing.");
            ReplaceText("ELDERBUG_INTRO_MAIN", "The entrance to the lower levels has been blocked for days.<br>I'm almost worried sick.");
            ReplaceText("ELDERBUG_HINT_CITY_OF_TEARS", "Hello, dear wanderer. And where have your travels lead you this time?");
            ReplaceText("ELDERBUG_TOWN_GREET_4", "There's been quite the conflict raging, over in the deeper parts of the Realm. But I mostly stay away from politics. Terrible for the appetite, really.");
            ReplaceText("ELDERBUG_MAP_SHOP_OPEN", "The stag station shop has opened. Perhaps you'll take a look?");
            ReplaceText("ELDERBUG_TOWN_GREET_3", "You know, there's a lovely old catapillar living below. Great father, and an excellent cook!");
            ReplaceText("ELDERBUG_SHOPKEEP_RETURNED", "Oh, Sly has returned! No idea where that old vagabond has been spending his time.<page>Though I could make an educated guess...");
            ReplaceText("ELDERBUG_DREAM_FLOWER", "These petals... they remind me of better days. Maybe it's a sign?");
            ReplaceText("ELDERBUG_KINGS_PASS", "The old outer gate has been locked for a long time now. Well, I say locked. People get through occasionally. Then some Menderbug comes along and puts the pieces back together.<page>It's quite a curious system, really.");
            ReplaceText("ELDERBUG_BLACK_EGG_OPENED", "Oh, you broke into the kings vault you say? That's dangerous. You should be more careful.");
            ReplaceText("ELDERBUG_DUNG", "You've smelled better on other occasions, have you per chance fought some sort of dung knight? No? A shame, we used to be friends.");
            ReplaceText("ELDERBUG_TEMPLE_VISITED", "You've seen the kings secret vault, you say? Be careful with those things. One should never meddle with royalty. It just leads to trouble.");
            ReplaceText("ELDERBUG_HINT_RESTING_GROUNDS", "Hello, dear wanderer. And where have your travels lead you this time?");

            ReplaceText("BRETTA_DREAM_BED", "Maybe... becoming a fighter myself one day?... Bretta the Brave...");
            ReplaceText("BRETTA_DREAM_BENCH", "He's back!... Such a strong little fellow... Perhaps he could teach... me?");
            ReplaceText("BRETTA_DIARY_1", " - The Adventures of Bretta the Brave - <br><br>She awoke in a panic. Steps! She should never have let her guard down in such a place! Her nail was at the ready, like lightning streaking through the night. And not a second too soon, as a whirring claw struck it from the dark. She took a somersault back, over her meager campfire, as another razorsharp claw sailed by her face.<page>The abomination drew closer, and in the fire's dim light its features became visible. Its segmented body grew to a pointed tail on one end, and a needle thin neck at the other. Its smooth white head rose into two fearsome horns, and its eyes glowed amber with rage. Its glistening wings beat like whirring blades.<page>It wound up, to hurl another blade, but Bretta ever-cunning foresaw the move. She dashed forward, just in time to strike the whirling claw, the blade grazing the creature's spiked, grotesque right extremity.<page>As the creature hissed in pain, Bretta the Brave struck again, cleaving through the horrifying, slender neck. The creature fell out of the air like a plummeting rock, spraying the heroine with thick amber blood.<page>Victory was hers. She wiped her blade clean of blood, with her handkerchief woven from the hair of her prey. Another threat to the kingdom slain. But there would be more. There were always more.<page>- To be Continued");
            ReplaceText("BRETTA_DIARY_2", " - The Continued Adventures of Bretta the Brave - <br><br>Aching of her last encounter, Bretta sat down on her bedding again. Then her eyes narrowed. Foot steps! Again! She whirled around, determined to not be caught off guard again. Clang! Another nail sliced through the air, catching hers with swift precision.<page>\"Ho there, my lady! Such an elegant strike. You must be a hunter yourself?\" A tall bug stepped into the light of the fire. His gleaming grey chitin was littered with the scars of old battles.<page>Bretta was stunned for a moment: \"I've roamed this realm with the blade for some time indeed. But never have I met another hunter like you. Please, take a seat. There is room at the fire.\" The hunter sat down, laying down his nail next to him. The skillful yet sturdy tool glimmered in the flickering light.<page>The hunter took a deep sigh. It was only now that his striking complexion became visible: \"I've been hunting that creature the whole day. But it appears you had the honour of striking it down at last. May I rest here for the night? I have some stories to tell, in exchange.\"<page>Bretta the Brave smiled, and edged a little closer: \"Perhaps you would like to hear some of my stories too? We have all night, after all.\" <page>- To be Continued");
            ReplaceText("BRETTA_DIARY_3", " - The Adventures of Bretta the Brave and the Steadfast Hunter - <br><br>Bretta awoke. A cold breeze of fresh morning air brushed through the vegetation of the nook they had made camp in. She could feel his reassuring presence next to her, as she slowly arose. Though the air was cold, and the fire nearly burned to ash, she had a pleasant warm feeling in her chest.<page>She started to carve into the abomination she had slain yesterday, slowly laying out the strips of meat in her trusty little pan that had followed her on her travels for such a long time. As the meat began to sizzle, she heard the hunter wake. He sat up, wrapped in his weather-worn leather blanket, and threw her a slight smile.<page>\"May I?\", he asked, as he reached for the pan. Bretta felt a sudden reflex to protect her precious companion, but allowed him to touch it. He shook it slightly, to unstick the strips of meat, and reached into his pack for a small flask. \"Aspid rennet. It softens the meat, and adds a citrussy flavour. Also, I've added some herbs to it.\" The proud undertone in his voice was unmistakeable, as he added a few drops, and stirred the meat with the barb of some creature: \"Care to taste?\" He handed the pan back. Bretta took a bite. It was the most delicious meat she had ever tasted.<page>They ate the remaining strips with an appetite fitting to two well worn hunters. As they finished up, Bretta spoke up again: \"I have heard rumours of a terrifying beast, not far from here. A giant, swollen locust, with burning yellow eyes and mandibles powerful enough to rip you clean in two. Perhaps you would care to join me on the hunt?\"<page>The hunter smiled, as he took a small sip of fungal coffee, and grabbed his nail: \"A hunt you say. I would be honored to join you... Partner?\"");

            ReplaceText("MAP_SHOP_CLOSED", "Dirtmouth Stag Station offices are closed due to maintenance<br>  - Iselda & Cornifer");

            ReplaceText("SHEO_MEET", "Don't think you are creeping up on me. You've been rustling through the shrubbery outside for over a minute now. <page>You seem like someone who is proficient in the art of carving... So I challenge you to an art duel!");
            ReplaceText("SHEO_REFUSE", "You refuse? Coward! Fight me like a ... bug!");
            ReplaceText("SHEO_TAUGHT", "I'm no match for your beautiful carving. But I have learned as much from this duel as you hopefully have!");
            ReplaceText("SHEO_GREET", "Hah! It's the little knife bug again!");
            ReplaceText("SHEO_REPEAT", "One day I'll take up embroidery as a hobby. Then I'll show you!");
            ReplaceText("SHEO_DREAM", "The brush... such a beautiful tool. If only paint wasn't so expensive!");
            ReplaceText("SHEO_ART", "You come to rechallenge me? Fine... Engarde!");
            
            ReplaceText("SHEO_SLY", "Oh, you've found yourself a cheap little medal of \"Being better with knifes\"?!<page>That's nothing compared to true craftsmanship!");
            
            ReplaceText("NM_SHEO_SUPER", "Definitely");
            ReplaceText("NM_SHEO_MAIN", "Leonardo da Vinci?");
            ReplaceText("NAILMASTER_FREE", "Fight!");

            ReplaceText("DREAM_MOTH_MAIN", "Mothman");
            ReplaceText("WITCH_INTRO", "Huuuh! A small shiny creature! I have a magic chest of dreams! Want to take a peek?<page>This chest... it is worth... almost two chests...");
            ReplaceText("WITCH_MEET_A", "Small shiny creature! You remind me... of the light...");
            ReplaceText("WITCH_MEET_B", "Small shiny creature! Take a peek... fulfill your dreams...");
            ReplaceText("WITCH_GENERIC", "This chest... it is worth... almost two chests...");
            ReplaceText("WITCH_GREET", "Small shiny creature! You are back!");
            ReplaceText("WITCH_HINT_XERO", "Have you met... the old bug? He is not as shiny as you... but smells nice...");
            ReplaceText("WITCH_HINT_DREAMPLANT", "Have you met... the old caterpillar? He lacks... children...");

            ReplaceText("WITCH_QUEST_1", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_2", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_3", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_4", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_5", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_5B", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_6", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_7", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_8", "Bring me... dreams...");
            ReplaceText("WITCH_QUEST_9", "Bring me... dreams...");

            ReplaceText("WITCH_FINAL_1", "");
            ReplaceText("WITCH_FINAL_2", "");
            ReplaceText("WITCH_FINAL_3", "");
            
            ReplaceText("WITCH_REWARD_1", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_2A", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_2B", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_3", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_4", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_5", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_6", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_5B", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_7", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_8A", "Your dreams... put them... in my chest...");
            ReplaceText("WITCH_REWARD_8B", "Your dreams... put them... in my chest...");

            ReplaceText("WITCH_DREAM1", "Maybe I will one day dream... of whole new world?!");
            ReplaceText("WITCH_DREAM_FALL", "Dreams... such power...");
            ReplaceText("WITCH_DREAM", "Have no dreams... must collect...");
            ReplaceText("WITCH_TALK", "Have you met... the old bug? He is not as shiny as you... but smells nice...<page>Have you met... the old caterpillar? He lacks... children...");

            ReplaceText("GH_GRAVEDIGGER_NC_MAIN", "Gravedigger");
            ReplaceText("GRAVEDIGGER_TALK", "Ah, another warrior! Fantastic, those are always great for business!");
            ReplaceText("GRAVEDIGGER_REPEAT", "Could maybe commit a few murders on your way out? Or at least some light pillaging?");
        }

        public override void OnBeforeLoad()
        {
            //Add new right transition
            GameObject right2 = UnityEngine.Object.Instantiate(Prefabs.RIGHT_TRANSITION.Object, new Vector3(234, 8, 0), Quaternion.identity);
            right2.transform.SetScaleY(300);
            right2.SetActive(true);
            right2.name = "right2";
        }

        public override void OnLoad()
        {
            //Spawn the brittle floor that blocks the well
            GameObject wellFloor = UnityEngine.Object.Instantiate(Prefabs.BREAKABLE_FLOOR.Object, new Vector3(184, 5, 0), Quaternion.identity);
            wellFloor.SetActive(true);


            //slice of right side of Dirthmouth
            GameObject.Find("CameraLockArea Graveyard").GetComponent<CameraLockArea>().cameraXMax = 229;
        }

        public override void OnWorldInit()
        {
            SetTransition(NAME, "right2", Area1.Cliff01.NAME, "left1");
            SetTransition("Fungus1_15", "right1", "Tutorial_01", "top2");
            SetTransition("Town", "bot1", "Crossroads_01", "top1");
            SetTransition("Crossroads_01", "left1", "Crossroads_38", "right1");
            SetTransition("Crossroads_01", "right1", "Crossroads_13", "left1");
            SetTransition("Crossroads_13", "right1", "Crossroads_08", "left1");
            SetTransition("Crossroads_08", "left2", "RestingGrounds_07", "right1");
            SetTransition("Crossroads_08", "right1", "Crossroads_48", "left1");
            SetTransition("Crossroads_08", "right2", "Crossroads_09", "left1");
            SetTransition("Crossroads_09", "right1", "Crossroads_37", "right1");


            SetItem(LocationNames.Hallownest_Seal_Crossroads_Well, ItemNames.Hallownest_Seal);
            SetItem(LocationNames.Grub_Crossroads_Guarded, ItemNames.Grub);
            SetItem(LocationNames.Mask_Shard_Crossroads_Goam, ItemNames.Vessel_Fragment);
            SetItem(LocationNames.Mask_Shard_Brooding_Mawlek, ItemNames.Rancid_Egg);
            SetItem(LocationNames.Mask_Shard_Bretta, ItemNames.Charm_Notch);
            SetItem(LocationNames.Vessel_Fragment_Crossroads, ItemNames.Monomon, alternateName: "Mask of Wisdom");
            SetItem(LocationNames.Rancid_Egg_Sheo, ItemNames.Arcane_Egg);

            SetItem(LocationNames.Dirtmouth_Stag, ItemNames.Geo_Rock_Default);
             
            SetItem(LocationNames.Grubfather, ItemNames.Lumafly_Lantern, true, grubCost: 4);
            SetItem(LocationNames.Grubfather, ItemNames.Grubsong, true, grubCost: 3);
            SetItem(LocationNames.Grubfather, ItemNames.Kings_Idol, true, grubCost: 5);
            SetItem(LocationNames.Grubfather, ItemNames.Pale_Ore, true, grubCost: 6);
             
            SetItem(LocationNames.Seer, ItemNames.Elegant_Key, true, essenceCost: 150, destroySeerRewards: true);
            SetItem(LocationNames.Seer, ItemNames.Dream_Wielder, true, essenceCost: 300, destroySeerRewards: true);
            SetItem(LocationNames.Seer, ItemNames.Kings_Idol, true, essenceCost: 500, destroySeerRewards: true);
            SetItem(LocationNames.Seer, ItemNames.Dream_Gate, true, essenceCost: 600, destroySeerRewards: true);
            SetItem(LocationNames.Seer, ItemNames.Arcane_Egg, true, essenceCost: 700, destroySeerRewards: true);

        }
    }
}
