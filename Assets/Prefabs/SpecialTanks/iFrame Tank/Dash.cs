using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject Tank;
    private float originalSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    public AudioClip dash;
    public CooldownBar CBar;
    public GameObject CDImage;
    // Start is called before the first frame update
    void Start()
    {
        TankScript scr = Tank.GetComponent<TankScript>();
        originalSpeed = scr.moveSpeedMax;
        if (Tank.tag == "Player1")
        {
            CDImage = GameObject.FindWithTag("OneFireTwoCD");
        }
        else
        {
            CDImage = GameObject.FindWithTag("TwoFireTwoCD");
        }
        
        CBar = CDImage.GetComponent<CooldownBar>();
        CBar.CD = dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                TankScript scr = Tank.GetComponent<TankScript>();
                scr.moveSpeedMax = dashSpeed;
                dashCounter = dashLength;
                Echo echoScr = Tank.GetComponent<Echo>();
                echoScr.enabled = true;
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = dash;
                audio.Play(); 
            }
        }

        if (Input.GetKey(KeyCode.Q) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                TankScript scr = Tank.GetComponent<TankScript>();
                scr.moveSpeedMax = dashSpeed;
                dashCounter = dashLength;
                Echo echoScr = Tank.GetComponent<Echo>();
                echoScr.enabled = true;
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = dash;
                audio.Play(); 
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                TankScript scr = Tank.GetComponent<TankScript>();
                scr.moveSpeedMax = originalSpeed;
                Echo echoScr = Tank.GetComponent<Echo>();
                echoScr.enabled = false;
                Debug.Log("dash end");
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            CBar.currentCD = dashCoolCounter;
        }
    }
}
