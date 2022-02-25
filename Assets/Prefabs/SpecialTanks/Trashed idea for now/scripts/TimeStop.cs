using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeStop : MonoBehaviour
{
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    private float fixedDeltaTime;
    public GameObject Tank;
    public bool TimeStopped;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Cooldown = true;
                timeBtwShots = cd;
                TimeStopped = true;
                List<GameObject> rootObjects = new List<GameObject>();
                Scene scene = SceneManager.GetActiveScene();
                scene.GetRootGameObjects( rootObjects );
  
                // iterate root objects and do something
                for (int i = 0; i < rootObjects.Count; ++i)
                {
                    GameObject gameObject = rootObjects[ i ];
                    if (gameObject.tag == "Tank" && gameObject.name !=  "PauseTank")
                    {
                        TankScript scr = gameObject.GetComponent<TankScript>();
                        scr.enabled = false;
                    }
                    else if (gameObject.tag == "bullet")
                    {
                        if (gameObject.name == "PauseBullet")
                        {
                            PauseBullet scr = gameObject.GetComponent<PauseBullet>();
                            scr.enabled = false;
                        }
                        else
                        {
                            BulletScript scr = gameObject.GetComponent<BulletScript>();
                            scr.enabled = false;
                        }
                        
                    }
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (timeBtwShots <= 0)
        {
            Cooldown = false;
            TimeStopped = false;
        }
    }
}
