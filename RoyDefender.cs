using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using GlobalEnums;
using HutongGames.PlayMaker.Actions;
using Modding;
using On.UnityEngine.UI;
using SFCore.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoyDefender
{
    public class RoyDefender : Mod
    {
        public override void Initialize()
        {
            Log("Initializing");

            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;

            Log("Initialized");
        }

        private void SceneManagerOnActiveSceneChanged(Scene from, Scene to)
        {
            if (to.name != "Dream_04_White_Defender" && to.name != "GG_White_Defender") return;
            GameObject wdGo = to.Find("White Defender");
            PlayMakerFSM wdFsm = wdGo.LocateMyFSM("Dung Defender");
            wdFsm.GetAction<SendEvent>("Move Choice", 0).Enabled = true;
            wdFsm.GetAction<SetIntValue>("Air Dive?", 3).intValue = 100;
        }
    }
}