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
    /// <summary>
    /// Handles changes to rooms or areas of the game
    /// </summary>
    public abstract class Room
    {
        /// <summary>
        /// The scene name of the room to be modified (if none is provided, OnBeforeLoad and OnLoad never trigger)
        /// </summary>
        public string RoomName;

        /// <summary>
        /// Should the room be flipped?
        /// </summary>
        public bool IsFlipped = false;

        /// <summary>
        /// What's the minimum amount of damage any hit should deal?
        /// </summary>
        public int MinDamage = 1;

        
        /// <param name="roomName">The scene name of this room (or a placeholder if there is none)</param>
        protected Room(string roomName)
        {
            RoomName = roomName;
        }

        /// <summary>
        /// Called on initialization of the mod
        /// </summary>
        public virtual void OnInit() {}

        /// <summary>
        /// Called on creation of a new save file
        /// </summary>
        public virtual void OnWorldInit() {}

        /// <summary>
        /// Called before any "Start" functions are executed in this room
        /// </summary>
        public virtual void OnBeforeLoad() {}

        /// <summary>
        /// Called after the "Start" functions of the room have executed
        /// </summary>
        public virtual void OnLoad() {}


        /// <summary>
        /// Changes an item location using ItemChanger (Call in OnWorldInit)
        /// </summary>
        /// <param name="location">The item location to change</param>
        /// <param name="item">The item it should be changed to</param>
        /// <param name="merge">Should the item be merged with other items place here (used for shops,grubfather & seer)?</param>
        /// <param name="alternateName">Alternate name to be displayed in shops</param>
        /// <param name="alternateDesc">Alternate description to be displayed in shops</param>
        /// <param name="destroySeerRewards">Should the normal rewards of Seer be removed? (only applicable at that location)</param>
        public void SetItem(string location, string item, bool merge = false, int geoCost = 0, int essenceCost = 0, int grubCost = 0, string alternateName=null, string alternateDesc=null, bool destroySeerRewards=false)
        {
            //find item and location
            AbstractPlacement placement = Finder.GetLocation(location).Wrap();
            AbstractItem aitem = Finder.GetItem(item);

            //set cost tags if necessary
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

            //change UIDef names if necessary
            if (alternateName != null) ((MsgUIDef)aitem.UIDef).name = new BoxedString(alternateName);
            if (alternateDesc != null) ((MsgUIDef)aitem.UIDef).shopDesc = new BoxedString(alternateDesc);

            placement.Add(aitem);

            //add DestroySeerRewardTag if necessary
            if (destroySeerRewards)
            {
                placement.AddTag<DestroySeerRewardTag>().destroyRewards = SeerRewards.All;
            }

            //choose conflict reolution methos
            PlacementConflictResolution resolution = merge ? PlacementConflictResolution.MergeKeepingNew : PlacementConflictResolution.Throw;

            //add placement
            ItemChangerMod.AddPlacements(new AbstractPlacement[] { placement }, resolution);
        }

        /// <summary>
        /// Changes a transition using ItemChanger
        /// </summary>
        /// <param name="oneWay">If true, no transition from target to source will be set</param>
        public void SetTransition(string sourceScene, string sourceGate, string targetScene, string targetGate, bool oneWay = false)
        {
            Transition t1 = new Transition(sourceScene, sourceGate);
            Transition t2 = new Transition(targetScene, targetGate);

            ItemChangerMod.AddTransitionOverride(t1, t2);

            if (!oneWay) ItemChangerMod.AddTransitionOverride(t2, t1);
        }

        /// <summary>
        /// Places a prefab (Call in OnBeforeLoad or OnLoad)
        /// </summary>
        public GameObject PlaceGO(GameObject prefab, float x, float y, Quaternion? rotation = null)
        {
            GameObject go =  GameObject.Instantiate(prefab, new Vector3(x, y, 0), rotation.GetValueOrDefault(Quaternion.identity));
            go.SetActive(true);
            return go;
        }

        /// <summary>
        /// Destroys the named GameObject (Call in OnBeforeLoad or OnLoad)
        /// </summary>
        public void DestroyGO(string name)
        {
            GameObject.Destroy(GameObject.Find(name));
        }

        /// <summary>
        /// Adds a text replacement to the TextChanger (Call in OnInit)
        /// </summary>
        public void ReplaceText(string key, string text, string sheetKey = "")
        {
            HKSecondQuest.Instance.TextChanger.AddReplacement(key, text, sheetKey);
        }

        /// <summary>
        /// Changes whether the room should be dark without lantern (Call in OnBeforeLoad)
        /// </summary>
        public void SetDarkness(bool dark)
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)).Where(go => go.name == "_SceneManager"))
            {
                go.GetComponent<SceneManager>().darknessLevel = dark ? 2 : 0;
            }
        }
        
    }
}
