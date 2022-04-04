using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using Tayx.Graphy.Audio;
using Tayx.Graphy;
using UnhollowerRuntimeLib;
using Tayx.Graphy.Advanced;
using Tayx.Graphy.Fps;
using Tayx.Graphy.Graph;
using Tayx.Graphy.Ram;
using System.Net.Http;

[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonInfo(typeof(GraphyForVRC.Main), "VRChat_Mod", "1.0.0", "KeafyIsHere & myrkie")]

namespace GraphyForVRC
{

    public class Main : MelonMod
    {
        private AssetBundle MyBundle;
        public static Material mobile;
        public static Material standard;
        private G_RamText RamText;

        public override void OnApplicationStart()
        {

            ClassInjector.RegisterTypeInIl2Cpp<G_AdvancedData>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_AudioGraph>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_AudioManager>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_AudioMonitor>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_AudioText>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_FpsGraph>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_FpsManager>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_FpsMonitor>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_FpsText>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_Graph>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_RamGraph>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_RamManager>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_RamMonitor>(true);
            ClassInjector.RegisterTypeInIl2Cpp<G_RamText>(true);
            ClassInjector.RegisterTypeInIl2Cpp<GraphyManager>(true);
            ClassInjector.RegisterTypeInIl2Cpp<GraphyDebugger>(true);

            MyBundle = AssetBundle.LoadFromFile(@"G:\Unity Projects\il2cpp\Assets\AssetBundles\booba");
            
            MelonCoroutines.Start(WaitForUI());

        }

        private IEnumerator WaitForUI()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
            {
                yield return null;
            }
            
        }
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.PageDown)) 
            {
                GameObject graphy = MyBundle.LoadAsset<GameObject>("[Graphy]").Cast<GameObject>();
                mobile = MyBundle.LoadAsset<Material>("Mobile").Cast<Material>();
                standard = MyBundle.LoadAsset<Material>("Standard").Cast<Material>();
                graphy.AddComponent<GraphyManager>();
                graphy.AddComponent<GraphyDebugger>();
                graphy.transform.FindChild("FPS - Module").gameObject.AddComponent<G_FpsGraph>();
                graphy.transform.FindChild("FPS - Module").gameObject.AddComponent<G_FpsMonitor>();
                graphy.transform.FindChild("FPS - Module").gameObject.AddComponent<G_FpsText>();
                graphy.transform.FindChild("FPS - Module").gameObject.AddComponent<G_FpsManager>();
                graphy.transform.FindChild("RAM - Module").gameObject.AddComponent<G_RamGraph>();
                graphy.transform.FindChild("RAM - Module").gameObject.AddComponent<G_RamManager>();
                graphy.transform.FindChild("RAM - Module").gameObject.AddComponent<G_RamMonitor>();
                RamText = graphy.transform.FindChild("RAM - Module").gameObject.AddComponent<G_RamText>();
                graphy.transform.FindChild("AUDIO - Module").gameObject.AddComponent<G_AudioGraph>();
                graphy.transform.FindChild("AUDIO - Module").gameObject.AddComponent<G_AudioManager>();
                graphy.transform.FindChild("AUDIO - Module").gameObject.AddComponent<G_AudioMonitor>();
                graphy.transform.FindChild("AUDIO - Module").gameObject.AddComponent<G_AudioText>();
                graphy.transform.FindChild("ADVANCED - Module").gameObject.AddComponent<G_AdvancedData>();
                var InstantiatedGraphy = GameObject.Instantiate(graphy);
                GameObject.DontDestroyOnLoad(InstantiatedGraphy);
            }
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (G_AudioMonitor.Instance != null)
            {
                if (G_AudioMonitor.Instance.m_findAudioListenerInCameraIfNull == GraphyManager.LookForAudioListener.ON_SCENE_LOAD)
                {
                    G_AudioMonitor.Instance.m_audioListener = G_AudioMonitor.Instance.FindAudioListener();
                }
            }
        }
    }
}
