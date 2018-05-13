using UnityEngine;

namespace SKU { 
    public abstract class ALocalizeBase : MonoBehaviour {
        public string Key = string.Empty;

        public abstract void LoadLocalization();

        protected void InitializeElement()
        {
            GameManager.Instance.Localization.AddLocalizedElement(this);

            if (IsKeyEmpty())
            {
                Log.WarningLocalization("Missing key for the localization the gameobject [" + gameObject.name + "]", gameObject);
            }
            else
            {
                LoadLocalization();
            }
        }

        private bool IsKeyEmpty()
        {
            return string.IsNullOrEmpty(Key);
        }
    }

    public abstract class ALocalize<T> : ALocalizeBase {

        protected T _localizationContainer;

        protected void Start()
        {
            _localizationContainer = GetComponent<T>();
            InitializeElement();
        }
    }
}