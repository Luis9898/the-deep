using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour {


    public static int curScore = 0;
    Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + curScore;
	}
}
