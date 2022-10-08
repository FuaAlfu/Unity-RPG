using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

/// <summary>
/// 2022.10.8
/// </summary>

namespace RPG.SceneManagements
{
    public class SavingWrapper : MonoBehaviour
    {
        //DEFAULT_SAVE_FILE
        const string dufaultSaveFile = "save";

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

        private void Save()
        {
            GetComponent<SavingSystem>().Save(dufaultSaveFile);
        }

        private void Load()
        {
            GetComponent<SavingSystem>().Load(dufaultSaveFile);
        }
    }
}
