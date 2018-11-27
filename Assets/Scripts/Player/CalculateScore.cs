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
        scoreBuffer *= CurrentScore.Level;
        CurrentScore.Score += scoreBuffer;
        scoreBuffer = 0;
	}

    //displayed score on upper left corner - added 11/26/2018
    private void OnGUI()
    {

        GUIStyle HealthGUI = new GUIStyle();

        HealthGUI.fontSize = 20;

        HealthGUI.normal.textColor = Color.black;

        GUI.Label(new Rect(12, 40, 100, 30), "Score: " + CurrentScore.Score, HealthGUI);
        GUI.Label(new Rect(8, 40, 100, 30), "Score: " + CurrentScore.Score, HealthGUI);
        GUI.Label(new Rect(10, 38, 100, 30), "Score: " + CurrentScore.Score, HealthGUI);
        GUI.Label(new Rect(10, 42, 100, 30), "Score: " + CurrentScore.Score, HealthGUI);

        HealthGUI.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 40, 100, 30), "Score: " + CurrentScore.Score, HealthGUI);
    }
}
