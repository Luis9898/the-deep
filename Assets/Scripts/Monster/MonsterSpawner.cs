using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SPAWNS all monsters at specified location. Monsters generated randomly to dictate which type is chosen (not currently implemented)
public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefabSlow;                //monster object, to later be modified for various types
    public GameObject monsterPrefabFast;                //monster object, to later be modified for various types
    GameObject monsterInstance;
    Transform player;

    public float monsterDelay = 1f;
    private float timeToSpawn = 0f;

    // Use this for initialization
    void Start()
    {
        //nop
        GameObject go = GameObject.FindWithTag("Player");

        if (go != null)
            player = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn monster every (timeToSpawn) time (public variable)
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            spawnMonster();
            timeToSpawn = monsterDelay;

        }
    }

    //spawns the monster
    public void spawnMonster()
    {
        int monstertype = (int)(Random.Range(1f, 2.999999f));

        //if 1, spawn the fast (but weak) monster
        if(monstertype == 1) {
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

