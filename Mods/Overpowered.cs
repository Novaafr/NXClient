using UnityEngine;
using static NXClient.Classes.RigManager;

namespace NXClient.Mods
{
    public class Overpowered
    {
        public static void FlingOnGrab()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    if (rig.rightHandLink.grabbedPlayer == NetworkSystem.Instance.LocalPlayer || rig.leftHandLink.grabbedPlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        if (ControllerInputPoller.instance.rightGrab)
                        {
                            VRRig.LocalRig.enabled = false;
                            VRRig.LocalRig.transform.position = new Vector3(rig.transform.position.x, 6767, rig.transform.position.z);
                        }
                        else
                        {
                            VRRig.LocalRig.enabled = true;
                        }
                    }
                }
            }
        }

        public static void CrashOnGrab()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    if (rig.rightHandLink.grabbedPlayer == NetworkSystem.Instance.LocalPlayer || rig.leftHandLink.grabbedPlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        if (ControllerInputPoller.instance.rightGrab)
                        {
                            VRRig.LocalRig.enabled = false;
                            VRRig.LocalRig.transform.position = new Vector3(rig.transform.position.x, 226767, rig.transform.position.z + 67);
                        }
                        else
                        {
                            VRRig.LocalRig.enabled = true;
                        }
                    }
                }
            }
        }
    }
}
