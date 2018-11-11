using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamageHandler : MonoBehaviour {

    public int health = 1;                          //health of object
    public GameObject powerupPrefab;                //used to create powerup (upon monster death)
    public GameObject urchinPrefab;                 //used to create urchin


    // Use this for initialization
    private void Start () {		
        //nop
	}
	

	// Update is called once per frame
	private void Update () {

        //check for health inside Update() to prevent sync issues
        if (health <= 0)
            Die();
    }


    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision) {

        //if not colliding colliding with terrain, deduct health.
        //NOTE: monsters cannot collide with other monsters (possibly change later)
        if (collision.gameObject.layer != 13) {
            health--;
        }
    }


    //generate powerup, delete monster
    private void Die() {

        //run randomizer. 1/10 chance to get powerup
        int lucky = (int)(Random.Range(1f, 19.999999f));

        //initalize powerup, at position of monster, looking straight up
        if (lucky <= 2)
            Instantiate(powerupPrefab, transform.position, Quaternion.identity);

        //chance to drop an urchin
        if(lucky == 3)
            Instantiate(urchinPrefab, transform.position, Quaternion.identity);

        //delete monster
        Destroy(gameObject);
    }
}
