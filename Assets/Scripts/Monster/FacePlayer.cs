using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    Transform player;           //transform of playerAI
    float angVel = 180f;        //angular velocity (to prevent automatic turning)

    // Use this for initialization
    void Start () {
		//nop
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) {
            //find player (in case deleted)
            GameObject go = GameObject.FindWithTag("Player");

            if(go != null)
                player = go.transform;
        }

        //if player still not found, end this iteration
        if (player == null)
            return;

        //find direction to player, normalize
        Vector3 dirToPlayer = player.position - transform.position;
        dirToPlayer.Normalize();

        //rotate in said direction (slowly)
        float zAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg - 90;
        Quaternion target = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, angVel * Time.deltaTime);
    }
}
