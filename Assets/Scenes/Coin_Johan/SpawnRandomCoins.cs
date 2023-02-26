using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;



namespace UnityEngine.XR.ARFoundation
{
    [RequireComponent(typeof(ARRaycastManager))]
    [RequireComponent(typeof(ARAnchorManager))]
    public class SpawnRandomCoins : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_prefabSpawn;
        private GameObject spawnObject;

        [SerializeField]
        private GameObject _camera;

        private ARRaycastManager _raycastManager;

        private ARAnchorManager _anchorManager;

        public ARPlane aRPlane;

        [SerializeField]
        private GameObject origin;
        Vector3 currentPos;

        [SerializeField]
        public int numberOfSpawnCoins;



        private static readonly List<ARRaycastHit> Hits = new List<ARRaycastHit>();


        void Awake()
        {
            _anchorManager = GetComponent<ARAnchorManager>();
            _raycastManager = GetComponent<ARRaycastManager>();
            currentPos = origin.transform.position;
        }


        void Update()
        {

            if (spawnObject == null || 0 < numberOfSpawnCoins)
            {

                Vector3 spawnPosition = (origin.transform.position + new Vector3(Random.Range(-3.0f, 3f) * 2 - 1, -1, Random.Range(-3f, 3f) * 2 - 1));
                if (Mathf.Abs(spawnPosition.x - _camera.transform.position.x) > 2 || Mathf.Abs(spawnPosition.z - _camera.transform.position.z) > 2)
                {

                    if (GameObject.FindGameObjectsWithTag("CoinTag").Length > 0)
                    {
                        foreach (GameObject prefab in GameObject.FindGameObjectsWithTag("CoinTag"))
                        {
                            if (Mathf.Abs(spawnPosition.x - prefab.transform.position.x) > 2 || Mathf.Abs(spawnPosition.z - prefab.transform.position.z) > 2)
                            {
                                spawnObject = Instantiate(m_prefabSpawn, spawnPosition, origin.transform.rotation);
                            }
                            break;
                        }
                    }
                    else
                    {
                        spawnObject = Instantiate(m_prefabSpawn, spawnPosition, origin.transform.rotation);
                    }

                    numberOfSpawnCoins--;
                }

                //origin.transform.position = currentPos;

                //currentPos = spawnObject.transform.position;

                // Debug.Log("Origin Pos: " + origin.transform.position + " CoinPois : " + spawnObject.transform.position);
                // if(_raycastManager.Raycast())
                // CreateAnchor(Hits[0]);
            }
            // // Ray rayCast;
            // // rayCast = Camera.main.ScreenPointToRay(new Vector3((Camera.main.pixelWidth - 1) / 2, (Camera.main.pixelHeight - 1) / 2, 0));
            // // //if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began) { return; }
            // // // Perform AR raycast to any kind of trackable

            // // if (_raycastManager.Raycast(rayCast, Hits, TrackableType.PlaneWithinPolygon))
            // // {
            // //     // Raycast hits are sorted by distance, so the first one will be the closest hit.

            // //     var hitPose = Hits[0].pose;



            // //     if (spawnObject == null)
            // //     {
            // //         spawnObject = Instantiate(m_prefabSpawn, hitPose.position, hitPose.rotation);
            // //         CreateAnchor(Hits[0]);
            // //     }
            // else
            // {
            //     spawnObject.transform.position = hitPose.position;
            //     CreateAnchor(Hits[0]);
            //     // if (!spawnObject.activeSelf)
            //     // {
            //     //     spawnObject.SetActive(true);

            //     // }
            // }


            // Instantiate the prefab at the given position
            // Note: the object is not anchored yet!

            //}

        }

        private float ARPlaneSize(ARPlaneBoundaryChangedEventArgs obj)
        {
            return aRPlane.size.x * aRPlane.size.y;
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
            anchor = spawnObject.GetComponent<ARAnchor>();
            if (anchor == null)
            {
                anchor = spawnObject.AddComponent<ARAnchor>();
            }
            Debug.Log($"Created regular anchor (id: {anchor.nativePtr}).");
            return anchor;
        }
        //var instantiatedObject = Instantiate(m_prefabSpawn, (hit.pose.position + new Vector3(Random.Range(-5, 5), 0, 0)), hit.pose.rotation);

        // Make sure the new GameObject has an ARAnchor component
    }






}
