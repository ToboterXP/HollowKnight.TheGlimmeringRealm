using Modding;
using On;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ItemChanger;
using ItemChanger.Modules;
using UObject = UnityEngine.Object;
using System.Reflection;
using GlobalEnums;
using InControl;
using System.Drawing;
using ItemChanger.Internal;


/* The Glimmering Realm
 * A world changer mod, by Toboter
 * 
 * 
 */

namespace HKSecondQuest
{
    public class HKSecondQuest : Mod
    {
        internal static HKSecondQuest Instance;

        List<Room> rooms = new List<Room>();

        public TextChanger TextChanger = new TextChanger();

        PrefabManager PrefabMan = new PrefabManager();

        //the currently active room
        public Room ActiveRoom = null;

        public RoomMirrorer RoomMirrorer = new RoomMirrorer();

        public HKSecondQuest() : base("The Glimmering Realm")
        {
            Instance = this;

            //Instantiate all Room subclasses
            foreach (Type type in this.GetType().Assembly.GetTypes())
            {
                if (type.BaseType == typeof(Room))
                {
                    rooms.Add((Room)Activator.CreateInstance(type));
                }
            }
        }


        public override string GetVersion()
        {
            return "v0.9";
        }

        public override List<(string, string)> GetPreloadNames()
        {
            return PrefabMan.GetPreloadNames();
        }


        //Called when a new save file is started
        public void InitializeWorld(On.UIManager.orig_StartNewGame orig, UIManager self, bool permaDeath, bool bossRush)
        {
            
            Log("Initializing World");

            //initialize IC
            ItemChangerMod.CreateSettingsProfile(false, false);
            ItemChangerMod.Modules.GetOrAdd<TransitionFixes>();
            ItemChangerMod.Modules.GetOrAdd<MenderbugUnlock>();
            ItemChangerMod.Modules.GetOrAdd<ElevatorPass>();

            //Call OnInit for all Room subclasses
            foreach (Room room in rooms)
            {
                room.OnWorldInit();
                Log("Initialized " + room.RoomName);
            }
            Log("World Initialized");

            orig(self, permaDeath, bossRush);
        }



        //called when the mod is initialized
        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            Log("Initializing Mod");

            Instance = this;

            //set up hooks
            On.GameManager.OnNextLevelReady += OnSceneLoad;
            On.UIManager.StartNewGame += InitializeWorld;

            On.HeroController.TakeDamage += OnDamage;

            On.MenuStyleTitle.SetTitle += OnMainMenu;

            On.HeroController.Update += OnUpdate;

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnBeforeSceneLoad;

            //intialize the Prefabs
            PrefabMan.InitializePrefabs(preloadedObjects);

            //initialize the TextChanger
            TextChanger.Hook();

            RoomMirrorer.Hook();

            GameCompletion.Hook();

            //Call OnInit for all Room subclasses
            foreach (Room room in rooms)
            {
                room.OnInit();
                Log("Initialized " + room.RoomName); 
            }

            GeneralChanges.ChangeText();

            

            Log("Initialization Complete");
        }

        public void OnDamage(On.HeroController.orig_TakeDamage orig, global::HeroController self, GameObject go, CollisionSide damageSide, int damageAmount, int hazardType)
        {
            if (ActiveRoom != null && damageAmount < ActiveRoom.MinDamage) damageAmount = ActiveRoom.MinDamage;
            orig(self, go, damageSide, damageAmount, hazardType);
        }

        //called before the room has started loading
        public void OnBeforeSceneLoad(Scene current, Scene next)
        {
            string scene = next.name;
            ActiveRoom = null;

            GeneralChanges.OnSceneLoad();

            foreach (Room room in rooms)
            {
                if (room.RoomName == scene)
                {
                    ActiveRoom = room;
                    room.OnBeforeLoad();
                }
            }

            RoomMirrorer.UpdateFlipping();

        }

        //called after the room has loaded
        public void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);
            string scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            Log("Loading " + scene);
            foreach (Room room in rooms)
            {
                if (room.RoomName == scene)
                {
                    room.OnLoad();
                }
            }
        }

        //Called when the main menu is opened
        public void OnMainMenu(On.MenuStyleTitle.orig_SetTitle orig, global::MenuStyleTitle self, int index)
        {
            orig(self, index);
            GameObject title = GameObject.Find("LogoTitle");
            if (title != null)
            {
                var assembly = Assembly.GetExecutingAssembly();

                foreach (string name in assembly.GetManifestResourceNames()) Log(name);

                using (var stream = assembly.GetManifestResourceStream("HKSecondQuest.Resources.title.png"))
                {
                    Sprite titleSprite = SpriteManager.Load(stream);
                    title.GetComponent<SpriteRenderer>().sprite = titleSprite;
                    //slightly blue, to make it stand apart from the background
                    title.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(193 / 255f, 225 / 255f, 253 / 255f);
                    title.transform.SetScaleMatching(2.7f);
                }
            }
        }

        //Called every frame
        public void OnUpdate(On.HeroController.orig_Update orig, global::HeroController self)
        {
            orig(self);
            GeneralChanges.OnUpdate();
        }
    }
}