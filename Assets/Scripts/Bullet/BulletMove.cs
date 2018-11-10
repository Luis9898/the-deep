using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bullet always moves in straight line from which it started
public class BulletMove : MonoBehaviour {

    public float speed = .08f;

    //private float screen_ratio;
    //private float width_ortho;

    private void Start() {
        //get screen width and height (NOT currently used)
        //screen_ratio = 1.0f * Screen.width / Screen.height;
        //width_ortho = screen_ratio * Camera.main.orthographicSize;
    }

    //use transform.Translate to use the rigidbody (NOT transform.position)
    private void Update() {
        transform.Translate(0, speed, 0);
    }
}
