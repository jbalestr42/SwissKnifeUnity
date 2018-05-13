using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

namespace SKU
{
    public class LogFunctionalities{

	    [MenuItem("SKU/Logs/Clear All Logs %U")]
        static void ClearAllLogs()
        {
            string folder = Application.persistentDataPath + "/Logs";
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
                Directory.CreateDirectory(folder);
            }
        }

        [MenuItem("SKU/Logs/Save All Logs %I")]
        static void SaveAllLogs()
        {
            if (Application.isEditor && Application.isPlaying) 
            {
                if (!Log._hasDictionaryBeenInitialized)
                {
                    Log.Info("Log initialization");
                }

                Log.SaveLogs();
            } else
            {
                Debug.LogWarning("Logs can not be saved while the game is not running");
            }
        }
    }
}