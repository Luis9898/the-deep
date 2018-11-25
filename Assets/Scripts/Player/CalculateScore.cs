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
}
