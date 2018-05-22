using System.Collections.Generic;
using UnityEngine;

namespace SKU {

    [CreateAssetMenu(fileName = "LocalizationsManager", menuName = "SKU/Managers/Localizations Manager")]
    public class LocalizationManager : AManagers{

        #region Variables

        private const string kDefaultLanguage = "en-US";

        [SerializeField]
        private StringLanguageDictionary Languages = StringLanguageDictionary.New<StringLanguageDictionary>();
        private Dictionary<string, Language> _languages
        {
            get { return Languages.dictionary; }
        }

        private List<ALocalizeBase> _localizedElements;

        private string _currentLanguageKey = string.Empty;
        private Language _currentLanguage;

        public static LocalizationManager Instance
        {
            get { return GameManager.Instance.Get(typeof(LocalizationManager)) as LocalizationManager; }
        }

        #endregion

        #region Methods

        public void LoadLanguage(string languageKey, bool gameInitialization = false)
        {
            if (languageKey == _currentLanguageKey)
            {
                return;
            }

            _currentLanguage = null;

            _languages.TryGetValue(languageKey, out _currentLanguage);

            if (_currentLanguage == null)
            {
                Log.WarningLocalization("The language [" + languageKey + "] is not present inside the localization manager.");
                return;
            }

            PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsKey, languageKey);
            PlayerPrefs.Save();
            _currentLanguageKey = languageKey;

            if (!_currentLanguage.DeserializeTextFile())
            {
                return;
            }

            if (!gameInitialization)
            {
                for(int i = 0; i < _localizedElements.Count; ++i)
                {
                    _localizedElements[i].LoadLocalization();
                }
            }
        }

        public void AddLocalizedElement(ALocalizeBase item)
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

        public override void Init()
        {
            _localizedElements = new List<ALocalizeBase>();

            if (!PlayerPrefs.HasKey(PlayerPrefsKey.kplayerPrefsKey))
            {
                PlayerPrefs.SetString(PlayerPrefsKey.kplayerPrefsKey, kDefaultLanguage);
                PlayerPrefs.Save();
            }

            LoadLanguage(PlayerPrefs.GetString(PlayerPrefsKey.kplayerPrefsKey), true);
        }

        #endregion
    }
}