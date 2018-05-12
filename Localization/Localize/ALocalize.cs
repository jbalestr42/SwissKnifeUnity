using UnityEngine;

namespace SKU { 
    public abstract class ALocalizeBase : MonoBehaviour {
        public string Key = string.Empty;

        public abstract void ReloadLocalization();
    }

    public abstract class ALocalize<T> : ALocalizeBase {

        protected T _localizationContainer;

        protected void Start()
        {
            _localizationContainer = GetComponent<T>();
            InitializeElement();
        }

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

        public override void ReloadLocalization()
        {
            LoadElement();
        }
    }
}