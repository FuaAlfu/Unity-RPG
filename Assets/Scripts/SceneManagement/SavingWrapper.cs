using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

/// <summary>
/// 2022.10.8
/// </summary>

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        //DEFAULT_SAVE_FILE
        const string dufaultSaveFile = "save";

         IEnumerator Start()
        {
          yield return GetComponent<SavingSystem>().LoadLastScene(dufaultSaveFile);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(dufaultSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(dufaultSaveFile);
        }
    }
}
