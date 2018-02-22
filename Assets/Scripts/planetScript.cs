

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetScript : MonoBehaviour {

    [SerializeField]
    private int gravity;

    private Transform bodie;


    public void attract(Transform body)
    {
       
        Vector2 gravityUp= (body.position - transform.position).normalized;
        Vector2 bodyUp = body.up;

     

     }


}
