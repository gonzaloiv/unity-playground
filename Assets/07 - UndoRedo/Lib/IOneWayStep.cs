using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Xoia.UndoRedo
{

    public interface IOneWayStep
    {
        void Do(IStore store, Action onComplete);
    }

}