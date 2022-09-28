using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace FlowControl
{

    [Serializable]
    public class StateFactory
    {

        private IShowable[] showables;

        public void Register(params IShowable[] showables)
        {
            this.showables = showables;
        }

        public State Convert(StateData stateData)
        {
            StateBuilder<State> builder = new StateBuilder<State>();
            builder.Route(stateData.route);
            builder.Scenes(stateData.sceneNames.ToArray());
            builder.Show(GetShowables(stateData.showables));
            return builder.Build();
        }

        private IShowable[] GetShowables(List<string> toGet)
        {
            List<IShowable> result = new List<IShowable>();
            foreach (string value in toGet)
            {
                IShowable showable = showables.FirstOrDefault(showable => string.Equals(value, showable.GetType().Name));
                result.Add(showable);
            }
            return result.ToArray();
        }

    }

}