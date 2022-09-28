using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace FlowControl
{

    public class SceneNamesPanelEditor
    {

        private int sceneIndex = 0;

        public void OnGUI(StateData stateData)
        {
            string[] scenePaths = GetScenePaths();
            for (int i = 0; i < stateData.sceneNames.Count; i++)
            {
                EditorGUILayout.LabelField($"0{i + 1} - Scene", stateData.sceneNames[i]);
                if (GUILayout.Button("Delete"))
                    stateData.sceneNames.Remove(stateData.sceneNames[i]);
            }
            sceneIndex = EditorGUILayout.Popup(sceneIndex, scenePaths);
            if (GUILayout.Button("Add scene"))
            {
                string sceneName = Path.GetFileNameWithoutExtension(scenePaths[sceneIndex]);
                stateData.sceneNames.Add(sceneName);
            }
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

    }

}