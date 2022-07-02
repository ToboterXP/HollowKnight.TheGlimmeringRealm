using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Area8
{
    internal class Area8 : Room
    {
        public Area8() : base("Area 8") { Revision = 2; }

        public override void OnWorldInit()
        {
            SetTransition("Deepnest_East_03", "right1", "White_Palace_11", "left1");
            SetTransition("White_Palace_11", "door2", "White_Palace_05", "right1");
            SetTransition("White_Palace_05", "left1", "White_Palace_03_hub", "bot1");
            SetTransition("White_Palace_03_hub", "left2", "White_Palace_13", "left2");
            SetTransition("White_Palace_03_hub", "left1", "White_Palace_13", "left1");
            SetTransition("White_Palace_13", "right1", "Room_Mender_House", "left1");
            SetTransition("Room_Mender_House", "left1", "White_Palace_03_hub", "left1", oneWay: true);
            SetTransition("White_Palace_03_hub", "right1", "White_Palace_15", "left1");
            SetTransition("White_Palace_15", "right2", "White_Palace_04", "right2");
            SetTransition("White_Palace_04", "top1", "White_Palace_15", "right1");
            //SetTransition("White_Palace_03_hub", "top1", "GG_Hollow_Knight", "door1");
        }

        public override void OnInit()
        {
            ReplaceText("MENDER_DIARY", "Hi, my name is Toboter. We've probably never talked, but it seems you are enjoying my mod. And I just wanted to thank you with all my heart for playing it.<page>Many people have contributed to this. I couldn't have changed the game's world like I did without the ItemChanger Mod by homothety and Flibber. And Gaia - the Dancer On The Sun did wonderful work on the cutscenes, which truely elevate the story. homothety also made the MenuChanger mod that made it possible for me to make this a seperate game mode.<page>I want to thank Exempt-Medic, DwarfWoot, Rye and all the other playtesters for enduring a less than stellar version of this mod.<br>And I want to thank everyone in the Hollow Knight Modding Discord who offered guidance and technical help.<page>But the final person I want to thank...<page>Is the one who recommended you the mod.<page>They're the real hero of this story.<page>You want to be thanked for playing? I did that at the very start! Were you even listening?!<page>Okay...<page>fine...<page>Thank you so much for playing. If you want to chat, there's a channel in the Modding Discord. I hope I could temporarily ease some of the burdens on your current path in life. So... Good luck with the rest of the mod, I guess!");
            ReplaceText("WHITE_PALACE", "The Glimmering Palace");
            ReplaceText("WHITE_PALACE_SUPER", "The Glimmering");
            ReplaceText("HK_PRIME_MAIN", "The Glimmering King");
        }
    }
}
