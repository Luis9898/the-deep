using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 mouse_pos;
    private Vector3 mouse_dir;
    public float maxSpeed = 5;
    Rigidbody2D rb;
    int force = 40;

    public float speedupTimerMax = 10f;               //max time for speedup
    public float speedupTimer = 0f;                  //time remaining for speedup

    //private float screen_ratio;
    //private float width_ortho;

	// Use this for initialization
	void Start () {
        //get screen width and height. NOT currently used
        //screen_ratio = 1.0f * Screen.width / Screen.height;
        //width_ortho = screen_ratio * Camera.main.orthographicSize;

        //get rigidbody, add drag to prevent superspeed
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 1 ;
    }

    // Using rigidbody to give a more 'underwater-like' movement
    void FixedUpdate()
    {
        Touch touch = Input.GetTouch(0);
        mouse_pos = Camera.main.ScreenToWorldPoint(touch.position);

        //mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_dir = mouse_pos - gameObject.transform.position;
        mouse_pos.z = 0.0f;
        mouse_dir = mouse_dir.normalized;

        //if right mouse button held down
        if(Input.touchCount > 0)
        //if (Input.GetMouseButton(1))
        {
            rb.AddForce(mouse_dir * force);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mouse_pos - transform.position);
        }

        //set max speed (in case surpassed)
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    private void Update()
    {
        if (speedupTimer > 0)
        {
            force = 60;
            speedupTimer -= Time.deltaTime;
        }

        else
            force = 40;
    }
}
