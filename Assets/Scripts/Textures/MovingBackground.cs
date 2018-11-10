using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {

    private float time_flow = 0;
    private float rotate_dir = .5f;

    //give background some REALISM
    void Update() {

        //change rotate direction every 5 seconds
        time_flow += Time.deltaTime;
        if(time_flow > 5)
        {
            time_flow = 0;
            rotate_dir *= -1;
        }
        transform.Rotate(new Vector3(0, 0, rotate_dir) * Time.deltaTime);
    }
}
