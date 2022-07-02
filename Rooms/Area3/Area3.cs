using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area3
{
    internal class Area3 : Room
    {
        public Area3() : base("Area 3") { }

        public override void OnWorldInit()
        {
            SetTransition("Fungus1_02", "right1", "Fungus2_06", "left1");
            SetTransition("Fungus2_06", "right2", "Fungus2_32", "left1");
            SetTransition("Fungus2_06", "right1", "Fungus2_07", "left1");
            SetTransition("Fungus2_07", "right1", "Fungus2_08", "left2");
            SetTransition("Fungus2_08", "left1", "Fungus2_26", "left1"); 
            SetTransition("Fungus2_08", "right1", "Fungus2_33", "left1");
            SetTransition("Fungus2_33", "right1", "Fungus2_11", "left1");
            SetTransition("Fungus2_11", "top1", "Fungus2_05", "bot1");
            SetTransition("Fungus2_11", "left2", "Fungus1_19", "right1");

            SetTransition("Fungus2_06", "top1", "Fungus2_03", "bot1");
            SetTransition("Fungus2_03", "left1", "Crossroads_49b", "right1");
            SetTransition("Fungus2_03", "right1", "Fungus2_20", "left1");
            SetTransition("Fungus2_20", "right1", "Fungus2_19", "left1");
            SetTransition("Fungus2_19", "top1", "Fungus2_23", "right1");


            SetItem(LocationNames.Leg_Eater, ItemNames.Elevator_Pass, true, 120, alternateDesc: "A carved chitin card, giving the bearer access to the massive cargo lifts of the Glimmering City.");
            SetItem(LocationNames.Leg_Eater, ItemNames.Shopkeepers_Key, true, 280, alternateDesc: "A small rusty key. There is still some mycelial dirt on it.");
            SetItem(LocationNames.Leg_Eater, ItemNames.Grub, true, 160, alternateDesc: "A harmless, whimpering creature. You can only guess whether it's his pet, or his breakfast.");
            SetItem(LocationNames.Elevator_Pass, ItemNames.Hallownest_Seal);

            SetItem(LocationNames.Charm_Notch_Shrumal_Ogres, ItemNames.Simple_Key);
            SetItem(LocationNames.Hallownest_Seal_Fungal_Wastes_Sporgs, ItemNames.Wanderers_Journal);
            SetItem(LocationNames.Grub_Fungal_Spore_Shroom, ItemNames.Geo_Rock_Default);
            SetItem(LocationNames.Spore_Shroom, ItemNames.Grub);
        }

        public override void OnInit()
        {
            ReplaceText("LEGEATER_MEET", "Huh. You smell... smell of liquorice. Dark, bitter liquorice.<page>I collect things, little liquorice man. Fun things. Smelly things. Pay to see them?");
            ReplaceText("LEGEATER_DREAM", "It smells nice as well. Dark. Perhaps... in its sleep?<page>But no, I smell his sharp metal. What if he wakes?!<page>But... just a leg maybe....");
            ReplaceText("LEGEATER_NOSTOCK", "My smellys... You've taken them all! Now I have none. None!<page>But you smell nice... Like the deepest cracks of the rocks<br>Dark. Darker yet Darker.");
            ReplaceText("LEGEATER_REFUSE_AGAIN", "Not enough to smell again? Well then see you shall not! These smellys will stay mine!");
            ReplaceText("LEGEATER_CONVO1", "I roam these lands. The farmers have been gone for months now, you see? Once I had to sneak. Now there's no one left to see me. Except these wicked mushrooms.<page>Tasty mushrooms...");
            ReplaceText("LEGEATER_CONVO2", "Sometimes, nasty people come. People with pointy metal. Take my stuff.<page>It's not fair. Why don't they get their own?!");
            ReplaceText("LEGEATER_CONVO3", "This key, I saw it in the wake of a small stumbling bug. He looked all bitter and sinewy...<page>But such a musty, tasty key!");
            ReplaceText("LEGEATER_CONVO4", "A very round bug came by recently...<br>He smelled all oily, like an ancient old grandma slug!<page>Gave me a wonderful old oily copper fitting. Here. Smell it!<page>But no take! It's my favorite!");
            ReplaceText("LEGEATER_CONVO5", "Sometimes... I wander deeper. But danger is there.<page> Shiny sharp rocks. Dark shadows. Evil shrubs.<page>But the smell... so precious!");
            ReplaceText("LEGEATER_NOTENOUGHGEO", "The smell... It is not enough... Perhaps you might return?");
            ReplaceText("LEGEATER_GREET", "Ahhh.... the liquorice man returns. What smells have you brought me?");
            ReplaceText("LEGEATER_DUNG", "Terrible smell! Bad smell! Smells of old sins! Take it away!");
            ReplaceText("LEGEATER_REMEET", "Liquorice man... have you changed your mind? Will you see my smellys?");
            ReplaceText("LEGEATER_REFUSE", "No smellys? Okay... more for me!");
            ReplaceText("LEGEATER_PAID", "Ahhh.... the smell. Here, these are my smellys. Aren't they precious?!");
            ReplaceText("LEGEATER_SOMETHING", "Pay to see smelly things?", "Prompts");

            ReplaceText("BRETTA_DREAM_DAZED", "Bad!... mushroom... leave me in peace!... my blade!... no... ");
            ReplaceText("BRETTA_RESCUE_1", "Oooooh... head... hurts...");
            ReplaceText("BRETTA_RESCUE_2", "Ow. Who are you. Where am I?");
            ReplaceText("BRETTA_RESCUE_3", "I was stupid. I should never have gone out alone. Everyone at the village said I shouldn't.");
            ReplaceText("BRETTA_RESCUE_4", "I should get back to the village. They'll be worried sick there.");
            ReplaceText("BRETTA_RESCUE_5", "Thank you, for waking me.");

            ReplaceText("FUNGUS_SUPER", "Derelict");
            ReplaceText("FUNGUS_MAIN", "Plantations");
            ReplaceText("MAP_NAME_FUNGAL_WASTES", "Derelict Plantations");
            ReplaceText("WASTES", "Derelict Plantations");

            ReplaceText("FUNG_TAB_04", "This plantation is property of the Glimmering King");

            ReplaceText("HU_INSPECT", "Here rests the master of mushroom pancakes");
            ReplaceText("HU_TALK", "Ho! In life I was the best chef in the realm! Noone could withstand my mighty mushroom pancakes! Will you challenge my prowess?!");
            ReplaceText("HU_REPEAT", "Will you challenge my mushroom pancakes?!");
            ReplaceText("HU_DEFEAT", "Delicious! What exquisit knife work! Truly, you are a great chef!");
        }
    }
}
