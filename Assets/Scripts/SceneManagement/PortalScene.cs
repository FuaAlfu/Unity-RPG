using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScene : MonoBehaviour
{
    // public static Action ScenesManiging;

    [SerializeField]
    private int nextScene = -1;

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
