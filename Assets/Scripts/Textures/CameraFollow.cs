using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    GameObject player;                  //player object (to give powerup)
    public float cameraHeight = 20.0f;

    private void Start() {
        player = GameObject.FindWithTag("Player");                  //find player object
    }
    private void Update() {
        Vector3 pos = player.transform.position;
        pos.z = cameraHeight;
        gameObject.transform.position = pos;
    }
}
