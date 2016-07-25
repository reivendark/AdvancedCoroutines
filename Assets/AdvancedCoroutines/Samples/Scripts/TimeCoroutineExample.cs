// <copyright file="TimeCoroutineExample.cs" company="Parallax Pixels">
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
    public class TimeCoroutineExample : MonoBehaviour
    {
        public string AttentionText = "Attention! Open statistics window for better experience Window->Advanced Coroutines->Statistics";
        public string Note = "Timer running by Coroutine";

        private string _resultText = "Press 'Start coroutine' to start test";
        private string _pauseResumeBtnText = "Pause";
        public bool _pauseResumeBtnOn;

        private Routine _workingRoutine;
        private DateTime _startDateTime;

        private Rect _attentionLabelRect;
        private Rect _noteRect;
        private Rect _resultLabelRect;
        private Rect _startButtonRect;
        private Rect _stopButtonRect;
        private Rect _pauseButtonRect;

        public void Awake()
        {
            _pauseResumeBtnOn = false;
            var y = 0;
            var smallWidth = 25;
            var bigWidth = 95;

            _attentionLabelRect = new Rect(5, y, Screen.width - 5, smallWidth);
            _noteRect = new Rect(5, y+=smallWidth, Screen.width - 5, smallWidth);
            _resultLabelRect = new Rect(5, y+=smallWidth, Screen.width - 5, bigWidth);

            _startButtonRect = new Rect(5, y+=smallWidth, Screen.width / 2 - 5, bigWidth);
            _stopButtonRect = new Rect(Screen.width / 2 + 5, y, Screen.width / 2 - 5, bigWidth);
            _pauseButtonRect = new Rect(5, y+=bigWidth, Screen.width - 5, bigWidth);
        }

        public void StartTest()
        {
            if(!Routine.IsNull(_workingRoutine)) return;

            _workingRoutine = CoroutineManager.StartCoroutine(TimeCoroutine(), gameObject);
            _pauseResumeBtnOn = true;
            _startDateTime = DateTime.UtcNow;
        }

        public void StopTest()
        {
            CoroutineManager.StopCoroutine(_workingRoutine);
            if(!Routine.IsNull(_workingRoutine)) throw new Exception("IsNull must return true");
            _pauseResumeBtnOn = false;
            _resultText = "Press 'Start coroutine' to begin";
        }

        public void PauseResumeTest()
        {
            if(_workingRoutine == null) return;

            if(_workingRoutine.IsPaused())
            {
                _workingRoutine.Resume();
                _pauseResumeBtnText = "Pause";
            }
            else
            {
                _workingRoutine.Pause();
                _pauseResumeBtnText = "Resume";
            }
        }

        private void OnGUI()
        {
            GUI.contentColor = Color.red;
            GUI.Label(_attentionLabelRect, AttentionText);
            GUI.contentColor = Color.white;

            GUI.Label(_noteRect, Note);
            GUI.Label(_resultLabelRect, _resultText);

            if (GUI.Button(_startButtonRect, "Start coroutine"))
            {
                StartTest();
            }

            if (GUI.Button(_stopButtonRect, "Stop coroutine"))
            {
                StopTest();
            }

            if (_pauseResumeBtnOn)
            {
                if (GUI.Button(_pauseButtonRect, _pauseResumeBtnText))
                {
                    PauseResumeTest();
                }
            }

            GoBack.Button();
        }

        public IEnumerator TimeCoroutine()
        {
            do
            {
                _startDateTime = _startDateTime.AddSeconds(1f);
                _resultText = _startDateTime.ToLongTimeString();
                yield return new Wait(1f);
            } while (true);
        }
    }
}