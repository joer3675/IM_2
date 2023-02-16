using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


namespace UnityEngine.XR.ARFoundation
{
    public class ImagePicker : MonoBehaviour
    {
        // Start is called before the first frame update

        public Sprite[] images;

        ARTrackedImage aRTrackedImage;
        IntPtr myIntPtr;
        ARSubsystems.XRReferenceImage refImage;

        void Start()
        {
           // refImage = aRTrackedImage.referenceImage;
            this.gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            this.gameObject.GetComponent<Image>().sprite = images[0];
        }

        // Update is called once per frame
        void Update()
        {
           // Debug.Log(refImage);
        }
    }

}


