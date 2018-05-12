using UnityEngine;

namespace SKU { 
    public abstract class ALocalize : MonoBehaviour {

        public string Key = string.Empty;

        protected abstract void LoadElement();

        protected void InitializeElement()
        {
            GameManager.Instance.Localization.AddLocalizedElement(this);

            if (IsKeyEmpty())
            {
                Log.WarningLocalization("Missing key for the localization the gameobject [" + gameObject.name + "]", gameObject);
            } else
            {
                LoadElement();
            }
        }

        private bool IsKeyEmpty()
        {
            if (string.IsNullOrEmpty(Key))
            {
                return true;
            }

            return false;
        }

        public void ReloadLocalization()
        {
            LoadElement();
        }
    }
}