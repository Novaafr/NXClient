using GorillaNetworking;
using NXClient.Patches.Internal;
using System.Diagnostics;
using UnityEngine;

namespace NXClient.Mods
{
    public class Important
    {
        public static void QuitGame() => Application.Quit();
        public static void RestartGame()
        {
            Process.Start(Process.GetCurrentProcess().MainModule.FileName);
            Process.GetCurrentProcess().Kill();
        }

        public static void AcceptTOS()
        {
            TOSPatch.enabled = true;
        }

        public static void FirstPerson()
        {
            GorillaTagger.Instance.thirdPersonCamera.SetActive(false);
        }
        public static void DisableFirstPerson()
        {
            GorillaTagger.Instance.thirdPersonCamera.SetActive(true);
        }

        public static void OculusReportMenu()
        {
            GameObject.Find("Miscellaneous Scripts/MetaReporting").SetActive(true);
            GameObject.Find("Miscellaneous Scripts/MetaReporting").GetComponent<GorillaMetaReport>().StartOverlay();
        }

        public static void AntiAFK() => PhotonNetworkController.Instance.disableAFKKick = true;
        public static void DisableQuitBox() => GameObject.Find("QuitBox").SetActive(false);
    }
}