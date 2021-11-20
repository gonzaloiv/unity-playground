using System;
using UnityEngine.Events;

public class Binding : IBindable
{

    public UnityEvent unityEvent;
    public Action action;

    public Binding(UnityEvent unityEvent, Action action)
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