using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour {

    //choice of powerup (1-5)
    public int powerupSelect;           //choice of powerup
    private int health;                 //health remaining on powerup (0 or 1)
    GameObject player;                  //player object (to give powerup)


    // Use this for initialization
    void Start() {
        powerupSelect = (int)(Random.Range(1f, 6.999999f));
        health = 1;
        player = GameObject.FindWithTag("Player");                  //find player object
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

        //if 1 (shotgun) or 2 (lead bullets)
        if (powerupSelect == 1 || powerupSelect == 2)
            player.GetComponent<PlayerShoot>().receivePowerup(powerupSelect);

        //if 3 (add health)
        else if (powerupSelect == 3)
            player.GetComponent<PlayerDamageHandler>().health++;

        //if 4 (grant invincibility)
        else if (powerupSelect == 4)
            player.GetComponent<PlayerDamageHandler>().juggerTimer = 10;

        //if 5 (speed up)
        else if (powerupSelect == 5)
            player.GetComponent<PlayerMove>().speedupTimer = 10;

        //if 6 (rapidfire)
        else
            player.GetComponent<PlayerShoot>().fastTimer = 60;

        Destroy(gameObject);
    }
}