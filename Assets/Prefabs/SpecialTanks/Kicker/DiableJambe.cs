using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiableJambe : MonoBehaviour
{
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public bool DiableLeg;
    public GameObject Tank;
    private Animator anim;
    public GameObject fireEffect;
    public bool transforming;
    public GameObject transformParticle;
    public GameObject FirePoint;
    public SpriteRenderer SobaRenderer;
    public AudioClip transSound;
    // Start is called before the first frame update
    void Start()
    {
        DiableLeg = false;
        Tank = GameObject.Find("KickerTank(Clone)");
        anim = this.gameObject.GetComponent<Animator>();
        Cooldown = true;
        timeBtwShots = cd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Tank.GetComponent<TankScript>().isPlayer2Input == false)
            { 
                StartCoroutine(fireSpin());
            }

            if (Input.GetKeyDown(KeyCode.W) && Tank.GetComponent<TankScript>().isPlayer2Input == false)
            {  
                StartCoroutine(fireSpin());     
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }

        if(transforming)
        {
            anim.SetBool("Spin", true);
            
        }
    }

    IEnumerator fireSpin()
    {
        if (DiableLeg == false && Cooldown == false)
        {
            transforming = true;
            GameObject SpinEffectIns = Instantiate(transformParticle, FirePoint.transform.position, Quaternion.identity);
            SpinEffectIns.transform.parent = Tank.transform;
            TankScript Tscr = Tank.GetComponent<TankScript>();
            Tscr.enabled = false;
            AudioSource audio = Tank.GetComponent<AudioSource>();
            audio.clip = transSound;
            audio.Play();

            yield return new WaitForSeconds(3f);

            SobaRenderer.color = Color.red;
            Tscr.enabled = true;
            Destroy(SpinEffectIns);
            GameObject fireEffectIns = Instantiate(fireEffect, transform.position, Quaternion.identity);
            GameObject fireEffectIns2 = Instantiate(fireEffect, transform.position, Quaternion.identity);
            Destroy(fireEffectIns, 0.75f);
            Destroy(fireEffectIns2, 0.75f);
            print("spin done");
            DiableLeg = true;
            transforming = false;
            anim.SetBool("Spin", false);

            yield return new WaitForSeconds(1f);
            
            audio.Stop();

            yield return new WaitForSeconds(13.5f);
            SobaRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            SobaRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            SobaRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            SobaRenderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            SobaRenderer.color = Color.white;
            yield return new WaitForSeconds(0.05f);
            SobaRenderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            SobaRenderer.color = Color.white;
            yield return new WaitForSeconds(0.05f);
            SobaRenderer.color = Color.red;
            SobaRenderer.color = Color.white;
            DiableLeg = false;
            timeBtwShots = cd;
            Cooldown = true;
        }    
    }
}
