using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 2022.10.5
/// </summary>

namespace SceneManagement
{
    public class PortalScene : MonoBehaviour
    {
        // public static Action ScenesManiging;

        enum DestinationIdentifire
        {
            A, B, C, D, E
        }

        [SerializeField]
        private int nextScene = -1;

        [Header("Timer")]
        [SerializeField]
        float fadeOut = 1f;

        [SerializeField]
        float fadeIn = 2f;

        [SerializeField]
        float fadeWaitTime = 0.5f;

        [Header("prefabe")]
        [SerializeField]
        Transform spawnPoint;

        [SerializeField]
        DestinationIdentifire destination;

        private void OnTriggerEnter(Collider c)
        {
            if (c.tag == "Player")
            {
                //  SceneManager.LoadScene(nextScene);
                StartCoroutine(Transition());
            }
        }

        private IEnumerator Transition()
        {
            if (nextScene < 0)
            {
                Debug.LogError("Scene to load not set..");
                yield break;
            }
            DontDestroyOnLoad(gameObject);

            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOut);
            yield return SceneManager.LoadSceneAsync(nextScene);
            PortalScene otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);
            print("Scene Loaded..");
            yield return new WaitForSeconds(fadeWaitTime);
            yield return fader.FadeIn(fadeIn);
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
            foreach (PortalScene portal in FindObjectsOfType<PortalScene>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;
                return portal;
            }

            return null;
        }
    }
}
