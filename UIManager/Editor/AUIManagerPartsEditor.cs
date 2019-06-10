using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SKU
{
    [CustomEditor(typeof(AUIManagerParts), true)]
    public class AUIManagerPartsEditor : Editor
    {
        string[] _choices;
        int _choiceIndex = 0;

        public override void OnInspectorGUI()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsKey.kplayerPrefsCanvasSelected)) {
                Log.Error("Initialize the Canvas used byt the UIManager by clicking the button inside the Scriptable Object of the UIManager");
                return;
            }

            var managerParts = target as AUIManagerParts;
            _choices = PlayerPrefs.GetString(PlayerPrefsKey.kplayerPrefsCanvasSelected).Split('#');

            for (int i = 0; i < _choices.Length; ++i)
            {
                if (managerParts.CanvasToInstantiate == _choices[i])
                {
                    _choiceIndex = i;
                    break;
                }
            }

            DrawDefaultInspector();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Canvas to instantiate the layer");

            _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);

            //managerParts.CanvasToInstantiate = _choices[_choiceIndex];
            EditorUtility.SetDirty(target);
        }
    }
}