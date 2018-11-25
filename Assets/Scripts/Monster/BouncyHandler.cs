using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyHandler : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(transform.up * speed);
        rb.MoveRotation(rb.rotation + 5);

        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }
}
