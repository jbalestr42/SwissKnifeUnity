using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
                SetCurrentTagUsed((UIManager)target);
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

            for (int i = 0; i < uiManager.Canvas.Count; ++i)
            {
                bool isPresent = false;
                string currentCanvas = uiManager.Canvas[i];

                if (string.IsNullOrEmpty(currentCanvas))
                {
                    Log.UI(i + " - Canvas EMPTY !");
                    continue;
                }

                for (int tagIndex = 0; tagIndex < tagsProp.arraySize; ++tagIndex)
                {
                    if (tagsProp.GetArrayElementAtIndex(tagIndex).stringValue.Equals(currentCanvas))
                    {
                        isPresent = true;
                        break;
                    }
                }

                if (!isPresent)
                {
                    tagsProp.InsertArrayElementAtIndex(0);
                    tagsProp.GetArrayElementAtIndex(0).stringValue = currentCanvas;
                    Log.Editor(i + " - Tag [" + currentCanvas + "] added.");
                }
                else
                {
                    Log.Editor(i + " - Tag [" + currentCanvas + "] already present.");
                }
            }
        }

        private void SetCurrentTagUsed(UIManager uiManager)
        {
            string playerPref = "";
            bool isFirst = true;
            Log.UI("Tags used for the UIManager: ");

            for (int i = 0; i < uiManager.Canvas.Count; ++i)
            {
                bool isPresent = false;
                string currentCanvas = uiManager.Canvas[i];

                if (string.IsNullOrEmpty(currentCanvas))
                {
                    Log.UI(i + " - Canvas EMPTY !");
                    continue;
                }

                Log.UI(i + " - " + currentCanvas);

                if (!isFirst)
                {
                    playerPref += "#";
                } else
                {
                    isFirst = false;
                }

                playerPref += currentCanvas;
            }

            PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsCanvasSelected, playerPref);
        }
    }
}