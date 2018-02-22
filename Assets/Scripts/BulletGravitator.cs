/*Main Programmer: Khadijah Wali (but really Cameron Blomquist)
 * a minorly edited version of gravitator applied to a bullet
 * It had to be edited to be general and not use an "active planet"
 * It just shoots a ray straights down and if it hits something
 * on the planet layer it applies graviational force
 * it has a hardcoded gravity because the bullet should always
 * simply follow the curvature of the planet (even on light planets)
 * or heavy planets)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGravitator : MonoBehaviour
{
    private Rigidbody2D rb;
    private RaycastHit2D hit;

    public RaycastHit2D GravitatorInfo { get { return hit; } }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 
    }

    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(rb.position, -transform.up, Mathf.Infinity, LayerMask.GetMask("Planet"));

        if (hit)
        {
            // Force body towards planet
            rb.AddForce(30 * -hit.normal);
            Debug.DrawRay(hit.point, transform.up);
            Debug.DrawRay(hit.point, hit.normal);
            // Rotate body towards planet
            transform.up = Vector2.Lerp(transform.up, hit.normal, Time.fixedDeltaTime * 5);
        }


    }
}
