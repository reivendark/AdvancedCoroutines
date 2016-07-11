using UnityEngine;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class GoBack : MonoBehaviour
    {
        public void Back()
        {
            Application.LoadLevel("0.StartScene");
        } 
    }
}