/* Main Programmer: Micah Debruno
 * A simple script that applies a force
 * onto a bullet object straight outwards
 * based on which way the player is facing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    public float rocketSpeed = 1f;
    protected Rigidbody2D myRB;


	// Use this for initialization
	void Awake () {
        myRB = GetComponent<Rigidbody2D>();

        //y is negative when character is facing left
        if (transform.localRotation.y < 0)
        {
            myRB.AddForce(-transform.parent.transform.right * rocketSpeed, ForceMode2D.Impulse);
           
        }
        else myRB.AddForce(transform.parent.transform.right * rocketSpeed, ForceMode2D.Impulse);

        transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //delete bullet after its lifetime ends
    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
