using UnityEngine;
using System.Collections;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        private Rect _btn1Rect;
        private Rect _btn2Rect;
        private Rect _btn3Rect;
        private Rect _btn4Rect;
        private Rect _btn5Rect;

        private void Awake()
        {
            var y = 0;
            var bigWidth = 55;

            _btn1Rect = new Rect(50, y+=bigWidth, Screen.width - 100, bigWidth-5);
            _btn2Rect = new Rect(50, y+=bigWidth, Screen.width - 100, bigWidth-5);
            _btn3Rect = new Rect(50, y+=bigWidth, Screen.width - 100, bigWidth-5);
            _btn4Rect = new Rect(50, y+=bigWidth, Screen.width - 100, bigWidth-5);
            _btn5Rect = new Rect(50, y+=bigWidth, Screen.width - 100, bigWidth-5);
        }

        private void OnGUI()
        {
            if (GUI.Button(_btn1Rect, "1. Time Coroutine Example"))
            {
                LoadScene1();
            }
            if (GUI.Button(_btn2Rect, "2. Frame Coroutine Example"))
            {
                LoadScene2();
            }
            if (GUI.Button(_btn3Rect, "3. Stop All Coroutines Example"))
            {
                LoadScene3();
            }
            if (GUI.Button(_btn4Rect, "4. Standalone Coroutine Example"))
            {
                LoadScene4();
            }
            if (GUI.Button(_btn5Rect, "5. Linked Coroutine Example"))
            {
                LoadScene5();
            }
        }

        public void LoadScene1()
        {
            Application.LoadLevel("1.TimeCoroutineExampleScene");
        }
    
        public void LoadScene2()
        {
            Application.LoadLevel("2.FrameCoroutineExampleScene");
        }
    
        public void LoadScene3()
        {
            Application.LoadLevel("3.StopAllCoroutinesExampleScene");
        }
    
        public void LoadScene4()
        {
            Application.LoadLevel("4.StandaloneCoroutineExampleScene");
        }
    
        public void LoadScene5()
        {
            Application.LoadLevel("5.LinkedCoroutineExampleScene");
        }
    }
}
