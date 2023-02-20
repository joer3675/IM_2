using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    public string task; 
    public GameObject prefabObject;
    private bool hasPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void onPress() {
        if (!hasPressed)
        {
            prefabObject.transform.GetChild(0).gameObject.SetActive(true);
            prefabObject.transform.GetChild(1).gameObject.SetActive(false);
            hasPressed = true;
        }
        else
        {
            prefabObject.transform.GetChild(0).gameObject.SetActive(false);
            prefabObject.transform.GetChild(1).gameObject.SetActive(true);
            hasPressed = false;
        }
      
    }
}
