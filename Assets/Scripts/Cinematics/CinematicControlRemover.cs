using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using RPG.Attribute;
using RPG.Control;

/// <summary>
/// 2022.9.4
/// </summary>

namespace RPG.Cinematics
{
    public class CinematicControlRemover : MonoBehaviour
    {
        GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            //for testing
            GetComponent<FakePlayableDirector>().onFinish += TestEnableControl;
            GetComponent<FakePlayableDirector>().onFinish += TestDisableControl;

            player = GameObject.FindWithTag("Player");

            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().played += EnableControl;
        }

        void DisableControl(PlayableDirector pd)
        {
            print("DisableControl");
            
            player.GetComponent<ActionScheduler>().CancelCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
        }

        void EnableControl(PlayableDirector pd)
        {
            print("EnableControl");
            player.GetComponent<PlayerController>().enabled = true;
        }

        //for testing
        void TestDisableControl(float test)
        {
            print("DisableControl");
        }

        void TestEnableControl(float test)
        {
            print("EnableControl");
        }
    }
}
