using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using RPG.SceneManagement;

/// <summary>
/// 2022.10.5
/// </summary>

namespace RPG.SceneManagement
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
            //save current scene..
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            wrapper.Save();
            yield return SceneManager.LoadSceneAsync(nextScene);
            //load current scene..
            wrapper.Load();
            PortalScene otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);
            print("Scene Loaded..");

            wrapper.Save();
            yield return new WaitForSeconds(fadeWaitTime);
            yield return fader.FadeIn(fadeIn);
            Destroy(gameObject);
        }

        private void UpdatePlayer(PortalScene otherPortal)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = otherPortal.spawnPoint.position;
            player.transform.rotation = otherPortal.spawnPoint.rotation;
            player.GetComponent<NavMeshAgent>().enabled = true;
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
