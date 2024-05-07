using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColor : MonoBehaviour
{
    public Dropdown colorDropdown;
    public Text colorText;
    public GameObject player;

    void Start()
    {
        player.GetComponent<Renderer>().material.color = Color.green;
    }

    public void chooseColor()
    {
        switch(colorDropdown.value)
        {
            case 1:
                colorText.text = colorDropdown.options[1].text;
                player.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                colorText.text = colorDropdown.options[2].text;
                player.GetComponent<Renderer>().material.color = Color.black;
                break;
            default:
                colorText.text = colorDropdown.options[0].text;
                player.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
    }
}
