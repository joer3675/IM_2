using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{
    //public string task;
    public GameObject gameobject;


    private int pressNumber = 0;
    private GameObject[] objectsPrefabList;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Start()
    {

        //gameobject = GameObject.FindGameObjectWithTag("prefabtag");
        if (Task.getTask().Equals("Dammsuga"))
        {

            //foreach (GameObject gameobject in objectsPrefabList)
            //{
            gameobject.transform.GetChild(0).gameObject.SetActive(true);
            gameobject.transform.GetChild(1).gameObject.SetActive(false);
            gameobject.transform.GetChild(2).gameObject.SetActive(false);
            //GameObject.FindGameObjectWithTag("prefabtag").transform.GetChild(0).gameObject.SetActive(true);
            //GameObject.FindGameObjectWithTag("prefabtag").transform.GetChild(1).gameObject.SetActive(false);

            //}
            pressNumber++;

            //prefabObject.transform.GetChild(0).gameObject.SetActive(true);
            //prefabObject.transform.GetChild(1).gameObject.SetActive(false);

        }
        else if (Task.getTask().Equals("Mala"))
        {

            //    foreach (GameObject gameobject in objectsPrefabList)
            //{
            gameobject.transform.GetChild(0).gameObject.SetActive(false);
            gameobject.transform.GetChild(1).gameObject.SetActive(true);
            gameobject.transform.GetChild(2).gameObject.SetActive(false);
            //GameObject.FindGameObjectWithTag("prefabtag").transform.GetChild(0).gameObject.SetActive(false);
            //GameObject.FindGameObjectWithTag("prefabtag").transform.GetChild(1).gameObject.SetActive(true);

            //}
            pressNumber++;

            //prefabObject.transform.GetChild(0).gameObject.SetActive(false);
            //prefabObject.transform.GetChild(1).gameObject.SetActive(true);

        }
        else if (Task.getTask().Equals("Vattna"))
        {
            //foreach (GameObject gameobject in objectsPrefabList)
            //{
            gameobject.transform.GetChild(0).gameObject.SetActive(false);
            gameobject.transform.GetChild(1).gameObject.SetActive(false);
            gameobject.transform.GetChild(2).gameObject.SetActive(true);
            //}
            pressNumber = 0;

        }


    }
}
