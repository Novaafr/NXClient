using NXClient.Classes;
using NXClient.Menu;
using UnityEngine;

namespace NXClient
{
    public class Settings
    {
        private static int CurrentThemeIndex = 0;
        private static string[] themes = { "Default", "Red", "Green", "Blue", "Black", "Rainbow", "Pastel Rainbow", "Transparent" };
        public static ExtGradient backgroundColor = new ExtGradient { colors = ExtGradient.GetSimpleGradient(Color.black, Color.grey) };
        public static void ChangeMenuTheme()
        {
            CurrentThemeIndex = (CurrentThemeIndex + 1) % themes.Length;

            switch (CurrentThemeIndex)
            {
                case 0: backgroundColor = new ExtGradient { colors = ExtGradient.GetSimpleGradient(Color.black, Color.grey) }; break;
                case 1: backgroundColor = new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.red) }; break;
                case 2: backgroundColor = new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.green) }; break;
                case 3: backgroundColor = new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.blue) }; break;
                case 4: backgroundColor = new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.black) }; break;
                case 5: backgroundColor = new ExtGradient { rainbow = true }; break;
                case 6: backgroundColor = new ExtGradient { pastelRainbow = true }; break;
                case 7: backgroundColor = new ExtGradient { transparent = true }; break;
            }

            Main.GetIndex("Change Menu Theme <color=cyan>[Default]</color>").overlapText = $"Change Menu Theme <color=cyan>[{themes[CurrentThemeIndex]}]</color>";
        }

        public static int ButtonSound = 67;
        private static int CurrentSoundIndex = 0;
        private static string[] Sounds = { "Default", "Keyboard", "Snow", "Bubble" };
        public static void ChangeButtonSound()
        {
            CurrentSoundIndex = (CurrentSoundIndex + 1) % Sounds.Length;

            switch (CurrentSoundIndex) 
            {
                case 0: ButtonSound = 67; break;
                case 1: ButtonSound = 66; break;
                case 2: ButtonSound = 32; break;
                case 3: ButtonSound = 84; break;
            }

            Main.GetIndex("Change Button Sound <color=cyan>[Default]</color>").overlapText = $"Change Button Sound <color=cyan>[{Sounds[CurrentSoundIndex]}]</color>";
        }

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.black) }, // Disabled
            new ExtGradient { colors = ExtGradient.GetSolidGradient(Color.red) } // Enabled
        };

        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.white // Enabled
        };

        public static Font currentFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool outline = false;
        public static bool triggerpages = false;
        public static bool rightHanded;
        public static bool disableNotifications;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, width, height
        public static int buttonsPerPage = 8;

        public static float gradientSpeed = 0.5f; // Speed of colors
    }
}
