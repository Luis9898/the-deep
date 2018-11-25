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
        GUI.Label(new Rect(20, Screen.height - 50, 128, 128), "Level: " + CurrentScore.Level);
        GUI.Label(new Rect(20, Screen.height - 25, 128, 128), "Score: " + CurrentScore.Score);
    }
}
