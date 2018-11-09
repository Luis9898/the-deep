using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHandler : MonoBehaviour {

    //choice of powerup (1-5)
    public int powerupSelect;

	// Use this for initialization
	void Start () {
        System.Random rand = new System.Random();
        powerupSelect = rand.Next(1, 6);
	}

    //detect a (semi) collision (no physics)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    //execute upon object death
    private void Die()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().receivePowerup(powerupSelect);

        Destroy(gameObject);
    }
}