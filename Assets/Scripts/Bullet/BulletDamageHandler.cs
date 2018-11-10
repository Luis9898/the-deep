using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageHandler : MonoBehaviour {

    public int health = 1;                          //health of object

    void Start () {
		//nop
	}
	
	// Update is called once per frame
	void Update () {

        //check for health inside Update() to prevent sync issues
        if (health <= 0)
            Die();
    }

    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision) {
        health--;
    }

    //execute upon object death
    private void Die() {
        Destroy(gameObject);
    }
}
