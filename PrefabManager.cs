using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HKSecondQuest
{
    internal class PrefabManager
    {


        //returns a list of the requested prefabs
        public List<(string, string)> GetPreloadNames()
        {
            List<(string, string)> preloadNames = new List<(string, string)> ();

            foreach (FieldInfo prop in typeof(Prefabs).GetFields())
            {
                if (prop.IsStatic && prop.FieldType == typeof(Prefab))
                {
                    Prefab prefab = (Prefab)prop.GetValue(null);
                    preloadNames.Add((prefab.OriginRoom, prefab.OriginName));
                }
            }
            
            return preloadNames;
        }

        //assigns the loaded prefabs to their Prefab Object
        public void InitializePrefabs(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            HKSecondQuest.Instance.Log("Loaded Prefabs:" + preloadedObjects.Count);
            foreach (FieldInfo prop in typeof(Prefabs).GetFields())
            {
                if (prop.IsStatic && prop.FieldType == typeof(Prefab))
                {
                    Prefab prefab = (Prefab)prop.GetValue(null);
                    prefab.Object = preloadedObjects[prefab.OriginRoom][prefab.OriginName];
                }
            }
        }
    }
}
