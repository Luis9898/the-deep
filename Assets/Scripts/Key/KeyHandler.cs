using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision) {

        //if key collides with player
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10) {
            //update key count
            KeyCount.Keys++;
            Debug.Log(KeyCount.Keys);
            //kys
            Die();
        }
    }

    //destroy key
    private void Die() {
        Destroy(gameObject);
    }
}
