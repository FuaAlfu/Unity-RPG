using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.10.16
/// </summary>


namespace RPG.Core
{
    public class PeristentObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject peristentObjectPrefabe;

        static bool hasSpawn = false;
        private void Awake()
        {
            if (hasSpawn) return;

            SpawnPeristentObject();

            hasSpawn = true;
        }

        private void SpawnPeristentObject()
        {
            GameObject peristentObject = Instantiate(peristentObjectPrefabe);
            DontDestroyOnLoad(peristentObject);
        }
    }
}
