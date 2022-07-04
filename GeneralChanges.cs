using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest
{
    /// <summary>
    /// Implements some overarching changes to text and the world
    /// </summary>
    internal class GeneralChanges
    {
        /// <summary>
        /// Called on Initialization
        /// </summary>
        public static void ChangeText()
        {
            ReplaceText("GAME_TITLE", "Hollow Knight The Glimmering Realm");
            ReplaceText("INV_NAME_TRINKET2", "Glimmering Seal");
            ReplaceText("INV_NAME_WALLJUMP", "Fisherman's Hook");

            //stag dialog
            ReplaceText("STAG_MEET", "You called, traveler? How unusual, these days. But maybe this is a sign of better times.<page>I can only take you to places you have a ticket for. I heard the stag engineer, Cornifer is selling them.<page>Also, be careful when going to Dirtmouth, you need a ticket for the station door as well.");
            ReplaceText("STAG_TOWN", "A bustling little town, this once was. Used to run here at least ten times a day.<page>But there's only Iselda here, to occasionally keep me company. At least some things never change.");
            ReplaceText("STAG_GREENPATH", "Well, if this isn't a surprise. These gates have been stuck for months. Iselda's husband must have been hard at work. A wonder such a small fella would get these pried open.");
            ReplaceText("STAG_RUINS2", "Welcome traveler, to the Glimmering City! It seems to be a little worse for wear at the moment, though.<page>No wonder the stag network is so dilapitated, with all this water running in.");
            ReplaceText("STAG_CROSSROADS", "Ah, the old village on the road to the Glimmering City! Travelers often stayed here for the night, in one of the Inns.<page>Not sure how many are left, though.<page>I heard there's a little cleptomaniac bug that lives deep within the plantations. Maybe you should pay him a visit. You also seem to like collecting things.");
            ReplaceText("STAG_NEST", "This is where we stags live. Please don't wake anyone up, being a stag is hard work!", "Stag");
            ReplaceText("STAG_HIDDEN", "Ah, the old station at the King's Palace. It does seem to be in quite bad shape, a wonder that it still works.<page>Though I doubt it will see much travel in the future.");
            ReplaceText("STAG_DREAM", "I wonder how my brethren are doing? I really can handle all trafic on my own these days...");
            ReplaceText("STAG_TRAM", "Oh, you carry a tram pass! They are beautiful machines, aren't they? Though I always said they should leave out the windows. Travel just isn't the same without the fresh breeze in your mane.");
            ReplaceText("STAG_HOPE_1", "The stag nest. Be careful, it's quite crammed. Once dozens of stags were necessary to run the stag network. Now I can easily handle everyone. I'm the youngest, you see? So the burden fell on me.");
            ReplaceText("STAG_HOPE_2", "There have been now new stags as well for quite some time. It just isn't necessary these days. So everyone just gets older and older.");
            ReplaceText("STAG_REMEMBER_1", "Ah, Cornifer has been busy, hasn't he? At least some of the network is up and running again. I'm sure business will be right back to normal soon.");

            //inventory text
            ReplaceText("INV_DESC_WHITEKEY", "A very fancy, glimmering key");
            ReplaceText("INV_DESC_FLOWER", "A very fragile flower, given to you by the Grey Mourner. She asked you to place it at the grave of her lover, down in the Crystal Depths.");
            ReplaceText("INV_DESC_FLOWER_BROKEN_QG", "A serviceable toothpick");
            ReplaceText("INV_DESC_FLOWER_BROKEN", "A serviceable toothpick");
            ReplaceText("INV_DESC_FLOWER_QG", "A very fragile yet pretty flower");
            ReplaceText("INV_DESC_WALLJUMP", "An old fishing hook. Perfectly serviceable for all sorts of dangerous stunts.");
            ReplaceText("INV_DESC_KINGSBRAND", "The key to a long forgotten door");
            ReplaceText("INV_DESC_GEO", "The currency of the Glimmering Realm and its neighbouring kingdoms.");
            ReplaceText("INV_NAME_KINGSBRAND", "Mask Maker's Key");
            ReplaceText("INV_DESC_KINGSBRAND", "An intricate piece of carved shell. Created by a rather questionable creator.");
            ReplaceText("INV_DESC_TRAM_PASS", "A piece of chitin, etched with a pattern. Used to gain access to the trams of the Glimmering Realm.");
            ReplaceText("INV_DESC_TRINKET1", "A journal of a long dead wanderer. His story is riveting!");
            ReplaceText("INV_DESC_TRINKET2", "The seal of the Glimmering Realm. Quite fetching.");
            ReplaceText("INV_DESC_TRINKET3", "A statue of the Glimmering King. The guy seems to have an unusual taste in hats.");
            ReplaceText("INV_DESC_TRINKET4", "A smooth stone egg. It tastes of nothing, making you wonder why you licked it in the first place.");
            ReplaceText("INV_DESC_SUPERDASH", "A crystaline geode from the Crystal Depths. It hums with energy, ready to catapult you in any direction you desire.");
            ReplaceText("INV_DESC_ART_DASH", "A massive strike with the nail, taught to you by a slightly drunken painter.");
            ReplaceText("CHARM_DESC_18", "Carved by a powerful nailmaster. Empowers the user to stretch his arm just a little longer.");
            ReplaceText("CHARM_DESC_7", "Used in the dangerous mines of the Crystal Depths to quickly heal grievously injured miners.");
            ReplaceText("CHARM_DESC_17", "Mark of the farmers of the Glimmering Realm. Can dispose of pests, and grants access to notes left by other farmers.");
            ReplaceText("CHARM_DESC_15", "A heavy medal made from multiple tiny nails. The added weight makes enemies recoil further.");
            ReplaceText("CHARM_DESC_26", "A special order from an artist, who failed to pick it up. Contains a tutorial on advanced carving, in fine print.");
            ReplaceText("CHARM_DESC_8", "Seems to always contains a small sip of lifeblood, to strengthen those who take a short break.");
            ReplaceText("CHARM_DESC_2", "A pointless yet adorable tool of navigation");
            ReplaceText("CHARM_DESC_37", "Banned in most sporting competitions");
            ReplaceText("CHARM_DESC_33", "Little threads of soul seem to sprout from the mirror, decreasing the amount of soul necessary to cast spells");
            ReplaceText("CHARM_DESC_22", "It makes you feel like you have butterflies in your stomach, for some reason.");
            ReplaceText("CHARM_DESC_10", "You honestly don't even want to touch it. Why did you buy this again?");
            ReplaceText("CHARM_DESC_13", "A little medal containing ancient wisdom from a far away tribe of warriors<br><br>\"Tape a knife to the tip of your nail!\"");
            ReplaceText("CHARM_DESC_19", "A medal containing the soul of someone's grandma. She's delighted by how much your spells have grown!");
            ReplaceText("CHARM_DESC_32", "An indispensible tools for the stag network engineer of rank. Accelerates any engineering task.");
            ReplaceText("CHARM_DESC_30", "A strange medal given to you by Mothman. It might contain drugs.");
            ReplaceText("CHARM_DESC_3", "A present from an old catapillar. Probably won't change your size though.");
            ReplaceText("CHARM_DESC_31", "A very pretty medal. Could probably be sold for a good prize to a collector. If you had a mouth to barter with, that is.");
            ReplaceText("CHARM_DESC_40_N", "A finely crafted medal, eternally giving off a faint lullaby.<br>Crafted by a mother mourning her family.");
            ReplaceText("CHARM_DESC_38", "A little medal with an emblem shaped like a flower. Used by gardeners across the world to repell snail invasions.");

            //Replace Elegy to Hallownest
            ReplaceText("PROLOGUE_EXCERPT_01", "A note to all who it may concern:");
            ReplaceText("PROLOGUE_EXCERPT_02", "I am the new king now! The old king has been banished!");
            ReplaceText("PROLOGUE_EXCERPT_03", "He is evil anyways, and has spread his monsters everywhere!");
            ReplaceText("PROLOGUE_EXCERPT_04", "Now can everyone please start rebuilding?!");
            ReplaceText("PROLOGUE_EXCERPT_AUTHOR", "- Recent notice to all citizens of the Glimmering Realm");
             
            ReplaceText("DREAM_PLANT_FUNGUS_FOG", "...Mushrooms growing...<br>...Feeding all...");
            ReplaceText("DREAM_PLANT_GREENPATH", "...Pens untended...<br>...Beasts escaped...");
            ReplaceText("DREAM_PLANT_CLIFFS", "...Strong walls...<br>...But what use against a foe inside?...");
            ReplaceText("DREAM_PLANT_MINES", "...A Battle won...<br>...A Battle lost...");
            ReplaceText("DREAM_PLANT_QUEEN_GARDEN", "...Such useful beasts...<br>...But what danger when restraints are left untended...");
            ReplaceText("DREAM_PLANT_REST_MAIN", "...White flowers charred...<br>...Venerable graves spoiled...<br>...Beautiful arches smashed...");


            ReplaceText("CARD", "Sorry for leaving, I'm terribly busy right now. See you soon!<br><br>- Cornifer", "Cornifer");
        }

        /// <summary>
        /// Called before every scene load, locks a bunch of events to certain states
        /// </summary>
        public static void OnSceneLoad()
        {

            //fix bug when diving into direction changing transition
            string entryGate = GameManager.instance.entryGateName;
            if (entryGate.StartsWith("left") || entryGate.StartsWith("right")) HeroController.instance.exitedQuake = false;
            if (entryGate.StartsWith("top") || entryGate.StartsWith("bot")) HeroController.instance.exitedSuperDashing = false;

            //fix playerdata bools
            if (HeroController.instance != null)
            {
                SetBool("crossroadsInfected", false); //uninfect crossroads
                SetBool("marmOutside", false); //Put Lemm inside
                SetBool("corn_crossroadsLeft", false); //make Cornifer stay in all the places forever
                SetBool("corn_greenpathLeft", false);
                SetBool("corn_fogCanyonLeft", false);
                SetBool("corn_fungalWastesLeft", false);
                SetBool("corn_cityLeft", false);
                SetBool("corn_waterwaysLeft", false);
                SetBool("corn_minesLeft", false);
                SetBool("corn_cliffsLeft", false);
                SetBool("corn_deepnestLeft", false);
                SetBool("corn_outskirtsLeft", false);
                SetBool("corn_royalGardensLeft", false);
                SetBool("corn_abyssLeft", false);
                SetBool("corniferAtHome", false);
                SetBool("city2_sewerDoor", true); //open Emilitia entrance
                SetBool("bathHouseWall", true); //break wall in right city elevator
                SetBool("gladeDoorOpened", false); //lock glade door permanently
                SetBool("whitePalaceMidWarp", false); //so the TFK dream warp works
                //SetBool("quirrelLeftEggTemple", true); //despawn quirrel in TBE
            }
        }

        /// <summary>
        /// Called every frame, disables the stag station map
        /// </summary>
        public static void OnUpdate()
        {
            //deactivate Stag Station Map
            GameObject go = GameObject.Find("Stag_Map_Pieces");
            if (go != null) go.SetActive(false);
        }

        /// <summary>
        /// Adds a replacement to the TextChanger
        /// </summary>
        static void ReplaceText(string key, string text, string sheet="")
        {
            HKSecondQuest.Instance.TextChanger.AddReplacement(key, text, sheetKey: sheet);
        }

        /// <summary>
        /// Sets a save value in PlayerData
        /// </summary>
        static void SetBool(string key, bool val)
        {
            HeroController.instance.playerData.SetBool(key, val);
        }
    }
}
