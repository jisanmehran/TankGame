using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangeRulesScrn : MonoBehaviour
{
    public GameObject CameraHolder;
    public bool There;
    public GameObject SSkybox;
    public GameObject Skybox;
    public AudioClip howcouldyou;
    public GameObject canvas;
    public GameObject canvas1;
    public GameObject Tank1;
    public GameObject Tank2;
    public Transform Spawn1;
    public Transform Spawn2;
    // Start is called before the first frame update
    void Start()
    {
        There = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tank" && There == false)
        {
            Vector3 p = CameraHolder.transform.position;
            if (p.x == 0)
            {
                p.x = p.x + 24;
                There = true;
                AudioSource audio = SSkybox.gameObject.GetComponent<AudioSource>();
                audio.clip = howcouldyou;
                audio.Play();
                Skybox.gameObject.GetComponent<AudioSource>().Stop();
                Tank1.transform.position = Spawn1.position;
                Tank2.transform.position = Spawn1.position;
                canvas.SetActive(false);
                canvas1.SetActive(true);
            }
            CameraHolder.transform.position = p;  // you can set the position as a whole, just not individual fields
            
        }
        else if(other.gameObject.tag == "Tank" && There == true)
        {
            Vector3 p = CameraHolder.transform.position;
            if (p.x == 24)
            {
                p.x = p.x - 24;
                There = false;
                AudioSource audio = SSkybox.gameObject.GetComponent<AudioSource>();
                audio.Stop();
                Skybox.gameObject.GetComponent<AudioSource>().Play();
                Tank1.transform.position = Spawn2.position;
                Tank2.transform.position = Spawn2.position;
                canvas.SetActive(true);
                canvas1.SetActive(false);
            } 
            CameraHolder.transform.position = p;
        }
    }
}
