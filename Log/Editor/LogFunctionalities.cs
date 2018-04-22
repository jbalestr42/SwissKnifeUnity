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
    }
}