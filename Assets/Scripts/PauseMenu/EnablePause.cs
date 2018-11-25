using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePause : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

    }
}
