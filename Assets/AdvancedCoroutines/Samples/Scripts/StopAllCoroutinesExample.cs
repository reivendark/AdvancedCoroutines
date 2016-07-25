using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class StopAllCoroutinesExample : MonoBehaviour
    {
        public string AttentionText = "Attention! Open statistics window for better experience Window->Advanced Coroutines->Statistics";

        private Rect _attentionLabelRect;
        private Rect _resultRect;
        private Rect _startButtonRect;
        private Rect _stopButtonRect;

        public string startCoroutinesBtnText = "Start coroutines";
        public string stopCoroutinesBtnText = "Stop all coroutines";
        public string ResultText;

        private Routine _r1;
        private Routine _r2;
        private Routine _r3;

        public void StartTest()
        {
            _r1 = CoroutineManager.StartCoroutine(TestCoroutine1(), gameObject);
            _r2 = CoroutineManager.StartCoroutine(TestCoroutine2(), gameObject);
            _r3 = CoroutineManager.StartCoroutine(TestCoroutine3(), gameObject);
        }

        public void StopTest()
        {
            CoroutineManager.StopAllCoroutines(gameObject);
            if(Routine.IsNull(_r1) && Routine.IsNull(_r2) && Routine.IsNull(_r3))
            {
                ResultText = "All coroutines stopped";
            }
        }

        private void Awake()
        {
            ResultText = "Press '" + startCoroutinesBtnText + "' to begin";

            var y = 0;
            var smallWidth = 25;
            var bigWidth = 55;

            _attentionLabelRect = new Rect(5, y, Screen.width - 5, smallWidth);
            _resultRect = new Rect(5, y+=smallWidth, Screen.width - 5, smallWidth);
            _startButtonRect = new Rect(5, y+=smallWidth, Screen.width / 2 - 5, bigWidth);
            _stopButtonRect = new Rect(Screen.width / 2 + 5, y, Screen.width / 2 - 5, bigWidth);
        }

        private void OnGUI()
        {
            GUI.contentColor = Color.red;
            GUI.Label(_attentionLabelRect, AttentionText);
            GUI.contentColor = Color.white;

            GUI.Label(_resultRect, ResultText);

            if (GUI.Button(_startButtonRect, startCoroutinesBtnText))
            {
                StartTest();
            }

            if (GUI.Button(_stopButtonRect, stopCoroutinesBtnText))
            {
                StopTest();
            }

            GoBack.Button();
        }

        private void Update()
        {
            int workingCoroutinesCount = 0;
            if(!Routine.IsNull(_r1)) 
            {
                workingCoroutinesCount++;
            }
            if(!Routine.IsNull(_r2)) 
            {
                workingCoroutinesCount++;
            }
            if(!Routine.IsNull(_r3))
            {
                workingCoroutinesCount++;
            }
            if(workingCoroutinesCount > 0)
            {
                ResultText = workingCoroutinesCount + " coroutines are working...";
            }
        }

        private IEnumerator TestCoroutine1()
        {
            while(true)
            {
                yield return new Wait(1f);
            }
        }

        private IEnumerator TestCoroutine2()
        {
            while(true)
            {
                yield return new Wait(5f);
            }
        }

        private IEnumerator TestCoroutine3()
        {
            while(true)
            {
                yield return new Wait(10f);
            }
        }
    }
}