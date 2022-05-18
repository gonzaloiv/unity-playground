using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xoia.UndoRedo;

namespace Xoia.SceneEditor
{

    public abstract class BaseOneWayStep : IStep, IOneWayStep
    {

        protected BaseStore store;

        public virtual void Do(IStore iStore, Action onComplete = null)
        {
            store = (iStore as BaseStore);
        }

    }

}