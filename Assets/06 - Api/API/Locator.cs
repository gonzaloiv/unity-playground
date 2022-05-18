﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Locator
{

    protected Dictionary<Type, object> daos = new Dictionary<Type, object>();

    public void Register<T>(object instance)
    {
        daos[typeof(T)] = instance;
    }

    public void Unregister<T>(object instance)
    {
        if (HasDao<T>())
        {
            daos.Remove(typeof(T));
        }
        else
        {
            Debug.LogWarning("Instance for type " + typeof(T) + " not found!");
        }
    }

    public bool HasDao<T>()
    {
        return daos.ContainsKey(typeof(T));
    }

    public object Get<T>()
    {
        if (HasDao<T>())
        {
            return daos[typeof(T)];
        }
        else
        {
            Debug.LogWarning("Client for type " + typeof(T) + " not found!");
            return null;
        }
    }

}