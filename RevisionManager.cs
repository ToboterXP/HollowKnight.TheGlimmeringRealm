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
            }
        }
    }
}
