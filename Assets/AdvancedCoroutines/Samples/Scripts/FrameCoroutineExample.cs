// <copyright file="FrameCoroutineExample.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class FrameCoroutineExample : MonoBehaviour
    {
        public string AttentionText = "Attention! Open statistics window for better experience Window->Advanced Coroutines->Statistics";
        public string Note = "Timer running by Coroutine";
        public string ResultLabel;

        private bool _testIsEnded = true;
        private int frameIndex;

        private Rect _attentionLabelRect;
        private Rect _noteRect;
        private Rect _resultLabelRect;

        private void Awake()
        {
        	frameIndex = -1;
            ResultLabel = "";
            _testIsEnded = false;

            var y = 0;
            var smallWidth = 25;
            var bigWidth = Screen.height - smallWidth*2 - 55;

            _attentionLabelRect = new Rect(5, y, Screen.width - 5, smallWidth);
            _noteRect = new Rect(5, y+=smallWidth, Screen.width - 5, smallWidth);
            _resultLabelRect = new Rect(5, y+=smallWidth, Screen.width - 5, bigWidth);

            CoroutineManager.StartCoroutine(WaitForEndOfFrameCoroutine(), gameObject);
        }

        private void OnGUI()
        {
            GUI.contentColor = Color.red;
            GUI.Label(_attentionLabelRect, AttentionText);
            GUI.contentColor = Color.white;

            GUI.Label(_noteRect, Note);
            GUI.Label(_resultLabelRect, ResultLabel);

            GoBack.Button();
        }

        private void Update()
        {
            if(!_testIsEnded)
            {
            	frameIndex++;
            }
        }

        private IEnumerator WaitForEndOfFrameCoroutine()
        {
            ResultLabel += "Frame [0] coroutine started\n";
            yield return new Wait(0.1f);
            ResultLabel += "Frame [" + frameIndex + "] [yield return new Wait(0.1f)] started after 0.1 seconds\n";
            yield return null;
            ResultLabel += "Frame [" + frameIndex + "] [yield return null] skipped one frame\n";
            yield return new Wait(Wait.WaitType.ForEndOfUpdate);
            ResultLabel += "Frame [" + frameIndex + "] [yield return new Wait(Wait.WaitType.ForEndOfUpdate)] working after Update in LateUpdate\n";
            yield return new Wait(Wait.WaitType.ForEndOfFrame);
            ResultLabel += "Frame [" + frameIndex + "] [yield return new Wait(Wait.WaitType.ForEndOfFrame)] I'm working on the end of frame\n";
            _testIsEnded = true;
        }
    }
}