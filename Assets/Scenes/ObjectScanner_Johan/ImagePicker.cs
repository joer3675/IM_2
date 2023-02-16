using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;


namespace UnityEngine.XR.ARFoundation
{
    public class ImagePicker : MonoBehaviour
    {
        [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;
        // Start is called before the first frame update
        [SerializeField]
        private GameObject inputField;
        public Sprite[] images;

        public string task;


        void Start()
        {

        }
        void Update()
        {
            GameObject.FindGameObjectWithTag("DebugTag").GetComponent<Text>().text = inputField.GetComponent<TMP_InputField>().text;
        }

        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {
                // task = inputField.GetComponent<TMP_InputField>().text;
                // var imageName = newImage.referenceImage.name;

                // Debug.Log("test");
                // if (task.Equals("vacuum", StringComparison.OrdinalIgnoreCase))
                // {

                //     if (imageName != null)
                //     {
                //         if (imageName.Equals("VacuumQR"))
                //         {
                //             GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
                //             GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);
                //         }
                //         else
                //         {
                //             GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                //             GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                //         }
                //     }
                // }
                // else if (task.Equals("paint", StringComparison.OrdinalIgnoreCase))
                // {
                //     if (imageName != null)
                //     {
                //         if (imageName.Equals("VacuumQR"))
                //         {
                //             GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                //             GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                //         }
                //         else
                //         {
                //             GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
                //             GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);
                //         }
                //     }
                // }

            }

            foreach (var updatedImage in eventArgs.updated)
            {
                task = inputField.GetComponent<TMP_InputField>().text;
                var imageName = updatedImage.referenceImage.name;

                Debug.Log("test");
                if (task.Equals("vacuum", StringComparison.OrdinalIgnoreCase))
                {

                    if (imageName != null)
                    {
                        if (imageName.Equals("VacuumQR"))
                        {
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);
                        }
                        else
                        {
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                        }
                    }
                }
                else if (task.Equals("paint", StringComparison.OrdinalIgnoreCase))
                {
                    if (imageName != null)
                    {
                        if (imageName.Equals("VacuumQR"))
                        {
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                        }
                        else
                        {
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);
                        }
                    }
                }
            }

            foreach (var removedImage in eventArgs.removed)
            {
                // Handle removed event
            }
        }
    }

}


