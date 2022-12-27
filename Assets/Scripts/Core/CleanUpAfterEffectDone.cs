using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.11.29
/// </summary>

namespace RPG.Core
{
    public class CleanUpAfterEffectDone : MonoBehaviour
    {
        void Update()
        {
            if (!GetComponent<ParticleSystem>().IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}