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
        public string AttentionText = "Attention! Open statistics window for better experience Window->Advanced Coroutines->Statistics";

        public string nonStandaloneText = "Non standalone (attached) coroutine";
        public string standaloneText = "Standalone coroutine";

        private string ResultText;
        private string ResultTextNonStandalone;
        private string ResultTextStandalone;

        private DateTime _startDateTimeNonStanalone;
        private DateTime _startDateTimeStandalone;

        private NonMonoBehaviorClass _nonMonoClass;
        private Routine _standaloneRoutine;
        private Routine _routine;

        private Rect _attentionLabelRect;
        private Rect _resultLabelRect;

        private Rect _nonStandRect1;
        private Rect _nonStandRect2;

        private Rect _standRect1;
        private Rect _standRect2;

        private Rect _startButtonRect;
        private Rect _stopButtonRect;

        private bool _resultTextNonStandaloneOn;
        private bool _resultTextStandaloneOn;

        public void Awake()
        {
            ResultText = "Press 'Start coroutines' to start test";
            _nonMonoClass = new NonMonoBehaviorClass();
            _resultTextNonStandaloneOn = false;
            _resultTextStandaloneOn = false;

            var y = 0;
            var smallWidth = 25;
            var bigWidth = 95;

            _attentionLabelRect = new Rect(5, y, Screen.width - 5, smallWidth);
            _resultLabelRect = new Rect(5, y+=smallWidth, Screen.width - 5, bigWidth);

            _nonStandRect1 = new Rect(5, y+=smallWidth, Screen.width/2-5, smallWidth);
            _nonStandRect2 = new Rect(Screen.width/2+5, y, Screen.width/2-5, smallWidth);

            _standRect1 = new Rect(5, y+=smallWidth, Screen.width/2-5, smallWidth);
            _standRect2 = new Rect(Screen.width/2+5, y, Screen.width/2-5, smallWidth);

            _startButtonRect = new Rect(5, y+=smallWidth, Screen.width / 2 - 5, bigWidth);
            _stopButtonRect = new Rect(Screen.width / 2 + 5, y, Screen.width / 2 - 5, bigWidth);
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
            _routine = CoroutineManager.StartCoroutine(TimeCoroutineStandalone(), gameObject);
            _startDateTimeNonStanalone = DateTime.UtcNow;
            _startDateTimeStandalone = DateTime.UtcNow;

            ResultText = "Press 'Stop coroutines' to stop test";

            _resultTextNonStandaloneOn = true;
            _resultTextStandaloneOn = true;
        }

        public void StopTest()
        {
            //Stop coroutine through non-MonoBehaviour class
            _nonMonoClass.StopStandaloneCoroutine(_standaloneRoutine);
            if(!Routine.IsNull(_standaloneRoutine)) throw new Exception("IsNull must return true");
            ResultText = "Press 'Start coroutines' to start test";
            CoroutineManager.StopCoroutine(_routine);

            _resultTextNonStandaloneOn = false;
            _resultTextStandaloneOn = false;
        }

        private void OnGUI()
        {
            GUI.contentColor = Color.red;
            GUI.Label(_attentionLabelRect, AttentionText);

            GUI.contentColor = Color.white;
            GUI.Label(_resultLabelRect, ResultText);

            GUI.contentColor = Color.cyan;
            GUI.Label(_nonStandRect1, nonStandaloneText);
            if(_resultTextNonStandaloneOn)
                GUI.Label(_nonStandRect2, ResultTextNonStandalone);

            GUI.contentColor = Color.yellow;
            GUI.Label(_standRect1, standaloneText);
            if(_resultTextStandaloneOn)
                GUI.Label(_standRect2, ResultTextStandalone);

            GUI.contentColor = Color.white;

            if (GUI.Button(_startButtonRect, "Start coroutines"))
            {
                StartTest();
            }

            if (GUI.Button(_stopButtonRect, "Stop coroutines"))
            {
                StopTest();
            }

            GoBack.Button();
        }

        private IEnumerator TimeCoroutineNonStandalone()
        {
            do
            {
                _startDateTimeNonStanalone = _startDateTimeNonStanalone.AddSeconds(1f);
                ResultTextNonStandalone = _startDateTimeNonStanalone.ToLongTimeString();
                yield return new Wait(1f);
            } while (true);
        }

        private IEnumerator TimeCoroutineStandalone()
        {
            do
            {
                _startDateTimeStandalone = _startDateTimeStandalone.AddSeconds(1f);
                ResultTextStandalone = _startDateTimeStandalone.ToLongTimeString();
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