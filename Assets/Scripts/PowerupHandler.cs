using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour {

    //choice of powerup (1-5)
    public int powerupSelect;           //choice of powerup
    private int health;                 //health remaining on powerup (0 or 1)
    GameObject player;                  //player object (to know when they connect)

	// Use this for initialization
	void Start () {
        powerupSelect = (int)(Random.Range(1f, 2.999999f));
        health = 1;
        player = GameObject.FindWithTag("Player");
        Debug.Log("num = " + powerupSelect);
    }

    private void Update()
    {
        if (health <= 0)
            Die();
    }

    //detect a (semi) collision (no physics)
    //NOTE: powerup does not currently use rigidbody. May later be used (unlikely)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        health--;
    }

    //give player the powerup, execute upon object death
    private void Die()
    {
        player.GetComponent<PlayerShoot>().receivePowerup(powerupSelect);
        Destroy(gameObject);
    }
}