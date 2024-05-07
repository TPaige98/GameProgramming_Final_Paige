using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiTraversal : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene("Intro");
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void loadExit()
    {
        SceneManager.LoadScene("Exit");
    }

    public void quitGame()
    {
        Debug.Log("Quitting game");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
