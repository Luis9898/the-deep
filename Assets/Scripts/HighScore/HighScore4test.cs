using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore4test : MonoBehaviour {


    public static int curHighScore = 0;
    Text highscore;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("HIGHSCORE4") != null)
            curHighScore = PlayerPrefs.GetInt("HIGHSCORE4");

        highscore = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        highscore.text = "Highscore: " + curHighScore;
	}
}
