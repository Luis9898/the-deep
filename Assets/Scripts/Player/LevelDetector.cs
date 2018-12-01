using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetector : MonoBehaviour {

    int[] levels = new int[] { 1, 2, 3, 4, 5 };
    int[] depths = new int[] { 0, -50, -100, -150, -200 };
    int pos;

    // Use this for initialization
    private void Start () {
        pos = 0;
        CurrentScore.Score = 0;
        CurrentScore.Level = 1;
        CurrentScore.Treasure = 0;
        KeyCount.Keys = 0;
    }

    // Update is called once per frame
    private void Update() {
        if (gameObject.transform.position.y < depths[pos]) {
            //CurrentScore.Level = levels[pos];
            //pos++;

            //Debug.Log("Now on Level: " + CurrentScore.Level);
        }

        if (gameObject.transform.position.y > -5 && CurrentScore.Treasure == 1) {
            CurrentScore.Score += 50000;
            gameObject.GetComponent<PlayerDamageHandler>().health = 0;

        }
    }

    private void OnGUI() {


        GUIStyle LevelGUI = new GUIStyle();


        LevelGUI = new GUIStyle();
        int yCoordinate = 160;
        int xCoordinate = 10;

        LevelGUI.fontSize = 80;
        LevelGUI.font = Resources.Load<Font>("TheJewishBitmap");

        LevelGUI.normal.textColor = Color.black;

        GUI.Label(new Rect(xCoordinate + 2, yCoordinate, 100, 40), "Level: " + CurrentScore.Level, LevelGUI);
        GUI.Label(new Rect(xCoordinate - 2, yCoordinate, 100, 40), "Level: " + CurrentScore.Level, LevelGUI);
        GUI.Label(new Rect(xCoordinate, yCoordinate + 2, 100, 40), "Level: " + CurrentScore.Level, LevelGUI);
        GUI.Label(new Rect(xCoordinate, yCoordinate - 2, 100, 40), "Level: " + CurrentScore.Level, LevelGUI);

        LevelGUI.normal.textColor = Color.white;

        GUI.Label(new Rect(xCoordinate, yCoordinate, 100, 40), "Level: " + CurrentScore.Level, LevelGUI);

    }
}
