using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlopScript : MonoBehaviour
{
    //changed all pivate variables to protected
    protected bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    protected float groundCheckRadius = 0.2f;

    [SerializeField]
    protected float jumpSpeed = 5f;
    
    protected Rigidbody2D rb;

    protected Gravitator grav;

    //for movement
    int direction = 0;
    float timer = 1f;
    public float speed = 2f;

    // Use this for initialization
    protected void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        grav = GetComponent<Gravitator>();

    }

    // Update is called once per frame

    virtual protected void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            //Jump();   //changed to a method to ovride it
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Jump();
                timer = .7f;
                direction = Random.Range(1, 3);
            }
            Move();
        }
    }

    virtual protected void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(grav.GravitatorInfo.normal * jumpSpeed, ForceMode2D.Impulse);
        if (direction == 1)
        {
            rb.AddForce(Vector3.Cross(grav.GravitatorInfo.normal, Vector3.back) * 5 * direction, ForceMode2D.Impulse);//push forward
        }
        else if(direction == 2)
        {
            rb.AddForce(Vector3.Cross(grav.GravitatorInfo.normal, Vector3.back) * 5 * -direction, ForceMode2D.Impulse);//push forward
        }
    }

    protected void Move()
    {
      
        if (direction == 1)
        {
            rb.transform.Translate(-speed * Time.deltaTime, 0, 0);
            
        }
        else if (direction == 2)
        {
            rb.transform.Translate(speed * Time.deltaTime, 0, 0);
            
        }
        else if(direction == 3)
        {
            Jump();
        }
    }
}
