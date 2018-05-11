using System.Collections.Generic;
using UnityEngine;

namespace SKU { 

    [CreateAssetMenu(fileName = "Language", menuName = "SKU/DefaultLanguage")]
    public class Language : ScriptableObject {
        public string LanguageKey;

        [SerializeField]
        private StringLETextDictionary Texts = StringLETextDictionary.New<StringLETextDictionary>();
        private Dictionary<string, LanguageElementText> _texts
        {
            get { return Texts.dictionary; }
        }

        [SerializeField]
        private StringLESpriteDictionary Sprites = StringLESpriteDictionary.New<StringLESpriteDictionary>();
        private Dictionary<string, LanguageElementSprite> _sprites
        {
            get { return Sprites.dictionary; }
        }

        [SerializeField]
        private StringLEAudioClipDictionary AudioClips = StringLEAudioClipDictionary.New<StringLEAudioClipDictionary>();
        private Dictionary<string, LanguageElementAudioClip> _audioClips
        {
            get { return AudioClips.dictionary; }
        }

        public string GetString(string key)
        {
            LanguageElementText value;

            if (!_texts.ContainsKey(key))
            {
                Log.WarningLocalization(LanguageKey + " | Missing STRING key: " + key);
                return key;
            }

            _texts.TryGetValue(key, out value);
            return value.Get();
        }

        public Sprite GetSprite(string key)
        {
            LanguageElementSprite value;

            if (!_sprites.ContainsKey(key))
            {
                Log.WarningLocalization(LanguageKey + " | Missing SPRITE key: " + key);
                return null;
            }

            _sprites.TryGetValue(key, out value);
            return value.Get();
        }

        public AudioClip GetAudioClip(string key)
        {
            LanguageElementAudioClip value;

            if (!_audioClips.ContainsKey(key))
            {
                Log.WarningLocalization(LanguageKey + " | Missing AUDIOCLIP key: " + key);
                return null;
            }

            _audioClips.TryGetValue(key, out value);
            return value.Get();
        }
    }
}