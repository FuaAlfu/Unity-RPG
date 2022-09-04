using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// 2022.9.1
/// </summary>


namespace RPG.Cinematics
{
    public class CinematicsTriggerByPlayer : MonoBehaviour
    {
        bool alreadyTriggered = false;

        private void OnTriggerEnter(Collider c)
        {
            if (!alreadyTriggered && c.gameObject.CompareTag("Player"))
            {
                alreadyTriggered = true;
                GetComponent<PlayableDirector>().Play();
            }
        }
    }
}
