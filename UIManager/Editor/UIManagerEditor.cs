using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SKU
{
    [CustomEditor(typeof(UIManager))]
    public class UIManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Create needed tags"))
            {
                InitializeUIManager((UIManager)target);
            }

            if (GUILayout.Button("Use current tags for UIManager"))
            {
                SetCurrentTagUsed((UIManager)target);
            }
        }

        private void InitializeUIManager(UIManager uiManager)
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

            //Create tags
            AddTag(tagManager, uiManager);

            //Save the modification
            tagManager.ApplyModifiedProperties();
            tagManager.Update();
        }

        private static void AddTag(SerializedObject tagManager, UIManager uiManager)
        {
            SerializedProperty tagsProp = tagManager.FindProperty("tags");

            foreach (KeyValuePair<string, GameObject> pair in uiManager._canvasPrefab)
            {
                bool isPresent = false;
                for (int tagIndex = 0; tagIndex < tagsProp.arraySize; ++tagIndex)
                {
                    if (tagsProp.GetArrayElementAtIndex(tagIndex).stringValue.Equals(pair.Key))
                    {
                        isPresent = true;
                        break;
                    }
                }

                if (!isPresent)
                {
                    tagsProp.InsertArrayElementAtIndex(0);
                    tagsProp.GetArrayElementAtIndex(0).stringValue = pair.Key;
                    Log.Editor("Tag [" + pair.Key + "] added.");
                }
                else
                {
                    Log.Editor("Tag [" + pair.Key + "] already present.");
                }
            }
        }

        private void SetCurrentTagUsed(UIManager uiManager)
        {
            Log.UI("Tags used for the UIManager: ");
            foreach (KeyValuePair<string, GameObject> pair in uiManager._canvasPrefab)
            {
                Log.UI("- " + pair.Key);
            }
        }
    }
}