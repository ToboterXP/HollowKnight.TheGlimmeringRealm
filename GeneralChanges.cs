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
    internal class GeneralChanges
    {
        public static void ChangeText()
        {
            ReplaceText("GAME_TITLE", "Hollow Knight The Glimmering Realm");
            ReplaceText("INV_NAME_TRINKET2", "Glimmering Seal");
            ReplaceText("INV_NAME_WALLJUMP", "Fisherman's Hook");

            //stag dialog
            ReplaceText("STAG_MEET", "You called, traveler? How unusual, these days. But maybe this is a sign of better times.<page>I can only take you to places you have a ticket for. I heard the stag engineer, Cornifer is selling them.<page>Also, be careful when going to Dirtmouth, you need a ticket for the station door as well.");
            ReplaceText("STAG_TOWN", "A bustling little town, this once was. Used to run here at least ten times a day.<page>But there's only Iselda here, to occasionally keep me company. At least some thing never change.");
            ReplaceText("STAG_GREENPATH", "Well, if this isn't a surprise. These gates have been stuck for months.Iselda's husband must have been hard at work. A wonder such a small fella would get these pried open.");
            ReplaceText("STAG_RUINS2", "Welcome traveler, to the Glimmering City! It seems to be a little worse for wear at the moment, though.<page>No wonder the stag network is so delapitated, with all this water running in.");
            ReplaceText("STAG_CROSSROADS", "Ah, the old village on the road to the Glimmering City! Travelers often stayed here for the night, in one of the Inns.<page>Not sure how many are left, though.");
            ReplaceText("STAG_NEST", "This is where we stags live. Please don't wake anyone up, being a stag is hard work!", "Stag");

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
            ReplaceText("INV_DESC_TRAM_PASS", "A piece of chitin, etched with a pattern. Used to gain access to the trams of the glimmering realm.");
            ReplaceText("INV_DESC_TRINKET1", "A journal of a long dead wanderer. His story is riveting!");
            ReplaceText("INV_DESC_TRINKET2", "The seal of the Glimmering Realm. Quite fetching.");
            ReplaceText("INV_DESC_TRINKET3", "A statue of the Glimmering King. The guy seems to have an unusual taste in hats.");
            ReplaceText("INV_DESC_TRINKET4", "A smooth stone egg. It tastes of nothing, making you wonder why you licked it in the first place.");
            ReplaceText("INV_DESC_SUPERDASH", "A crystaline geode from the crystal depths. It hums with energy, ready to catapult you in any direction you desire.");
            ReplaceText("INV_DESC_ART_DASH", "A massive strike with the nail, taught to you by a slightly drunken painter.");

            ReplaceText("PROLOGUE_EXCERPT_01", "A note to all who it may concern:");
            ReplaceText("PROLOGUE_EXCERPT_02", "I am the new king now! The old king has been banished!");
            ReplaceText("PROLOGUE_EXCERPT_03", "He is evil anyways, and has spread his monsters everywhere!");
            ReplaceText("PROLOGUE_EXCERPT_04", "Now can everyone please start rebuilding?!");
            ReplaceText("PROLOGUE_EXCERPT_AUTHOR", "- Recent notice to all citizens of the Glimmering Realm");

            ReplaceText("CARD", "Have fun with your ticket, see you soon!<br><br>- Cornifer", "Cornifer");
        }

        public static void OnSceneLoad()
        {
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
                SetBool("quirrelLeftEggTemple", true); //despawn quirrel in TBE
            }
        }

        //Called every frame
        public static void OnUpdate()
        {
            //deactivate Stag Station Map
            GameObject go = GameObject.Find("Stag_Map_Pieces");
            if (go != null) go.SetActive(false);
        }

        static void ReplaceText(string key, string text, string sheet="")
        {
            HKSecondQuest.Instance.TextChanger.AddReplacement(key, text, sheetKey: sheet);
        }

        static void SetBool(string key, bool val)
        {
            HeroController.instance.playerData.SetBool(key, val);
        }
    }
}
