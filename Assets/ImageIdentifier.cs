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
    public class ImageIdentifier : MonoBehaviour
    {
        [SerializeField]
        ARTrackedImageManager m_TrackedImageManager;
        // Start is called before the first frame update
        [SerializeField]
        private GameObject gameObject;


        void Start()
        {

        }
        void Update()
        {
            //  GameObject.FindGameObjectWithTag("DebugTag").GetComponent<Text>().text = inputField.GetComponent<TMP_InputField>().text;
        }

        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {
                Task.setTask(newImage.referenceImage.name);
                // gameObject.GetComponent<Text>().text = Task.getTask();

            }

            //foreach (var updatedImage in eventArgs.updated)
            //{

            //}

            //foreach (var removedImage in eventArgs.removed)
            //{

            //}
        }
    }

}