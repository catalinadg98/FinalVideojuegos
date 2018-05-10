using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitScore : MonoBehaviour {

    private InputField inputField;

	// Use this for initialization
	void Start () {
        inputField = GameObject.FindObjectOfType<InputField>();
	}
	
	public void Submit()
    {
        Leaderboard.leaderboard.Add(new scoreboard(inputField.text));
    }
}
