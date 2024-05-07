using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestScript
{
    //Variables used for tests
    private string testName = "Trevor";
    private string playerTestName;
    private InputField nameInput;
    private Text nameList;

    [UnityTest]
    public IEnumerator _1PlayButtonStartsPlay()
    {
        SceneManager.LoadScene("Intro");

        yield return new WaitForSeconds(2.0f);

        GameObject play = GameObject.Find("PlayButton");

        play.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual("Game", SceneManager.GetActiveScene().name, "Game did not load");
    }

    [UnityTest]
    public IEnumerator _2StopButtonStopsPlay()
    {
        SceneManager.LoadScene("Game");

        yield return new WaitForSeconds(2.0f);

        GameObject stop = GameObject.Find("StopButton");

        stop.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name, "Exit did not load");
    }

    [UnityTest]
    public IEnumerator _3PlayAgainButtonRestartsGame()
    {
        SceneManager.LoadScene("Exit");

        yield return new WaitForSeconds(2.0f);

        GameObject stop = GameObject.Find("PlayAgainButton");

        stop.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name, "Intro did not load");
    }

    [UnityTest]
    public IEnumerator _4PlayerNameShownInGame()
    {
        SceneManager.LoadScene("Game");

        yield return new WaitForSeconds(2.0f);

        GameObject name = GameObject.Find("NameText");
        Text nameText = name.GetComponent<Text>();

        nameText.text = "Trevor";

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual(testName, nameText.text);
    }

    [UnityTest]
    public IEnumerator _5DestroyingFiveObjectsStopsPlay()
    {
        SceneManager.LoadScene("Game");

        yield return new WaitForSeconds(2.0f);

        GameObject player = GameObject.Find("Player");
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");

        yield return new WaitForSeconds(1.0f);

        Vector3 moveObjects = new Vector3(0, 3, 0);

        foreach(GameObject target in targets)
        {
            target.transform.localPosition = moveObjects;
        }

        yield return new WaitForSeconds(1.0f);

        player.transform.position = new Vector3(0, 3, 0);

        yield return new WaitForSeconds(1.0f);

        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name, "Exit did not load");
    }

    [UnityTest]
    public IEnumerator _6NameFromIntroShowsInGameScene()
    {
        SceneManager.LoadScene("Intro");

        yield return new WaitForSeconds(2.0f);

        GameObject introSceneInputField = GameObject.Find("NameInputField");
        GameObject play = GameObject.Find("PlayButton");
        nameInput = introSceneInputField.GetComponent<InputField>();

        nameInput.text = testName;
        playerTestName = nameInput.text;

        play.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        yield return new WaitForSeconds(2.0f);

        GameObject gameSceneName = GameObject.Find("NameText");
        nameList = gameSceneName.GetComponent<Text>();

        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(nameList.text, playerTestName);
    }


}
