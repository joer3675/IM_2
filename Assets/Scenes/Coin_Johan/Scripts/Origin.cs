using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;


namespace UnityEngine.XR.ARFoundation.Samples
{

    public class Origin : PressInputBase
    {

        [SerializeField]
        private ARRaycastManager _raycastManager;
        [SerializeField]
        private ARPlaneManager _planeManger;

        [SerializeField]
        private GameObject planeManger;

        [SerializeField]
        private GameObject prefabOrigin;

        [SerializeField]
        private ARAnchorManager _anchorManager;

        [SerializeField]
        private GameObject _camera;

        [SerializeField]
        private GameObject buttonGround;

        private GameObject spawnObject;

        private bool hasFoundPlane = false;

        bool m_Pressed;
        TrackableId _id;

        private static readonly List<ARRaycastHit> Hits = new List<ARRaycastHit>();




        void Update()
        {

            if (!hasFoundPlane)
            {
                if (Pointer.current == null || m_Pressed == false)
                    return;


                var touchPosition = Pointer.current.position.ReadValue();

                if (_raycastManager.Raycast(touchPosition, Hits, TrackableType.PlaneWithinPolygon))
                {

                    var hit = Hits[0];
                    Pose hitpose = Hits[0].pose;

                    _id = _planeManger.GetPlane(hit.trackableId).trackableId;

                    if (spawnObject == null)
                    {
                        spawnObject = Instantiate(prefabOrigin, hitpose.position, hitpose.rotation);
                        buttonGround.SetActive(true);

                        var anchor = CreateAnchorSetPrefab(hit);
                    }
                    else
                    {
                        spawnObject.transform.position = hitpose.position;
                    }




                    // planeManger.GetComponent<ARPlaneManager>().enabled = false;

                    // ARPlane currentPlane = _planeManger.GetPlane(hit.trackableId);
                    // foreach (var plane in _planeManger.trackables)
                    // {

                    //     if (plane.center.y < currentPlane.center.y)
                    //     {

                    //         currentPlane.gameObject.SetActive(false);
                    //         currentPlane = plane;

                    //     }
                    //     else
                    //     {

                    //         plane.gameObject.SetActive(false);

                    //     }


                    // }




                }
                // else
                // {
                //     prefabOrigin.SetActive(false);

                // }
            }
            // else
            // {
            //     foreach (var plane in _planeManger.trackables)
            //     {
            //         if (plane.trackableId != _id)
            //         {
            //             plane.gameObject.SetActive(false);

            //         }

            //     }
            //planeManger.GetComponent<ARPlaneManager>().enabled = false;
            //}
            // if (spawnObject.GetComponent<ARAnchor>() == null)
            // {
            //     ARAnchor anchor = spawnObject.AddComponent<ARAnchor>();
            // }

        }
        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;

        public void ButtonPressed()
        {
            hasFoundPlane = true;
        }

        public bool GetButtonPressed()
        {

            return hasFoundPlane;
        }


        // public void SetPosition(Vector3 v3)
        // {
        //     prefabOrigin.transform.position = v3;

        // }

        // public Vector3 GetPosition()
        // {
        //     return prefabOrigin.transform.position;
        // }





        private ARAnchor CreateAnchorSetPrefab(in ARRaycastHit hit)
        {
            ARAnchor anchor = null;

            if (hit.trackable is ARPlane plane)
            {
                var planeManager = GetComponent<ARPlaneManager>();
                if (planeManager != null)
                {

                    var oldPrefab = _anchorManager.anchorPrefab;
                    _anchorManager.anchorPrefab = prefabOrigin;
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

            if (prefabOrigin != null)
            {
                //var gameObject = Instantiate(prefabOrigin, hit.pose.position, hit.pose.rotation);

                anchor = ComponentUtils.GetOrAddIf<ARAnchor>(prefabOrigin, true);
            }

            return anchor;
        }



        //     if (_raycastManager.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)), Hits, TrackableType.PlaneWithinPolygon))
        //     {

        //         var hitPose = Hits[0].pose;
        //         if (spawnObject == null)
        //         {
        //             spawnObject = Instantiate(prefabOrigin, hitPose.position, hitPose.rotation);
        //         }
        //         else
        //         {
        //             spawnObject.transform.position = hitPose.position;
        //         }

        //         if (spawnObject.GetComponent<ARAnchor>() == null)
        //         {
        //             spawnObject.AddComponent<ARAnchor>();
        //         }

        //     }

        //var instantiatedObject = Instantiate(m_prefabSpawn, (hit.pose.position + new Vector3(Random.Range(-5, 5), 0, 0)), hit.pose.rotation);

        // Make sure the new GameObject has an ARAnchor component
    }
}





