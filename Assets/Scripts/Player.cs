/*
  Main Programmer: Khadijah Wali
  There are some components that Cameron and Micah and Yitzhak have made as well

  This is the main controller for the player, it keeps track of the player controls
  for movement and gun shooting (doesn't actually control shooting, just when the 
  player shoots)
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject hearts;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float jumpSpeed = 5f;
    [SerializeField]
    private int maxPlayerHealth;

    private int playerHealth; //current player health

    private Rigidbody2D rb;

    private Gravitator grav; //used to calculate jump angle

    // private Collider2D co; //I just got annoyed by the complaints of this never being used. Will be uncommented if we ever use it

    private float horizontalInput; //used in character input
    private bool isGrounded;
    public LayerMask groundLayer; //used to determine which layer isGrounded should check "should be set to Planet"
    public Transform groundCheck; //a transform what is a child of player which lies at their feet used to see if they are grounded
    private float groundCheckRadius = 0.2f;

    private bool facingRight; //used to determine the character direction for flipping character model or firing bullet direction
    private GameObject[] heartList;
    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate = .5f;
    public float nextFire = 0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     //   co = GetComponent<Collider2D>();
        grav = GetComponent<Gravitator>();

        playerHealth = maxPlayerHealth;

        facingRight = true;

        GameObject heart = hearts.transform.GetChild(0).gameObject;
        GameObject lastHeart = heart;
        heartList = new GameObject[playerHealth];
        heartList[0] = lastHeart;
        for(int i = 1; i<playerHealth;i++)
        {
            lastHeart = Instantiate(heart);
            lastHeart.transform.parent = hearts.transform;
            lastHeart.transform.localPosition = new Vector3(i * 20, 0, 0);
            lastHeart.transform.localScale = new Vector3(50, 50, 1);
            heartList[i] = lastHeart;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //jumping
        if (isGrounded && (Input.GetKeyDown("up") || Input.GetKeyDown("w")))
        {
            rb.AddForce(grav.GravitatorInfo.normal * jumpSpeed, ForceMode2D.Impulse);
        }

        //firing rocket
        if (Input.GetKeyDown("space")) fireRocket();
    }

    private void FixedUpdate()
    {

        //turns character based on whether they are facing right or not
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0 && facingRight)
        {
            facingRight = false;
            flip();
        }
        else if (horizontalInput > 0 && !facingRight)
        {
            facingRight = true;
            flip();
        }

        //move player
        transform.RotateAround(Vector3.zero, Vector3.back, horizontalInput * Time.deltaTime * speed);//changed from rb.position +=

        //check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
    }

    /// <summary>
    /// Flips the sprite around horizontally
    /// </summary>
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        theScale = gunTip.localScale;
        theScale.x *= -1;
        gunTip.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("You're hurt!");
            playerHealth--;
            if (playerHealth >=0)
            {
                heartList[playerHealth].GetComponent<SpriteRenderer>().color = Color.black;
            }

            //check character death
            if (playerHealth <= 0)
            {
                Debug.Log("You died!");
                SceneManager.LoadScene(2);
            }
        }
    }

    /// <summary>
    /// Instantiates a bullet object
    /// </summary>
    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y, rb.transform.eulerAngles.z)), transform);
                //Physics2D.IgnoreLayerCollision(10,9);
              //  Physics2D.IgnoreLayerCollision(10,0);
                //Physics2D.IgnoreLayerCollision(10, 10);
                bullet.GetComponent<Rigidbody2D>().velocity = rb.velocity;
                bullet.GetComponent<Rigidbody2D>().angularVelocity = rb.angularVelocity;
            }
            else if (!facingRight)
            {
                
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(-1, rb.transform.eulerAngles.y, rb.transform.eulerAngles.z)), transform);
               // Physics2D.IgnoreLayerCollision(10, 9);
               // Physics2D.IgnoreLayerCollision(10, 0);
               // Physics2D.IgnoreLayerCollision(10, 10);
                bullet.GetComponent<Rigidbody2D>().velocity = rb.velocity;
                bullet.GetComponent<Rigidbody2D>().angularVelocity = rb.angularVelocity;
            }
        }


    }

    public void changeGun(GameObject newGun)
    {
        bullet = newGun;
    }
}
