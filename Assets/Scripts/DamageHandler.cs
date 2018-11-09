using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{

    public int health = 1;                          //health of object
    public float juggerTimerMax = 0f;               //max time for invulnerability (player into enemy collision). Should only be modified if a player object.
    private float juggerTimer = 0f;                 //time remaining for invulnerability
    int defaultLayer;                               //default layer for object

    public GameObject powerupPrefab;
    GameObject powerupInstance;


    // Use this for initialization
    void Start() {
        defaultLayer = gameObject.layer;
    }


    void Update()
    {
        //give invulnerability(before updating position). If invulnerability is done, return player to normal layer.
        if (juggerTimer > 0)
            juggerTimer -= Time.deltaTime;
        else
            gameObject.layer = defaultLayer;

        if (health <= 0)
            Die();
    }

    //detect a (semi) collision (no physics)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (juggerTimer <= 0)
        {
            health--;

            //grant brief invulnerability IF object is a player
            if (health > 0 && defaultLayer == 9)
            {
                juggerTimer = juggerTimerMax;
                gameObject.layer = 10;
            }
        }
    }

    //execute upon object death
    private void Die()
    {
        //if object that died is a monster
        if(gameObject.layer == 8)
        {
            //run randomizer. 1/20 chance to get powerup
            System.Random rand = new System.Random();
            int lucky = rand.Next(1, 21);

            //initalize powerup, at position of monster, with 0 rotation
            if(lucky == 1)
                powerupInstance = (GameObject)Instantiate(powerupPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    //display player health. ONLY used for player
    private void OnGUI() {
        if(juggerTimerMax > 0)
            GUI.Label(new Rect(0, 0, 100, 50), "Health: " + health);
    }
}
