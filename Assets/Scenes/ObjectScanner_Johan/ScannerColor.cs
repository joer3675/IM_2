using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScannerColor : MonoBehaviour
{
    [SerializeField]
    public Image[] images;

    public void setColor(string color)
    {
        if (color.Equals("green"))
        {
            foreach (Image image in images)
            {
                image.color = Color.green;
            }

        }
        else if (color.Equals("red"))
        {
            foreach (Image image in images)
            {
                image.color = Color.red;
            }
        }
        else
        {
            foreach (Image image in images)
            {
                image.color = Color.white;
            }
        }
    }
}
