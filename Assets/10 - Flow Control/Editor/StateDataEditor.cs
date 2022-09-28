using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace FlowControl
{

    [CustomEditor(typeof(StateData))]
    public class EditorStateData : Editor
    {

        private StateData stateData;
        private SceneNamesPanelEditor scenesPanel = new SceneNamesPanelEditor();
        private int showablesIndex = 0;

        private void OnEnable()
        {
            stateData = (StateData)target;
        }

        public override void OnInspectorGUI()
        {
            OnRouteGUI();
            scenesPanel.OnGUI(stateData);
            OnShowableTypesGUI();
            Save();
        }

        private void OnRouteGUI()
        {
            EditorGUILayout.LabelField("Route");
            stateData.route = EditorGUILayout.TextField(stateData.route);
        }

        private void OnShowableTypesGUI()
        {
            List<Type> showables = ReflectionUtil.GetTypes<IShowable>();
            string[] typeNames = showables.Select(type => type.ToString()).ToArray();
            EditorGUILayout.LabelField("IShowable Types");
            for (int i = 0; i < stateData.showables.Count; i++)
            {
                EditorGUILayout.LabelField($"0{i + 1} - IShowable Type", stateData.showables[i]);
                if (GUILayout.Button("Delete"))
                    stateData.RemoveShowable(stateData.showables[i]);
            }
            showablesIndex = EditorGUILayout.Popup(showablesIndex, typeNames);
            if (GUILayout.Button("Add type"))
                stateData.AddShowable(showables[showablesIndex].Name);
        }

        private void Save()
        {
            if (GUI.changed)
                EditorUtility.SetDirty(stateData);
        }

    }

}
