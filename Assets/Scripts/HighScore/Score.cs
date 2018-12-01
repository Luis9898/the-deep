using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


    public static int curScore = 0;
    Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        //GUI.Label(new Rect(25, 0, 100, 50), "Health: " + health);
        if (HighScore.curHighScore == 0)
            score.text = "Score: " + curScore;
        else
            score.text = "";
	}
}
