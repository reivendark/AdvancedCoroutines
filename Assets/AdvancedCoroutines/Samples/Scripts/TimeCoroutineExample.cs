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
        public Text ResultText;
        public Text PauseResumeBtnText;
        public Button PauseResumeBtn;

        private Routine _workingRoutine;
        private DateTime _startDateTime;

        public void Awake()
        {
            PauseResumeBtn.enabled = false;
        }

        public void StartTest()
        {
            if(!Routine.IsNull(_workingRoutine)) return;

            _workingRoutine = CoroutineManager.StartCoroutine("TimeCoroutine", gameObject);
            PauseResumeBtn.enabled = true;
            _startDateTime = DateTime.UtcNow;
        }

        public void StopTest()
        {
            CoroutineManager.StopCoroutine(_workingRoutine);
            if(!Routine.IsNull(_workingRoutine)) throw new Exception("IsNull must return true");
            PauseResumeBtn.enabled = false;
            ResultText.text = "Press 'Start coroutine' to begin";
        }

        public void PauseResumeTest()
        {
            if(_workingRoutine == null) return;

            if(_workingRoutine.IsPaused())
            {
                _workingRoutine.Resume();
                PauseResumeBtnText.text = "Pause";
            }
            else
            {
                _workingRoutine.Pause();
                PauseResumeBtnText.text = "Resume";
            }
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
}