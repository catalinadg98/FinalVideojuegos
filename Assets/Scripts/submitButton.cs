using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class submitButton : MonoBehaviour {

    Leaderboard leaderboard;

	// Use this for initialization
	void Start () {
        leaderboard = GameObject.FindObjectOfType<Leaderboard>();
        Debug.Log("add Listener");
        GameObject.Find("submit").GetComponent<Button>().onClick.AddListener(leaderboard.Submit);
    }
}
