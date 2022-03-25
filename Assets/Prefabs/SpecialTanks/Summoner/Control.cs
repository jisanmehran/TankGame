using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject Master;
    public GameObject inputdetector;
    public GameObject Servant;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    private int ServantNumber;
    public bool Possessed;
    public Servant thePossessed;
    public AudioClip switchTo;
    public AudioClip switchBack;
    public AudioClip pulse;
    public GameObject ControlEffect;
    public GameObject CurrentControlEffect;
    public GameObject SecondSound;
    public CooldownBar CBar;
    public GameObject CDImage;

    // Start is called before the first frame update
    void Start()
    {
        inputdetector = GameObject.Find("GameControl");
        Cooldown = false;
        if (Master.tag == "Player1")
        {
            CDImage = GameObject.FindWithTag("OneFireTwoCD");
        }
        else
        {
            CDImage = GameObject.FindWithTag("TwoFireTwoCD");
        }
        
        CBar = CDImage.GetComponent<CooldownBar>();
        CBar.CD = cd;
    }

    // Update is called once per frame
    void Update()
    {
        if (thePossessed == null && Possessed == true)
        {
            Cooldown = true;
            timeBtwShots = cd;
            gameObject.GetComponent<TankScript>().enabled = true;
            gameObject.GetComponentInChildren<FiringScript>().enabled = true;
            Possessed = false;
            AudioSource audio = Master.GetComponent<AudioSource>();
            audio.clip = switchBack;
            audio.Play();
        }
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.Q) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            {  
                if (Possessed == false && GameObject.FindObjectsOfType<Servant>() != null )
                {
                    float distanceToClosestServant = Mathf.Infinity;
                    Servant closestServant = null;
                    //Edit Servant in the FindObjectsOfType to a component on the object you
                    //want to find nearest 
                    Servant[] allServants = GameObject.FindObjectsOfType<Servant>();

                    foreach (Servant currentServant in allServants)
                    {
                        float distanceToServant = (currentServant.transform.position - this.transform.position).sqrMagnitude;
                        if (distanceToServant < distanceToClosestServant)
                        {
                            distanceToClosestServant = distanceToServant;
                            closestServant = currentServant;
                            thePossessed =  closestServant; 
                        }
                    }
                    if (closestServant != null)
                    {
                        Cooldown = true;
                        timeBtwShots = cd;
                        gameObject.GetComponent<TankScript>().enabled = false;
                        gameObject.GetComponentInChildren<FiringScript>().enabled = false;
                        closestServant.GetComponent<TankScript>().enabled = true;
                        closestServant.GetComponent<TurretScript>().enabled = false;
                        closestServant.GetComponentInChildren<FiringScript>().enabled = true;
                        Possessed = true;
                        GameObject ControlEffectIns = Instantiate(ControlEffect, closestServant.transform.position, Quaternion.identity);
                        CurrentControlEffect = ControlEffectIns;
                        ControlEffectIns.transform.parent = closestServant.transform;
                        AudioSource audio = Master.GetComponent<AudioSource>();
                        audio.clip = switchTo;
                        audio.Play();
                        AudioSource audio2 = SecondSound.GetComponent<AudioSource>();
                        audio2.clip = pulse;
                        audio2.Play();

                        if (gameObject.GetComponent<TankScript>().isPlayer2Input == false)
                        {
                        closestServant.GetComponent<TankScript>().isPlayer2Input = false;
                        }

                        if (gameObject.GetComponent<TankScript>().isPlayer2Input == true)
                        {
                            closestServant.GetComponent<TankScript>().isPlayer2Input = true;
                        }
                    }
                    

                    
                }
                else if (Possessed == true)
                {
                    //Debug.Log("Switch Back");
                    Cooldown = true;
                    timeBtwShots = cd;
                    gameObject.GetComponent<TankScript>().enabled = true;
                    gameObject.GetComponentInChildren<FiringScript>().enabled = true;
                    thePossessed.GetComponent<TankScript>().enabled = false;
                    thePossessed.GetComponent<TurretScript>().enabled = true;
                    thePossessed.GetComponentInChildren<FiringScript>().enabled = false;
                    Possessed = false;
                    Destroy(CurrentControlEffect);
                    AudioSource audio = Master.GetComponent<AudioSource>();
                    audio.clip = switchBack;
                    audio.Play();
                    AudioSource audio2 = SecondSound.GetComponent<AudioSource>();
                    audio2.Stop();
                }  
            }

            if (Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
            {  
                if (Possessed == false && GameObject.FindObjectsOfType<Servant>() != null )
                {
                    float distanceToClosestServant = Mathf.Infinity;
                    Servant closestServant = null;
                    //Edit Servant in the FindObjectsOfType to a component on the object you
                    //want to find nearest 
                    Servant[] allServants = GameObject.FindObjectsOfType<Servant>();

                    foreach (Servant currentServant in allServants)
                    {
                        float distanceToServant = (currentServant.transform.position - this.transform.position).sqrMagnitude;
                        if (distanceToServant < distanceToClosestServant)
                        {
                            distanceToClosestServant = distanceToServant;
                            closestServant = currentServant;
                            thePossessed =  closestServant; 
                        }
                    }
                    if (closestServant != null)
                    {
                        Cooldown = true;
                        timeBtwShots = cd;
                        gameObject.GetComponent<TankScript>().enabled = false;
                        gameObject.GetComponentInChildren<FiringScript>().enabled = false;
                        closestServant.GetComponent<TankScript>().enabled = true;
                        closestServant.GetComponent<TurretScript>().enabled = false;
                        closestServant.GetComponentInChildren<FiringScript>().enabled = true;
                        Possessed = true;
                        GameObject ControlEffectIns = Instantiate(ControlEffect, closestServant.transform.position, Quaternion.identity);
                        CurrentControlEffect = ControlEffectIns;
                        ControlEffectIns.transform.parent = closestServant.transform;
                        AudioSource audio = Master.GetComponent<AudioSource>();
                        audio.clip = switchTo;
                        audio.Play();
                        AudioSource audio2 = SecondSound.GetComponent<AudioSource>();
                        audio2.clip = pulse;
                        audio2.Play();

                        if (gameObject.GetComponent<TankScript>().isPlayer2Input == false)
                        {
                        closestServant.GetComponent<TankScript>().isPlayer2Input = false;
                        }

                        if (gameObject.GetComponent<TankScript>().isPlayer2Input == true)
                        {
                            closestServant.GetComponent<TankScript>().isPlayer2Input = true;
                        }
                    }
                    

                    
                }
                else if (Possessed == true)
                {
                    //Debug.Log("Switch Back");
                    Cooldown = true;
                    timeBtwShots = cd;
                    gameObject.GetComponent<TankScript>().enabled = true;
                    gameObject.GetComponentInChildren<FiringScript>().enabled = true;
                    thePossessed.GetComponent<TankScript>().enabled = false;
                    thePossessed.GetComponent<TurretScript>().enabled = true;
                    thePossessed.GetComponentInChildren<FiringScript>().enabled = false;
                    Possessed = false;
                    Destroy(CurrentControlEffect);
                    AudioSource audio = Master.GetComponent<AudioSource>();
                    audio.clip = switchBack;
                    audio.Play();
                    AudioSource audio2 = SecondSound.GetComponent<AudioSource>();
                    audio2.Stop();
                }  
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
            CBar.currentCD = timeBtwShots;
        }
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
        }
    }
}
