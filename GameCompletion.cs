using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest
{
    /// <summary>
    /// Implements changes to the games completion counter
    /// </summary>
    internal class GameCompletion
    {
        public static bool Enabled = false;

        public static void Hook()
        {
            On.PlayerData.CountGameCompletion += CalculateCompletion;
        }

        /// <summary>
        /// Recalculates completion based on items available in the Glimmering Realm
        /// </summary>
        public static void CalculateCompletion(On.PlayerData.orig_CountGameCompletion orig, global::PlayerData self)
        {
            orig(self);

            if (!Enabled) return;

            int charmCount = self.GetInt("charmsOwned"); //max 19

            int nailUpgrades = self.GetInt("nailSmithUpgrades"); // max 3

            int charmNotches = self.GetInt("charmSlots") - 3; //max 3

            int spells = 0; //max 3
            if (self.GetInt("fireballLevel") > 0) spells++;
            if (self.GetInt("screamLevel") > 0) spells++;
            if (self.GetInt("quakeLevel") > 0) spells++;

            int mainUpgrades = 0; //max 8
            if (self.GetBool("hasDoubleJump")) mainUpgrades++;
            if (self.GetBool("hasSuperDash")) mainUpgrades++;
            if (self.GetBool("hasTramPass")) mainUpgrades++;
            if (self.GetBool("hasWalljump")) mainUpgrades++;
            if (self.GetBool("hasLantern")) mainUpgrades++;
            if (self.GetBool("hasDreamNail")) mainUpgrades++;
            if (self.GetBool("hasDreamGate")) mainUpgrades++;
            if (self.GetBool("dreamNailUpgraded")) mainUpgrades++;

            int dreamers = 0; //max 3
            if (self.GetBool("monomonDefeated")) dreamers++;
            if (self.GetBool("hegemolDefeated")) dreamers++;
            if (self.GetBool("lurienDefeated")) dreamers++;

            int masks = self.GetInt("maxHealth") - 5; //max 2
            int vessels = self.GetInt("MPReserveMax") / 33; //max 1

            float percentage = 3 * charmCount + 1 * nailUpgrades + 2 * charmNotches + 2 * spells + 2 * mainUpgrades + 2 * dreamers + 2 * masks + 2 * vessels;

            if (percentage > 100) percentage = 100;

            self.completionPercentage = percentage;
        }
    }
}
