using System;
using UnityEngine.Events;

public class FloatBinding : IBindable
{

    public UnityEvent<float> unityEvent;
    public Action<float> action;

    public FloatBinding(UnityEvent<float> unityEvent, Action<float> action)
    {
        this.unityEvent = unityEvent;
        this.action = action;
    }

    public virtual void Bind()
    {
        this.unityEvent.AddListener(action.Invoke);
    }

    public virtual void Unbind()
    {
        this.unityEvent.RemoveListener(action.Invoke);
    }

}