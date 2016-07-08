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
        public Text PauseResumeBtnText;

        private DateTime _startDateTime;

        private NonMonoBehaviorClass _nonMonoClass;
        private Routine _standaloneRoutine;
        private Routine _routine;

        public void Awake()
        {
            _nonMonoClass = new NonMonoBehaviorClass();
        }

        public void StartTest()
        {
            if(!Routine.IsNull(_standaloneRoutine)) return;
            //Start coroutine through non-MonoBehaviour class
            _standaloneRoutine = _nonMonoClass.StartStandaloneCoroutine(TimeCoroutine());
            _routine = CoroutineManager.StartCoroutine(TimeCoroutine(), this);
            _startDateTime = DateTime.UtcNow;
        }

        public void StopTest()
        {
            //Stop coroutine through non-MonoBehaviour class
            _nonMonoClass.StopStandaloneCoroutine(_standaloneRoutine);
            if(!Routine.IsNull(_standaloneRoutine)) throw new Exception("IsNull must return true");
            ResultText.text = "Press 'Start test' to begin";
            CoroutineManager.StopCoroutine(_routine);
        }

        public IEnumerator TimeCoroutine()
        {
            do
            {
                _startDateTime = _startDateTime.AddSeconds(1f);
                ResultText.text = _startDateTime.ToLongTimeString();
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