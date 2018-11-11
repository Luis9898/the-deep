using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
        spawnPlayer();
	}

    //spawns the player
    void spawnPlayer() {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
