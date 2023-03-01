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

 
    public TextMeshProUGUI ToggleButtonText;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        ToggleButtonText.text = "Disable";


    }

    public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";


        if (planeManager.enabled)
        {

            toggleButtonMessage = "Disable";
            SetAllPlanesActive(true);
        }
        else
        {
            toggleButtonMessage = "Enable";
            SetAllPlanesActive(false);
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
}

