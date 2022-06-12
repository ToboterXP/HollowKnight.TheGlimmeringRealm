﻿using Modding;
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

        bool inKeyboardMenu = false;

        List<string> excludedObjects = new List<string>();

        //hook all the things that need hooking
        public void Hook()
        {
            On.tk2dCamera.UpdateCameraMatrix += OnUpdateCameraMatrix;
            On.GameCameras.StartScene += OnNewSceneCam;
            
            On.GameManager.OnNextLevelReady += OnNextScene;

            On.UIManager.GoToKeyboardMenu += OnOpenKeyboardMenu;
            On.UIManager.GoToRemapControllerMenu += OnOpenGamepadMenu;
            On.UIManager.HideCurrentMenu += OnHideMenu;

            On.HutongGames.PlayMaker.Actions.SendEventByName.OnEnter += OnSendEventByName;

            On.ObjectPool.Spawn_GameObject_Transform_Vector3_Quaternion += OnSpawnObject;
            On.GameManager.OnNextLevelReady += OnSceneLoad;
            On.GameMap.Update += GameMapUpdate;

        }

        //inverts the inputs the game uses
        public void SetInvertInputs(bool invert)
        {
            if (invert != inputsInverted)
            {
                inputsInverted = invert;
                PlayerAction tmp = InputHandler.Instance.inputActions.left;
                InputHandler.Instance.inputActions.left = InputHandler.Instance.inputActions.right;
                InputHandler.Instance.inputActions.right = tmp;

                InputHandler.Instance.inputActions.moveVector.InvertXAxis = !InputHandler.Instance.inputActions.moveVector.InvertXAxis;
            }
        }

        public void OnSendEventByName(On.HutongGames.PlayMaker.Actions.SendEventByName.orig_OnEnter orig, global::HutongGames.PlayMaker.Actions.SendEventByName self)
        {
            string event_ = self.sendEvent.Value;

            if (event_ == "INVENTORY OPENED") SetInvertInputs(false);
            if (event_ == "INVENTORY CLOSED") SetInvertInputs(isFlipping);

            orig(self);
        }

        //make sure controls are unflipped before being saved
        public IEnumerator OnHideMenu(On.UIManager.orig_HideCurrentMenu orig, global::UIManager self)
        {
            SetInvertInputs(false);

            var ret = orig(self);

            SetInvertInputs(isFlipping);

            return ret;
        }

        public IEnumerator OnOpenKeyboardMenu(On.UIManager.orig_GoToKeyboardMenu orig, global::UIManager self)
        {
            if (isFlipping) return self.GoToOptionsMenu(); //it seems to break stuff, so just don't allow it
             
            SetInvertInputs(false);

            return orig(self);
        }

        public IEnumerator OnOpenGamepadMenu(On.UIManager.orig_GoToRemapControllerMenu orig, global::UIManager self)
        {
            if (isFlipping) return self.GoToOptionsMenu(); //it seems to break stuff, so just don't allow it

            SetInvertInputs(false); 

            return orig(self);
        }

        //flip the controls if necessary
        public void OnNextScene(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);

            SetInvertInputs(isFlipping);
        }

        //updates wheter the room should be flipped or not
        public void UpdateFlipping()
        {
            previouslyFlipping = isFlipping;
            if (HKSecondQuest.Instance.ActiveRoom != null) isFlipping = HKSecondQuest.Instance.ActiveRoom.IsFlipped;
            else isFlipping = false;
        }

        //adds an object to be excluded from not being flipped
        public void AddExcludedObject(string name)
        { 
            excludedObjects.Add(name);
        }

        //Called before any Rooms are executed
        public void BeforeSceneLoad()
        {
            excludedObjects.Clear();
        }

        //make sure text already in the scene is flipped
        private void OnSceneLoad(On.GameManager.orig_OnNextLevelReady orig, global::GameManager self)
        {
            orig(self);

            
            foreach (GameObject prefab in GameObject.FindObjectsOfType<GameObject>())
            {
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

        //make sure the map is flipped (unused)
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

        //flip newly spawned cameras
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

        //flip text that is spawned via prefab
        private GameObject OnSpawnObject(On.ObjectPool.orig_Spawn_GameObject_Transform_Vector3_Quaternion orig, GameObject prefab, Transform parent, Vector3 pos, Quaternion rot)
        {
            prefab = orig(prefab, parent, pos, rot);
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

        //make sure cameras stay flipped
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

        //flip a camera
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
