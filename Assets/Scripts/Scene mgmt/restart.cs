using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
public void Restart()
    {
        SceneManager.LoadScene("base 1");
        Score.score = 0;
        Lives.lives = 2;
    }

public void Win()
    {
        SceneManager.LoadScene("win");
    }
    public void Menu()
    {
        SceneManager.LoadScene("mainmenu");
        Score.score = 0;
    }

    public void exit()
    {
        Application.Quit();
    }
}
