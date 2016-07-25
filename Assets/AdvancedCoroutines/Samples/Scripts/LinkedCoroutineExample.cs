// <copyright file="LinkedCoroutineExample.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using UnityEngine;
using UnityEngine.UI;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class LinkedCoroutineExample : MonoBehaviour
    {
        public string AttentionText = "Attention! Open statistics window for better experience Window->Advanced Coroutines->Statistics";

        public GameObject Prefab;
        private string HintText = "Cube is rotating by coroutine. Press 'Destroy Instance' to destroy cube and stop coroutine";

        private Rect _attentionLabelRect;
        private Rect _startButtonRect;
        private Rect _stopButtonRect;
        private Rect _hintRect;

        private GameObject Instance;

        private bool HintTextOn;

        public void Awake()
        {
            HintTextOn = false;

            var y = 0;
            var smallWidth = 25;
            var bigWidth = 95;

            _attentionLabelRect = new Rect(5, y, Screen.width - 5, smallWidth);

            _startButtonRect = new Rect(5, y+=smallWidth, Screen.width / 2 - 5, bigWidth);
            _stopButtonRect = new Rect(Screen.width / 2 + 5, y, Screen.width / 2 - 5, bigWidth);

            _hintRect = new Rect(5, y+=bigWidth, Screen.width - 5, smallWidth);
        }

        private void OnGUI()
        {
            GUI.contentColor = Color.red;
            GUI.Label(_attentionLabelRect, AttentionText);

            GUI.contentColor = Color.white;

            GUI.contentColor = Color.white;

            if (GUI.Button(_startButtonRect, "Create instance"))
            {
                CreateInstance();
            }

            if (GUI.Button(_stopButtonRect, "Destroy instance"))
            {
                DestroyInstance();
            }

            if(HintTextOn)
                GUI.Label(_hintRect, HintText);

            GoBack.Button();
        }

        public void CreateInstance()
        {
            Instance = Instantiate(Prefab);
            HintTextOn = true;       
        }

        public void DestroyInstance()
        {
            Destroy(Instance);
            HintTextOn = false;
        }
    }
}