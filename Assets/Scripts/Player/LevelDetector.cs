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
    }

    // Update is called once per frame
    private void Update() {
        if (gameObject.transform.position.y < depths[pos]) {
            CurrentScore.Level = levels[pos];
            pos++;

            Debug.Log("Now on Level: " + CurrentScore.Level);
        }

        if (gameObject.transform.position.y < 10 && CurrentScore.Treasure == 1) {
            gameObject.GetComponent<PlayerDamageHandler>().health = 0;
        }
    }

    private void OnGUI() {

        GUIStyle HealthGUI = new GUIStyle();

        HealthGUI.fontSize = 20;

        HealthGUI.normal.textColor = Color.black;

        GUI.Label(new Rect(12, 65, 100, 30), "Level: " + CurrentScore.Level, HealthGUI);
        GUI.Label(new Rect(8, 65, 100, 30), "Level: " + CurrentScore.Level, HealthGUI);
        GUI.Label(new Rect(10, 63, 100, 30), "Level: " + CurrentScore.Level, HealthGUI);
        GUI.Label(new Rect(10, 67, 100, 30), "Level: " + CurrentScore.Level, HealthGUI);

        HealthGUI.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 65, 100, 30), "Level: " + CurrentScore.Level, HealthGUI);
    }
}
