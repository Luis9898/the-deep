using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamageHandler : MonoBehaviour {

    public int health = 1;                          //health of object
    public GameObject powerupPrefab;                //used to create powerup (upon monster death)
    public GameObject urchinPrefab;                 //used to create urchin

    public GameObject monsterPrefabSlow;                //monster object, to later be modified for various types
    public GameObject monsterPrefabFast;                //monster object, to later be modified for various types
    GameObject monsterInstance;


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

        else if(gameObject.tag == "Urchin") {
            Die();
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

        //if urchin, spawn more monsters (depending on scale)
        if(gameObject.tag == "Urchin") {
            int spawnNum = 2*(int)(gameObject.transform.localScale.x);

            for (int i = 0; i < spawnNum; i++) {
                int monstertype = (int)(Random.Range(1f, 2.999999f));

                //if 1, spawn the fast (but weak) monster
                if (monstertype == 1) {
                    monsterInstance = (GameObject)Instantiate(monsterPrefabFast, transform.position, Quaternion.identity);
                    monsterInstance.transform.rotation = Quaternion.LookRotation(Vector3.forward, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                }

                //if 2, spawn the slow (but strong) monster)
                else {
                    monsterInstance = (GameObject)Instantiate(monsterPrefabSlow, transform.position, Quaternion.identity);
                    monsterInstance.transform.rotation = Quaternion.LookRotation(Vector3.forward, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                }
            }
        }

        //delete monster
        Destroy(gameObject);

        //update player score
        GameObject.FindWithTag("Player").GetComponent<Score>().scoreBuffer++;
    }
}
