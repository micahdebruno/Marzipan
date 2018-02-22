using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyRocketHit : MonoBehaviour {

    public float weaponDamage;

    projectileController myPC;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<projectileController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Destroy(gameObject);
            if(other.collider.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.removeForce();
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

}
