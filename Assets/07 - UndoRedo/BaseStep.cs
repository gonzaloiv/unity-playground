using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xoia.UndoRedo;

namespace Xoia.SceneEditor
{

    public abstract class BaseTwoWayStep : ITwoWayStep, IStep
    {

        protected BaseStore store;

        public virtual void Do(IStore iStore, Action onComplete = null)
        {
            store = (iStore as BaseStore);
        }

        public virtual void Undo(Action onComplete = null)
        {
            Debug.Log("Undo method for " + this.GetType() + " not implemented");
        }

        public virtual void Redo(Action onComplete = null)
        {
            Debug.Log("Redo method for " + this.GetType() + " not implemented");
        }

    }

}