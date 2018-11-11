using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinGrow : MonoBehaviour {

    float growspeed = .1f;
    float scale = 1.0f;


    // Use this for initialization
    private void Start () {
        //nop
    }
	
	// Update is called once per frame
	private void Update () {
        scale += growspeed * Time.deltaTime;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
