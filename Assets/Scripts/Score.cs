using UnityEngine;
using System.Collections;


public class Score : MonoBehaviour
{


    private PlayerControl playerControl;    // Reference to the player control script.
    private int previousScore = 0;           // The score in the previous frame.
    public static int score = 0;

    void Awake()
    {
        // Setting up the reference.
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        // Set the score text.
        GetComponent<GUIText>().text = "Score: " + score;

        // Set the previous score to this frame's score.
        previousScore = score;
    }

    public static void Reset()
    {
        score = 0;
    }

    }