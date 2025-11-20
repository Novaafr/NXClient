using NXClient.Notifications;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static NXClient.Menu.Main;

namespace NXClient.Mods
{
    public class Master //  spaz targets
    {
        public static void SpazTargets()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (HitTargetNetworkState target in GameObject.FindObjectsOfType<HitTargetNetworkState>())
                {
                    target.TargetHit(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position);
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
            }
        }

        public static void UnTagAll()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (GorillaTagManager tag in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (VRRig rig in GorillaParent.instance.vrrigs)
                    {
                        if (rig != null && rig != VRRig.LocalRig)
                        {
                            tag.currentInfected.Remove(rig.OwningNetPlayer);
                            tag.UpdateInfectionState();
                        }
                    }
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
            }
        }

        public static void UnTagGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject Pointer = GunData.NewPointer;
                RaycastHit Ray = GunData.Ray;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        foreach (GorillaTagManager tag in GameObject.FindObjectsOfType<GorillaTagManager>())
                        {
                            VRRig rig = Ray.collider.GetComponentInParent<VRRig>();
                            if (rig != null && rig != VRRig.LocalRig)
                            {
                                if (tag.currentInfected.Contains(rig.OwningNetPlayer))
                                {
                                    tag.currentInfected.Remove(rig.OwningNetPlayer);
                                    tag.UpdateInfectionState();
                                }
                            }
                        }
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
                    }
                }
            }
        }

        public static void SlowAll()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (rig != null && rig != VRRig.LocalRig)
                    {
                        RoomSystem.SendStatusEffectToPlayer(RoomSystem.StatusEffects.TaggedTime, rig.OwningNetPlayer);
                    }
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
            }
        }

        public static void SlowGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject Pointer = GunData.NewPointer;
                RaycastHit Ray = GunData.Ray;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        VRRig rig = Ray.collider.GetComponentInParent<VRRig>();
                        if (rig != null && rig != VRRig.LocalRig)
                        {
                            RoomSystem.SendStatusEffectToPlayer(RoomSystem.StatusEffects.TaggedTime, rig.OwningNetPlayer);
                        }
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
                    }
                }
            }
        }

        public static void MatSpamAll()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (GorillaTagManager tag in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (VRRig rig in GorillaParent.instance.vrrigs)
                    {
                        if (rig != null && rig != VRRig.LocalRig)
                        {
                            if (tag.currentInfected.Contains(rig.OwningNetPlayer))
                            {
                                tag.currentInfected.Remove(rig.OwningNetPlayer);
                                tag.UpdateInfectionState();
                            }
                            else
                            {
                                tag.AddInfectedPlayer(rig.OwningNetPlayer);
                                tag.UpdateInfectionState();
                            }
                        }
                    }
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
            }
        }

        public static void MatSpamGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject Pointer = GunData.NewPointer;
                RaycastHit Ray = GunData.Ray;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        foreach (GorillaTagManager tag in GameObject.FindObjectsOfType<GorillaTagManager>())
                        {
                            VRRig rig = Ray.collider.GetComponentInParent<VRRig>();
                            if (rig != null && rig != VRRig.LocalRig)
                            {
                                if (tag.currentInfected.Contains(rig.OwningNetPlayer))
                                {
                                    tag.currentInfected.Remove(rig.OwningNetPlayer);
                                    tag.UpdateInfectionState();
                                }
                                else
                                {
                                    tag.AddInfectedPlayer(rig.OwningNetPlayer);
                                    tag.UpdateInfectionState();
                                }
                            }
                        }
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
                    }
                }
            }
        }

        public static void MatSpamSelf()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (GorillaTagManager tag in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    if (tag.currentInfected.Contains(NetworkSystem.Instance.LocalPlayer))
                    {
                        tag.currentInfected.Remove(NetworkSystem.Instance.LocalPlayer);
                        tag.UpdateInfectionState();
                    }
                    else
                    {
                        tag.AddInfectedPlayer(NetworkSystem.Instance.LocalPlayer);
                        tag.UpdateInfectionState();
                    }
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[MASTER]</color> you are not master client");
            }
        }
    }
}
