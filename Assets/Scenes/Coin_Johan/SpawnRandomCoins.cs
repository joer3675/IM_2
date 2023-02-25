using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;
using UnityEngine.UI;



namespace UnityEngine.XR.ARFoundation
{
    [RequireComponent(typeof(ARRaycastManager))]
    [RequireComponent(typeof(ARAnchorManager))]
    public class SpawnRandomCoins : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_prefabSpawn;
        private GameObject spawnObject;

        private ARRaycastManager _raycastManager;

        private ARAnchorManager _anchorManager;


        private static readonly List<ARRaycastHit> Hits = new List<ARRaycastHit>();


        void Awake()
        {
            _anchorManager = GetComponent<ARAnchorManager>();
            _raycastManager = GetComponent<ARRaycastManager>();
        }


        void Update()
        {
            Touch touch;
            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began) { return; }

            // Perform AR raycast to any kind of trackable
            if (_raycastManager.Raycast(touch.position, Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one will be the closest hit.

                var hitPose = Hits[0].pose;

                if (spawnObject == null)
                {
                    spawnObject = Instantiate(m_prefabSpawn, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnObject.transform.position = hitPose.position;
                }


                // Instantiate the prefab at the given position
                // Note: the object is not anchored yet!
                //CreateAnchor(Hits[0]);
            }


        }

        private ARAnchor CreateAnchor(in ARRaycastHit hit)
        {

            ARAnchor anchor;
            if (hit.trackable is ARPlane plane)
            {
                var planeManager = GetComponent<ARPlaneManager>();
                if (planeManager)
                {

                    var oldPrefab = _anchorManager.anchorPrefab;
                    _anchorManager.anchorPrefab = m_prefabSpawn;
                    anchor = _anchorManager.AttachAnchor(plane, hit.pose);
                    _anchorManager.anchorPrefab = oldPrefab;

                    Debug.Log($"Created anchor attachment for plane (id: {anchor.nativePtr}).");
                    return anchor;
                }
            }
            // ... here, we'll place the plane anchoring code!

            // Otherwise, just create a regular anchor at the hit pose

            // Note: the anchor can be anywhere in the scene hierarchy
            var instantiatedObject = Instantiate(m_prefabSpawn, (hit.pose.position + new Vector3(Random.Range(-5, 5), 0, 0)), hit.pose.rotation);

            // Make sure the new GameObject has an ARAnchor component
            anchor = instantiatedObject.GetComponent<ARAnchor>();
            if (anchor == null)
            {
                anchor = instantiatedObject.AddComponent<ARAnchor>();
            }
            Debug.Log($"Created regular anchor (id: {anchor.nativePtr}).");



            return anchor;
        }
    }

}
