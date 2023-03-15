using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;
using System.Collections;
namespace UnityEngine.XR.ARFoundation
{
    public class ImagePicker_Two : MonoBehaviour
    {
        [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;
        // Start is called before the first frame update
        [SerializeField]
        private GameObject inputField;
        [SerializeField]
        private GameObject scannerObject;

        [SerializeField]
        private GameObject nextSceneObject;
        public Sprite[] images;

        private string task;

        [SerializeField]
        private AudioClip audioClipGood;
        [SerializeField]
        private AudioClip audioClipBad;
        [SerializeField]
        private AudioSource audioSource;
        private bool hasPlayedSound;
        private bool isCorrectNewImage;
        private bool hasImagageChanged;
        public GameObject prefabVac;
        public GameObject prefabBrush;

        void Awake()
        {

        }


        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;



        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {

            task = Task.getTask();
            foreach (var newImage in eventArgs.added)
            {



                var imageName = newImage.referenceImage.name;


                if (task.Equals("Dammsuga", StringComparison.OrdinalIgnoreCase))
                {

                    if (imageName != null)
                    {
                        if (imageName.Equals("VacuumQR"))
                        {

                            audioSource.PlayOneShot(audioClipGood);

                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);
                            scannerObject.GetComponent<ScannerColor>().setColor("green");

                        }
                        else if (imageName.Equals("BrushQR"))
                        {
                            audioSource.PlayOneShot(audioClipBad);

                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                            scannerObject.GetComponent<ScannerColor>().setColor("red");

                        }
                        else if (imageName.Equals("WaterCanQR"))
                        {
                            audioSource.PlayOneShot(audioClipBad);

                            GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                            scannerObject.GetComponent<ScannerColor>().setColor("red");
                        }
                        else
                        {
                            scannerObject.GetComponent<ScannerColor>().setColor("white");
                        }

                    }
                }
                else if (task.Equals("Mala", StringComparison.OrdinalIgnoreCase))
                {
                    if (imageName != null)
                    {

                        if (imageName.Equals("VacuumQR"))
                        {

                            audioSource.PlayOneShot(audioClipBad);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                            scannerObject.GetComponent<ScannerColor>().setColor("red");
                        }
                        else if (imageName.Equals("BrushQR"))
                        {
                            audioSource.PlayOneShot(audioClipGood);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);
                            scannerObject.GetComponent<ScannerColor>().setColor("green");

                        }
                        else if (imageName.Equals("WaterCanQR"))
                        {
                            audioSource.PlayOneShot(audioClipBad);
                            GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                            scannerObject.GetComponent<ScannerColor>().setColor("red");
                        }
                        else
                        {
                            scannerObject.GetComponent<ScannerColor>().setColor("white");
                        }
                    }
                }
                else if (task.Equals("Vattna", StringComparison.OrdinalIgnoreCase))
                {
                    if (imageName != null)
                    {

                        if (imageName.Equals("VacuumQR"))
                        {
                            audioSource.PlayOneShot(audioClipBad);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                            scannerObject.GetComponent<ScannerColor>().setColor("red");
                        }
                        else if (imageName.Equals("BrushQR"))
                        {
                            audioSource.PlayOneShot(audioClipBad);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                            GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                            scannerObject.GetComponent<ScannerColor>().setColor("red");
                        }
                        else if (imageName.Equals("WaterCanQR"))
                        {
                            audioSource.PlayOneShot(audioClipGood);
                            GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(true);
                            GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(false);
                            scannerObject.GetComponent<ScannerColor>().setColor("green");
                        }
                        else
                        {
                            scannerObject.GetComponent<ScannerColor>().setColor("white");
                        }
                    }
                }
            }

            foreach (var updatedImage in eventArgs.updated)
            {

                var imageName = updatedImage.referenceImage.name;

                // if (!GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible() && !GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible() && !GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                // {
                //     //GameObject.FindGameObjectWithTag("DebugTag").GetComponent<Text>().text = "Failed";
                //     scannerObject.GetComponent<ScannerColor>().setColor("white");
                //     nextSceneObject.SetActive(false);

                //     return;

                // }

                if (task.Equals("Dammsuga", StringComparison.OrdinalIgnoreCase))
                {

                    if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("green");
                        nextSceneObject.SetActive(true);
                    }
                    else if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                        nextSceneObject.SetActive(false);
                    }
                    else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                        nextSceneObject.SetActive(false);
                    }
                    else
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("white");
                        nextSceneObject.SetActive(false);
                    }

                }
                else if (task.Equals("Mala", StringComparison.OrdinalIgnoreCase))
                {
                    if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("green");
                        //  nextSceneObject.SetActive(true);
                    }
                    else if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                        //   nextSceneObject.SetActive(false);
                    }
                    else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                        // nextSceneObject.SetActive(false);
                    }
                    else
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("white");
                        nextSceneObject.SetActive(false);
                    }


                }
                else if (task.Equals("Vattna", StringComparison.OrdinalIgnoreCase))
                {
                    if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                        //nextSceneObject.SetActive(false);
                    }
                    else if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                        // nextSceneObject.SetActive(false);
                    }
                    else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("green");
                        //nextSceneObject.SetActive(true);
                    }
                    else
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("white");
                        nextSceneObject.SetActive(false);
                    }


                }
                if (imageName != null)
                {
                    SetMarkers(task);

                }
            }


        }
        private void SetMarkers(String task)
        {
            switch (task)
            {
                case "Dammsuga":
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                    break;

                case "Mala":
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                    break;

                case "Vattna":
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(false);
                    break;


                default:
                    break;
            }

        }
    }




}


