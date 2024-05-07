using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSize : MonoBehaviour
{
    public GameObject player;
    public Slider slider;
    public Text sliderText;
    private float size = 1.0f;

    public void changePlayerSize()
    {
        size = slider.value;
        sliderText.text = size.ToString();
        player.transform.localScale = new Vector3 (size, size, size);
    }
}
