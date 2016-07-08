// <copyright file="LinkedCoroutineExample.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using UnityEngine;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class LinkedCoroutineExample : MonoBehaviour
    {
        public GameObject Prefab;
        private GameObject Instance;

        public void CreateInstance()
        {
            Instance = Instantiate(Prefab);
        }

        public void DestroyInstance()
        {
            Destroy(Instance);
        }
    }
}