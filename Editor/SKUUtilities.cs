using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace SKU
{
    public class SKUUtilities : Editor
    {

        [MenuItem("SKU/Delete Example Folders")]
        private static void DeleteAllExampleFolders()
        {
            string path = Application.dataPath + "/SKU";

            RecursiveDeletion(path);
            AssetDatabase.Refresh();

            Log.Editor("Example folders deletion complete.");
        }

        private static void RecursiveDeletion(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                if (directory.Contains("Example"))
                {
                    Directory.Delete(directory, true);
                    Log.Editor("Folder deleted: + " + directory);
                } else
                {
                    RecursiveDeletion(directory);
                }
            }
        }
    }
}