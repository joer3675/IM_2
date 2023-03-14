using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pictogram
{
    public static bool isPictogram;


    public static void setPictogram(bool status)
    {
        isPictogram = status;


    }

    public static bool getPictogramState()
    {
        return isPictogram;
    }
}
