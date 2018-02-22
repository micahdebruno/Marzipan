using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;

    public float CurrentHealth { get; private set; }
    public float delay;

	// Use this for initialization
	void Start () {
        CurrentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) makeDead();
        
    }

    void makeDead()
    {
        gameObject.SetActive(false);
        Destroy(gameObject,delay);
    }
}
