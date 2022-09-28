using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FlowControl
{

    public class StateBuilder<T> where T : State, new()
    {

        protected T state;

        public StateBuilder()
        {
            state = new T();
        }

        public StateBuilder(T state)
        {
            this.state = state;
        }

        public StateBuilder<T> Route(string route)
        {
            state.Route = route;
            return this;
        }

        public StateBuilder<T> Enter(Action onEnter)
        {
            state.onEnter = onEnter;
            return this;
        }

        public StateBuilder<T> Exit(Action onExit)
        {
            state.onExit = onExit;
            return this;
        }

        public StateBuilder<T> Show(params IShowable[] showables)
        {
            state.Show(showables);
            return this;
        }

        public StateBuilder<T> Hide(params IHideable[] hideables)
        {
            state.Hide(hideables);
            return this;
        }

        public StateBuilder<T> Scenes(params string[] sceneNames)
        {
            state.Scenes(sceneNames);
            return this;
        }

        public T Build()
        {
            return state;
        }

    }

}