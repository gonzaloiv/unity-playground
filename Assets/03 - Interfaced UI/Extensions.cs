using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{

    public static void ForEach<T>(this T[] instances, Action<T> actionToDo)
    {
        foreach (T instance in instances)
        {
            actionToDo(instance);
        }
    }

}