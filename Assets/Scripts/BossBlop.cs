using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBlop : BouncyBlop
{
    Player player;
    public GameObject Blopling;
    bool spawnedBlop = false;

    // Update is called once per frame
    new void Start()
    {
        base.Start();
        player = FindObjectOfType(typeof(Player)) as Player;
        jumpSpeed *= 2;
    }

    override protected void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 20)
        {
            base.FixedUpdate();
        }
    }
    override protected void Jump()
    {
        if (!spawnedBlop)
        {
            SpawnBlop();
            spawnedBlop = true;
        }
        //if (Random.Range(0, 100) == 0)
        //{
        spawnedBlop = false;
        direction *= -1;
        base.Jump();
        //}
    }

    void SpawnBlop()
    {
        GameObject newBlop = Instantiate(Blopling, transform.position + new Vector3(0, -10 * 1, 0), transform.rotation);
        newBlop.GetComponent<Gravitator>().activePlanet = grav.activePlanet;
        newBlop.GetComponent<BouncyBlop>().direction = 1;
    }

    void OnDestroy()
    {
        if (GetComponent<enemyHealth>().CurrentHealth <= 0)
        {
            print("You win");
            SceneManager.LoadScene(0);
        }
    }
     
}
