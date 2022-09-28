using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Reflection;
using System.Linq;

namespace FlowControl
{

    [CreateAssetMenu(fileName = "StateData", menuName = "FlowControl/StateData")]
    public class StateData : ScriptableObject
    {

        public string route;
        public List<string> sceneNames = new List<string>();
        public List<string> showables = new List<string>();

        public void AddShowable(string toAdd)
        {
            string showable = GetShowable(toAdd);
            if (string.IsNullOrEmpty(showable))
                showables.Add(toAdd);
        }

        public void RemoveShowable(string toRemove)
        {
            string showable = GetShowable(toRemove);
            if (string.IsNullOrEmpty(showable))
                showables.Remove(toRemove);
        }

        public string GetShowable(string other)
        {
            return showables.FirstOrDefault(type => type == other);
        }

    }

}