using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trackCam : MonoBehaviour
{
    // The target we are following
    public Transform target;
    private Vector3 offset;
    public Canvas playerUI;


    void Start()
    {
        playerUI.enabled = true;
        offset = transform.position - target.transform.position;
    }


    void FixedUpdate()
    {
        transform.position = target.transform.position + offset;
        transform.rotation = new Quaternion(0f, target.rotation.y, target.rotation.z, target.rotation.w);

        if(transform.rotation.x == -180f)
        {
            transform.rotation = Quaternion.AngleAxis(0, transform.right);
        }
    }
}


