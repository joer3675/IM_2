using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class VolUIStatic
{
    static float volumeSetting = 1f;
    static float _uISize = 15f;
    public static float GetUI()
    {
        return _uISize;
    }
    public static float GetVol()
    {
        return volumeSetting;
    }
    public static void SetVolume(float value)
    {
        volumeSetting = value;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Sound"))
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>().volume = value;
        }
    }
    public static void SetUI(float value)
    {
        _uISize = value;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("TextTag"))
        {
            //gameObject.GetComponent<Text>().fontSize = (int)GameObject.Find("UI Slide").gameObject.GetComponent<Slider>().value;
            gameObject.GetComponent<TMP_Text>().fontSize = value;
        }
    }
}
