using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Xoia.UndoRedo
{

    public interface IStore
    {
        bool IsInInitialStep { get; }
        bool IsInLastStep { get; }
        void Do(ITwoWayStep step);
        void Do(IOneWayStep step);
        void Undo();
        void Redo();
        void Clear();
        void AddListener<T>(Action onComplete) where T : IStep;
        void RemoveListener<T>(Action onComplete) where T : IStep;
    }

}