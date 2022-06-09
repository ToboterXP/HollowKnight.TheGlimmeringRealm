using Modding;
using System.Collections.Generic;
using UnityEngine;
using UObject = UnityEngine.Object;
using UCamera = UnityEngine.Camera;
using InControl;
using GlobalEnums;
using System;
using MonoMod.Cil;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker;

/* Mirroring Code from Mimijackz MirroredHallownest Mod
 * 
 * Input flipping fixed by Mulhima
 */

namespace HKSecondQuest
{
    public class IsFlippedComponent : MonoBehaviour
    {
        public bool flipped = false;
    }

    public class RoomMirrorer
    {

        private bool isFlipping = false;
        private bool previouslyFlipping = false;

        List<string> excludedObjects = new List<string>();

        public void Hook()
        {
            On.tk2dCamera.UpdateCameraMatrix += OnUpdateCameraMatrix;
            On.GameCameras.StartScene += OnNewSceneCam;

            IL.HeroController.HeroDash += FlipHorizontalInput;
            IL.HeroController.FixedUpdate += FlipHorizontalInput;
            IL.HeroController.LookForInput += FlipHorizontalInput;
            IL.HeroController.UnPauseInput += FlipHorizontalInput;

            On.HeroController.LookForInput += FlipHorizontalInputMore;
            On.GameManager.OnNextLevelReady += FlipSwimFSM;

            On.ObjectPool.Spawn_GameObject_Transform_Vector3_Quaternion += OnSpawnObject;
            On.GameManager.OnNextLevelReady += OnSceneLoad;
            On.GameMap.Update += GameMapUpdate;

        }

        public void UpdateFlipping()
        {
            previouslyFlipping = isFlipping;
            if (HKSecondQuest.Instance.ActiveRoom != null) isFlipping = HKSecondQuest.Instance.ActiveRoom.IsFlipped;
            else isFlipping = false;
        }

        public void FlipSwimFSM(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);

            if (!HeroController.instance) return;

            PlayMakerFSM fsm = HeroController.instance.gameObject.LocateMyFSM("Surface Water");

            List<FsmState> states = new List<FsmState>(fsm.FsmStates);

            FsmState swimRight = states.Find((state) => state.Name == "Swim Right");
            FsmState swimLeft = states.Find((state) => state.Name == "Swim Left");

            //swap directions of swimming if the world has been flipped
            if (isFlipping != previouslyFlipping)
            {
                FunctionCall swap = ((SendMessage)swimRight.Actions[0]).functionCall;
                ((SendMessage)swimRight.Actions[0]).functionCall = ((SendMessage)swimLeft.Actions[0]).functionCall;
                ((SendMessage)swimLeft.Actions[0]).functionCall = swap;

                FsmFloat swap2 = ((SetVelocity2d)swimRight.Actions[3]).x;
                ((SetVelocity2d)swimRight.Actions[3]).x = ((SetVelocity2d)swimLeft.Actions[3]).x;
                ((SetVelocity2d)swimLeft.Actions[3]).x = swap2;
            }
        }

        private void FlipHorizontalInputMore(On.HeroController.orig_LookForInput orig, global::HeroController self)
        {
            orig(self);
            if (isFlipping) self.move_input = -self.move_input;
        }

        //Thanks Mulhima for the help!
        private void FlipHorizontalInput(ILContext il)
        {
            if (isFlipping)
            {
                var cursor = new ILCursor(il);

                while (cursor.TryGotoNext(MoveType.After,
                            i => i.MatchLdfld<HeroController>("inputHandler"),
                            i => i.MatchLdfld<InputHandler>("inputActions"),
                            i => i.MatchLdfld<HeroActions>("right")
                        ))
                {
                    cursor.EmitDelegate<Func<PlayerAction, PlayerAction>>((_) => {
                        if (isFlipping)
                        {
                            return InputHandler.Instance.inputActions.left;
}
                        else
                        {
                            return InputHandler.Instance.inputActions.right;
                        }
                    });
                }

                cursor.Goto(0);

                while (cursor.TryGotoNext(MoveType.After,
                            i => i.MatchLdfld<HeroController>("inputHandler"),
                            i => i.MatchLdfld<InputHandler>("inputActions"),
                            i => i.MatchLdfld<HeroActions>("left")
                        ))
                {
                    cursor.EmitDelegate<Func<PlayerAction, PlayerAction>>((_) => {
                        if (isFlipping)
                        {
                            
                            return InputHandler.Instance.inputActions.right;
                        }
                        else
                        {
                            return InputHandler.Instance.inputActions.left;
                        }
                    });
                }
            }
        }

        public void AddExcludedObject(string name)
        {
            excludedObjects.Add(name);
        }

        private void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);

            /*foreach (string name in excludedObjects)
            {
                Transform transform = GameObject.Find(name).transform;
                transform.SetScaleX(-transform.GetScaleX());
            }*/

            foreach (GameObject prefab in GameObject.FindObjectsOfType<GameObject>())
            {
                if (isFlipping && prefab.scene.name != "DontDestroyOnLoad" && prefab.scene.name != "HideAndDontSave")
                {

                    PromptMarker prefabPrompt;
                    TMPro.TextMeshPro textMesh;
                    prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                    prefab.gameObject.TryGetComponent(out textMesh);
                    if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x > 0)
                    {
                        prefab.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }
                else
                {
                    PromptMarker prefabPrompt;
                    TMPro.TextMeshPro textMesh;
                    prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                    prefab.gameObject.TryGetComponent(out textMesh);
                    if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x < 0)
                    {
                        prefab.transform.localScale = Vector3.one;
                    }

                    excludedObjects.Clear();
                }
            }
        }

        private void GameMapUpdate(On.GameMap.orig_Update orig, GameMap self)
        {
            orig(self);

            if (!isFlipping) return;

            float scaleX = self.transform.GetScaleX();
            if (scaleX >= 0)
            {
                self.transform.SetScaleX(scaleX * -1);
            }
        }



        private void OnNewSceneCam(On.GameCameras.orig_StartScene orig, GameCameras self)
        {

            orig(self);
            if (isFlipping)
            {
                if (!hasBlurCam(self))
                {
                    return;
                }
                /*if (self.tk2dCam.transform.GetComponentInChildren<IsFlippedComponent>() == null) self.tk2dCam.gameObject.AddComponent<IsFlippedComponent>();
                if (self.tk2dCam.transform.GetComponentInChildren<IsFlippedComponent>().flipped)
                {
                    return;
                }

                self.tk2dCam.transform.GetComponentInChildren<IsFlippedComponent>().flipped = true;*/
                foreach (UCamera cam in self.tk2dCam.transform.GetComponentsInChildren<UCamera>()) {
                    if (cam.GetComponent<IsFlippedComponent>() == null) cam.gameObject.AddComponent<IsFlippedComponent>();
                    if (!cam.GetComponent<IsFlippedComponent>().flipped)
                    {
                        HKSecondQuest.Instance.Log("Flip " + cam.name);
                        cam.GetComponent<IsFlippedComponent>().flipped = true;
                        FlipUCam(cam);
                    }
                }
            } else
            {
                foreach (UCamera cam in self.tk2dCam.transform.GetComponentsInChildren<UCamera>())
                {
                    if (cam.GetComponent<IsFlippedComponent>() == null) cam.gameObject.AddComponent<IsFlippedComponent>();
                    if (cam.GetComponent<IsFlippedComponent>().flipped)
                    {
                        HKSecondQuest.Instance.Log("Unflip " + cam.name);
                        cam.GetComponent<IsFlippedComponent>().flipped = false;
                        FlipUCam(cam);
                    }
                }
            }
        }

        private GameObject OnSpawnObject(On.ObjectPool.orig_Spawn_GameObject_Transform_Vector3_Quaternion orig, GameObject prefab, Transform parent, Vector3 pos, Quaternion rot)
        {
            prefab = orig(prefab, parent, pos, rot);
            if (isFlipping)
            {
                
                PromptMarker prefabPrompt;
                TMPro.TextMeshPro textMesh;
                prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                prefab.gameObject.TryGetComponent(out textMesh);
                if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x > 0)
                {
                    prefab.transform.localScale = new Vector3(-1, 1, 1);
                }
            } else
            {
                PromptMarker prefabPrompt;
                TMPro.TextMeshPro textMesh;
                prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                prefab.gameObject.TryGetComponent(out textMesh);
                if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x < 0)
                { 
                    prefab.transform.localScale = Vector3.one;
                }
            }
            
            return prefab;
        }

        private void OnUpdateCameraMatrix(On.tk2dCamera.orig_UpdateCameraMatrix orig, tk2dCamera self)
        {
            orig(self);

            if (!isFlipping) return;

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Menu_Title") return;

            // Can't use ?. on a Unity type because they override == to null.
            if (GameCameras.instance == null || GameCameras.instance.tk2dCam == null)
                return;

            UCamera cam = self.GetComponent<UCamera>();

            if (cam == null)
                return;

            Matrix4x4 p = cam.projectionMatrix;

            Matrix4x4 _reflectMatrix = Matrix4x4.identity;
            _reflectMatrix[0, 0] = -1;
            p *= _reflectMatrix;

            cam.projectionMatrix = p;
        } 

        void FlipUCam(UCamera cam)
        {
            Matrix4x4 mat = cam.projectionMatrix;
            mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
            cam.projectionMatrix = mat;
        }
        bool hasBlurCam(GameCameras self)
        {
            return !(self.tk2dCam == null || self.tk2dCam.transform.GetComponentInChildren<Camera>() == null);
        }
    }
}
