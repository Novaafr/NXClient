using GorillaLocomotion;
using UnityEngine;

namespace NXClient.Mods
{
    public class VRig
    {
        public static void GhostMonkey()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                VRRig.LocalRig.enabled = false;
            else
                VRRig.LocalRig.enabled = true;
        }
        public static void InvisMonkey()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                VRRig.LocalRig.enabled = false;
                VRRig.LocalRig.transform.position = new Vector3(32894, 32423, 234);
            }
            else
                VRRig.LocalRig.enabled = true;
        }

        public static void GrabRig()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                VRRig.LocalRig.enabled = false;
                VRRig.LocalRig.transform.position = GTPlayer.Instance.rightHand.controllerTransform.position;
            }
            else
                VRRig.LocalRig.enabled = true;

            if (ControllerInputPoller.instance.leftGrab)
            {
                VRRig.LocalRig.enabled = false;
                VRRig.LocalRig.transform.position = GTPlayer.Instance.leftHand.controllerTransform.position;
            }
            else
                VRRig.LocalRig.enabled = true;
        }


        // ill fix soon
        public static void SpazMonkey()
        {
            VRRig.LocalRig.leftHand.trackingPositionOffset = VRRig.LocalRig.leftHand.trackingPositionOffset + new Vector3(UnityEngine.Random.Range(999, 999), UnityEngine.Random.Range(999, 999), UnityEngine.Random.Range(999, 999));
            VRRig.LocalRig.rightHand.trackingPositionOffset = VRRig.LocalRig.leftHand.trackingPositionOffset + new Vector3(UnityEngine.Random.Range(999, 999), UnityEngine.Random.Range(999, 999), UnityEngine.Random.Range(999, 999));
            VRRig.LocalRig.head.trackingPositionOffset = VRRig.LocalRig.leftHand.trackingPositionOffset + new Vector3(UnityEngine.Random.Range(999, 999), UnityEngine.Random.Range(999, 999), UnityEngine.Random.Range(999, 999));
        }
        public static void DisableSpazMonkey()
        {
            VRRig.LocalRig.leftHand.trackingPositionOffset = GorillaTagger.Instance.offlineVRRig.leftHand.trackingPositionOffset;
            VRRig.LocalRig.rightHand.trackingPositionOffset = GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset;
            VRRig.LocalRig.head.trackingPositionOffset = GorillaTagger.Instance.offlineVRRig.head.trackingPositionOffset;
        }
    }
}