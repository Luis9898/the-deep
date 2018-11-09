using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    Transform player;
    float angVel = 180f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) {
            GameObject go = GameObject.FindWithTag("Player");

            if(go != null)
                player = go.transform;
        }

        if (player == null)
            return;

        Vector3 dirToPlayer = player.position - transform.position;

        dirToPlayer.Normalize();
        float zAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg - 90;
        Quaternion target = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, angVel * Time.deltaTime);
    }
}
