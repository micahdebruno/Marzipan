/*Main Programmer: Cameron Blomquist
 * 
 * Assigned to any object that is affected by planet gravity (player, enemies, etc)
 * The object will shoot a ray directly under it and if it hits something one the
 * planet layer it will pull the object towards the planet and roate them according 
 * to the normal
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitator : MonoBehaviour {

    public Planet activePlanet;

    private Rigidbody2D rb;
   // private Collider2D col; //I just got annoyed by the complaints of this never being used. Will be uncommented if we ever use it

    public RaycastHit2D GravitatorInfo { get; private set; } //collapsed to make a private set instead of a seprate private variable

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        // col = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        GravitatorInfo = Physics2D.Raycast(rb.position, -transform.up, Mathf.Infinity, LayerMask.GetMask("Planet"));

        if (GravitatorInfo)
        {
            // Force body towards planet
            rb.AddForce(activePlanet.Gravity * rb.mass * -GravitatorInfo.normal);
            Debug.DrawRay(GravitatorInfo.point, transform.up);
            Debug.DrawRay(GravitatorInfo.point, GravitatorInfo.normal);
            // Rotate body towards planet
            transform.up = Vector3.Lerp(transform.up, GravitatorInfo.normal, Time.fixedDeltaTime * 5); // ANIIMATION ISSUE IS HERE
            //if (GetComponent<Player>()) transform.rotation.Set(transform.rotation.x, 90, 0,0);
          //  transform.up = Vector2.Lerp(transform.up, new Vector2(GravitatorInfo.normal.x, transform.localRotation.y), Time.fixedDeltaTime * 5);
        }

    }
}
