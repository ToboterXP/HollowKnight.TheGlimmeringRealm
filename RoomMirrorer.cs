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
using System.Reflection;
using System.Collections;

/* Mirroring Code partially from Mimijackz MirroredHallownest Mod
 * 
 */

namespace HKSecondQuest
{
    /// <summary>
    /// Added to cameras to mark whether they have been flipped
    /// </summary>
    public class IsFlippedComponent : MonoBehaviour
    {
        public bool flipped = false;
    }

    /// <summary>
    /// Handles horizontal mirroring of rooms
    /// </summary>
    public class RoomMirrorer
    {

        private bool isFlipping = false;

        /// <summary>
        /// Are the inputs currently inverted?
        /// </summary>
        private bool inputsInverted = false; 

        /// <summary>
        /// List of all objects in this scene that shouldn't be ignored by the text correction code
        /// </summary>
        List<string> excludedObjects = new List<string>();

        //hook all the things that need hooking
        public void Hook()
        {
            On.tk2dCamera.UpdateCameraMatrix += OnUpdateCameraMatrix;
            On.GameCameras.StartScene += OnNewSceneCam;
            
            On.UIManager.GoToKeyboardMenu += OnOpenKeyboardMenu;
            On.UIManager.GoToRemapControllerMenu += OnOpenGamepadMenu;
            On.UIManager.HideCurrentMenu += OnHideMenu;

            On.HutongGames.PlayMaker.Actions.SendEventByName.OnEnter += OnSendEventByName;

            On.ObjectPool.Spawn_GameObject_Transform_Vector3_Quaternion += OnSpawnObject;
            On.GameManager.OnNextLevelReady += OnSceneLoad;
        }

        /// <summary>
        /// Handles inversion of the player controls (since the normal controls are effectively inverted when the camera is flipped)
        /// </summary>
        public void SetInvertInputs(bool invert)
        {
            if (invert != inputsInverted)
            {
                inputsInverted = invert;
                PlayerAction tmp = InputHandler.Instance.inputActions.left; 
                InputHandler.Instance.inputActions.left = InputHandler.Instance.inputActions.right;
                InputHandler.Instance.inputActions.right = tmp;

                //InputHandler.Instance.inputActions.moveVector.InvertXAxis = !InputHandler.Instance.inputActions.moveVector.InvertXAxis;
                InputHandler.Instance.inputActions.moveVector.InvertXAxis = invert;
            }
        }

        /// <summary>
        /// Uninvert the controls when the inventory is opened (since it uses a camera that isn't flipped)
        /// </summary>
        public void OnSendEventByName(On.HutongGames.PlayMaker.Actions.SendEventByName.orig_OnEnter orig, global::HutongGames.PlayMaker.Actions.SendEventByName self)
        {
            string event_ = self.sendEvent.Value;

            if (event_ == "INVENTORY OPENED") SetInvertInputs(false);
            if (event_ == "INVENTORY CLOSED") SetInvertInputs(isFlipping);

            orig(self);
        }

        /// <summary>
        /// Unflip the controls before any menu is closed (since that action saves the controls in the remapping menus)
        /// </summary>
        public IEnumerator OnHideMenu(On.UIManager.orig_HideCurrentMenu orig, global::UIManager self)
        {
            SetInvertInputs(false);

            var ret = orig(self);

            SetInvertInputs(isFlipping);

            return ret;
        }

        /// <summary>
        /// Make sure the keyboard remapping menu is only openable in unflipped rooms
        /// </summary>
        public IEnumerator OnOpenKeyboardMenu(On.UIManager.orig_GoToKeyboardMenu orig, global::UIManager self)
        {
            if (isFlipping) return self.GoToOptionsMenu(); //it seems to break stuff, so just don't allow it
             
            SetInvertInputs(false);

            return orig(self);
        }

        /// <summary>
        /// Make sure the gamepad remapping menu is only openable in unflipped rooms
        /// </summary>
        public IEnumerator OnOpenGamepadMenu(On.UIManager.orig_GoToRemapControllerMenu orig, global::UIManager self)
        {
            if (isFlipping) return self.GoToOptionsMenu(); //it seems to break stuff, so just don't allow it

            SetInvertInputs(false); 

            return orig(self);
        }



        /// <summary>
        /// Called before the scene is loaded, sets whether the current room is flipped
        /// </summary>
        public void UpdateFlipping()
        {
            if (HKSecondQuest.Instance.ActiveRoom != null) isFlipping = HKSecondQuest.Instance.ActiveRoom.IsFlipped;
            else isFlipping = false;
        }

        /// <summary>
        /// Adds an object to be ignored by the text correction code
        /// </summary>
        /// <param name="name"></param>
        public void AddExcludedObject(string name)
        { 
            excludedObjects.Add(name);
        }

        /// <summary>
        /// Called before a new scene is loaded, clears all previous excluded objects
        /// </summary>
        public void BeforeSceneLoad()
        {
            excludedObjects.Clear();
        }

        /// <summary>
        /// Called once a scene has finished loading, ensures the control inversion is correct, and that all text is either flipped or unflipped properly
        /// </summary>
        private void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);

            SetInvertInputs(isFlipping);


            foreach (GameObject prefab in GameObject.FindObjectsOfType<GameObject>())
            {
                //invert all text if it's in a flipped rooms scene
                if (isFlipping && prefab.scene.name != "DontDestroyOnLoad" && prefab.scene.name != "HideAndDontSave" && !excludedObjects.Contains(prefab.name))
                {

                    PromptMarker prefabPrompt;
                    TMPro.TextMeshPro textMesh;
                    prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                    prefab.gameObject.TryGetComponent(out textMesh);
                    if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x > 0)
                    {
                        Vector3 oldScale = prefab.transform.localScale;
                        prefab.transform.localScale = new Vector3(-oldScale.x, oldScale.y, oldScale.z);
                    }
                }
                //otherwise, make sure it's not inverted
                else
                {
                    PromptMarker prefabPrompt;
                    TMPro.TextMeshPro textMesh;
                    prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                    prefab.gameObject.TryGetComponent(out textMesh);
                    if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x < 0)
                    {
                        Vector3 oldScale = prefab.transform.localScale;
                        prefab.transform.localScale = new Vector3(-oldScale.x, oldScale.y, oldScale.z);
                    }
                }
            }
        }


        /// <summary>
        /// Called when the cameras have finished loading, makes sure they are properly flipped/unflipped
        /// </summary>
        private void OnNewSceneCam(On.GameCameras.orig_StartScene orig, GameCameras self)
        {

            orig(self);
            if (isFlipping)
            {
                if (!hasBlurCam(self)) 
                {
                    return;
                }
               
                foreach (UCamera cam in self.tk2dCam.transform.GetComponentsInChildren<UCamera>()) {
                    if (cam.GetComponent<IsFlippedComponent>() == null) cam.gameObject.AddComponent<IsFlippedComponent>();
                    if (!cam.GetComponent<IsFlippedComponent>().flipped)
                    {
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

        /// <summary>
        /// Flip any newly spawned text if required
        /// </summary>
        private GameObject OnSpawnObject(On.ObjectPool.orig_Spawn_GameObject_Transform_Vector3_Quaternion orig, GameObject prefab, Transform parent, Vector3 pos, Quaternion rot)
        {
            prefab = orig(prefab, parent, pos, rot);
            //flip text in a flipped room
            if (isFlipping && !excludedObjects.Contains(prefab.name))
            {

                PromptMarker prefabPrompt;
                TMPro.TextMeshPro textMesh;
                prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                prefab.gameObject.TryGetComponent(out textMesh);
                if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x > 0)
                {
                    Vector3 oldScale = prefab.transform.localScale;
                    prefab.transform.localScale = new Vector3(-oldScale.x, oldScale.y, oldScale.z);
                }
            //otherwise unflip it
            } else
            {
                PromptMarker prefabPrompt;
                TMPro.TextMeshPro textMesh;
                prefab.gameObject.TryGetComponent<PromptMarker>(out prefabPrompt);
                prefab.gameObject.TryGetComponent(out textMesh);
                if ((prefabPrompt != null || textMesh != null) && prefab.transform.localScale.x < 0)
                {
                    Vector3 oldScale = prefab.transform.localScale;
                    prefab.transform.localScale = new Vector3(-oldScale.x, oldScale.y, oldScale.z);
                }
            }
            
            return prefab;
        }

        /// <summary>
        /// Make sure the cameras stay flipped
        /// </summary>
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

        /// <summary>
        /// Utility function that handles flipping cameras
        /// </summary>
        void FlipUCam(UCamera cam)
        {
            Matrix4x4 mat = cam.projectionMatrix;
            mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
            cam.projectionMatrix = mat;
        }

        /// <summary>
        /// Does this scene have a blurry background?
        /// </summary>
        bool hasBlurCam(GameCameras self)
        {
            return !(self.tk2dCam == null || self.tk2dCam.transform.GetComponentInChildren<Camera>() == null);
        }

    }
}
