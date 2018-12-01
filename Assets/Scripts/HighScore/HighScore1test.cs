using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore1test : MonoBehaviour {


    public static int curHighScore = 0;
    Text highscore;

	// Use this for initialization
	void Start ()
    {

        if (PlayerPrefs.GetInt("HIGHSCORE1") > 0)
            curHighScore = PlayerPrefs.GetInt("HIGHSCORE1");

        highscore = GetComponent<Text>();

    }

    public void placeScore(int index)
    {

        if (PlayerPrefs.GetInt("HIGHSCORE1") > 0)
            curHighScore = PlayerPrefs.GetInt("HIGHSCORE1");

        highscore = GetComponent<Text>();
    }

    public void newPlayerScore()
    {
        highscore.color = new Color(1f, 1f, .0f);
    }

	// Update is called once per frame
	void Update () {

        if (HighScore.curHighScore == 0)
            highscore.text = "";
        else
            highscore.text = "Highscore: " + curHighScore;
	}
}
