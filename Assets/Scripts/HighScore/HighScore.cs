using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {


    public static int curHighScore = 0;
    Text highscore;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.GetInt("HIGHSCORE1") != null)
            curHighScore = PlayerPrefs.GetInt("HIGHSCORE1");

        highscore = GetComponent<Text> ();
	}

    // Shifts Highscore values down
    public static void ShiftHighScores(int index)
    {
        for(int i = 4; i >= index ; i--)
        {
            string curHSname = "HIGHSCORE" + i.ToString();
            string nexHSname = "HIGHSCORE" + (1+i).ToString();
            int tempHS = PlayerPrefs.GetInt(curHSname);
            PlayerPrefs.SetInt(nexHSname, tempHS);

        }
        
    }

	// Update is called once on death of player in PlayerDamageHandler.cs
	void Update () {
        highscore.text = "Highscore: " + curHighScore;
	}
}
