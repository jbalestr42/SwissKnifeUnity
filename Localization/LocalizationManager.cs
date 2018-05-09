using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKU { 

    public class LocalizationManager : MonoBehaviour{

        #region Variables

        private const string kDefaultLanguage = "en-US";
        private const string kplayerPrefsKey = "LanguageSelected";

        public List<Language> _languagesToLoad;

        private static LocalizationManager _instance;
        private List<ALocalize> _localizedElements;
        private Dictionary<string, Language> _languages;
        private string _currentLanguageKey = kDefaultLanguage;
        private string _lastLanguageKey = kDefaultLanguage;
        private Language _currentLanguage;

        #endregion

        #region Constructors_Getters_Setters

        private void Awake()
        {
            _instance = this;
            _localizedElements = new List<ALocalize>();
            _languages = new Dictionary<string, Language>();

            if (!PlayerPrefs.HasKey(kplayerPrefsKey))
            {
                PlayerPrefs.SetString(kplayerPrefsKey, kDefaultLanguage);
                PlayerPrefs.Save();
            }
            _currentLanguageKey = PlayerPrefs.GetString(kplayerPrefsKey);

            LoadLanguages();
            LoadLanguage();
        }

        public static LocalizationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Log.Localization("Wait until the end of the first awake of the game for the initialization of the localization manager");
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        private void SetPlayerPrefs(string languageKey)
        {
            PlayerPrefs.SetString(kplayerPrefsKey, languageKey);
            PlayerPrefs.Save();
            _currentLanguageKey = languageKey;
        }

        public void LoadLanguages()
        {
            for (int i = 0; i < _languagesToLoad.Count; ++i)
            {
                _languages.Add(_languagesToLoad[i].LanguageKey, _languagesToLoad[i]);
            }
        }

        public void ChangeLanguage(string newKey)
        {
            SetPlayerPrefs(newKey);
            LoadLanguage();
        }

        private void LoadLanguage(bool gameInitialization = false)
        {
            _currentLanguage = null;
            _languages.TryGetValue(_currentLanguageKey, out _currentLanguage);

            if (_currentLanguage == null)
            {
                Log.Localization("The language " + _currentLanguageKey + " is not present inside the localization manager.");
                SetPlayerPrefs(_lastLanguageKey);
                return;
            }

            _lastLanguageKey = _currentLanguageKey;
            _currentLanguage.Load();

            if (!gameInitialization)
            {
                for(int i = 0; i < _localizedElements.Count; ++i)
                {
                    _localizedElements[i].ReloadLocalization();
                }
            }
        }

        public void AddLocalizedText(ALocalize item)
        {
            _localizedElements.Add(item);
        }

        public string Get(string key)
        {
            return _currentLanguage.Get(key);
        }

        #endregion
    }
}