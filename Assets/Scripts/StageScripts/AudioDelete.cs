using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<SceneAudio>().StopMusic();
        Destroy(GameObject.FindGameObjectWithTag("Music"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
