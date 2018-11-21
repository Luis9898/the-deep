using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHandler : MonoBehaviour {

    Rigidbody2D rb;
    int force = 200;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void onCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.layer == 12) {
            rb.AddForce(collision.gameObject.transform.rotation.eulerAngles * force);
        }
    }
}
