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

    [CreateAssetMenu(fileName = "StateData", menuName = "Meta/FlowControl/StateData")]
    public class StateData : ScriptableObject
    {

        public string sceneName;
        public List<Type> viewTypes = new List<Type>();

        public void AddViewType(Type toAdd)
        {
            Type type = GetViewType(toAdd);
            if (type == null)
                viewTypes.Add(toAdd);
        }

        public Type GetViewType(Type other)
        {
            return viewTypes.FirstOrDefault(type => type == other);
        }

    }

    [CustomEditor(typeof(StateData))]
    public class InspectorItemHolder : Editor
    {

        private StateData stateData;
        private int sceneIndex = 0;
        private int typeIndex = 0;

        private void OnEnable()
        {
            stateData = (StateData)target;
        }

        public override void OnInspectorGUI()
        {
            OnSceneNameGUI();
            OnViewTypesGUI();
            if (GUI.changed)
                EditorUtility.SetDirty(stateData);
        }

        private void OnSceneNameGUI()
        {
            string[] scenePaths = GetScenePaths();
            EditorGUILayout.LabelField("Scene Name", stateData.sceneName);
            sceneIndex = EditorGUILayout.Popup(sceneIndex, scenePaths);
            string name = Path.GetFileNameWithoutExtension(scenePaths[sceneIndex]);
            stateData.sceneName = name;
        }

        private string[] GetScenePaths()
        {
            int length = EditorBuildSettings.scenes.Length;
            string[] sceneNames = new string[length];
            for (int i = 0; i < length; i++)
            {
                sceneNames[i] = EditorBuildSettings.scenes[i].path;
            }
            return sceneNames;
        }

        private void OnViewTypesGUI()
        {
            Type[] iViewTypes = GetIViewTypes();
            string[] typeNames = iViewTypes.Select(type => type.ToString()).ToArray();
            EditorGUILayout.LabelField("IView Types");
            for (int i = 0; i < stateData.viewTypes.Count; i++)
            {
                EditorGUILayout.LabelField($"{i} - IView Type", stateData.viewTypes[i].Name);
            }
            typeIndex = EditorGUILayout.Popup(typeIndex, typeNames);
            if (GUILayout.Button("Add type"))
                stateData.AddViewType(iViewTypes[typeIndex]);
        }

        private Type[] GetIViewTypes()
        {
            List<Type> result = new List<Type>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                List<Type> types = assembly.GetTypes()
                    .Where(type => type != typeof(IView) && typeof(IView).IsAssignableFrom(type))
                    .ToList();
                foreach (Type type in types)
                {
                    result.Add(type);
                }
            }
            return result.ToArray();
        }

    }

}