using UnityEngine;

namespace SKU {

    #region Abstract class

    [System.Serializable]
    public abstract class ALanguageElement<T> {
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
    public class LanguageElementSprite : ALanguageElement<Sprite> { }

    [System.Serializable]
    public class LanguageElementAudioClip : ALanguageElement<AudioClip> { }

    #endregion
}