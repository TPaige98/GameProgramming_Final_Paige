using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyTargets : MonoBehaviour
{
    private static int targetsDestroyed;
    public Text score;

    public SendNameAndScores saveScore;

    // Start is called before the first frame update
    void Start()
    {
        targetsDestroyed = 0;
        score.text = "0";   
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            targetsDestroyed++;
            score.text = targetsDestroyed.ToString();
            Destroy(gameObject);

            if(score.text == "5")
            {
                saveScore.SaveData();
                SceneManager.LoadScene("Exit");
            }
        }
    }
}
