using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

    public static int lives = 2;

    // Update is called once per frame
    void Update () {
        GetComponent<GUIText>().text = "Lives: " + lives;
    }

    public static void Reset()
    {
        lives = 2;
    }
}
