using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Culling : MonoBehaviour
{

    [SerializeField]
    private AROcclusionManager _occlusionM;

    bool isActive;

    public void onButtonPressed()
    {
        if (!isActive)
        {
            _occlusionM.GetComponent<AROcclusionManager>().enabled = false;
            isActive = true;
        }
        else
        {
            _occlusionM.GetComponent<AROcclusionManager>().enabled = true;
            isActive = false;
        }
    }
}
