using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyCount {
    private static int keys;

    public static int Keys {
        get {
            return keys;
        }
        set {
            keys = value;
        }
    }
}
