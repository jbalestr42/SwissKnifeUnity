using UnityEngine;

namespace SKU
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject LocalizationManagerPrefab;

        LocalizationManager _localizationMgr;

        #region Properties

        public LocalizationManager Localization
        {
            get { return _localizationMgr; }
        }

        #endregion

        #region Unity_Methods

        private void Awake()
        {
            _localizationMgr = Instantiate(LocalizationManagerPrefab, transform).GetComponent<LocalizationManager>();
            _localizationMgr.Init();
        }

        #endregion
    }
}