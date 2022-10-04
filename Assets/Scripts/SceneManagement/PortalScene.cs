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

    [SerializeField]
    Transform spawnPoint;

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            //  SceneManager.LoadScene(nextScene);
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        DontDestroyOnLoad(gameObject);
        yield return SceneManager.LoadSceneAsync(nextScene);
        PortalScene otherPortal = GetOtherPortal();
        UpdatePlayer(otherPortal);
        print("Scene Loaded..");
        Destroy(gameObject);
    }

    private void UpdatePlayer(PortalScene otherPortal)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = otherPortal.spawnPoint.position;
        player.transform.rotation = otherPortal.spawnPoint.rotation;
    }

    private PortalScene GetOtherPortal()
    {
        foreach(PortalScene portal in FindObjectsOfType<PortalScene>())
        {
            if (portal == this) continue;
            return portal;
        }

        return null;
    }
}
