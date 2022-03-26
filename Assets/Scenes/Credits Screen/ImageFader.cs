using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum FadeAction
{
    FadeIn,
    FadeOut,
    FadeInAndOut,
    FadeOutAndIn
}
public class ImageFader : MonoBehaviour
{
    [Tooltip("The Fade Type.")]
    [SerializeField] private FadeAction fadeType;
 
    [Tooltip("the image you want to fade, assign in inspector")]
    [SerializeField] private Image img;

    private float timeincrease = 1f;
    private float elaspedtime = 0f;
 
 
    public void Start()
    {
        if (fadeType == FadeAction.FadeIn)
        {
 
            StartCoroutine(FadeIn());
 
        }
 
        else if (fadeType == FadeAction.FadeOut)
        {
 
            StartCoroutine(FadeOut());
 
        }
 
        else if (fadeType == FadeAction.FadeInAndOut)
        {
 
            StartCoroutine(FadeInAndOut());
 
        }
 
        else if (fadeType == FadeAction.FadeOutAndIn)
        {
 
            StartCoroutine(FadeOutAndIn());
 
        }
    }
 
    // fade from transparent to opaque
    IEnumerator FadeIn()
    {
 
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
 
    }
 
    // fade from opaque to transparent
    IEnumerator FadeOut()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
 
    IEnumerator FadeInAndOut()
    {
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
 
        //Temp to Fade Out
        yield return new WaitForSeconds(1);
 
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
 
    IEnumerator FadeOutAndIn()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
 
        //Temp to Fade In
        yield return new WaitForSeconds(1);
 
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    void Update()
    {
        elaspedtime += timeincrease * Time.deltaTime;

        if (elaspedtime >= 4)
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}