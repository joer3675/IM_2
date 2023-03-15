using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class FindAObject : MonoBehaviour
{
    private string task;
    public Sprite[] images;

    void Awake(){
	   task =  Task.getTask();
       if(task.Equals("Dammsuga", StringComparison.OrdinalIgnoreCase)){
            //gameObject.GetComponent<TMP_Text>().text = "Hitta dammsugaren";
            gameObject.GetComponent<Image>().sprite = images[0];

       }else if (task.Equals("Mala", StringComparison.OrdinalIgnoreCase))
            {
           // gameObject.GetComponent<TMP_Text>().text = "Hitta penseln";
            gameObject.GetComponent<Image>().sprite = images[1];
            }
        else{
            gameObject.GetComponent<Image>().sprite = images[2];
            //gameObject.GetComponent<TMP_Text>().text = "Hitta vattenkannan";
        }
    }
}
