﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    // Use this for initialization
    private Score score;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Lives.lives > 0)
            {
                Lives.lives--;
                SceneManager.LoadScene("base 1");
            } else
            {
                SceneManager.LoadScene("gameover");
            }
        }
            
    }
}