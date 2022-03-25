using UnityEngine;
using UnityEngine.Video;
 
public class Jumpscare : MonoBehaviour
{
    private VideoPlayer MyVideoPlayer;
 
    private void Start()
    {
        //video player component
        MyVideoPlayer = GetComponent<VideoPlayer>();
        // assign video clip
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) | Input.GetKey(KeyCode.Z))
        {
            MyVideoPlayer.clip = Resources.Load<VideoClip>("JScare");
        }
    }
}
