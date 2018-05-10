using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalscore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<GUIText>().text = "Score: " + Score.score;
    }
}
