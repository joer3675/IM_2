using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeUISize : MonoBehaviour
{
    private GameObject soundUISettings;
    private GameObject[] soundObject;
    private GameObject[] textObject;
    private bool firstLoad;

    void Awake()
    {
        textObject = GameObject.FindGameObjectsWithTag("TextTag");
        soundObject = GameObject.FindGameObjectsWithTag("Sound");
        soundUISettings = GameObject.Find("Sound and UI Settings");
        if (!firstLoad && soundObject != null)
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Sound"))
            {
                gameObject.GetComponent<AudioSource>().volume = VolUIStatic.GetVol();
                firstLoad = true;
            }
            if (soundUISettings != null)
            {
                float _volume = VolUIStatic.GetVol();
                float _ui = VolUIStatic.GetUI();
                foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Sound"))
                {

                    gameObject.GetComponent<AudioSource>().volume = _volume;
                }
                foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("TextTag"))
                {
                    gameObject.GetComponent<TMP_Text>().fontSize = _ui;
                    Debug.Log(gameObject.GetComponent<TMP_Text>().fontSize);
                }
                // soundUISettings.GetComponent<SettingsSoundTextSize>().SetUI(soundUISettings.GetComponent<SettingsSoundTextSize>().GetUI());
            }

        }
    }
    public void VolumeChange()
    {
        float _volume = GameObject.Find("Volume Slide").gameObject.GetComponent<Slider>().value;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Sound"))
        {
            gameObject.GetComponent<AudioSource>().volume = GameObject.Find("Volume Slide").gameObject.GetComponent<Slider>().value;
            _volume = gameObject.GetComponent<AudioSource>().volume;

        }
        Debug.Log(" VASDA " + _volume);
        VolUIStatic.SetVolume(_volume);
    }
    public void UIChange()
    {
        float fontSize = GameObject.Find("UI Slide").gameObject.GetComponent<Slider>().value;
        foreach (GameObject gameObject in textObject)
        {
            //gameObject.GetComponent<Text>().fontSize = (int)GameObject.Find("UI Slide").gameObject.GetComponent<Slider>().value;
            //VolUIStatic.SetUI((int)GameObject.Find("UI Slide").gameObject.GetComponent<Slider>().value);
            gameObject.GetComponent<TMP_Text>().fontSize = (int)GameObject.Find("UI Slide").gameObject.GetComponent<Slider>().value;
            fontSize = gameObject.GetComponent<TMP_Text>().fontSize;
        }
        VolUIStatic.SetUI(fontSize);
        Debug.Log(fontSize);
    }

}
