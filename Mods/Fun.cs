using GorillaLocomotion;
using Photon.Pun;
using UnityEngine;
using static NXClient.Menu.Main;

namespace NXClient.Mods
{
    public class Fun 
    {
        public static void ButtonSpam()
        {
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                PlaySound(67, 999f);
            }
        }
        public static void KeyboardSpam()
        {
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                PlaySound(66, 999f);
            }
        }
        public static void MetalSpam()
        {
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                PlaySound(18, 999f);
            }
        }
        public static void HandTapSpam()
        {
            if (ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                PlaySound(1, 999f);
            }
        }

        public static void MaxQuestScore()
        {
            VRRig.LocalRig.SetQuestScore(int.MaxValue);
        }
        public static void PlaySound(int soundIndex, float volume)
        {
            if (PhotonNetwork.InRoom)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[] { soundIndex, false, volume });
                Safety.FlushRPC();
            }
        }

        public static void GrabBug()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GTPlayer.Instance.rightHand.controllerTransform.position;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = GTPlayer.Instance.leftHand.controllerTransform.position;
            }
        }

        public static void GrabBat()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GTPlayer.Instance.rightHand.controllerTransform.position;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = GTPlayer.Instance.leftHand.controllerTransform.position;
            }
        }

        public static void WaterSplashWalk()
        {
            if (GTPlayer.Instance.rightHand.wasColliding)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", RpcTarget.All, new object[] { GTPlayer.Instance.leftHand.controllerTransform.position, GTPlayer.Instance.rightHand.controllerTransform.rotation, 5, 3, true, true });
                Safety.FlushRPC();
            }
            if (GTPlayer.Instance.rightHand.wasColliding)
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", RpcTarget.All, new object[] { GTPlayer.Instance.leftHand.controllerTransform.position, GTPlayer.Instance.rightHand.controllerTransform.rotation, 5, 3, true, true });
                Safety.FlushRPC();
            }
        }

        public static void WaterSplashGun()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                var GunData = RenderGun();
                GameObject Pointer = GunData.NewPointer;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    VRRig.LocalRig.enabled = false;
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", RpcTarget.All, new object[] { Pointer.transform.position, Pointer.transform.rotation, 5, 3, true, true });
                    Safety.FlushRPC();
                }
                else
                {
                    VRRig.LocalRig.enabled = true;
                }
            }
        }
    }
}
