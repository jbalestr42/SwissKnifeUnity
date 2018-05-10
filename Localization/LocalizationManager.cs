using System.Collections.Generic;
using UnityEngine;

namespace SKU { 

    public class LocalizationManager : MonoBehaviour{

        #region Variables

        private const string kDefaultLanguage = "en-US";

        public List<Language> _languagesToLoad;

        private List<ALocalize> _localizedElements;
        private Dictionary<string, Language> _languages;
        private string _currentLanguageKey = kDefaultLanguage;
        private string _lastLanguageKey = kDefaultLanguage;
        private Language _currentLanguage;

        #endregion

        #region Methods

        public void Init()
        {
            _localizedElements = new List<ALocalize>();
            _languages = new Dictionary<string, Language>();

            if (!PlayerPrefs.HasKey(PlayerPrefsKey.kplayerPrefsKey))
            {
                PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsKey, kDefaultLanguage);
                PlayerPrefs.Save();
            }
            _currentLanguageKey = PlayerPrefs.GetString(PlayerPrefsKey.kplayerPrefsKey);

            LoadLanguages();
            LoadLanguage();
        }

        private void SetPlayerPrefs(string languageKey)
        {
            PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsKey, languageKey);
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

        public string GetString(string key)
        {
            Log.Localization("GetString");
            return _currentLanguage.GetString(key);
        }

        public Sprite GetSprite(string key)
        {
            return _currentLanguage.GetSprite(key);
        }

        public AudioClip GetAudioClip(string key)
        {
            return _currentLanguage.GetAudioClip(key);
        }

        #endregion
    }
}