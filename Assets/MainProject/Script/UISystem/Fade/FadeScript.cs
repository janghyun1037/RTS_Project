using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0;
    float F_time = 1f;

    public void FadeOut()
    {
        StartCoroutine(Fadeout());
    }

    public void FadeIn()
    {
        StartCoroutine(Fadein());
    }

    IEnumerator Fadeout()
    {
        Panel.gameObject.SetActive(true);
        time = 0;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0;
        yield return null;
    }

    IEnumerator Fadein()
    {
        Color alpha = Panel.color;
        time = 0;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        time = 0;
        yield return null;
    }
}
