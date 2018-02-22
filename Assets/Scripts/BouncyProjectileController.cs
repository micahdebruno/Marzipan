using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyProjectileController : projectileController {

    int direction;

    private BulletGravitator grav; //used to calculate bounce angle

    // Use this for initialization
    void Awake () {
        myRB = GetComponent<Rigidbody2D>();
        grav = GetComponent<BulletGravitator>();
        if (transform.parent.localScale.x < 0)
        {
            myRB.AddForce(-transform.parent.transform.right *( rocketSpeed + System.Math.Abs(transform.parent.GetComponent<Rigidbody2D>().velocity.x)), ForceMode2D.Impulse);
            direction = 1;

        }
        else
        {
            myRB.AddForce(transform.parent.transform.right * (rocketSpeed + System.Math.Abs(transform.parent.GetComponent<Rigidbody2D>().velocity.x)), ForceMode2D.Impulse);
            direction = -1;
        }

        transform.parent = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Planet")
        {

            myRB.velocity = Vector2.zero;//stop all motion
           myRB.AddForce(grav.GravitatorInfo.normal * rocketSpeed , ForceMode2D.Impulse);
           myRB.AddForce(Vector3.Cross(grav.GravitatorInfo.normal, Vector3.back) * 5 * direction, ForceMode2D.Impulse);

        }
    }
}
