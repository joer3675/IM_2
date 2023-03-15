using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class FindAObject : MonoBehaviour
{
    private string task;

    void Awake(){
	   task =  Task.getTask();
       if(task.Equals("Dammsuga", StringComparison.OrdinalIgnoreCase)){
            gameObject.GetComponent<TMP_Text>().text = "Hitta Dammsugaren";

       }else if (task.Equals("Mala", StringComparison.OrdinalIgnoreCase))
            {
            gameObject.GetComponent<TMP_Text>().text = "Hitta Penseln";
            }
        else{
            gameObject.GetComponent<TMP_Text>().text = "Hitta Vattenkannan";
        }
    }
}
