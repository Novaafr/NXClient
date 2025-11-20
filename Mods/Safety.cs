using GorillaLocomotion;
using NXClient.Notifications;
using Photon.Pun;
using UnityEngine;

namespace NXClient.Mods
{
    public class Safety
    {
        public static void NoFinger()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
            ControllerInputPoller.instance.leftControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.leftControllerSecondaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerPrimaryButtonTouch = false;
            ControllerInputPoller.instance.rightControllerSecondaryButtonTouch = false;
        }

        public static void AntiMod()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    if (rig.concatStringOfCosmeticsAllowed.Contains("LBAAK") || rig.concatStringOfCosmeticsAllowed.Contains("LBAAD") || rig.concatStringOfCosmeticsAllowed.Contains("LMAPY"))
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification($"<color=yellow>[ANTI MODERATOR]</color> {rig.OwningNetPlayer.NickName} had {rig.concatStringOfCosmeticsAllowed} | userid: {rig.OwningNetPlayer.UserId}");
                    }
                }
            }
        }

        public static void AntiReport()
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
                {
                    if (line.linePlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        Transform report = line.reportButton.transform;
                        foreach (VRRig rig in GorillaParent.instance.vrrigs)
                        {
                            if (rig != null && rig != VRRig.LocalRig)
                            {
                                float R = Vector3.Distance(rig.rightHandTransform.position, report.position);
                                float L = Vector3.Distance(rig.leftHandTransform.position, report.position);
                                if (R < 0.45f || L < 0.45f)
                                {
                                    PhotonNetwork.Disconnect();
                                    NotifiLib.SendNotification($"<color=yellow>[ANTIREPORT]</color> {rig.OwningNetPlayer.NickName} Tried to report you");
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void FakeQuestMenu()
        {
            if (!GorillaLocomotion.GTPlayer.Instance.inOverlay)
                GorillaLocomotion.GTPlayer.Instance.inOverlay = true;

            GorillaLocomotion.GTPlayer.Instance.leftHand.controllerTransform.localPosition = new Vector3(238f, -90f, 0f);
            GorillaLocomotion.GTPlayer.Instance.rightHand.controllerTransform.localPosition = new Vector3(-190f, 90f, 0f);
            GorillaLocomotion.GTPlayer.Instance.leftHand.controllerTransform.rotation = Camera.main.transform.rotation * Quaternion.Euler(-55f, 90f, 0f);
            GorillaLocomotion.GTPlayer.Instance.rightHand.controllerTransform.rotation = Camera.main.transform.rotation * Quaternion.Euler(-55f, -49f, 0f);

            GorillaLocomotion.GTPlayer.Instance.leftHand.wasColliding = false;
            GorillaLocomotion.GTPlayer.Instance.rightHand.wasColliding = false;
            NoFinger();
        }
        public static void DisableFakeQuestMenu() => GTPlayer.Instance.inOverlay = false;

        public static void FlushRPC()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;

            PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
            PhotonNetwork.QuickResends = int.MaxValue;

            PhotonNetwork.SendAllOutgoingCommands();
        }
    }
}
