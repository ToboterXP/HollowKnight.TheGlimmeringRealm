using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest
{
    internal class GameCompletion
    {
        public static bool Enabled = false;

        public static void Hook()
        {
            On.PlayerData.CountGameCompletion += CalculateCompletion;
        }

        public static void CalculateCompletion(On.PlayerData.orig_CountGameCompletion orig, global::PlayerData self)
        {
            orig(self);

            if (!Enabled) return;

            int charmCount = self.charmsOwned; //max 16

            int nailUpgrades = self.nailSmithUpgrades; // max 3

            int charmNotches = self.charmSlots - 3; //max 3

            int spells = 0; //max 3
            if (self.fireballLevel > 0) spells++;
            if (self.screamLevel > 0) spells++;
            if (self.quakeLevel > 0) spells++;

            int mainUpgrades = 0; //max 7
            if (self.hasDoubleJump) mainUpgrades++;
            if (self.hasSuperDash) mainUpgrades++;
            if (self.hasTramPass) mainUpgrades++;
            if (self.hasWalljump) mainUpgrades++;
            if (self.hasLantern) mainUpgrades++;
            if (self.hasDreamNail) mainUpgrades++;
            if (self.hasDreamGate) mainUpgrades++;

            int dreamers = 0; //max 3
            if (self.monomonDefeated) dreamers++;
            if (self.hegemolDefeated) dreamers++;
            if (self.lurienDefeated) dreamers++;

            int masks = self.maxHealth - 5; //max 1
            int vessels = self.MPReserveMax / 11; //max 1

            float percentage = 3 * charmCount + 2 * nailUpgrades + 3 * charmNotches + 3 * spells + 2 * mainUpgrades + 3 * dreamers + 3 * masks + 2 * vessels;

            self.completionPercentage = percentage;
        }
    }
}
