using GorillaNetworking;
using NXClient.Classes;
using NXClient.Mods;
using NXClient.Notifications;
using static NXClient.Menu.Main;
using static NXClient.Settings;

namespace NXClient.Menu
{
    public class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens settings for the menu."},
                new ButtonInfo { buttonText = "Important", method =() => currentCategory = 4, isTogglable = false, toolTip = "Opens important mods for the menu."},
                new ButtonInfo { buttonText = "Computer", method =() => currentCategory = 5, isTogglable = false, toolTip = "Opens important mods for the menu."},
                new ButtonInfo { buttonText = "Safety", method =() => currentCategory = 6, isTogglable = false, toolTip = "Opens safety mods for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => currentCategory = 7, isTogglable = false, toolTip = "Opens movement mods for the menu."},
                new ButtonInfo { buttonText = "Visual", method =() => currentCategory = 8, isTogglable = false, toolTip = "Opens visual mods for the menu."},
                new ButtonInfo { buttonText = "VRRig", method =() => currentCategory = 9, isTogglable = false, toolTip = "Opens vrrig mods for the menu."},
                new ButtonInfo { buttonText = "Advantadge", method =() => currentCategory = 10, isTogglable = false, toolTip = "Opens advantadge mods for the menu."},
                new ButtonInfo { buttonText = "Fun", method =() => currentCategory = 11, isTogglable = false, toolTip = "Opens fun mods for the menu."},
                new ButtonInfo { buttonText = "Overpowered", method =() => currentCategory = 12, isTogglable = false, toolTip = "Opens overpowered mods for the menu."},
                new ButtonInfo { buttonText = "Master", method =() => currentCategory = 13, isTogglable = false, toolTip = "Opens master mods for the menu."},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Menu Settings", method =() => currentCategory = 2, isTogglable = false, toolTip = "Opens menu settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => currentCategory = 3, isTogglable = false, toolTip = "Opens movement settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Change Menu Theme <color=cyan>[Default]</color>", method =() => Settings.ChangeMenuTheme(), toolTip = "Changes the menu theme.", isTogglable = false},
                new ButtonInfo { buttonText = "Change Button Sound <color=cyan>[Default]</color>", method =() => Settings.ChangeButtonSound(), toolTip = "Changes the button sound.", isTogglable = false},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => rightHanded = true, disableMethod =() => rightHanded = false, toolTip = "Switches the menu hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => disableNotifications = false, disableMethod =() => disableNotifications = true, enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => fpsCounter = true, disableMethod =() => fpsCounter = false, enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => disconnectButton = true, disableMethod =() => disconnectButton = false, enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Outline", enableMethod =() => outline = true, disableMethod =() => outline = false, toolTip = "Gives the menu a outline."},
                new ButtonInfo { buttonText = "Trigger Pages", enableMethod =() => triggerpages = true, disableMethod =() => triggerpages = false, toolTip = "Lets you use triggers to switch pages."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Change Fly Speed <color=cyan>[Default]</color>", method =() => Movement.ChangeFlySpeed(), toolTip = "Changes the fly speed.", isTogglable = false},
                new ButtonInfo { buttonText = "Change Platform Type <color=cyan>[Default]</color>", method =() => Movement.ChangePlatformType(), toolTip = "Changes the platform type.", isTogglable = false},
                new ButtonInfo { buttonText = "Change Arm Length <color=cyan>[Default]</color>", method =() => Movement.ChangeArmLength(), toolTip = "Changes the arm length amount.", isTogglable = false},
                new ButtonInfo { buttonText = "Change Speed Amount <color=cyan>[Default]</color>", method =() => Movement.ChangeSpeedAmount(), toolTip = "Changes the arm speed amount.", isTogglable = false},
            },

            new ButtonInfo[] { // Important [4]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Quit GTAG", method =() => Important.QuitGame(), toolTip = "Quits your game.", isTogglable = false},
                new ButtonInfo { buttonText = "Restart GTAG", method =() => Important.RestartGame(), toolTip = "Restarts your game.", isTogglable = false},
                new ButtonInfo { buttonText = "Accept TOS", method =() => Important.AcceptTOS(), toolTip = "Accepts the tos.", isTogglable = false},
                new ButtonInfo { buttonText = "First Person Camera", enableMethod =() => Important.FirstPerson(), disableMethod =() => Important.DisableFirstPerson(), toolTip = "Makes the camera first person.", isTogglable = true},
                new ButtonInfo { buttonText = "Oculus Report Menu", method =() => Important.OculusReportMenu(), toolTip = "Opens the oculus report menu.", isTogglable = false},
                new ButtonInfo { buttonText = "Anti AFK", method =() => Important.AntiAFK(), toolTip = "Removes the afk kick.", isTogglable = true},
                new ButtonInfo { buttonText = "Disable Quit Box", method =() => Important.DisableQuitBox(), toolTip = "Removes the quitbox.", isTogglable = true},
                new ButtonInfo { buttonText = "Unlock Comp", method =() => GorillaComputer.instance.CompQueueUnlockButtonPress(), toolTip = "Unlocks the comp queue.", isTogglable = false},
                new ButtonInfo { buttonText = "Clear Notifications", method =() => NotifiLib.ClearAllNotifications(), toolTip = "Clears all the notifications.", isTogglable = false},
            },

            new ButtonInfo[] { // Computer [5]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Disconnect", method =() => Computer.Disconnect(), toolTip = "Disconnects you from the current lobby.", isTogglable = false},
                new ButtonInfo { buttonText = "Join Random", method =() => Computer.JoinRandom(), toolTip = "Lets you join a random room.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[NX Client Code]</color>", method =() => Computer.JoinRoom("@NXCLIENT@"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[DAISY]</color>", method =() => Computer.JoinRoom("DAISY"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[DAISY09]</color>", method =() => Computer.JoinRoom("DAISY09"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[PBBV]</color>", method =() => Computer.JoinRoom("PBBV"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[1]</color>", method =() => Computer.JoinRoom("1"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[MODS]</color>", method =() => Computer.JoinRoom("MODS"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[MOD]</color>", method =() => Computer.JoinRoom("MOD"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[VEN1]</color>", method =() => Computer.JoinRoom("VEN1"), toolTip = "Lets you join a certain code.", isTogglable = true},
                new ButtonInfo { buttonText = "Join Code <color=red>[LUCIO]</color>", method =() => Computer.JoinRoom("LUCIO"), toolTip = "Lets you join a certain code.", isTogglable = true},
            },

            new ButtonInfo[] { // Safety [6]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.NoFinger(), toolTip = "Gives you no finger movement.", isTogglable = true},
                new ButtonInfo { buttonText = "Anti Report <color=yellow>[Disconnect]</color>", method =() => Safety.AntiReport(), toolTip = "Kicks you from the lobby when someone tries to report you.", isTogglable = true},
                new ButtonInfo { buttonText = "Fake Quest Menu", method =() => Safety.FakeQuestMenu(), disableMethod =() => Safety.DisableFakeQuestMenu(), toolTip = "Gives you a fake quest menu.", isTogglable = true},
                new ButtonInfo { buttonText = "Flush RPCs", method =() => Safety.FlushRPC(), toolTip = "Flushes your rpcs.", isTogglable = false},
                new ButtonInfo { buttonText = "Show Anti Cheat Reports", enableMethod =() => showanticheatreports = true, disableMethod =() => showanticheatreports = false, toolTip = "Shows the anti cheat reports.", isTogglable = true},
                new ButtonInfo { buttonText = "Anti Moderator", method =() => Safety.AntiMod(), toolTip = "Kicks you from the lobby when a moderator joins.", isTogglable = true},
            },

            new ButtonInfo[] { // Movement [7]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Lets you walk on air.", isTogglable = true},
                new ButtonInfo { buttonText = "Fly <color=purple>[A]</color>", method =() => Movement.Fly(), toolTip = "Lets you fly.", isTogglable = true},
                new ButtonInfo { buttonText = "Slingshot Fly <color=purple>[A]</color>", method =() => Movement.SlingFly(), toolTip = "Lets you slingshot fly.", isTogglable = true},
                new ButtonInfo { buttonText = "Iron Man", method =() => Movement.IronMan(), toolTip = "Lets you fly like iron man while holding grips.", isTogglable = true},
                new ButtonInfo { buttonText = "NoClip <color=purple>[RT]</color>", method =() => Movement.NoClip(), toolTip = "Lets you go through objects.", isTogglable = true},
                new ButtonInfo { buttonText = "Long Arms", method =() => Movement.LongArms(), toolTip = "Gives you long arms.", isTogglable = true},
                new ButtonInfo { buttonText = "Speedboost", method =() => Movement.SpeedBoost(), toolTip = "Gives you a speedboost.", isTogglable = true},
                new ButtonInfo { buttonText = "Wall Walk", method =() => Movement.WallWalk(), toolTip = "Lets you wall walk while holding grip.", isTogglable = true},
                new ButtonInfo { buttonText = "TP Gun", method =() => Movement.TPGun(), toolTip = "Lets you teleport with a gun.", isTogglable = true},
                new ButtonInfo { buttonText = "Watery Air", method =() => Movement.WateryAir(), disableMethod =() => Movement.DestroyWaterBox(), toolTip = "Lets you swim in the air.", isTogglable = true},
                new ButtonInfo { buttonText = "No Gravity", method =() => Movement.NoGrav(), toolTip = "Gives you no gravity.", isTogglable = true},
                new ButtonInfo { buttonText = "Low Gravity", method =() => Movement.HighGrav(), toolTip = "Gives you low gravity.", isTogglable = true},
                new ButtonInfo { buttonText = "High Gravity", method =() => Movement.LowGrav(), toolTip = "Gives you high gravity.", isTogglable = true},
                new ButtonInfo { buttonText = "No Tag Freeze", method =() => Movement.NoTagFreeze(), toolTip = "Gives you no tag freeze.", isTogglable = true},
                new ButtonInfo { buttonText = "Force Tag Freeze", method =() => Movement.TagFreeze(), disableMethod =() => Movement.NoTagFreeze(), toolTip = "Gives you no tag freeze.", isTogglable = true},
            },

            new ButtonInfo[] { // Visual [8]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Chams", method =() => Visual.Chams(), disableMethod =() => Visual.chamsOff(), toolTip = "Lets you see people through walls.", isTogglable = true},
                new ButtonInfo { buttonText = "Box ESP", method =() => Visual.BoxESP(), toolTip = "Lets you see people through walls.", isTogglable = true},
                new ButtonInfo { buttonText = "Sphere ESP", method =() => Visual.SphereESP(), toolTip = "Lets you see people through walls.", isTogglable = true},
                new ButtonInfo { buttonText = "Tracers", method =() => Visual.Tracers(), toolTip = "Points lines at others.", isTogglable = true},
                new ButtonInfo { buttonText = "NameTags", method =() => Visual.NameTags(), toolTip = "Gives you nametags.", isTogglable = true},
                new ButtonInfo { buttonText = "Hand ESP", method =() => Visual.HandESP(), toolTip = "Lets you see other peoples hands through stuff.", isTogglable = true},
                new ButtonInfo { buttonText = "Head ESP", method =() => Visual.HeadESP(), toolTip = "Lets you see other peoples head through stuff.", isTogglable = true},
                new ButtonInfo { buttonText = "Hitboxes", method =() => Visual.HitBoxes(), toolTip = "Lets you see your hitboxes.", isTogglable = true},
                new ButtonInfo { buttonText = "Bug ESP", method =() => Visual.BugESP(), toolTip = "Lets you see the bug through walls.", isTogglable = true},
                new ButtonInfo { buttonText = "Bat ESP", method =() => Visual.BatESP(), toolTip = "Lets you see the bat through walls.", isTogglable = true},
                new ButtonInfo { buttonText = "Morning Time", method =() => Visual.ChangeTime(1), toolTip = "Changes the time of day.", isTogglable = true},
                new ButtonInfo { buttonText = "Day Time", method =() => Visual.ChangeTime(3), toolTip = "Changes the time of day.", isTogglable = true},
                new ButtonInfo { buttonText = "Evening Time", method =() => Visual.ChangeTime(7), toolTip = "Changes the time of day.", isTogglable = true},
                new ButtonInfo { buttonText = "Night Time", method =() => Visual.ChangeTime(0), toolTip = "Changes the time of day.", isTogglable = true},
                new ButtonInfo { buttonText = "Start Rain", method =() => Visual.ChangeWeather(BetterDayNightManager.WeatherType.Raining), toolTip = "Changes the current weather.", isTogglable = true},
                new ButtonInfo { buttonText = "Stop Rain", method =() => Visual.ChangeWeather(BetterDayNightManager.WeatherType.None), toolTip = "Changes the current weather.", isTogglable = true},
            },

            new ButtonInfo[] { // VRRig [9]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Ghost Monkey <color=purple>[A]</color>", method =() => VRig.GhostMonkey(), disableMethod =() => FixRig(), toolTip = "Lets you become a ghost.", isTogglable = true},
                new ButtonInfo { buttonText = "Invis Monkey <color=purple>[B]</color>", method =() => VRig.GhostMonkey(), disableMethod =() => FixRig(), toolTip = "Lets you become invis.", isTogglable = true},
                //new ButtonInfo { buttonText = "Spaz Monkey", method =() => VRig.SpazMonkey(), disableMethod =() => VRig.DisableSpazMonkey(), toolTip = "Lets you spaz your rig.", isTogglable = true},
                new ButtonInfo { buttonText = "Grab Rig", method =() => VRig.GrabRig(), disableMethod =() => FixRig(), toolTip = "Lets you grab your rig.", isTogglable = true},
            },

            new ButtonInfo[] { // Advantadge [10]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Tag All", method =() => Advantadge.TagAll(), disableMethod =() => FixRig(), toolTip = "Lets you tag everyone.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Self", method =() => Advantadge.TagSelf(), disableMethod =() => FixRig(), toolTip = "Lets you get tagged.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Advantadge.TagGun(), disableMethod =() => FixRig(), toolTip = "Lets you tag with a gun.", isTogglable = true},
                new ButtonInfo { buttonText = "Flick Tag Gun", method =() => Advantadge.FlickTagGun(), disableMethod =() => FixRig(), toolTip = "Lets you flick tag with a gun.", isTogglable = true},
                new ButtonInfo { buttonText = "Tag Aura", method =() => Advantadge.TagAura(), disableMethod =() => FixRig(), toolTip = "Lets you tag the nearest player.", isTogglable = true},
            },

            new ButtonInfo[] { // Fun [11]
                new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
                new ButtonInfo { buttonText = "Grab Bug", method =() => Fun.GrabBug(), toolTip = "Lets you grab the bug.", isTogglable = true},
                new ButtonInfo { buttonText = "Grab Bat", method =() => Fun.GrabBat(), toolTip = "Lets you grab the bat.", isTogglable = true},
                new ButtonInfo { buttonText = "Water Splash Gun", method =() => Fun.WaterSplashGun(), toolTip = "Lets you shoot water from a gun.", isTogglable = true},
                new ButtonInfo { buttonText = "Water Splash Walk", method =() => Fun.WaterSplashWalk(), toolTip = "Lets you walk on water.", isTogglable = true},
                new ButtonInfo { buttonText = "Max Quest Score", method =() => Fun.MaxQuestScore(), toolTip = "Gives you max quest score.", isTogglable = true},
                new ButtonInfo { buttonText = "Hand Tap Spam <color=purple>[RT]</color>", method =() => Fun.HandTapSpam(), toolTip = "Lets you spam a sound.", isTogglable = true},
                new ButtonInfo { buttonText = "Metal Spam <color=purple>[RT]</color>", method =() => Fun.MetalSpam(), toolTip = "Lets you spam a sound.", isTogglable = true},
                new ButtonInfo { buttonText = "Keyboard Spam <color=purple>[RT]</color>", method =() => Fun.KeyboardSpam(), toolTip = "Lets you spam a sound.", isTogglable = true},
                new ButtonInfo { buttonText = "Button Spam <color=purple>[RT]</color>", method =() => Fun.ButtonSpam(), toolTip = "Lets you spam a sound.", isTogglable = true},
            },

            new ButtonInfo[] { // Overpowered [12]
               new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
               new ButtonInfo { buttonText = "Fling On Grab", method =() => Overpowered.FlingOnGrab(), toolTip = "Flings the person you grab.", isTogglable = true},
               new ButtonInfo { buttonText = "Crash On Grab", method =() => Overpowered.CrashOnGrab(), toolTip = "Crashes the person you grab.", isTogglable = true},
            },

            new ButtonInfo[] { // Master [13]
               new ButtonInfo { buttonText = "Return", method =() => currentCategory = 0, toolTip = "Returns you to the main page.", isTogglable = false},
               new ButtonInfo { buttonText = "Mat Spam All", method =() => Master.MatSpamAll(), toolTip = "Material spams everyone.", isTogglable = true},
               new ButtonInfo { buttonText = "Mat Spam Gun", method =() => Master.MatSpamGun(), toolTip = "Material spams the person you shoot.", isTogglable = true},
               new ButtonInfo { buttonText = "Mat Spam Self", method =() => Master.MatSpamGun(), toolTip = "Material spams yourself.", isTogglable = true},
               new ButtonInfo { buttonText = "Slow All", method =() => Master.SlowAll(), toolTip = "Makes everyone slow.", isTogglable = true},
               new ButtonInfo { buttonText = "Slow Gun", method =() => Master.SlowGun(), toolTip = "Makes the person you shoot slow.", isTogglable = true},
               new ButtonInfo { buttonText = "UnTag All", method =() => Master.UnTagAll(), toolTip = "Untags everyone in the lobby.", isTogglable = true},
               new ButtonInfo { buttonText = "UnTag Gun", method =() => Master.UnTagGun(), toolTip = "Untags the person you shoot.", isTogglable = true},
               new ButtonInfo { buttonText = "Spaz Targets", method =() => Master.SpazTargets(), toolTip = "Spazzes all hitable targets.", isTogglable = true},
            },
        };
    }
}