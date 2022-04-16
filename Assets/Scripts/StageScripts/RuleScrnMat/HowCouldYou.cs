using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HowCouldYou : MonoBehaviour
{
    public AudioClip Hit;
    public Text LVL;
    public int num;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.clip = Hit;
            audio.Play();
            Destroy(other.gameObject);
            num += 1;
            LVL.text = "Level of Violence: " + num.ToString();
            GameObject hitEffectIns = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectIns, 0.9f);
        }     
    }
}
