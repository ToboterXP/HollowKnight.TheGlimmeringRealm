using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemChanger;
using ItemChanger.Items;
using UnityEngine;

namespace HKSecondQuest
{
    internal class CarefreeMelodyItem : ItemChanger.Items.CharmItem
    {
        public class Sprite : ISprite
        {
            public UnityEngine.Sprite Value
            {
                get { return CharmIconList.Instance.nymmCharm; }
            }

            public ISprite Clone()
            {
                return new Sprite();
            }
        }
        public CarefreeMelodyItem()
        {
            charmNum = 40;
        }

        public override void GiveImmediate(GiveInfo info)
        {
            base.GiveImmediate(info);
            PlayerData.instance.charmCost_40 = 3;
            PlayerData.instance.grimmChildLevel = 5;
            GameObject.Find("Queen").LocateMyFSM("Conversation Control").SendEvent("GET ITEM MSG END"); //to make queen fsm advance
        }
    }
}
