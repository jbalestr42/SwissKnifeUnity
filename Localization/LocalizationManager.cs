using System.Collections.Generic;
using UnityEngine;

namespace SKU { 

    public class LocalizationManager : MonoBehaviour{

        #region Variables

        private const string kDefaultLanguage = "en-US";

        [SerializeField]
        private StringLanguageDictionary Languages = StringLanguageDictionary.New<StringLanguageDictionary>();
        private Dictionary<string, Language> _languages
        {
            get { return Languages.dictionary; }
        }

        private List<ALocalize> _localizedElements;

        private string _currentLanguageKey = kDefaultLanguage;
        private Language _currentLanguage;

        #endregion

        #region Methods

        public void Init()
        {
            _localizedElements = new List<ALocalize>();

            if (!PlayerPrefs.HasKey(PlayerPrefsKey.kplayerPrefsKey))
            {
                PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsKey, kDefaultLanguage);
                PlayerPrefs.Save();
            }
            _currentLanguageKey = PlayerPrefs.GetString(PlayerPrefsKey.kplayerPrefsKey);
            LoadLanguage(_currentLanguageKey, true);
        }

        public void LoadLanguage(string languageKey, bool gameInitialization = false)
        {
            _currentLanguage = null;

            if (!_languages.ContainsKey(_currentLanguageKey))
            {
                Log.WarningLocalization("The language " + _currentLanguageKey + " is not present inside the localization manager.");
                return;
            }

            PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsKey, languageKey);
            PlayerPrefs.Save();
            _currentLanguageKey = languageKey;
            _languages.TryGetValue(_currentLanguageKey, out _currentLanguage);

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