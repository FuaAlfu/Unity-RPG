using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// 2022.9.4
/// </summary>

namespace RPG.Cinematics
{
    public class CinematicControlRemover : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            //for testing
            GetComponent<FakePlayableDirector>().onFinish += TestEnableControl;
            GetComponent<FakePlayableDirector>().onFinish += TestDisableControl;

            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().played += EnableControl;
        }

        void DisableControl(PlayableDirector pd)
        {
            print("DisableControl");
        }

        void EnableControl(PlayableDirector pd)
        {
            print("EnableControl");
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
