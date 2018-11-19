using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CurrentScore {
    private static int score;

    public static int Score {
        get {
            return score;
        }
        set {
            score = value;
        }
    }
}
