using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetector : MonoBehaviour {

    public struct LevelDetect {
        public int level;               //level
        public int y;                   //y value corresponding to level
    }

    int[] levels = new int[] { 1, 2, 3, 4, 5 };
    int[] depths = new int[] { 0, -50, -100, -150, -200 };
    int pos;

    // Use this for initialization
    private void Start () {
        pos = 0;
    }
	
	// Update is called once per frame
	private void Update () {
		if(gameObject.transform.position.y < depths[pos]) {
            gameObject.GetComponent<Score>().level = levels[pos];
            pos++;

            Debug.Log("Now on Level: " +  levels[pos - 1]);
        }
	}
}
