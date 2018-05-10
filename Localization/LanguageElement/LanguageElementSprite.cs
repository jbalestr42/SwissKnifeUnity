using UnityEngine;

namespace SKU
{
    [System.Serializable]
    public class LanguageElementSprite : ALanguageElement
    {
        [SerializeField]
        private Sprite _localization;

        public Sprite Get()
        {
            return _localization;
        }
    }
}