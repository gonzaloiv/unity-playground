using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{

    [Serializable]
    public abstract class State
    {

        protected StateMachine stateMachine;

        public State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            AddListeners();
        }

        public virtual void Exit()
        {
            RemoveListeners();
        }

        protected virtual void AddListeners() { }

        protected virtual void RemoveListeners() { }

    }

}