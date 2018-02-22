using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBlop : BlopScript {
    public int direction = 1;
    

    protected override void Jump()
    {
        rb.velocity = Vector2.zero;//stop all motion
        rb.AddForce(grav.GravitatorInfo.normal * jumpSpeed, ForceMode2D.Impulse); //jump up
        rb.AddForce(Vector3.Cross(grav.GravitatorInfo.normal, Vector3.back) * 5 * direction, ForceMode2D.Impulse);//push forward 
    }
}
