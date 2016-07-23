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
        public Text ResultLabel;

        private bool _testIsEnded = true;
        private int frameIndex;

        private void Awake()
        {
        	frameIndex = -1;
            ResultLabel.text = "";
            _testIsEnded = false;
            CoroutineManager.StartCoroutine(WaitForEndOfFrameCoroutine(), gameObject);
        }

        private void Update()
        {
            if(!_testIsEnded)
            {
            	frameIndex++;
                ResultLabel.text += "Frame [" + frameIndex + "] Update() method called\n";
            }
        }

        private void LateUpdate()
        {
            if(!_testIsEnded)
            {
                ResultLabel.text += "Frame [" + frameIndex + "] LateUpdate() method called\n";
            }
        }

        private IEnumerator WaitForEndOfFrameCoroutine()
        {
            ResultLabel.text += "Frame [0] coroutine started\n";
            yield return new Wait(0.1f);
            ResultLabel.text += "Frame [" + frameIndex + "] [yield return new Wait(0.1f)] started after 0.1 seconds\n";
            yield return null;
            ResultLabel.text += "Frame [" + frameIndex + "] [yield return null] skipped one frame\n";
            //yield return new Wait(Wait.WaitType.ForEndOfUpdate);
            //ResultLabel.text += "Frame [" + frameIndex + "] [yield return new Wait(Wait.WaitType.ForEndOfUpdate)] working after Update in LateUpdate\n";
            yield return new Wait(Wait.WaitType.ForEndOfFrame);
            ResultLabel.text += "Frame [" + frameIndex + "] [yield return new Wait(Wait.WaitType.ForEndOfFrame)] I'm working on the end of frame\n";
            _testIsEnded = true;
        }
    }
}