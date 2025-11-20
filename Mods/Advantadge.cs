using GorillaGameModes;
using GorillaLocomotion;
using UnityEngine;
using static NXClient.Menu.Main;

namespace NXClient.Mods
{
    public class Advantadge
    {
        public static void TagAll()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    if (VRRig.LocalRig.mainSkin.material.name.Contains("fected") && !rig.mainSkin.material.name.Contains("fected"))
                    {
                        VRRig.LocalRig.enabled = false;
                        VRRig.LocalRig.transform.position = rig.transform.position;
                        GameMode.ReportTag(rig.OwningNetPlayer);
                    }
                }
            }
        }

        public static void TagAura()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    if (VRRig.LocalRig.mainSkin.material.name.Contains("fected") && !rig.mainSkin.material.name.Contains("fected"))
                    {
                        float dis = Vector3.Distance(Camera.main.transform.position, rig.transform.position);
                        if (dis < 0.5f)
                        {
                            GameMode.ReportTag(rig.OwningNetPlayer);
                        }
                    }
                }
            }
        }

        public static void TagSelf()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    if (!VRRig.LocalRig.mainSkin.material.name.Contains("fected") && rig.mainSkin.material.name.Contains("fected"))
                    {
                        VRRig.LocalRig.enabled = false;
                        VRRig.LocalRig.transform.position = rig.rightHandTransform.position;
                    }
                }
            }
        }

        public static void TagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject Pointer = GunData.NewPointer;
                RaycastHit Ray = GunData.Ray;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    VRRig rig = Ray.collider.GetComponentInParent<VRRig>();
                    if (rig != null && rig != VRRig.LocalRig)
                    {
                        if (VRRig.LocalRig.mainSkin.material.name.Contains("fected") && !rig.mainSkin.material.name.Contains("fected"))
                        {
                            VRRig.LocalRig.enabled = false;
                            VRRig.LocalRig.transform.position = rig.transform.position;
                            GameMode.ReportTag(rig.OwningNetPlayer);
                        }
                    }
                }
                else
                {
                    VRRig.LocalRig.enabled = true;
                }
            }
        }

        public static void FlickTagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject Pointer = GunData.NewPointer;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    GTPlayer.Instance.rightHand.controllerTransform.position = Pointer.transform.position;
                }
            }
        }
    }
}
