using ItemChanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest.Rooms.Village1
{
    internal class Sly : Room
    {
        public Sly() : base("Room_shop") { }

        public override void OnInit()
        {
            ReplaceText("SLY_GENERIC", "Ah a customer from afar. Come in, come in!");
            ReplaceText("SLY_NAIL_HONED", "Oh, you met the old Nailsmith? Funny old fella. Always had an interesting story to tell, on an evening in the pubs of the Glimmering City.<page>Most of them were about swords, though.");
            ReplaceText("SLY_MAPPER", "Ah, the old stag station is getting back up and running? I used to take it all the way up to the City three times a week, to resupply. But those days have long passed.");
            ReplaceText("SLY_DREAM_STORE", "More geo... maybe... just one more visit?");
            ReplaceText("SLY_NOSTOCK_2", "Sorry, but I'm out of stock. The supply situation isn't what it was, you see? Even my storeroom has bled dry.<page>I could sell you some fresh durandoo meat, or a fine mushroom sandwich fresh from the plantations.<page>But you don't seem like the kind of fella that eats very much.");
            ReplaceText("SLY_NAILART", "Oh, you met old Sheo up Kings Pass? Strange fella. Buys all my art supplies whenever I have any.");
            ReplaceText("SLY_SHOP_INTRO", "Oh, you're back! I wondered whether we'd see each other again.<br>I was a little worse for wear up there, so I should thank you again for helping me out.<page>If you had the time I'd invite you to a drink in the Glimmering City. But the stag network is broken, and good luck finding an elevator pass!");
            ReplaceText("SLY_KEY", "The key to my storeroom! You found it! Goodness gracious, I was worried where it might have gone.<br>I should really drink less next time!");
            ReplaceText("SLY_KEY_2", "The key to my storeroom! You found it! Goodness gracious, I was worried where it might have gone.<br>I should really drink less next time!");
            ReplaceText("SLY_NOSTOCK_1", "Sorry, but looks like I'm all out. I could sell you some fresh durandoo meat, or a fine mushroom sandwich fresh from the plantations.<page>But you don't seem like the kind of fella that eats very much.");
        }

        public override void OnWorldInit()
        {
            SetItem(LocationNames.Sly, ItemNames.Tram_Pass, true, 800, alternateDesc: "A carved chitin card. Permits the traveler access to the trams of the Glimmering Realm");
            SetItem(LocationNames.Sly, ItemNames.Mask_Shard, true, 120, alternateDesc: "A cracked fragment of white, pale shell. Just like your own.");
            SetItem(LocationNames.Sly, ItemNames.Spore_Shroom, true, 180, alternateDesc: "A small medal, overgrown with a thick layer of fungi. They slowly shed their spores all around.");
            SetItem(LocationNames.Sly, ItemNames.Rancid_Egg, true, 110, alternateDesc: "A foul smelling egg. Said to be a delicacy from a faraway kingdom.");
            SetItem(LocationNames.Sly, ItemNames.Heavy_Blow, true, 180, alternateDesc: "A heavy medal of multiple tiny nails forged together.");
            SetItem(LocationNames.Sly_Key, ItemNames.Pale_Ore, true, 530, alternateDesc: "A glimmering chunk of fairly average looking rock. Probably completely unnecessary for your journey.");
            SetItem(LocationNames.Sly_Key, ItemNames.Nailmasters_Glory, true, 500, alternateDesc: "A small medal, bearing the sigil of a long forgotten master of the blade.");
            SetItem(LocationNames.Sly_Key, ItemNames.Mark_of_Pride, true, 580, alternateDesc: "A medal bearing a crude sigil. It seems to have been carved with a very sharp claw.");
        }
    }
}
