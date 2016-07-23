// <copyright file="PrefabWithLinkedCoroutine.cs" company="Parallax Pixels">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Michael Kulikov</author>
// <date>07/05/2016 19:09:58 AM </date>

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AdvancedCoroutines.Samples.Scripts
{
    public class PrefabWithLinkedCoroutine : MonoBehaviour
    {
        public new Transform transform;

        public void Start()
        {
            transform = GetComponent<Transform>();
            CoroutineManager.StartCoroutine(enumerator(), gameObject);
        }

        private IEnumerator enumerator()
        {
            while (true)
            {
                transform.Rotate(Vector3.up + Vector3.left, 10f * Time.deltaTime);
                yield return null;
            }
        }
    }
}