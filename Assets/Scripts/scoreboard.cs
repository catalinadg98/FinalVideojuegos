using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreboard {

    public int score;
    public string name;

    public scoreboard(string name)
    {
        this.score = Score.score;
        this.name = name;
    }
}
