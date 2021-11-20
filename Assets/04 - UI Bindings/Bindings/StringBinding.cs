using System;
using UnityEngine.Events;

public class StringBinding : IBindable
{

    public UnityEvent<string> unityEvent;
    public Action<string> action;

    public StringBinding(UnityEvent<string> unityEvent, Action<string> action)
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