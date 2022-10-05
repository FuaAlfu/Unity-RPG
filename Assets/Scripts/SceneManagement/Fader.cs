using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.10.5
/// </summary>

namespace SceneManagement
{
    public class Fader : MonoBehaviour
    {
        [SerializeField]
        float timer = 3f;

        CanvasGroup canvasGroup;

        // Start is called before the first frame update
        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            StartCoroutine(FadeOutIn());
        }

        IEnumerator FadeOutIn()
        {
            yield return FadeOut(timer);
            print("F: out");
            yield return FadeIn(1f);
            print("F: in");
        }

        IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
        }

        IEnumerator FadeIn(float time)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }
        }
    }
}