using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.9.4
/// </summary>

namespace RPG.Cinematics
{


    public class FakePlayableDirector : MonoBehaviour
    {
        public event Action<float> onFinish;
        private void Start()
        {
            Invoke("OnFninish", 3f);
        }

        void OnFninish() 
        {
            print("testing..");
            onFinish(3.9f);
        }
    }
}