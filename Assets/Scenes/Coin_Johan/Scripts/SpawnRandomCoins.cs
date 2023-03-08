using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.XR.ARSubsystems;
using Unity.XR.CoreUtils;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;



namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    [RequireComponent(typeof(ARAnchorManager))]
    //[RequireComponent(typeof(ARPointCloudManager))]
    public class SpawnRandomCoins : MonoBehaviour
    {
        public static List<GameObject> spawnedObjects = new List<GameObject>();

        private ARRaycastManager _raycastManager;


        private ARAnchorManager _anchorManager;
        //private ARPointCloudManager _pointCloudManger;

        private List<ARAnchor> m_anchors = new List<ARAnchor>();
        //public ARPlane aRPlane;

        [SerializeField]
        private GameObject m_prefabSpawn;
        private GameObject spawnObject;

        [SerializeField]
        private GameObject _camera;

        [SerializeField]
        private GameObject origin;
        Vector3 currentPos;

        [SerializeField]
        private float roomWidth = 1f;
        [SerializeField]
        private float roomLength = 1f;

        [SerializeField]
        private float coinSpawnHeight = 1f;

        public int numberOfSpawnCoins;

        [SerializeField]
        private int maxNumberOfSpawnedCoins;

        ARRaycast rayCast;

        GameObject sessionOrigin;

        public GameObject hits;
        public GameObject hits2;

        bool hasPressed;


        private static readonly List<ARRaycastHit> Hits = new List<ARRaycastHit>();


        void Awake()
        {

            _anchorManager = GetComponent<ARAnchorManager>();
            _raycastManager = GetComponent<ARRaycastManager>();

            //_pointCloudManger = GetComponent<ARPointCloudManager>();

            // ARAnchor from start of session //
            currentPos = origin.transform.position;
            rayCast = _raycastManager.AddRaycast((new Vector2((Screen.width - 1) / 2, (Screen.height - 1) / 2)), 10f);
        }


        void Update()
        {
            numberOfSpawnCoins = spawnedObjects.Count;

            if (origin.gameObject.GetComponent<Origin>().GetButtonPressed() && !hasPressed)
            {
                Debug.Log("1");
                sessionOrigin = GameObject.FindGameObjectWithTag("SessionOrigin");
                if (sessionOrigin != null)
                {
                    hasPressed = true;
                }

            }

            if (sessionOrigin != null)
            {
                if (spawnObject == null || maxNumberOfSpawnedCoins >= numberOfSpawnCoins && numberOfSpawnCoins >= 0)
                {

                    Vector3 spawnPosition = (sessionOrigin.transform.position + new Vector3(Random.Range(-roomWidth, roomWidth) * 2, +coinSpawnHeight, Random.Range(-roomLength, roomLength) * 2));
                    if (Mathf.Abs(spawnPosition.x - _camera.transform.position.x) > 2 || Mathf.Abs(spawnPosition.z - _camera.transform.position.z) > 2)
                    {
                        Transform ta = GameObject.FindGameObjectWithTag("SessionOrigin").transform;
                        if (GameObject.FindGameObjectsWithTag("CoinTag").Length > 0)
                        {
                            foreach (GameObject prefab in GameObject.FindGameObjectsWithTag("CoinTag"))
                            {
                                if (Mathf.Abs(spawnPosition.x - prefab.transform.position.x) > 2 || Mathf.Abs(spawnPosition.z - prefab.transform.position.z) > 2)
                                {

                                    spawnObject = Instantiate(m_prefabSpawn, spawnPosition, sessionOrigin.transform.rotation, ta);



                                }
                                break;
                            }
                        }
                        else
                        {
                            spawnObject = Instantiate(m_prefabSpawn, spawnPosition, sessionOrigin.transform.rotation, ta);

                        }

                        spawnedObjects.Add(spawnObject);

                    }
                    hits.GetComponent<Text>().text = spawnObject.transform.position.y.ToString();
                    hits2.GetComponent<Text>().text = sessionOrigin.transform.position.y.ToString();



                    // if (_raycastManager.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), Hits, TrackableType.PlaneWithinPolygon))
                    // {
                    //     var planeManager = GetComponent<ARPlaneManager>();
                    //     if (planeManager != null)
                    //     {
                    //         foreach (GameObject spawned in spawnedObjects)
                    //         {
                    //             if (_raycastManager.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), Hits, TrackableType.FeaturePoint))
                    //             {
                    //                 Pose hit = Hits[0].pose;
                    //                 if (MathF.Abs(hit.position.x - spawned.transform.position.x) > 4 && MathF.Abs(hit.position.z - spawned.transform.position.z) > 4)
                    //                 {
                    //                     spawned.transform.position = hit.position;
                    //                 }
                    //             }
                    //         }
                    //     }
                    // }




                    // origin.transform.position = currentPos;

                    // currentPos = spawnObject.transform.position;

                    // Debug.Log("Origin Pos: " + origin.transform.position + " CoinPois : " + spawnObject.transform.position);
                    // if (_raycastManager.Raycast())
                    //     CreateAnchor(Hits[0]);
                }

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





        // private float ARPlaneSize(ARPlaneBoundaryChangedEventArgs obj)
        // {
        //     return aRPlane.size.x * aRPlane.size.y;
        // }
        private void setAnchor(in ARRaycastHit hit, GameObject obj)
        {

            ARAnchor anchor = null;

            if (hit.pose.position.x - obj.transform.position.x > 3 || hit.pose.position.z - obj.transform.position.z > 3)
            {
                anchor = CreateAnchor(hit);
                _anchorManager.anchorPrefab = obj;

            }

        }


        private ARAnchor CreateAnchor(in ARRaycastHit hit)
        {

            ARAnchor anchor = null;

            if (hit.trackable is ARPlane plane)
            {
                var planeManager = GetComponent<ARPlaneManager>();
                if (planeManager != null)
                {

                    var oldPrefab = _anchorManager.anchorPrefab;
                    _anchorManager.anchorPrefab = m_prefabSpawn;
                    anchor = _anchorManager.AttachAnchor(plane, hit.pose);
                    _anchorManager.anchorPrefab = oldPrefab;

                    Debug.Log($"Created anchor attachment for plane (id: {anchor.nativePtr}).");
                    return anchor;
                }
                else
                {
                    anchor = _anchorManager.AttachAnchor(plane, hit.pose);
                }
            }
            // ... here, we'll place the plane anchoring code!

            // Otherwise, just create a regular anchor at the hit pose

            // Note: the anchor can be anywhere in the scene hierarchy
            //anchor = spawnObject.GetComponent<ARAnchor>();

            if (m_prefabSpawn != null)
            {
                anchor = spawnObject.GetComponent<ARAnchor>();
            }
            Debug.Log($"Created regular anchor (id: {anchor.nativePtr}).");
            return anchor;
        }
        //var instantiatedObject = Instantiate(m_prefabSpawn, (hit.pose.position + new Vector3(Random.Range(-5, 5), 0, 0)), hit.pose.rotation);

        // Make sure the new GameObject has an ARAnchor component
    }






}
