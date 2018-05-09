using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SKU { 
    public abstract class ALocalize : MonoBehaviour {
        public string Key = string.Empty;

        public abstract void ReloadLocalization();

        protected abstract void LoadElement();
        protected bool IsKeyEmpty()
        {
            if (string.IsNullOrEmpty(Key))
            {
                Log.Localization("Missing key for the localization the gameobject [" + gameObject.name + "]", gameObject);
                return true;
            }

            return false;
        }
    }
}