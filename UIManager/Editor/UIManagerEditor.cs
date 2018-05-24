using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SKU {
    public class UIManagerEditor : Editor {

        [MenuItem("SKU/Initialize/UIManager")]
        private static void InitializeUIManager()
        {
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

            //Create tags
            AddTag(tagManager);

            //Save the modification
            tagManager.ApplyModifiedProperties();
            tagManager.Update();
        }

        private static void AddTag(SerializedObject tagManager)
        {
            SerializedProperty tagsProp = tagManager.FindProperty("tags");

            List<string> tagsToAdd = new List<string>();
            tagsToAdd.Add(UIManager.kTagCanvas);

            for (int i = 0; i < tagsToAdd.Count; ++i)
            {
                bool isPresent = false;
                for (int tagIndex = 0; tagIndex < tagsProp.arraySize; ++tagIndex)
                {
                    if (tagsProp.GetArrayElementAtIndex(tagIndex).stringValue.Equals(tagsToAdd[i]))
                    {
                        isPresent = true;
                        break;
                    }
                }

                if (!isPresent)
                {
                    tagsProp.InsertArrayElementAtIndex(0);
                    tagsProp.GetArrayElementAtIndex(0).stringValue = tagsToAdd[i];
                    Log.Editor("Tag [" + tagsToAdd[i] + "] added.");
                } else
                {
                    Log.Editor("Tag [" + tagsToAdd[i] + "] already present.");
                }
            }
        }
    }
}