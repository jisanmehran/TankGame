using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool Cooldown;
    private float timeBtwShots;
    public float cd;
    public GameObject Tank;
    private Vector3 direction;
    public float jumpSpeed = 0.01f;
    public LayerMask Wall;
    public float Range;
    public bool jumping;
    public GameObject FirePoint;
    public GameObject enemy;
    public bool growing = true;
    public Vector3 scaleChange = new Vector3(-0.0025f, -0.0025f, -0.0025f);
    public Vector3 scaleMax = new Vector3(1.3f, 1.3f, 1.3f);
    public Vector3 scaleMin = new Vector3(0.7f, 0.7f, 0.7f);
    public bool jumpingup;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        if (Tank.tag == "Player1")
        {
            enemy = GameObject.FindWithTag("Player2");
        }
        else if (Tank.tag == "Player2")
        {
            enemy = GameObject.FindWithTag("Player1");
        }
        rb = GetComponent<Rigidbody2D>();
        direction = transform.up;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown == false)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Tank.GetComponent<TankScript>().isPlayer2Input == false)
            {   
                RaycastHit2D rayInfo = Physics2D.Raycast(new Vector2(FirePoint.transform.position.x, FirePoint.transform.position.y),FirePoint.transform.up,Range,Wall);
                if(rayInfo)
                {
                    Cooldown = true;
                    jumping = true;
                    StartCoroutine(jumpEffects());
                    timeBtwShots = cd;
                    growing = true;
                    jumpingup = true;
                    Tank.GetComponent<TankScript>().enabled = false;
                    Physics2D.IgnoreLayerCollision (8, 9, true);
                    Physics2D.IgnoreLayerCollision (8, 10, true);
                    print("hit");
                    StartCoroutine(jumpEnd());
                }
            }
            if (Input.GetKey(KeyCode.W) && gameObject.GetComponent<TankScript>().isPlayer2Input == true)
            {
                RaycastHit2D rayInfo = Physics2D.Raycast(new Vector2(FirePoint.transform.position.x, FirePoint.transform.position.y),FirePoint.transform.up,Range,Wall);
                if(rayInfo)
                {
                    Cooldown = true;
                    jumping = true;
                    StartCoroutine(jumpEffects());
                    timeBtwShots = cd;
                    growing = true;
                    jumpingup = true;
                    Tank.GetComponent<TankScript>().enabled = false;
                    Physics2D.IgnoreLayerCollision (8, 9, true);
                    Physics2D.IgnoreLayerCollision (8, 10, true);
                    print("hit");
                    StartCoroutine(jumpEnd());
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
        }

        if (jumping)
        {   
            if (jumpingup)
            {
                if (gameObject.transform.localScale.y < scaleMax.y)
                {
                    gameObject.transform.localScale -= scaleChange * 2;
                    print("jumpup is true");
                }     
            }
            else if (jumpingup == false)
            {
                if (gameObject.transform.localScale.y < scaleMin.y)
                {
                    gameObject.transform.localScale +=  scaleChange;
                    print("jumpup is false");
                }
                
            }
            print(gameObject.transform.localScale);
            StartCoroutine(jumpMovement());
        }
    }

    IEnumerator jumpEffects()
    {
        yield return new WaitForSeconds(.11f);
        jumpingup = false;
        yield return new WaitForSeconds(.1f);
        gameObject.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
    }
    
    IEnumerator jumpMovement()
    {
        jumpingup = true;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        jumpingup = false;
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        transform.position += transform.up * jumpSpeed;
        yield return new WaitForSeconds(.01f);
        jumping = false;        
    }

    IEnumerator jumpEnd()
    {
        yield return new WaitForSeconds(.75f);
        jumping = false;
        yield return new WaitForSeconds(.75f);
        gameObject.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        Tank.GetComponent<TankScript>().enabled = true;
        Physics2D.IgnoreLayerCollision (8, 9, false);
        Physics2D.IgnoreLayerCollision (8, 10, false);
    }

    
}
