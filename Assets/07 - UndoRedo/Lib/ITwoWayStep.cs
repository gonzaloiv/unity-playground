using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Xoia.UndoRedo
{

    public interface ITwoWayStep
    {
        void Do(IStore store, Action onComplete);
        void Undo(Action onComplete);
        void Redo(Action onComplete);
    }

}