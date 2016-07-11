// <copyright file="StandaloneCoroutineExample.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class StandaloneCoroutineExample : MonoBehaviour
    {
        public Text ResultText;
        public Text ResultTextNonStandalone;
        public Text ResultTextStandalone;

        private DateTime _startDateTimeNonStanalone;
        private DateTime _startDateTimeStandalone;

        private NonMonoBehaviorClass _nonMonoClass;
        private Routine _standaloneRoutine;
        private Routine _routine;

        public void Awake()
        {
            _nonMonoClass = new NonMonoBehaviorClass();
            ResultTextNonStandalone.enabled = false;
            ResultTextStandalone.enabled = false;
        }

        public void OnDestroy()
        {
            CoroutineManager.StopCoroutine(_standaloneRoutine);
        }

        public void StartTest()
        {
            if(!Routine.IsNull(_standaloneRoutine)) return;
            //Start coroutine through non-MonoBehaviour class
            _standaloneRoutine = _nonMonoClass.StartStandaloneCoroutine(TimeCoroutineNonStandalone());
            _routine = CoroutineManager.StartCoroutine(TimeCoroutineStandalone(), this);
            _startDateTimeNonStanalone = DateTime.UtcNow;
            _startDateTimeStandalone = DateTime.UtcNow;

            ResultText.text = "Press 'Stop coroutines' to stop test";

            ResultTextNonStandalone.enabled = true;
            ResultTextStandalone.enabled = true;
        }

        public void StopTest()
        {
            //Stop coroutine through non-MonoBehaviour class
            _nonMonoClass.StopStandaloneCoroutine(_standaloneRoutine);
            if(!Routine.IsNull(_standaloneRoutine)) throw new Exception("IsNull must return true");
            ResultText.text = "Press 'Start coroutines' to start test";
            CoroutineManager.StopCoroutine(_routine);

            ResultTextNonStandalone.enabled = false;
            ResultTextStandalone.enabled = false;
        }

        private IEnumerator TimeCoroutineNonStandalone()
        {
            do
            {
                _startDateTimeNonStanalone = _startDateTimeNonStanalone.AddSeconds(1f);
                ResultTextNonStandalone.text = _startDateTimeNonStanalone.ToLongTimeString();
                yield return new Wait(1f);
            } while (true);
        }

        private IEnumerator TimeCoroutineStandalone()
        {
            do
            {
                _startDateTimeStandalone = _startDateTimeStandalone.AddSeconds(1f);
                ResultTextStandalone.text = _startDateTimeStandalone.ToLongTimeString();
                yield return new Wait(1f);
            } while (true);
        }
    }

    public class NonMonoBehaviorClass
    {
        public Routine StartStandaloneCoroutine(IEnumerator enumerator)
        {
            return CoroutineManager.StartStandaloneCoroutine(enumerator);
        }

        public void StopStandaloneCoroutine(Routine standaloneRoutine)
        {
            CoroutineManager.StopCoroutine(standaloneRoutine);
        }
    }
}