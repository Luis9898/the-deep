using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoHandler : MonoBehaviour {

    //detect a collision (use rigid body, no triggers)
    private void OnCollisionEnter2D(Collision2D collision) {
        collision.gameObject.GetComponent<PlayerDamageHandler>().health--; ;
    }
}
