using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace StateMachine
{

    [Serializable]
    public class StateMachine
    {

        public State currentState;
        protected List<State> states;
        protected Stack<Type> previousStates;

        public bool HasPreviousStates => previousStates.Count > 0;

        public StateMachine()
        {
            this.states = new List<State>();
            this.previousStates = new Stack<Type>();
        }

        public virtual void AddState(State state)
        {
            this.states.Add(state);
        }

        public virtual void ChangeState(Type type)
        {
            if (currentState != null)
            {
                previousStates.Push(currentState.GetType());
                currentState.Exit();
            }
            currentState = GetStateByType(type);
            currentState.Enter();
        }

        public virtual void ChangeState<T>() where T : State
        {
            ChangeState(typeof(T));
        }

        public virtual void Return()
        {
            Assert.IsNotNull(currentState);
            Type previousStateType = previousStates.Pop();
            currentState.Exit();
            currentState = GetStateByType(previousStateType);
            currentState.Enter();
        }

        public virtual bool IsCurrentState<T>() where T : State
        {
            if (currentState == null)
                return false;
            return currentState.GetType().Equals(typeof(T));
        }

        protected virtual State GetStateByType(Type type)
        {
            foreach (State state in states)
            {
                if (type.IsAssignableFrom(state.GetType()))
                    return state;
            }
            throw new Exception(type.ToString() + " not found!");
        }

    }

}
