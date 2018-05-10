using UnityEngine;

namespace SKU
{
    [System.Serializable]
    public class LanguageElementAudioClip : ALanguageElement
    {
        [SerializeField]
        private AudioClip _localization;

        public AudioClip Get()
        {
            return _localization;
        }
    }
}