using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class StopAllCoroutinesExample : MonoBehaviour
    {
        public Text ResultText;

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
                ResultText.text = "All coroutines stopped";
            }
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
                ResultText.text = workingCoroutinesCount + " coroutines are working...";
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