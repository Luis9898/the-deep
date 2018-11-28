using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {

        //if collision with player
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10) {
            //disable player's ability to shoot
            collision.gameObject.GetComponent<PlayerShoot>().enabled = false;
            CurrentScore.Treasure = 1;

            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
