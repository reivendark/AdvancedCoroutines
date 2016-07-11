using UnityEngine;
using System.Collections;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class MainMenu : MonoBehaviour
    {
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
