using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pic_Text : MonoBehaviour
{

    private bool hasChanged;
    void Update()
    {

        if (Pictogram.getPictogramState())
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);


        }
    }

}
