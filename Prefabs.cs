using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest
{
    /// <summary>
    /// Contains the data necessary to find and load a prefab
    /// </summary>
    class Prefab
    {
        public string OriginRoom;
        public string OriginName;

        public GameObject Object;

        public Prefab(string originRoom, string originName)
        {
            OriginRoom = originRoom;
            OriginName = originName;
        }
    }

    /// <summary>
    /// Contains the prefabs to be loaded by the PrefabManager
    /// </summary>
    internal class Prefabs
    {
        public static Prefab BREAKABLE_FLOOR = new Prefab("RestingGrounds_05", "Quake Floor");
        public static Prefab LEFT_TRANSITION = new Prefab("Crossroads_01", "left1");
        public static Prefab RIGHT_TRANSITION = new Prefab("Crossroads_01", "_Transition Gates/right1");
        public static Prefab SMALL_PLATFORM = new Prefab("Tutorial_01", "_Scenery/plat_float_17");
        public static Prefab LARGE_PLATFORM = new Prefab("Crossroads_01", "_Scenery/plat_float_07");
        public static Prefab GARDENS_PLATFORM = new Prefab("Fungus3_08", "Royal Gardens Plat S");
        public static Prefab BOUNCE_MUSHROOM = new Prefab("Fungus2_20", "Bounce Shroom B");
        public static Prefab DUSK_KNIGHT = new Prefab("Abyss_05", "Dusk Knight");
        public static Prefab WHITE_PALACE_ENTRANCE = new Prefab("White_Palace_11", "door1");
        public static Prefab DREAM_ENTRY = new Prefab("White_Palace_11", "Dream Entry");
    }
}
