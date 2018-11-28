using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    public GameObject player;                  //player object (to give powerup)
    float angVel = 180f;        //angular velocity (to prevent automatic turning)
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");                  //find player object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        //find direction to player, normalize
        Vector3 dirToPlayer = player.transform.position - transform.position;
        dirToPlayer.Normalize();

        //rotate in said direction (slowly)
        float zAngle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg - 90;
        rb.MoveRotation(zAngle);

        if (Vector3.Distance(transform.position, player.transform.position) > 25)
            GetComponent<MonsterDamageHandler>().health = 0;
    }
}
