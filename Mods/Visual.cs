using Fusion;
using GorillaExtensions;
using GorillaLocomotion;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static NXClient.Menu.Main;
using static UnityEngine.Rendering.DebugUI;

namespace NXClient.Mods
{
    public class Visual
    {
        public static void Chams()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    rig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    if (rig.mainSkin.material.name.Contains("fected"))
                    {
                        rig.mainSkin.material.color = new Color(0.7f, 0, 0, 0.4f);
                    }
                    else
                    {
                        rig.mainSkin.material.color = new Color(0f, 0f, 1f, 0.4f); 
                    }
                }
            }
        }

        public static void BoxESP()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject.Destroy(box.GetComponent<Collider>());
                    Renderer boxRend = box.GetComponent<Renderer>();
                    box.transform.position = rig.headMesh.transform.position;
                    box.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    boxRend.material.shader = Shader.Find("GUI/Text Shader");
                    if (boxRend.material.name.Contains("fected"))
                    {
                        boxRend.material.color = new Color(0.7f, 0, 0, 0.4f);
                    }
                    else
                    {
                        boxRend.material.color = new Color(0f, 0f, 1f, 0.4f);
                    }
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void SphereESP()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    GameObject.Destroy(box.GetComponent<Collider>());
                    Renderer boxRend = box.GetComponent<Renderer>();
                    box.transform.position = rig.headMesh.transform.position;
                    box.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    boxRend.material.shader = Shader.Find("GUI/Text Shader");
                    if (boxRend.material.name.Contains("fected"))
                    {
                        boxRend.material.color = new Color(0.7f, 0, 0, 0.4f);
                    }
                    else
                    {
                        boxRend.material.color = new Color(0f, 0f, 1f, 0.4f);
                    }
                    GameObject.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void chamsOff()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    rig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    rig.mainSkin.material.color = rig.playerColor;
                }
            }
        }

        public static void NameTags()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    GameObject nameHol = new GameObject();
                    nameHol.transform.position = rig.headMesh.transform.position + new Vector3(0, 0.6f, 0);
                    TextMeshPro name = nameHol.AddComponent<TextMeshPro>();
                    name.transform.position = rig.headMesh.transform.position + new Vector3(0, 0.6f, 0);
                    name.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
                    name.alignment = TextAlignmentOptions.Center;
                    name.fontSize = 0.9f;
                    string Textt = $"{rig.OwningNetPlayer.NickName}\nUID: {rig.OwningNetPlayer.UserId}\nFPS: {rig.fps}";
                    name.text = Textt;
                    name.transform.LookAt(Camera.main.transform.position);
                    name.transform.Rotate(new Vector3(0, 180, 0));
                    GameObject.Destroy(nameHol, Time.deltaTime);
                }
            }
        }

        public static void BugESP()
        {
            GameObject Esp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Esp.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            Esp.transform.position = GameObject.Find("Floating Bug Holdable").transform.position;
            Esp.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            Esp.GetComponent<Renderer>().material.color = Color.blue;
            GameObject.Destroy(Esp.GetComponent<Collider>());
            GameObject.Destroy(Esp, Time.deltaTime);
        }

        public static void ChangeTime(int time) => BetterDayNightManager.instance.SetTimeOfDay(time);
        public static void ChangeWeather(BetterDayNightManager.WeatherType type) => BetterDayNightManager.instance.SetFixedWeather(type);

        public static void BatESP()
        {
            GameObject Esp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Esp.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            Esp.transform.position = GameObject.Find("Cave Bat Holdable").transform.position;
            Esp.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            Esp.GetComponent<Renderer>().material.color = Color.blue;
            GameObject.Destroy(Esp.GetComponent<Collider>());
            GameObject.Destroy(Esp, Time.deltaTime);
        }

        public static void HitBoxes()
        {
            GameObject hitbox = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            hitbox.transform.position = GTPlayer.Instance.rightHand.controllerTransform.position;
            GameObject.Destroy(hitbox.GetComponent<Collider>());
            hitbox.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            hitbox.transform.rotation = GTPlayer.Instance.rightHand.controllerTransform.rotation;
            hitbox.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            hitbox.GetComponent<Renderer>().material.color = Color.blue;

            GameObject hitbox1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            hitbox1.transform.position = GTPlayer.Instance.leftHand.controllerTransform.position;
            GameObject.Destroy(hitbox1.GetComponent<Collider>());
            hitbox1.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            hitbox1.transform.rotation = GTPlayer.Instance.leftHand.controllerTransform.rotation;
            hitbox1.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            hitbox1.GetComponent<Renderer>().material.color = Color.blue;

            GameObject.Destroy(hitbox, Time.deltaTime);
            GameObject.Destroy(hitbox1, Time.deltaTime);
        }

        public static void HandESP()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    GameObject hitbox = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    hitbox.transform.position = rig.rightHandTransform.position;
                    GameObject.Destroy(hitbox.GetComponent<Collider>());
                    hitbox.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    hitbox.transform.rotation = rig.rightHandTransform.rotation;
                    hitbox.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    hitbox.GetComponent<Renderer>().material.color = Color.blue;

                    GameObject hitbox1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    hitbox1.transform.position = rig.leftHandTransform.position;
                    GameObject.Destroy(hitbox1.GetComponent<Collider>());
                    hitbox1.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    hitbox1.transform.rotation = rig.leftHandTransform.rotation;
                    hitbox1.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    hitbox1.GetComponent<Renderer>().material.color = Color.blue;

                    GameObject.Destroy(hitbox, Time.deltaTime);
                    GameObject.Destroy(hitbox1, Time.deltaTime);
                }
            }
        }
        public static void HeadESP()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    GameObject hitbox = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    hitbox.transform.position = rig.headMesh.transform.position;
                    GameObject.Destroy(hitbox.GetComponent<Collider>());
                    hitbox.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    hitbox.transform.rotation = rig.headMesh.transform.rotation;
                    hitbox.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    hitbox.GetComponent<Renderer>().material.color = Color.blue;

                    GameObject.Destroy(hitbox, Time.deltaTime);
                }
            }
        }

        public static void Tracers()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && rig != VRRig.LocalRig)
                {
                    GameObject liner = new GameObject();
                    LineRenderer tracer = liner.AddComponent<LineRenderer>();
                    tracer.material.shader = Shader.Find("GUI/Text Shader");
                    tracer.startColor = rig.mainSkin.material.name.Contains("fected") ? new Color(0.7f, 0f, 0f, 0.4f) : new Color(0f, 0f, 1f, 0.4f);
                    tracer.endColor = rig.mainSkin.material.name.Contains("fected") ? new Color(0.7f, 0f, 0f, 0.4f) : new Color(0f, 0f, 1f, 0.4f);
                    tracer.startWidth = 0.02f;
                    tracer.endWidth = 0.02f;
                    tracer.positionCount = 2;
                    tracer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightHand.controllerTransform.position);
                    tracer.SetPosition(1, rig.rightHandTransform.position);
                    GameObject.Destroy(liner, Time.deltaTime);
                }
            }
        }
    }
}