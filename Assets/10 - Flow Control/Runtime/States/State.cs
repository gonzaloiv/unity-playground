using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlowControl
{

    [Serializable]
    public class State : IState
    {

        public Action onEnter;
        public Action onExit;

        protected List<IShowable> showables;
        protected List<IHideable> hideables;
        protected List<string> sceneNames;

        public string Route { get; set; }

        public State()
        {
            this.Route = this.GetType().Name;
            this.showables = new List<IShowable>();
            this.hideables = new List<IHideable>();
            this.sceneNames = new List<string>();
        }

        public void Show(params IShowable[] showables)
        {
            foreach (IShowable showable in showables)
            {
                this.showables.Add(showable);
            }
        }

        public void Hide(params IHideable[] hideables)
        {
            foreach (IHideable hideable in hideables)
            {
                this.hideables.Add(hideable);
            }
        }

        public void Scenes(params string[] sceneNames)
        {
            foreach (string sceneName in sceneNames)
            {
                this.sceneNames.Add(sceneName);
            }
        }

        public virtual void Enter()
        {
            onEnter?.Invoke();
            showables.ForEach(showable => showable.Show());
            sceneNames.ForEach(sceneName => SceneManager.LoadSceneAsync(sceneName));
        }

        public virtual void Exit()
        {
            onExit?.Invoke();
            hideables.ForEach(hideable => hideable.Hide());
        }

    }

}