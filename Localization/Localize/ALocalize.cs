using UnityEngine;

namespace SKU { 
    public abstract class ALocalize : MonoBehaviour {
        public string Key = string.Empty;

        protected abstract void LoadElement();

        protected bool IsKeyEmpty()
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