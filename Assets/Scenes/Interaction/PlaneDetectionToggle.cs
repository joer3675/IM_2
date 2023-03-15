using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

[RequireComponent(typeof(ARPlaneManager))]

public class PlaneDetectionToggle : MonoBehaviour
{
    private ARPlaneManager planeManager;
    

    [SerializeField]
    private GameObject buttonObject;

 
    public TextMeshProUGUI ToggleButtonText;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        ToggleButtonText.text = "Dölj";
        buttonObject.GetComponent<Image>().color = new Color32(170, 170, 170, 255);


    }

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";


        if (planeManager.enabled)
        {

            toggleButtonMessage = "Dölj";
            SetAllPlanesActive(true);
            buttonObject.GetComponent<Image>().color = new Color32(170, 170, 170, 255);
        }
        else
        {
            toggleButtonMessage = "Visa";
            SetAllPlanesActive(false);
            buttonObject.GetComponent<Image>().color = new Color32(255,250,250, 255);
        }

        ToggleButtonText.text = toggleButtonMessage;
        
    }

    private void SetAllPlanesActive(bool value)
    {
        
        foreach( var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

    public void SetEnable(){
        {
            planeManager.enabled = true;

        }
    }
}

