using UnityEngine;

namespace SKU {

    #region Abstract class

    [System.Serializable]
    public class LanguageElement<T> {
        public string Description;

        [SerializeField]
        private T _localization;

        public T Get()
        {
            return _localization;
        }
    }

    #endregion

    #region Inherits Membres

    [System.Serializable]
    public class LanguageElementSprite : LanguageElement<Sprite> { }

    [System.Serializable]
    public class LanguageElementAudioClip : LanguageElement<AudioClip> { }

    #endregion
}