using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Damage Handler used for Monsters, Player, and Bullets (Powerup has separate mechanism).
//OnCollisionEnter2D() checks for which type of object it is, and performs accordingly.
//Die() only triggered by frame-by-frame Update() to let each object sync collisions.

public class DamageHandler : MonoBehaviour
{

    public int health = 1;                          //health of object
    public float juggerTimerMax = 0f;               //max time for invulnerability (player into enemy collision). Should only be modified if a player object.
    public float juggerTimer = 0f;                  //time remaining for invulnerability
    int defaultLayer;                               //default layer for object

    public GameObject powerupPrefab;                //used to create powerup (upon monster death)
    GameObject powerupInstance;


    // Use this for initialization
    void Start() {
        defaultLayer = gameObject.layer;            //assign default layer, in case of later modification
    }


    void Update()
    {
        //give invulnerability(before updating position). If invulnerability is done, return player to normal layer.
        if (juggerTimer > 0)
        {
            gameObject.layer = 10;
            juggerTimer -= Time.deltaTime;
        }
        else
            gameObject.layer = defaultLayer;

        //check for health inside Update() to prevent sync issues
        if (health <= 0)
            Die();
    }

    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if PLAYER collision
        if (defaultLayer == 9)
        {
            //if player collision with monster
            if (collision.gameObject.layer == 8)
            {
                if (juggerTimer <= 0)
                {
                    health--;

                    //grant brief invulnerability IF player is still alive
                    if (health > 0)
                    {
                        juggerTimer = juggerTimerMax;
                        gameObject.layer = 10;
                    }
                }
            }
        }

        //if MONSTER collision
        else if(defaultLayer == 8)
        {
            //if not colliding colliding with terrain, deduct health.
            //NOTE: monsters cannot collide with other monsters (possibly change later)
            if (collision.gameObject.layer != 13)
            {
                health--;
            }
        }

        //else deduct health
        else
            health--;
    }

    //trigger ONLY active on bullet (always deletes on contact)
    private void OnTriggerEnter2D(Collider2D other)
    {
        health--;
    }

    //execute upon object death
    private void Die()
    {
        //if object that died is a monster
        if(defaultLayer == 8)
        {
            //run randomizer. 1/20 chance to get powerup
            int lucky = (int)(Random.Range(1f, 20.999999f));

            //initalize powerup, at position of monster, with 0 rotation
            if (lucky == 1)
                powerupInstance = (GameObject)Instantiate(powerupPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    //display player health. ONLY used for player
    //displayed on upper left
    private void OnGUI() {
        if(juggerTimerMax > 0)
            GUI.Label(new Rect(0, 0, 100, 50), "Health: " + health);
    }
}
