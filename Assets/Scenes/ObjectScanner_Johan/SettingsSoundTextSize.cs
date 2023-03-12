using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsSoundTextSize : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameObjectPanel;



    void Awake()
    {
        gameObjectPanel = GameObject.Find("Settings");
        DontDestroyOnLoad(this.gameObject);
    }

    public void onButtonPressed()
    {

        GameObject panel = gameObjectPanel.transform.GetChild(1).gameObject;
        panel.SetActive(true);
        GameObject panelOne = panel.transform.GetChild(0).gameObject;

        panelOne.transform.GetChild(1).gameObject.GetComponent<Slider>().value = VolUIStatic.GetVol();
        panelOne.transform.GetChild(2).gameObject.GetComponent<Slider>().value = VolUIStatic.GetUI();
        Debug.Log(VolUIStatic.GetUI());
        Debug.Log(VolUIStatic.GetVol());

    }
    public void onExitButtonPressed()
    {

        gameObjectPanel.transform.GetChild(1).gameObject.SetActive(false);

    }

}
