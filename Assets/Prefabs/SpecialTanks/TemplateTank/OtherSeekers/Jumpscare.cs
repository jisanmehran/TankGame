using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;
public class Jumpscare : MonoBehaviour
{
    public VideoPlayer MyVideoPlayer;
    public RawImage JScare;
    public VideoClip ScareVid;
    public GameObject Placeholder;
    private void Start()
    {
        
    }

    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) | Input.GetKey(KeyCode.Z))
        {
            Placeholder.SetActive(true);
            StartCoroutine("quit");
        }
    }

    IEnumerator quit() 
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Application.Quit();
        Debug.Log("quit");
    }
}
