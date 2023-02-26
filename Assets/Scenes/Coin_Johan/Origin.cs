using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation
{
    public class Origin : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefabOrigin;

        [SerializeField]
        private GameObject _camera;

        private GameObject spawnObject;


        void Awake()
        {
            spawnObject = Instantiate(prefabOrigin, _camera.transform.position, transform.rotation);
            if (spawnObject.GetComponent<ARAnchor>() == null)
            {
                spawnObject.AddComponent<ARAnchor>();
            }

        }


        public void SetPosition(Vector3 v3)
        {
            prefabOrigin.transform.position = v3;

        }

        public Vector3 GetPosition()
        {
            return prefabOrigin.transform.position;
        }
    }
}
