using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Xoia.UndoRedo
{

    public abstract class BaseStore : IStore
    {

        protected Stack<ITwoWayStep> steps = new Stack<ITwoWayStep>();
        protected Stack<ITwoWayStep> stepsBack = new Stack<ITwoWayStep>();
        protected Dictionary<Type, List<Action>> callbacks = new Dictionary<Type, List<Action>>();

        public bool IsInInitialStep { get => steps.Count <= 0; }
        public bool IsInLastStep { get => stepsBack.Count <= 0; }

        public virtual void Do(ITwoWayStep step)
        {
            steps.Push(step);
            step.Do(this, () => InvokeCallbacks(step.GetType()));
            if (!IsInLastStep)
                stepsBack.Clear();
        }

        public virtual void Do(IOneWayStep step)
        {
            step.Do(this, () => InvokeCallbacks(step.GetType()));
        }

        public virtual void Undo()
        {
            if (IsInInitialStep)
                return;
            ITwoWayStep step = steps.Pop();
            step.Undo(() => InvokeCallbacks(step.GetType()));
            stepsBack.Push(step);
        }

        public virtual void Redo()
        {
            if (IsInLastStep)
                return;
            ITwoWayStep step = stepsBack.Pop();
            step.Redo(() => InvokeCallbacks(step.GetType()));
            steps.Push(step);
        }

        public virtual void Clear()
        {
            steps.Clear();
            stepsBack.Clear();
        }

        public virtual void InvokeCallbacks(Type type)
        {
            if (callbacks.ContainsKey(type))
            {
                // It needs to be a new IEnumerable because callbacks can modify the callbacks dictionary
                foreach (Action callback in GetCallbacksByType(type))
                {
                    callback();
                }
            }
        }

        public virtual void AddListener<T>(Action onComplete) where T : IStep
        {
            if (!callbacks.ContainsKey(typeof(T)))
                callbacks[typeof(T)] = new List<Action>();
            callbacks[typeof(T)].Add(onComplete);
        }

        public virtual void RemoveListener<T>(Action onComplete) where T : IStep
        {
            if (callbacks.ContainsKey(typeof(T)))
            {
                if (callbacks[typeof(T)].Contains(onComplete))
                {
                    callbacks[typeof(T)].Remove(onComplete);
                }
                else
                {
                    Debug.LogWarning("Callbacks for step with type " + typeof(T) + " not registered yet!");
                }
            }
        }

        protected virtual List<Action> GetCallbacksByType(Type type)
        {
            List<Action> toCall = new List<Action>();
            foreach (Action callback in callbacks[type])
            {
                toCall.Add(callback);
            }
            return toCall;
        }

    }

}