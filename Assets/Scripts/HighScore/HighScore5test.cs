using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore5test : MonoBehaviour {


    public static int curHighScore = 0;
    Text highscore;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("HIGHSCORE5") > 0)
            curHighScore = PlayerPrefs.GetInt("HIGHSCORE5");

        highscore = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (HighScore.curHighScore == 0)
            highscore.text = "";
        else
            highscore.text = "Highscore: " + curHighScore;
    }
}
