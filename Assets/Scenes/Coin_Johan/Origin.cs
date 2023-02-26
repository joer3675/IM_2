using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Origin : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabOrigin;

    [SerializeField]
    private GameObject _camera;

    private GameObject spawnObject;

    void Awake()
    {
        Debug.Log(_camera.transform.position);
        Instantiate(prefabOrigin, _camera.transform.position, transform.rotation);

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
