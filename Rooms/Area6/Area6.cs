using ItemChanger;
using ItemChanger.Internal;
using ItemChanger.UIDefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area6
{
    internal class Area6 : Room
    {
        public Area6() : base("Area 6") { Revision = 2; }

        public override void OnWorldInit()
        {
            SetTransition("Ruins2_10b", "left1", "Abyss_18", "left1");
            SetTransition("Abyss_18", "right1", "Abyss_04", "left1");
            SetTransition("Abyss_04", "bot1", "RestingGrounds_02", "top1");
            SetTransition("RestingGrounds_02", "left1", "RestingGrounds_05", "left1");
            SetTransition("RestingGrounds_05", "bot1", "RestingGrounds_17", "right1");
            SetTransition("RestingGrounds_05", "right2", "Abyss_22", "left1");
            SetTransition("RestingGrounds_05", "left2", "Room_Queen", "left1");
            SetTransition("RestingGrounds_05", "left3", "RestingGrounds_04", "right1");
            SetTransition("RestingGrounds_04", "left1", "Abyss_04", "right1");
            SetTransition("Abyss_04", "top1", "Abyss_02", "bot1");
            SetTransition("Abyss_02", "right1", "Abyss_05", "left1");
            SetTransition("Abyss_05", "right1", "Abyss_21", "right1");

            SetItem(LocationNames.Dreamshield, ItemNames.Mask_Shard);
            SetItem(LocationNames.Hidden_Station_Stag, ItemNames.Kings_Idol);

            SetItem(LocationNames.Ancient_Basin_Map, ItemNames.Hidden_Station_Stag);
            SetItem(LocationNames.Vessel_Fragment_Basin, ItemNames.Mask_Shard);

            //place Carefree Melody
            AbstractPlacement placement = Finder.GetLocation(LocationNames.Queen_Fragment).Wrap();
            AbstractItem aitem = new CarefreeMelodyItem();
            aitem.UIDef = new MsgUIDef() {
                name = new BoxedString("Carefree Melody"),
                shopDesc = new BoxedString(""),
                sprite = new CarefreeMelodyItem.Sprite()
                //sprite=new BoxedSprite(SpriteManager.Instance.GetSprite("ItemChanger.Resources.Charms.40.png"))
            };
            placement.Add(aitem);
            ItemChangerMod.AddPlacements(new AbstractPlacement[] { placement }, PlacementConflictResolution.Replace);

            SetItem(LocationNames.Wanderers_Journal_Ancient_Basin, ItemNames.Rancid_Egg);
            SetItem(LocationNames.Monarch_Wings, ItemNames.Awoken_Dream_Nail);
        }

        public override void OnInit()
        {
            ReplaceText("HIDDEN_STATION", "Palace Gardens", "StagMenu");
            ReplaceText("HIDDEN_STATION_SUPER", "The King's");
            ReplaceText("RESTING_GROUNDS_SUPER", "Old Palace");
            ReplaceText("RESTING_GROUNDS_MAIN", "Graveyard");
            ReplaceText("ABYSS_MAIN", "Gardens");
            ReplaceText("ABYSS_SUPER", "Scorched");
            ReplaceText("PALACE_GROUNDS_MAIN", "Ruins");
            ReplaceText("ABYSS", "Scorched Gardens", "MapZones");
            ReplaceText("PALACE_GROUNDS", "Palace Ruins", "MapZones");
            ReplaceText("RESTING_GROUNDS", "Old Graveyard", "MapZones");

            ReplaceText("QUEEN_SUPER", "The Glimmering");
            ReplaceText("QUEEN_DUNG_02", "When I was young we used to try and sneak them into peoples back pockets, for a laugh.");
            ReplaceText("QUEEN_DUNG", "You poor thing! Did someone sell you one of those old prank charms?");
            ReplaceText("QUEEN_DREAM", "Will I ever leave here alive? These gardens used to bloom so beautifully. How I loathe that usurper!");
            ReplaceText("QUEEN_MEET", "Aah, someone's there! Are you one of his men!? Please! Don't tell him! I'll give you anything I've got!");
            ReplaceText("QUEEN_TALK_01", "So... you aren't a member of the masked army? What a relief! Thank you for finding me. I've been hiding here for an eternity. Keep the charm, maybe you can help me. If you want.");
            ReplaceText("QUEEN_TALK_02", "My husband has been locked deep below, battered and beaten, to suffer for all eternity.<page>I want you to break the seal placed on him, to end his pain forever.");
            ReplaceText("QUEEN_TALK_EXTRA", "Killing him won't be enough... a more powerful strike will be needed to break his seal.<page>I know there are tools to enter minds. I know such a tool is hidden on these Grounds, but whether it's enough I cannot say.<page>You may need to find a way to strengthen it.");
            ReplaceText("QUEEN_MEET_REPEAT", "Please... I beg you... Release him from his suffering.");

            ReplaceText("ABYSS_GREET", "Ah, the little wanderer shows himself again! I have just finished fixing up the old station at the palace.<page>Not much of a palace anymore. Filled with fortifications, burned down and smashed to bits. But the stag network has a duty to fullfill.<page>Be careful, the station is still full of cable reels from my repairs.");

            //Xero
            ReplaceText("XERO_INSPECT", "Here rests the great toothpick industrialist");
            ReplaceText("XERO_TALK", "My empire! I sold thousands of toothpicks a year once! Now all is gone!<page>You! You wield a toothpick! I challenge you!");
            ReplaceText("XERO_DEFEAT", "My toothpicks! You've broken them! What else is left for me in this cruel world!");
            ReplaceText("XERO_REPEAT", "Fight me, you blasphemer against all holy toothpicks!");
        }
    }
}
