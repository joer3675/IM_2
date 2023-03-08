using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;
using System.Collections;
namespace UnityEngine.XR.ARFoundation
{
    public class ImagePicker : MonoBehaviour
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

        void Start()
        {

        }
        void Update()
        {
            //GameObject.FindGameObjectWithTag("DebugTag").GetComponent<Text>().text = inputField.GetComponent<TMP_InputField>().text;
        }


        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;



        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {


            foreach (var newImage in eventArgs.added)
            {

                task = inputField.GetComponent<TMP_InputField>().text;
                var imageName = newImage.referenceImage.name;

                if (task.Equals("vacuum", StringComparison.OrdinalIgnoreCase))
                {

                    if (imageName != null)
                    {
                        if (imageName.Equals("VacuumQR"))
                        {
                            // if (!isCorrectNewImage)
                            // {
                            //     hasPlayedSound = false;
                            // }
                            audioSource.PlayOneShot(audioClipGood);
                            // isCorrectNewImage = true;
                            // GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);
                            // scannerObject.GetComponent<ScannerColor>().setColor("green");

                        }
                        else if (imageName.Equals("BrushQR"))
                        {
                            audioSource.PlayOneShot(audioClipBad);
                            // if (isCorrectNewImage)
                            // {
                            //     hasPlayedSound = false;
                            // }
                            // isCorrectNewImage = false;
                            // GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                            //scannerObject.GetComponent<ScannerColor>().setColor("red");

                        }
                        else
                        {
                            audioSource.PlayOneShot(audioClipBad);
                            // if (isCorrectNewImage)
                            // {
                            //     hasPlayedSound = false;
                            // }
                            // isCorrectNewImage = false;
                            // GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                        }
                        if (!hasPlayedSound)
                        {
                            if (isCorrectNewImage)
                            {
                                audioSource.PlayOneShot(audioClipGood);
                                // hasPlayedSound = true;

                            }
                            else
                            {
                                audioSource.PlayOneShot(audioClipBad);
                                // hasPlayedSound = true;
                            }
                        }
                    }
                }
                else if (task.Equals("paint", StringComparison.OrdinalIgnoreCase))
                {
                    if (imageName != null)
                    {
                        // if (!isCorrectNewImage)
                        // {
                        //     hasPlayedSound = false;
                        // }

                        if (imageName.Equals("VacuumQR"))
                        {
                            // isCorrectNewImage = false;
                            audioSource.PlayOneShot(audioClipBad);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);

                        }
                        else if (imageName.Equals("BrushQR"))
                        {
                            audioSource.PlayOneShot(audioClipGood);
                            //  isCorrectNewImage = true;
                            // GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);

                        }
                        else
                        {

                            // isCorrectNewImage = false;
                            audioSource.PlayOneShot(audioClipBad);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                            // GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);


                        }
                    }
                    else
                    {
                        if (imageName != null)
                        {
                            // if (!isCorrectNewImage)
                            // {
                            //     hasPlayedSound = false;
                            // }

                            if (imageName.Equals("VacuumQR"))
                            {
                                // isCorrectNewImage = false;
                                audioSource.PlayOneShot(audioClipBad);
                                // GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                                // GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);

                            }
                            else if (imageName.Equals("BrushQR"))
                            {
                                //isCorrectNewImage = false;
                                audioSource.PlayOneShot(audioClipBad);
                                // GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                                // GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);

                            }
                            else
                            {
                                audioSource.PlayOneShot(audioClipGood);
                                // isCorrectNewImage = true;
                                // GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(true);
                                // GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(false);


                            }
                        }
                    }

                    //     if (!hasPlayedSound)
                    //     {
                    //         if (isCorrectNewImage)
                    //         {
                    //             audioSource.PlayOneShot(audioClipGood);
                    //             hasPlayedSound = true;

                    //         }
                    //         else
                    //         {
                    //             audioSource.PlayOneShot(audioClipBad);
                    //             hasPlayedSound = true;
                    //         }
                    //     }
                }
                SetMarkers(task);
            }
            foreach (var updatedImage in eventArgs.updated)
            {
                task = inputField.GetComponent<TMP_InputField>().text;
                var imageName = updatedImage.referenceImage.name;

                if (!GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible() && !GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible() && !GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                {
                    GameObject.FindGameObjectWithTag("DebugTag").GetComponent<Text>().text = "Failed";
                    scannerObject.GetComponent<ScannerColor>().setColor("white");
                    nextSceneObject.SetActive(false);

                    return;

                }
                if (imageName != null)
                {
                    SetMarkers(task);

                }
                if (task.Equals("vacuum", StringComparison.OrdinalIgnoreCase))
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

                }
                else if (task.Equals("paint", StringComparison.OrdinalIgnoreCase))
                {
                    if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("green");
                    }
                    else if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                    }
                    else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                    }


                }
                else if (task.Equals("water", StringComparison.OrdinalIgnoreCase))
                {
                    if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                    }
                    else if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("red");
                    }
                    else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
                    {
                        scannerObject.GetComponent<ScannerColor>().setColor("green");
                    }


                }
            }


            // foreach (var updatedImage in eventArgs.updated)
            // {
            //     task = inputField.GetComponent<TMP_InputField>().text;
            //     var imageName = updatedImage.referenceImage.name;

            //     if (!GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible() && !GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible() && !GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
            //     {
            //         GameObject.FindGameObjectWithTag("DebugTag").GetComponent<Text>().text = "Failed";
            //         scannerObject.GetComponent<ScannerColor>().setColor("white");
            //         nextSceneObject.SetActive(false);

            //         return;

            //     }

            //     if (task.Equals("vacuum", StringComparison.OrdinalIgnoreCase))
            //     {

            //         if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("green");
            //             nextSceneObject.SetActive(true);
            //         }
            //         else if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("red");
            //             nextSceneObject.SetActive(false);
            //         }
            //         else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("red");
            //             nextSceneObject.SetActive(false);
            //         }

            //         if (imageName != null)
            //         {
            //             if (imageName.Equals("VacuumQR"))
            //             {


            //                 GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);



            //             }
            //             else if (imageName.Equals("BrushQR"))
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);

            //             }
            //             else
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
            //             }

            //         }
            //     }
            //     else if (task.Equals("paint", StringComparison.OrdinalIgnoreCase))
            //     {
            //         if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("green");
            //         }
            //         else if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("red");
            //         }
            //         else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("red");
            //         }

            //         if (imageName != null)
            //         {
            //             if (imageName.Equals("VacuumQR"))
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);

            //             }
            //             else if (imageName.Equals("BrushQR"))
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);

            //             }
            //             else
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
            //             }
            //         }

            //     }
            //     else if (task.Equals("water", StringComparison.OrdinalIgnoreCase))
            //     {
            //         if (GameObject.Find("PBrush(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("red");
            //         }
            //         else if (GameObject.Find("Vacuum(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("red");
            //         }
            //         else if (GameObject.Find("WaterCan(Clone)").GetComponent<OnVisible>().getVisible())
            //         {
            //             scannerObject.GetComponent<ScannerColor>().setColor("green");
            //         }

            //         if (imageName != null)
            //         {
            //             if (imageName.Equals("VacuumQR"))
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);

            //             }
            //             else if (imageName.Equals("BrushQR"))
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);

            //             }
            //             else
            //             {
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(true);
            //                 GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(false);
            //             }
            //         }

            //     }
            // }
            // foreach (var removedImage in eventArgs.removed)
            // {

            // }
        }
        private void SetMarkers(String task)
        {
            switch (task)
            {
                case "vacuum":

                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case "paint":
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("GreenRedMarker2").transform.GetChild(1).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.FindGameObjectWithTag("GreenRedMarker3").transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case "water":
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


