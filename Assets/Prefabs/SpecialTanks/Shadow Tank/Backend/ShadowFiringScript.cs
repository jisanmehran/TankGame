using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowFiringScript : MonoBehaviour
{
    public GameObject shadowbullet;
    public GameObject Tank; 
    public AudioClip fireSound;
    public bool ShadowCooldown;
    public float shadowtimeBtwShots;
    public float shadowcd;
    public bool ShadowExists;
    public GameObject ShadowTank;
    public GameObject shotShadowBullet;
    public AudioClip tpsound;

    public GameObject GameControl1;
    public GameObject GameControl2;
    public GameObject teleporteffect;

    private Image cd;

    // Start is called before the first frame update

    void Start()
    {
        ShadowCooldown = false;
        Invoke("FindSpritesCD", 2f);
        Invoke("FindGameControls", 1.5f);
    }

    void FindSpritesCD()
    {
        if (gameObject.GetComponent<TankScript>().isPlayer2Input == false)
        {
            cd = GameControl1.GetComponent<GameControl>().SHTankCDIcon1.GetComponent<Image>();
        }

        if (gameObject.GetComponent<TankScript>().isPlayer2Input == true)
        {
            cd = GameControl2.GetComponent<Game2Control>().SHTankCDIcon2.GetComponent<Image>();
        }
    }

    void FindGameControls()
    {
        GameControl1 = GameObject.Find("GameControl");
        GameControl2 = GameObject.Find("GameControl Player 2");
    }
    // Update is called once per frame
    void Update()
    {
        //TankScript scr = Tank.GetComponent<TankScript>();
        if (ShadowCooldown == false && gameObject.GetComponent<TankScript>().isPlayer2Input == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Rigidbody2D bulletrb = shadowbullet.GetComponent<Rigidbody2D>();
                ShadowCooldown = true;
                shadowtimeBtwShots = shadowcd;
                ShadowExists = true;
                shotShadowBullet = Instantiate(shadowbullet, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
                AudioSource audio = Tank.GetComponent<AudioSource>();
                cd.fillAmount = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {   
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = tpsound;
                audio.Play();
                ShadowTank.transform.position = shotShadowBullet.transform.position;
                GameObject teleportEffectIns = Instantiate(teleporteffect, new Vector2(ShadowTank.transform.position.x, ShadowTank.transform.position.y), ShadowTank.transform.rotation);
                Destroy (teleportEffectIns, 1f);
                DestroyImmediate(shotShadowBullet, true);
                cd.fillAmount = 0;
            }
        }


        else 
        {
            shadowtimeBtwShots -= Time.deltaTime;
        }

        if (shadowtimeBtwShots <= 0)
        {
            ShadowCooldown = false;
        }


        if (ShadowCooldown == false && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Rigidbody2D bulletrb = shadowbullet.GetComponent<Rigidbody2D>();
                ShadowCooldown = true;
                shadowtimeBtwShots = shadowcd;
                ShadowExists = true;
                shotShadowBullet = Instantiate(shadowbullet, new Vector2(transform.position.x, transform.position.y), transform.rotation) as GameObject;
                AudioSource audio = Tank.GetComponent<AudioSource>();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {   
                AudioSource audio = Tank.GetComponent<AudioSource>();
                audio.clip = tpsound;
                audio.Play();
                ShadowTank.transform.position = shotShadowBullet.transform.position;
                GameObject teleportEffectIns = Instantiate(teleporteffect, new Vector2(ShadowTank.transform.position.x, ShadowTank.transform.position.y), ShadowTank.transform.rotation);
                Destroy (teleportEffectIns, 1f);
                DestroyImmediate(shotShadowBullet, true);
            }
        }


        else 
        {
            shadowtimeBtwShots -= Time.deltaTime;
        }

        if (shadowtimeBtwShots <= 0)
        {
            ShadowCooldown = false;
        }

        if (shadowtimeBtwShots > 0)
        {
            cd.fillAmount += Time.deltaTime/3;
        }
    
    }
}
