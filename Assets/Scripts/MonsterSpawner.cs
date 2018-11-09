using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    GameObject monsterInstance;

    public float monsterDelay = 1f;
    private float timeToSpawn = 0f;

    // Use this for initialization
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            spawnMonster();
            timeToSpawn = monsterDelay;

        }
    }

    //spawns the player
    void spawnMonster()
    {
        monsterInstance = (GameObject)Instantiate(monsterPrefab, transform.position, Quaternion.identity);
    }
}

