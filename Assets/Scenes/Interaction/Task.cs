using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Task
{

    public static string task;

    public static void setTask(string text)
    {
        task = text;
    }

    public static string getTask()
    {
        return task;
    }

}
