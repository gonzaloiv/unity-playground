using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Binder : MonoBehaviour
{

    protected List<IBindable> bindables = new List<IBindable>();

    protected virtual void Start()
    {
        foreach (IBindable bindable in bindables)
        {
            bindable.Bind();
        }
    }

    protected virtual void OnDestroy()
    {
        foreach (IBindable bindable in bindables)
        {
            bindable.Unbind();
        }
    }

    public Binder AddBinding(UnityEvent unityEvent, Action action)
    {
        bindables.Add(new Binding(unityEvent, action));
        return this;
    }

    public Binder AddBinding(UnityEvent<float> unityEvent, Action<float> action)
    {
        bindables.Add(new FloatBinding(unityEvent, action));
        return this;
    }

    public Binder AddBinding(UnityEvent<string> unityEvent, Action<string> action)
    {
        bindables.Add(new StringBinding(unityEvent, action));
        return this;
    }

}