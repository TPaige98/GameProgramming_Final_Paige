using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTop10 : MonoBehaviour
{
    private string top10URL = "http://localhost/PaigeT/displaytopscores.php";

    void Start()
    {
        StartCoroutine(GetDatabaseScores());
    }

    IEnumerator GetDatabaseScores()
    {
        WWW www = new WWW(top10URL);

        yield return www;

        string result = www.text;

        GameObject.Find("HighScoresText").GetComponent<Text>().text = result;
    }
}
