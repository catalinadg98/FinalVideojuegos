using System.Threading;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;		// Requiered to switch scenes


public class LevelManager : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            foreach (ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
            {
                p.Play();
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

    }

}