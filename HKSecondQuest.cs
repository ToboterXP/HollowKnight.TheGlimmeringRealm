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
using System.Linq;


/* The Glimmering Realm
 * A world changer mod, by Toboter
 * 
 * 
 */


namespace HKSecondQuest
{
    ///<summary>
    ///Module used to store whether this is a second quest save file
    ///</summary>
    public class SaveSettings
    {
        public bool glimmeringRealmEnabled = false;
        public int revision = 1;
    }

    /// <summary>
    /// Base class of the mod that manages Rooms and various other systems
    /// </summary>
    public class HKSecondQuest : Mod, ILocalSettings<SaveSettings>
    {
        internal static HKSecondQuest Instance;

        /// <summary>
        /// Instances of all classes derived from Room
        /// </summary>
        List<Room> rooms = new List<Room>();

        public TextChanger TextChanger = new TextChanger();

        PrefabManager PrefabMan = new PrefabManager();

        /// <summary>
        /// The room instance corresponding to the currently loaded scene
        /// </summary>
        public Room ActiveRoom = null;

        public Room PreviousRoom = null;

        public RoomMirrorer RoomMirrorer = new RoomMirrorer();

        /// <summary>
        /// Is the mod activated in the current file?
        /// </summary>
        public bool Enabled = false;

        public static SaveSettings saveSettings { get; set; } = new SaveSettings();
        public void OnLoadLocal(SaveSettings s) => saveSettings = s;
        public SaveSettings OnSaveLocal() => saveSettings;

        public const int CurrentRevision = 3;


        public HKSecondQuest() : base("The Glimmering Realm")
        {
            Instance = this; 

            //Make sure the main menu text is changed, but disable all other functionalitly
            SetEnabled(false);
            TextChanger.Enabled = true; 

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
            return "v1.1.3.0";
        }

        public void SetEnabled(bool enabled)
        {
            Enabled = enabled;
            GameCompletion.Enabled = enabled;
            if (!enabled) {
                ActiveRoom = null;
                RoomMirrorer.UpdateFlipping();
            }
        }

        public override List<(string, string)> GetPreloadNames()
        {
            return PrefabMan.GetPreloadNames();
        }


        /// <summary>
        /// Hook for a new file starting, sets up ItemChanger 
        /// </summary>
        public void InitializeWorld(On.UIManager.orig_StartNewGame orig, UIManager self, bool permaDeath, bool bossRush)
        {
            if (!Enabled)
            {
                //make sure text changer gets disabled properly if the mod isn't enabled
                TextChanger.Enabled = false;  
            }
            else
            {
                Log("Initializing World");

                //initialize IC
                ItemChangerMod.CreateSettingsProfile(false, false);
                ItemChangerMod.Modules.GetOrAdd<TransitionFixes>();
                ItemChangerMod.Modules.GetOrAdd<MenderbugUnlock>();
                ItemChangerMod.Modules.GetOrAdd<ElevatorPass>();

                //save that this is a glimmeringRealm save file
                saveSettings.glimmeringRealmEnabled = true;
                saveSettings.revision = CurrentRevision;

                //Call OnWorldInit for all Room subclasses
                foreach (Room room in rooms)
                {
                    room.OnWorldInit();
                    Log("Initialized " + room.RoomName);
                }
                Log("World Initialized");
            }
             
            orig(self, permaDeath, bossRush);
        }

        /// <summary>
        /// Correct erroneous 7 grub reward from Grubfather
        /// </summary>
        public void CorrectGrubfather()
        {
            if (!saveSettings.glimmeringRealmEnabled) return;

            Settings set = (Settings)typeof(ItemChangerMod).GetField("SET", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
            foreach(var placement in set.GetPlacements())
            {
                if (placement.Name == LocationNames.Grubfather)
                {
                    foreach (var item in placement.Items)
                    {
                        if (item.name == ItemNames.Pale_Ore)
                        {
                            item.GetTag<CostTag>().Cost = new PDIntCost(6, nameof(PlayerData.grubsCollected), 6 + " Grubs");
                        }
                    }
                }
            }
        }

        public void OnSaveLoad()
        {
            if (!saveSettings.glimmeringRealmEnabled) return;

            if (saveSettings.revision < CurrentRevision)
            {
                RevisionManager.OnRevision(saveSettings.revision, CurrentRevision);

                //apply changes from new revisions if old revisions are loaded
                foreach(Room room in rooms)
                {
                    if (room.Revision > saveSettings.revision)
                    {
                        room.OnWorldInit();
                    }
                }
            }
            saveSettings.revision = CurrentRevision;
        }


        /// <summary>
        /// Called when the mod is loaded
        /// </summary>
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

            On.HeroController.Start += OnGameStart;

            On.GrimmEnemyRange.GetTarget += DisableGrimmchildShooting;

            Events.OnEnterGame += CorrectGrubfather;
            Events.OnEnterGame += OnSaveLoad;

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnBeforeSceneLoad;

            //intialize the Prefabs
            PrefabMan.InitializePrefabs(preloadedObjects);

            //initialize the TextChanger, RoomMirrorer, GameCompletion and Menu modules
            TextChanger.Hook();

            RoomMirrorer.Hook();

            GameCompletion.Hook();

            SecondQuestModeMenu.Register();

            //Call OnInit for all Room subclasses
            foreach (Room room in rooms)
            {
                room.OnInit();
                Log("Initialized " + room.RoomName); 
            }

            //load general text changes
            GeneralChanges.ChangeText();

            Log("Initialization Complete");
        }

        public GameObject DisableGrimmchildShooting(On.GrimmEnemyRange.orig_GetTarget orig, global::GrimmEnemyRange self)
        {
            if (!Enabled) return orig(self);
            return null;
        }

        /// <summary>
        /// Called when a file is started, ensures the mod gets enabled/disabled based on if the file is a Glimmering Realm save
        /// </summary>
        public void OnGameStart(On.HeroController.orig_Start orig, global::HeroController self)
        {
            orig(self);


            //Make sure Glimmering Realm is only active in the correct worlds
            if (saveSettings.glimmeringRealmEnabled)
            {
                SetEnabled(true);

                //workaround if HoGE messes with the PV fight
                if (ModHooks.GetMod("Hall of Gods Extras") is Mod)
                {
                    IMod hog = ModHooks.GetMod("Hall of Gods Extras");
                    object settings = hog.GetType().GetField("_localSettings", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
                    settings.GetType().GetField("_statueStateHollowKnight", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(settings, new BossStatue.Completion { hasBeenSeen = true, isUnlocked = true, usingAltVersion = true });
                }

            } else
            {
                SetEnabled(false);
            }

            TextChanger.Enabled = Enabled;

            
        }

        /// <summary>
        /// Called when the player takes damage, enforces the MinDamage feature of the Room class
        /// </summary>
        public void OnDamage(On.HeroController.orig_TakeDamage orig, global::HeroController self, GameObject go, CollisionSide damageSide, int damageAmount, int hazardType)
        {
            if (Enabled && ActiveRoom != null)
            {
                if (damageAmount < ActiveRoom.MinDamage && damageAmount > 0)
                {
                    damageAmount = ActiveRoom.MinDamage;
                }

                if (damageAmount > ActiveRoom.MaxDamage)
                {
                    damageAmount = ActiveRoom.MaxDamage;
                }
            } 

            orig(self, go, damageSide, damageAmount, hazardType);
        }

        /// <summary>
        /// Called before any "Start" functions in the new scene are executed
        /// </summary>
        public void OnBeforeSceneLoad(Scene current, Scene next)
        {
            if (!Enabled) return;

            string scene = next.name;
            ActiveRoom = null;

            //notify every module that needs it
            RoomMirrorer.BeforeSceneLoad();

            GeneralChanges.OnSceneLoad();

            PreviousRoom = ActiveRoom;

            //find and set the active room (if there is one
            foreach (Room room in rooms)
            {
                if (room.RoomName == scene)
                {
                    ActiveRoom = room;
                    room.OnBeforeLoad();
                }
            }

            //update whether the map should be flipped
            RoomMirrorer.UpdateFlipping();

        }

        /// <summary>
        /// Called after the "Start" functions of a newly loaded scene have executed
        /// </summary>
        public void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);

            if (!Enabled) return;

            if (HeroController.instance != null)
            {
                HeroController.instance.cState.inConveyorZone = false;
                HeroController.instance.cState.onConveyor = false;
                HeroController.instance.cState.onConveyorV = false;
            }

            //call the OnLoad functions of the current room
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

        /// <summary>
        /// Called when the main menu is opened, replaces the Hollow Knight Logo with the "Glimmering Realm" Logo
        /// </summary>
        public void OnMainMenu(On.MenuStyleTitle.orig_SetTitle orig, global::MenuStyleTitle self, int index)
        {
            orig(self, index);

            //disable everything except text changer
            SetEnabled(false);
            TextChanger.Enabled = true;

            GameObject title = GameObject.Find("LogoTitle");
            if (title != null)
            {
                var assembly = Assembly.GetExecutingAssembly();

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

        /// <summary>
        /// Called every frame, used by GeneralChanges
        /// </summary>
        public void OnUpdate(On.HeroController.orig_Update orig, global::HeroController self)
        {
            orig(self);

            if (!Enabled) return;

            GeneralChanges.OnUpdate();
        }


    }
}