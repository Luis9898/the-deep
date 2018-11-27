using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    GameObject HighscoreText;
    public static int curHighScore = 0;
    public static int newHS = 0;
    public Text highscore;

	// Use this for initialization
	void Start () {
        //HighscoreText.SetActive(false);
        highscore = GetComponent<Text> ();
    }

    public static void checkHS()
    {
        if (PlayerPrefs.GetInt("HIGHSCORE1") < curHighScore)
        {
            HighScore.ShiftHighScores(1);
            PlayerPrefs.SetInt("HIGHSCORE1", curHighScore);
            newHS = 1;
        }
        else if (PlayerPrefs.GetInt("HIGHSCORE2") < curHighScore)
        {
            HighScore.ShiftHighScores(2);
            PlayerPrefs.SetInt("HIGHSCORE2", curHighScore);
            newHS = 2;
        }
        else if (PlayerPrefs.GetInt("HIGHSCORE3") < curHighScore)
        {
            HighScore.ShiftHighScores(3);
            PlayerPrefs.SetInt("HIGHSCORE3", curHighScore);
            newHS = 3;
        }
        else if (PlayerPrefs.GetInt("HIGHSCORE4") < curHighScore)
        {
            HighScore.ShiftHighScores(4);
            PlayerPrefs.SetInt("HIGHSCORE4", curHighScore);
            newHS = 4;
        }
        else if (PlayerPrefs.GetInt("HIGHSCORE5") < curHighScore) {
            PlayerPrefs.SetInt("HIGHSCORE5", curHighScore);
            newHS = 5;
        }

        /*if (PlayerPrefs.GetInt("HIGHSCORE5") > 30) // Testing ResetHighScore() for errors - works currently
        {
            ResetHighScores();
        }*/

    }

    // Shifts Highscore values down
    public static void ShiftHighScores(int index)
    {
        for (int i = 4; i >= index; i--)
        {
            string curHSname = "HIGHSCORE" + i.ToString();
            string nexHSname = "HIGHSCORE" + (1 + i).ToString();
            int tempHS = PlayerPrefs.GetInt(curHSname);
            PlayerPrefs.SetInt(nexHSname, tempHS);

        }

    }

    // Resets all Highscore values to 0 - not yet implimented completely ------------------------------------------------------------------------------------------------------------ 
   /* public static void ResetHighScores()
    {
        for (int i = 1; i <= 5; i++)
        {
            string curHSname = "HIGHSCORE" + i.ToString();
            PlayerPrefs.SetInt(curHSname, 0);

        }

    } */ /*----------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        // Update is called once on death of player in PlayerDamageHandler.cs
        void Update ()
    {
        if (curHighScore == 0)
            highscore.text = "";
        else
            highscore.text = "Score: " + curHighScore;
	}

    //displayed highscores
    private void OnGUI()
    {
        GUIStyle HSGUI = new GUIStyle();
        GUIStyle HSGUIshadow = new GUIStyle();
        int yCoordinate = 100;
        int xCoordinate = 500;
        string highscoreText = "Score: " + curHighScore;
        
        HSGUI.fontSize = 33;
        HSGUIshadow.fontSize = 33;

        HSGUIshadow.normal.textColor = Color.black;

        HSGUI.normal.textColor = new Color(1f, 1f, 0f);
        GUI.Label(new Rect(152, 200, 300, 50), highscoreText, HSGUIshadow);
        GUI.Label(new Rect(148, 200, 300, 50), highscoreText, HSGUIshadow);
        GUI.Label(new Rect(150, 202, 300, 50), highscoreText, HSGUIshadow);
        GUI.Label(new Rect(150, 198, 300, 50), highscoreText, HSGUIshadow);
        GUI.Label(new Rect(150, 200, 300, 50), highscoreText, HSGUI);


        for (int i = 1; i <= 5; i++)
        {
            if(i == newHS)
                HSGUI.normal.textColor = new Color(1f, 1f, 0f);
            else
                HSGUI.normal.textColor = new Color(1f, .5f, 0f);

            string placement = "";

            if (i == 1)
                placement = "1st place: " + PlayerPrefs.GetInt("HIGHSCORE1");
            else if (i == 2)
                placement = "2nd place: " + PlayerPrefs.GetInt("HIGHSCORE2");
            else if (i == 3)
                placement = "3rd place: " + PlayerPrefs.GetInt("HIGHSCORE3");
            else if (i == 4)
                placement = "4th place: " + PlayerPrefs.GetInt("HIGHSCORE4");
            else if (i == 5)
                placement = "5th place: " + PlayerPrefs.GetInt("HIGHSCORE5");

            GUI.Label(new Rect(xCoordinate-2, yCoordinate, 300, 50), placement, HSGUIshadow);
            GUI.Label(new Rect(xCoordinate+2, yCoordinate, 300, 50), placement, HSGUIshadow);
            GUI.Label(new Rect(xCoordinate, yCoordinate-2, 300, 50), placement, HSGUIshadow);
            GUI.Label(new Rect(xCoordinate, yCoordinate+2, 300, 50), placement, HSGUIshadow);
            GUI.Label(new Rect(xCoordinate, yCoordinate, 300, 50), placement, HSGUI);
            yCoordinate += 50;
        }
    }

}