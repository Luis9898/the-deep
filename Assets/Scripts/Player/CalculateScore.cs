using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScore : MonoBehaviour {

    public int score;                   //player's current score
    public int scoreBuffer;             //buffered score
    public int level;                   //current level

	// Use this for initialization
	void Start () {
        score = 0;
        level = 1;
        scoreBuffer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreBuffer *= level;
        score += scoreBuffer;
        scoreBuffer = 0;
	}
}
