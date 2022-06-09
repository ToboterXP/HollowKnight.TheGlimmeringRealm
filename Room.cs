using ItemChanger;
using ItemChanger.Tags;
using ItemChanger.UIDefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest
{
    public abstract class Room
    {
        public string RoomName;

        public bool IsFlipped = false;

        public int MinDamage = 1;

        protected Room(string roomName)
        {
            RoomName = roomName;
        }

        //called when the mod is initializing
        public virtual void OnInit() {}

        //called when the save is created the first time
        public virtual void OnWorldInit() {}

        //called before the room is loaded
        public virtual void OnBeforeLoad() {}

        //called when the room is loaded
        public virtual void OnLoad() {}


        //Call in OnWorldInit
        public void SetItem(string location, string item, bool merge = false, int geoCost = 0, int essenceCost = 0, int grubCost = 0, string alternateName=null, string alternateDesc=null, bool destroySeerRewards=false)
        {
            //find item and location
            AbstractPlacement placement = Finder.GetLocation(location).Wrap();
            AbstractItem aitem = Finder.GetItem(item);

            if (geoCost > 0) 
            {
                aitem.AddTag<CostTag>().Cost = new GeoCost(geoCost);
            }

            if (essenceCost > 0)
            {
                aitem.AddTag<CostTag>().Cost = new PDIntCost(essenceCost, nameof(PlayerData.dreamOrbs), essenceCost+" Essence");
            }

            if (grubCost > 0)
            {
                aitem.AddTag<CostTag>().Cost = new PDIntCost(grubCost, nameof(PlayerData.grubsCollected), grubCost+" Grubs");
            }

            if (alternateName != null) ((MsgUIDef)aitem.UIDef).name = new BoxedString(alternateName);
            if (alternateDesc != null) ((MsgUIDef)aitem.UIDef).shopDesc = new BoxedString(alternateDesc);

            placement.Add(aitem);

            if (destroySeerRewards)
            {
                placement.AddTag<DestroySeerRewardTag>().destroyRewards = SeerRewards.All;
            }

            PlacementConflictResolution resolution = merge ? PlacementConflictResolution.MergeKeepingNew : PlacementConflictResolution.Throw;

            //add placement
            ItemChangerMod.AddPlacements(new AbstractPlacement[] { placement }, resolution);
        }

        //Call in OnWorldInit
        public void SetTransition(string sourceScene, string sourceGate, string targetScene, string targetGate, bool oneWay = false)
        {
            Transition t1 = new Transition(sourceScene, sourceGate);
            Transition t2 = new Transition(targetScene, targetGate);

            ItemChangerMod.AddTransitionOverride(t1, t2);

            if (!oneWay) ItemChangerMod.AddTransitionOverride(t2, t1);
        }

        //Call in OnLoad
        public GameObject PlaceGO(GameObject prefab, float x, float y, Quaternion? rotation = null)
        {
            GameObject go =  GameObject.Instantiate(prefab, new Vector3(x, y, 0), rotation.GetValueOrDefault(Quaternion.identity));
            go.SetActive(true);
            return go;
        }

        //Call in OnLoad
        public void DestroyGO(string name)
        {
            GameObject.Destroy(GameObject.Find(name));
        }

        //Call in OnInit
        public void ReplaceText(string key, string text, string sheetKey = "")
        {
            HKSecondQuest.Instance.TextChanger.AddReplacement(key, text, sheetKey);
        }

        //Call in OnBeforeLoad
        public void SetDarkness(bool dark)
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)).Where(go => go.name == "_SceneManager"))
            {
                go.GetComponent<SceneManager>().darknessLevel = dark ? 2 : 0;
            }
        }
        
    }
}
