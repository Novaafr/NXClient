using GorillaLocomotion;
using UnityEngine;
using static NXClient.Menu.Main;

namespace NXClient.Mods
{
    public class Movement
    {
        private static int CurrentFlyIndex = 0;
        private static float flySpeed = 13f;
        private static string[] Speeds = { "Default", "Very Slow", "Slow", "Medium", "Fast", "Very Fast" };
        public static void ChangeFlySpeed()
        {
            CurrentFlyIndex = (CurrentFlyIndex + 1) % Speeds.Length;

            switch (CurrentFlyIndex) 
            {
                case 0: flySpeed = 13f; break;
                case 1: flySpeed = 0.5f; break;
                case 2: flySpeed = 2f; break;
                case 3: flySpeed = 7f; break;
                case 4: flySpeed = 18f; break;
                case 5: flySpeed = 30f; break;
            }

            GetIndex("Change Fly Speed <color=cyan>[Default]</color>").overlapText = $"Change Fly Speed <color=cyan>[{Speeds[CurrentFlyIndex]}]</color>";
        }

        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GTPlayer.Instance.transform.position += GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * flySpeed;
                GTPlayer.Instance.bodyCollider.attachedRigidbody.linearVelocity = Vector3.zero;
            }
        }
        public static void SlingFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                GTPlayer.Instance.bodyCollider.attachedRigidbody.linearVelocity += GTPlayer.Instance.headCollider.transform.forward / 2f;
        }
        public static void IronMan()
        {
            if (ControllerInputPoller.instance.rightGrab)
                GTPlayer.Instance.bodyCollider.attachedRigidbody.linearVelocity += GTPlayer.Instance.rightHand.controllerTransform.right / 2f;
            if (ControllerInputPoller.instance.leftGrab)
                GTPlayer.Instance.bodyCollider.attachedRigidbody.linearVelocity += -GTPlayer.Instance.leftHand.controllerTransform.right / 2f;
        }

        private static int CurrentPlatformType = 0;
        private static string[] platformTypes = { "Default", "Invis", "Sticky" };
        private static bool sticky = false;
        private static bool invis = false;
        private static GameObject platR;
        private static GameObject platL;
        public static void ChangePlatformType()
        {
            CurrentPlatformType = (CurrentPlatformType + 1) % platformTypes.Length;

            switch (CurrentPlatformType)
            {
                case 0: sticky = false; invis = false; break;
                case 1: sticky = false; invis = true; break;
                case 2: sticky = true; invis = false; break;
            }

            GetIndex("Change Platform Type <color=cyan>[Default]</color>").overlapText = $"Change Platform Type <color=cyan>[{platformTypes[CurrentPlatformType]}]</color>";
        }

        public static void Platforms()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.position = TrueRightHand().position;
                    platR.transform.rotation = TrueRightHand().rotation;
                    if (invis)
                        platR.GetComponent<Renderer>().enabled = false;
                    else
                        platR.GetComponent<Renderer>().material.color = Settings.backgroundColor.GetColor(0);
                    platR.transform.localScale = new Vector3(0.1f, 0.255f, 0.255f);
                    if (sticky)
                        FixStickyColliders(platR);
                }
            }
            else
            {
                if (platR != null)
                {
                    platR = null;
                    GameObject.Destroy(platR);
                }
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.position = TrueRightHand().position;
                    platL.transform.rotation = TrueRightHand().rotation;
                    if (invis)
                        platL.GetComponent<Renderer>().enabled = false;
                    else
                        platL.GetComponent<Renderer>().material.color = Settings.backgroundColor.GetColor(0);
                    platL.transform.localScale = new Vector3(0.1f, 0.255f, 0.255f);
                    if (sticky)
                        FixStickyColliders(platL);
                }
            }
            else
            {
                if (platL != null)
                {
                    platL = null;
                    GameObject.Destroy(platL);
                }
            }
        }

        private static int CurrentLengthIndex = 0;
        private static string[] ArmLengths = { "Steam", "Long", "Very Long", "Ghost" };
        private static Vector3 armLength = new Vector3(1.1f, 1.1f, 1.1f);
        public static void ChangeArmLength()
        {
            CurrentLengthIndex = (CurrentLengthIndex + 1) % ArmLengths.Length;

            switch (CurrentLengthIndex)
            {
                case 0: armLength = new Vector3(1.1f, 1.1f, 1.1f); break;
                case 1: armLength = new Vector3(1.25f, 1.25f, 1.25f); break;
                case 2: armLength = new Vector3(1.5f, 1.5f, 1.5f); break;
                case 3: armLength = new Vector3(2f, 2f, 2f); break;
            }

            GetIndex("Change Arm Length <color=cyan>[Default]</color>").overlapText = $"Change Arm Length <color=cyan>[{ArmLengths[CurrentLengthIndex]}]</color>";
        }
        public static void LongArms() => GTPlayer.Instance.transform.localScale = armLength;


        private static int CurrentSpeedIndex = 0;
        private static string[] SpeedTypes = { "Normal", "Mosa", "Fast", "Insane" };
        private static float speed = 7.9f;
        public static void ChangeSpeedAmount()
        {
            CurrentSpeedIndex = (CurrentSpeedIndex + 1) % SpeedTypes.Length;

            switch (CurrentSpeedIndex)
            {
                case 0: speed = 7.9f; break;
                case 1: speed = 8.5f; break;
                case 2: speed = 10.1f; break;
                case 3: speed = 17.3f; break;
            }

            GetIndex("Change Speed Amount <color=cyan>[Default]</color>").overlapText = $"Change Speed Amount <color=cyan>[{SpeedTypes[CurrentSpeedIndex]}]</color>";
        }

        public static void SpeedBoost() => GTPlayer.Instance.maxJumpSpeed = speed;

        public static void NoClip()
        {
            foreach (MeshCollider m in GameObject.FindObjectsOfType<MeshCollider>())
            {
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    m.enabled = false;
                }
                else
                {
                    m.enabled = true;
                }
            }
        }


        private static Vector3 w; // creds to iidk for wall walk
        private static Vector3 d;
        public static void WallWalk()
        {
            if (GTPlayer.Instance.IsHandTouching(true) || GTPlayer.Instance.IsHandTouching(false))
            {
                RaycastHit ray = GTPlayer.Instance.lastHitInfoHand;
                w = ray.point;
                d = ray.normal;
            }

            if (w != Vector3.zero && ControllerInputPoller.instance.leftGrab || ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.rigidbody.AddForce(d * -6.15f, ForceMode.Acceleration);
                GorillaTagger.Instance.rigidbody.AddForce(-Physics.gravity, ForceMode.Acceleration);
            }
        }


        private static bool hasTp = false;
        public static void TPGun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                var GunData = RenderGun();
                GameObject GunPointer = GunData.NewPointer;
                if (ControllerInputPoller.instance.rightControllerTriggerButton)
                {
                    if (!hasTp)
                    {
                        GTPlayer.Instance.transform.position = GunPointer.transform.position;
                        hasTp = true;
                    }
                }
                else
                {
                    hasTp = false;
                }
            }
        }

        private static GameObject waterBox;
        public static void WateryAir()
        {
            if (waterBox == null)
            {
                GameObject water = GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/CaveWaterVolume");
                if (!water.activeSelf)
                    water.SetActive(true);
                waterBox = GameObject.Instantiate<GameObject>(water);
                if (waterBox.GetComponent<Renderer>() != null)
                    GameObject.Destroy(waterBox.GetComponent<Renderer>());
            }
            waterBox.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(0f, 1f, 0f);
        }
        public static void DestroyWaterBox() => GameObject.Destroy(waterBox);

        public static void NoGrav() => GorillaTagger.Instance.rigidbody.AddForce(-Physics.gravity, ForceMode.Acceleration);
        public static void LowGrav() => GorillaTagger.Instance.rigidbody.AddForce(Vector3.up * 7.8f, ForceMode.Acceleration);
        public static void HighGrav() => GorillaTagger.Instance.rigidbody.AddForce(Vector3.down * 7.8f, ForceMode.Acceleration);

        public static void NoTagFreeze() => GTPlayer.Instance.disableMovement = false;
        public static void TagFreeze() => GTPlayer.Instance.disableMovement = true;
    }
}