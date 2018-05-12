using System;
using System.Collections.Generic;
using UnityEngine;

namespace SKU { 

    [CreateAssetMenu(fileName = "Language", menuName = "SKU/DefaultLanguage")]
    public class Language : ScriptableObject {
        public string LanguageKey;

        public TextAsset TextsSourceFile;
        private Dictionary<string, string> _texts;

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

        /// <summary>
        /// This function desierialize the file containg all texts localization.
        /// It returns false if the function fails
        /// </summary>
        public bool DeserializeTextFile()
        {
            _texts = new Dictionary<string, string>();

            if (TextsSourceFile == null)
            {
                Log.WarningLocalization(LanguageKey + " - Text file is missing for string localization");
                return false;
            }

            string[] lines = TextsSourceFile.text.Split('\n');
            for (int i = 0; i < lines.Length; ++i)
            {
                string[] fragment = lines[i].Split(';');
                string key = fragment[0];
                string value = fragment[2];

                for (int j = 3; j < fragment.Length; ++j)
                {
                    value += ";" + fragment[j];
                }

                _texts.Add(key, value);
            }

            return true;
        }

        public string GetString(string key)
        {
            string value;

            _texts.TryGetValue(key, out value);

            if (value == null)
            {
                Log.WarningLocalization(LanguageKey + " | Missing STRING key: " + key);
                return null;
            }
            
            return value;
        }

        public Sprite GetSprite(string key)
        {
            LanguageElementSprite value;

            _sprites.TryGetValue(key, out value);

            if (value == null)
            {
                Log.WarningLocalization(LanguageKey + " | Missing SPRITE key: " + key);
                return null;
            }

            return value.Get();
        }

        public AudioClip GetAudioClip(string key)
        {
            LanguageElementAudioClip value;

            _audioClips.TryGetValue(key, out value);

            if (value == null)
            {
                Log.WarningLocalization(LanguageKey + " | Missing AUDIOCLIP key: " + key);
                return null;
            }

            return value.Get();
        }
    }
}