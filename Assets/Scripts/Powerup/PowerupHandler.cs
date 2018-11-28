using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour {

    //choice of powerup (1-5)
    public int powerupSelect;           //choice of powerup
    private int health;                 //health remaining on powerup (0 or 1)
    GameObject player;                  //player object (to give powerup)

    public AudioClip pup;
    private AudioSource source;

    // Use this for initialization
    void Start() {
        powerupSelect = (int)(Random.Range(1f, 5.999999f));
        health = 1;
        player = GameObject.FindWithTag("Player");                  //find player object
        source = GetComponent<AudioSource>();
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
        enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        source.PlayOneShot(pup, 1.0f);

        //if 1 (shotgun) or 2 (lead bullets)
        if (powerupSelect == 1)
            player.GetComponent<PlayerShoot>().receivePowerup(powerupSelect);

        //if 2 (add health)
        else if (powerupSelect == 2)
            player.GetComponent<PlayerDamageHandler>().health++;

        //if 3 (grant invincibility)
        else if (powerupSelect == 3)
            player.GetComponent<PlayerDamageHandler>().juggerTimer = 10;

        //if 4 (speed up)
        else if (powerupSelect == 4)
            player.GetComponent<PlayerMove>().speedupTimer = 10;

        //if 5 (rapidfire)
        else
            player.GetComponent<PlayerShoot>().fastTimer = 40;

        Destroy(gameObject, pup.length);
    }
}