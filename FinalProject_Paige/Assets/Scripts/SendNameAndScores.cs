using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SendNameAndScores : MonoBehaviour
{
    private InputField nameInput;
    private Text nameList;
    private string playerName;
    private Text score;
    private int scoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            GameObject introSceneInputField = GameObject.Find("NameInputField");
            nameInput = introSceneInputField.GetComponent<InputField>();

            /*
             * I used PlayerPrefs for the name saving between scenes, but I needed to delete the
             * name when the Intro scene was loaded again to give an empty Input field for the user
             * to fill in
             */
            PlayerPrefs.DeleteKey("playerName");
            nameInput.text = "";
        }


        if (SceneManager.GetActiveScene().name == "Game")
        {
            GameObject gameSceneScore = GameObject.Find("ScoreText");
            score = gameSceneScore.GetComponent<Text>();

            score.text = "0";
            scoreTotal = 0;

            GameObject gameSceneName = GameObject.Find("NameText");
            nameList = gameSceneName.GetComponent<Text>();

            /*
             * I wasn't sure how to pull from the database, so I just used Playerprefs
             * to carry names over into the next scene, they still update to database though
             */
            playerName = PlayerPrefs.GetString("playerName", "default");
            nameList.text = playerName;
        }
    }

    public void SaveData()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            playerName = nameInput.text;
            PlayerPrefs.SetString("playerName", playerName);
        }

        if (SceneManager.GetActiveScene().name == "Game")
        {
            playerName = nameList.text;
            scoreTotal = Convert.ToInt32(score.text);
        }

        StartCoroutine(connectToServer());
    }

    IEnumerator connectToServer()
    {
        string url = "http://localhost/PaigeT/addscore.php?";

        url += "name=" + playerName + "&score=" + scoreTotal;

        WWW www = new WWW(url);

        yield return www;
    }
}
