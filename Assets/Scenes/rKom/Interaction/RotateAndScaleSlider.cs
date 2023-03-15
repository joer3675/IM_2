using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RotateAndScaleSlider : MonoBehaviour
{
  
    private float floaterScale;
    private float floaterRotation;

    //public Slider rotationSlider;
    //public Slider scaleSlider;

    private float angleSliderNumber;
    private float scaleSliderNumber;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        floaterScale = GameObject.FindGameObjectWithTag("ScaleSlider1").GetComponent<Slider>().value * 10f;
        floaterRotation = GameObject.FindGameObjectWithTag("RotationSlider1").GetComponent<Slider>().value * 360f;

        //floaterRotation = rotationSlider.value * 10f;
        this.transform.rotation = Quaternion.Euler(0, floaterRotation, 0);

        //scaleSliderNumber = scaleSlider.value;
        Vector3 scale = new Vector3(floaterScale, floaterScale, floaterScale);
        Debug.Log(scale);
        this.transform.localScale = scale;
    }
}
