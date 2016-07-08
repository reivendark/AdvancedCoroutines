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
            ResultLabel.text = "";
            _testIsEnded = false;
            CoroutineManager.StartCoroutine(WaitForEndOfFrameCoroutine(), this);
        }

        private void Update()
        {
            if(!_testIsEnded)
            {
                frameIndex++;
                ResultLabel.text += "Update() frame(" + frameIndex + ")\n";
            }
        }

        private void LateUpdate()
        {
            if(!_testIsEnded)
            {
                ResultLabel.text += "LateUpdate() frame(" + frameIndex + ")\n";
            }
        }

        private IEnumerator WaitForEndOfFrameCoroutine()
        {
            ResultLabel.text += "Coroutine started frame(" + frameIndex + ")\n";
            yield return new Wait(0.1f);
            ResultLabel.text += "[yield return new Wait(0.1f)] I started after 0.1 seconds. frame(" + frameIndex + ")\n";
            yield return null;
            ResultLabel.text += "[yield return null] I skipped one frame. frame(" + frameIndex + ")\n";
            yield return new Wait(Wait.WaitType.ForEndOfUpdate);
            ResultLabel.text += "[yield return new Wait(Wait.WaitType.ForEndOfUpdate)] I'm working after Update in LateUpdate. frame(" + frameIndex + ")\n";
            yield return new Wait(Wait.WaitType.ForEndOfFrame);
            ResultLabel.text += "[yield return new Wait(Wait.WaitType.ForEndOfFrame)] I'm working on the end of frame. frame(" + frameIndex + ")\n";
            _testIsEnded = true;
        }
    }
}