using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    public GameObject player;                  //player object (to give powerup)
    float angVel = 180f;        //angular velocity (to prevent automatic turning)

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");                  //find player object
    }
	
	// Update is called once per frame
	void Update () {
        //find direction to player, normalize
        Vector3 dirToPlayer = player.transform.position - transform.position;
        dirToPlayer.Normalize();

        //rotate in said direction (slowly)
        float zAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg - 90;
        Quaternion target = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, angVel * Time.deltaTime);
    }
}
