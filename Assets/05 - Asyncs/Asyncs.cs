using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Asyncs : MonoBehaviour
{

    protected virtual void Start()
    {
        CallMethod();
    }

    public static async void CallMethod()
    {
        Task<int> task = Method1();
        Method2();
        int count = await task;
        Method3(count);
    }

    public static async Task<int> Method1()
    {
        int count = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Debug.LogWarning(" Method 1");
                count += 1;
            }
        });
        return count;
    }

    public static void Method2()
    {
        for (int i = 0; i < 25; i++)
        {
            Debug.LogWarning("Method 2");
        }
    }

    public static void Method3(int count)
    {
        Debug.LogWarning("Total count is " + count);
    }

}