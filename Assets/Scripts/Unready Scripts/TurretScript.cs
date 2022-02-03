
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Events;

//[RequireComponent(typeof(ObjectPool))]

public class TurretScript : MonoBehaviour

{

    //Variables
    public int rotationOffset = 0;

    public List<Transform> turretBarrels;

    public GameObject bulletPrefab;

    public float reloadDelay = 1;

    private bool canShoot = true;

    private Collider2D[] tankColliders;

    public float currentDelay = 0;


    //Functions

    public void Awake ( )

    {

        tankColliders = GetComponentsInParent<Collider2D>();

    }


    private void Update ( )
    
    {

        if ( canShoot == false )

        {

            currentDelay -= Time.deltaTime;

            if ( currentDelay <= 0 )

            {

                canShoot = true;

            }

        }

    //}

    //public void Shoot ( )

    //{

        if ( Input.GetKeyDown("space") )
            {
                if ( canShoot )

                {

                    canShoot = false;

                    currentDelay = reloadDelay;

                    foreach ( var barrel in turretBarrels )

                    {

                        GameObject bullet = Instantiate ( bulletPrefab );

                        bullet.transform.position = barrel.position;

                        bullet.transform.localRotation = barrel.rotation;

                        //bullet.GetComponent<BulletScript>().Initialize();

                        foreach ( var collider in tankColliders )

                        {

                            Physics2D.IgnoreCollision( bullet.GetComponent<Collider2D>(), collider );

                        }

                    }

                }
            }
            
        }
    //}

    private void FixedUpdate ( ) 

    {

        // Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;

        // difference.Normalize ();

        // float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        // transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0f, 0f, angle + rotationOffset), 200 * Time.deltaTime);

    }

    



}
