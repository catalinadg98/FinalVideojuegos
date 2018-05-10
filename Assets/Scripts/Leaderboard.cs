using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour {

    private InputField inputField;
    private GameObject leaderBoard;

    void Start()
    {
        leaderBoard = GameObject.Find("leaderBoard");
        //  If the instance is null, then we instanciate this GameObject
        //  and set it to not be destroyed when changing scenes
        if (leaderBoard == null)
        {
            leaderBoard = this.gameObject;
            leaderBoard.name = "leaderBoard";
            DontDestroyOnLoad(leaderBoard);
        }
        else
        //if the instance is not null, then we destroy this GameObject
        {
            Destroy(this.gameObject);
        }
    }

    public static List<scoreboard> leaderboard = new List<scoreboard>();

    public void showLeaderboard()
    {
        leaderboard.Sort((p1, p2) => p2.score.CompareTo(p1.score));
        string LBText = "Name \t Score\n";
        foreach(scoreboard temp in leaderboard)
        {
            LBText += temp.name + "\t" + temp.score+"\n";
        }
        GameObject.Find("leaderboardText").GetComponent<Text>().text = LBText;
    }

    public void Submit()
    {
        inputField = GameObject.FindObjectOfType<InputField>();
        leaderboard.Add(new scoreboard(inputField.text));
        SceneManager.LoadScene("LeaderBoard");
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LeaderBoard")
        {
            showLeaderboard();
        }
    }
}
