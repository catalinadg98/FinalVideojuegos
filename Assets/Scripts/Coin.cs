using UnityEngine;
using System.Collections;


public class Coin : MonoBehaviour
{
    //private static Score score;
    // Use this for initialization
    void Start()
    {
        //score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Score.score += 100;
        }

            
    }
}