using UnityEngine;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class GoBack
    {
        private static Rect BackBtnRect = new Rect(5, Screen.height - 45 - 5, 150, 45);

        private static void Back()
        {
            Application.LoadLevel("0.StartScene");
        }

        public static void Button()
        {
            if (GUI.Button(BackBtnRect, "Back"))
            {
                Back();
            }
        }
    }
}