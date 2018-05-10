using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Power_Up : MonoBehaviour {

    public static Canvas pantalla;
    public TextAsset textFile;
    private static List<string> preguntas;
    private static List<bool> respuestas;
    private static int index;
    public static bool isAsking;

    private Animator anim;

    static Power_Up instance;

    public float jpd;

    public static float JPduration;

    public int type;

    private static Text qText;

    void Start()
    {
        pantalla = GameObject.Find("pantalla").GetComponent<Canvas>();
        qText = GameObject.Find("Question").GetComponent<Text>();
        anim = GetComponent<Animator>();
        instance = this;

        JPduration = jpd;

        pantalla.enabled = false;
        preguntas = new List<string>();
        respuestas = new List<bool>();
        processTextFile();

        isAsking = false;

        type = Random.Range(0, 10);

        if (type>5)
        {
            anim.SetBool("Life", true);
        } else anim.SetBool("JetPack", true);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            instance = this;
            LoadQuestion();
        }
    }

    void LoadQuestion()
    {
        if(isAsking == false)
        {
            isAsking = true;
            GameObject.Find("Pause").GetComponent<Pauser>().paused = true;
            index = Random.Range(0, preguntas.Count);
            qText.text = preguntas[index];
            Debug.Log(respuestas[index]);
            pantalla.enabled = true;
        }
    }

    public void callSelectedAnswer(bool button)
    {
        selectedAnswer(button);
    }

    static public void selectedAnswer(bool button)
    {
        Debug.Log("clicked");
        if (isAsking == true)
        {
            isAsking = false;
            Debug.Log(button);
            if (respuestas[index] == button)
            {
                instance.StartCoroutine(Wait(3f, true));
                qText.text = "Correcto!";
            }
            else
            {
                instance.StartCoroutine(Wait(3f, false));
                qText.text = "Incorrecto! -300";
                Score.score -= 300;
            }
        }
    }

    static IEnumerator Wait(float duration, bool powerup)
    {
        //This is a coroutine
        Debug.Log("started Timer");
        yield return new WaitForSecondsRealtime(duration);
        Debug.Log("disabled Screen");
        pantalla.enabled = false;
        instance.GetComponent<BoxCollider2D>().enabled = false;
        instance.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Pause").GetComponent<Pauser>().paused = false;
        if (powerup) PowerUP();
    }

    void processTextFile()
    {
        /* split the text file by newline characters */
        string[] lineArray = textFile.text.Split("\n"[0]);
        /* loop over each line in the file */
        foreach (string thisLine in lineArray)
        {
            /* split each line by | */
            string[] questionsStrings = thisLine.Split("|"[0]);
            /* load question and answer to arrays */
            preguntas.Add(questionsStrings[0]);
            respuestas.Add(bool.Parse(questionsStrings[1]));
        }
    }

    static void PowerUP()
    {
        Animator anim = instance.GetComponent<Animator>();
        if (anim.GetBool("Life"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleController>().oneUP();
        }
        else
        {
            instance.StartCoroutine(JetPack());
        }
    }


    static IEnumerator JetPack()
    {
        Debug.Log("jetpack enabled");
        GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleController>().jetpackActive=true;
        yield return new WaitForSecondsRealtime(JPduration);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleController>().jetpackActive=false;
        Debug.Log("jetpack Disabled");
    }
}