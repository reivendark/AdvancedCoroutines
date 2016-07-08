// <copyright file="StopAllCoroutinesExample.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

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

        private int _dotIndex = 0;

        public void StartTest()
        {
            _r1 = CoroutineManager.StartCoroutine(TestCoroutine1(), this);
            _r2 = CoroutineManager.StartCoroutine(TestCoroutine2(), this);
            _r3 = CoroutineManager.StartCoroutine(TestCoroutine3(), this);
        }

        public void StopTest()
        {
            CoroutineManager.StopAllCoroutines(this);
            if(Routine.IsNull(_r1) && Routine.IsNull(_r2) && Routine.IsNull(_r3))
            {
                ResultText.text = "All coroutines stopped";
            }
        }

        private IEnumerator TestCoroutine1()
        {
            while(true)
            {
                DrawDots();
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

        private void DrawDots()
        {
            _dotIndex++;
            if(_dotIndex == 0 || _dotIndex == 4)
            {
                ResultText.text = "Coroutines working";
                _dotIndex = 0;
            }
            else
            {
                ResultText.text += ".";
            }
        }
    }
}