using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour {

    public int health = 5;                          //health of player
    public float juggerTimerMax = 0f;               //max time for invulnerability (player into enemy collision)
    public float juggerTimer = 0f;                  //time remaining for invulnerability
    int defaultLayer;                               //default layer for object (in case of modification)


    // Use this for initialization
    private void Start() {
        defaultLayer = gameObject.layer;            //assign default layer, in case of later modification
    }

    // Update is called once per frame
    private void Update() {

        //give invulnerability if time still remaining(before updating position). 
        //If invulnerability is done, return player to normal layer.
        if (juggerTimer > 0) {
            gameObject.layer = 10;
            juggerTimer -= Time.deltaTime;
        } else
            gameObject.layer = defaultLayer;

        //check for health inside Update() to prevent sync issues
        if (health <= 0)
            Die();
    }


    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision) {

        //if player collision with monster
        if (collision.gameObject.layer == 8) {
            if (juggerTimer <= 0) {
                health--;

                //grant brief invulnerability IF player is still alive
                if (health > 0) {
                    juggerTimer = juggerTimerMax;
                    gameObject.layer = 10;
                }
            }
        }
    }


    //execute upon object death
    private void Die() {

        //end game code here

        Destroy(gameObject);
    }


    //displayed health on upper left corner
    private void OnGUI() {
        GUI.Label(new Rect(100, 0, 100, 50), "Health: " + health);
    }


}
