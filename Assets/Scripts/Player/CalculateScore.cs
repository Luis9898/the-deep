using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScore : MonoBehaviour {

    public int scoreBuffer;             //buffered score

	// Use this for initialization
	void Start () {
        CurrentScore.Score = 0;
        CurrentScore.Level = 1;
        scoreBuffer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreBuffer *= (int)(Mathf.Pow(10, CurrentScore.Level - 1));
        CurrentScore.Score += scoreBuffer;
        scoreBuffer = 0;
	}

    //displayed score on upper left corner - added 11/26/2018
    private void OnGUI()
    {
        GUIStyle ScoreGUI = new GUIStyle();


        ScoreGUI = new GUIStyle();
        int yCoordinate = 85;
        int xCoordinate = 10;

        ScoreGUI.fontSize = 80;
        ScoreGUI.font = Resources.Load<Font>("TheJewishBitmap");

        ScoreGUI.normal.textColor = Color.black;

        GUI.Label(new Rect(xCoordinate + 2, yCoordinate, 100, 40), "Score: " + CurrentScore.Score, ScoreGUI);
        GUI.Label(new Rect(xCoordinate - 2, yCoordinate, 100, 40), "Score: " + CurrentScore.Score, ScoreGUI);
        GUI.Label(new Rect(xCoordinate, yCoordinate + 2, 100, 40), "Score: " + CurrentScore.Score, ScoreGUI);
        GUI.Label(new Rect(xCoordinate, yCoordinate - 2, 100, 40), "Score: " + CurrentScore.Score, ScoreGUI);

        ScoreGUI.normal.textColor = Color.white;

        GUI.Label(new Rect(xCoordinate, yCoordinate, 100, 40), "Score: " + CurrentScore.Score, ScoreGUI);

    }
}
