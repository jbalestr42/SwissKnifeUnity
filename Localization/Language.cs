using System.Collections.Generic;
using UnityEngine;

namespace SKU { 

    [CreateAssetMenu(fileName = "Language", menuName = "SKU/DefaultLanguage")]
    public class Language : ScriptableObject {
        public string LanguageKey;
        public List<LanguageElementText> Texts;
        public List<LanguageElementSprite> Sprites;
        public List<LanguageElementAudioClip> Sounds;


        private Dictionary<string, string> _texts;
        private Dictionary<string, Sprite> _sprites;
        private Dictionary<string, AudioClip> _audioClips;

        public void Load()
        {
            _texts = new Dictionary<string, string>();
            _sprites = new Dictionary<string, Sprite>();
            _audioClips = new Dictionary<string, AudioClip>();

            for (int i = 0; i < Texts.Count; ++i)
            {
                _texts.Add(Texts[i].Key, Texts[i].Get());
            }

            for (int i = 0; i < Sprites.Count; ++i)
            {
                _sprites.Add(Sprites[i].Key, Sprites[i].Get());
            }

            for (int i = 0; i < Sounds.Count; ++i)
            {
                _audioClips.Add(Sounds[i].Key, Sounds[i].Get());
            }
        }

        public string GetString(string key)
        {
            string value;
            _texts.TryGetValue(key, out value);

            Log.Localization("Getstring from language: " + key + " / " + value);

            return value;
        }

        public Sprite GetSprite(string key)
        {
            Sprite value;
            _sprites.TryGetValue(key, out value);

            return value;
        }

        public AudioClip GetAudioClip(string key)
        {
            AudioClip value;
            _audioClips.TryGetValue(key, out value);

            return value;
        }
    }
}