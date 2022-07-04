using ItemChanger;
using ItemChanger.Internal;
using ItemChanger.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest
{
    internal class RevisionManager
    {

        public static void OnRevision(int oldRev, int newRev)
        {
            //Change Vengeful Spirit placement to Shade Soul
            if (oldRev < 2 && newRev >= 2)
            {
                AbstractPlacement vsPlacement;
                Ref.Settings.Placements.TryGetValue(LocationNames.City_Crest, out vsPlacement);
                if (vsPlacement.CheckVisitedAny(VisitState.ObtainedAnyItem))
                {
                    //if VS has been collected, upgrade it to Shade Soul
                    PlayerData.instance.fireballLevel = 2;
                } else
                {
                    //otherwise change the placement
                    AbstractPlacement placement = Finder.GetLocation(LocationNames.City_Crest).Wrap();
                    AbstractItem aitem = Finder.GetItem(ItemNames.Shade_Soul);
                    aitem.RemoveTags<IItemModifierTag>();
                    placement.Add(aitem);
                    ItemChangerMod.AddPlacements(new AbstractPlacement[] { placement }, PlacementConflictResolution.Replace);
                }

                SetTransition("Ruins1_31", "bot1", "Room_GG_Shortcut", "top1");
                SetTransition("Room_GG_Shortcut", "left1", "Ruins2_10b", "right1");
            }
        }

        public static void SetTransition(string sourceScene, string sourceGate, string targetScene, string targetGate, bool oneWay = false)
        {
            Transition t1 = new Transition(sourceScene, sourceGate);
            Transition t2 = new Transition(targetScene, targetGate);

            ItemChangerMod.AddTransitionOverride(t1, t2);

            if (!oneWay) ItemChangerMod.AddTransitionOverride(t2, t1);
        }
    }
}
