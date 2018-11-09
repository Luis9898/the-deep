using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour {

    //choice of powerup (1-5)
    public int powerupSelect;
    private int health;
    GameObject player;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //add 1 to player health so powerup doesn't kill him/her
        //player.GetComponent<DamageHandler>().health++;
        health--;

    }

    //execute upon object death
    private void Die()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().receivePowerup(powerupSelect);

        player.GetComponent<PlayerShoot>().receivePowerup(powerupSelect);
        Destroy(gameObject);

        //player.GetComponent<DamageHandler>().juggerTimer = 0f;
    }
}