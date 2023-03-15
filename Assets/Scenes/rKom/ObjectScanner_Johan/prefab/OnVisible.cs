using UnityEngine;
using System.Collections;
public class OnVisible : MonoBehaviour
{
    bool isVisible;

    void OnBecameInvisible()
    {
        isVisible = false;
    }
    void OnBecameVisible()
    {
        isVisible = true;
    }

    public bool getVisible()
    {
        return isVisible;
    }

}
