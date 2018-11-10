using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SPAWNS all monsters at specified location. Monsters generated randomly to dictate which type is chosen (not currently implemented)
public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;                //monster object, to later be modified for various types
    //GameObject monsterInstance;

    public float monsterDelay = 1f;
    private float timeToSpawn = 0f;

    // Use this for initialization
    void Start()
    {
        //nop
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
    void spawnMonster()
    {
        Instantiate(monsterPrefab, transform.position, Quaternion.identity);
    }
}

