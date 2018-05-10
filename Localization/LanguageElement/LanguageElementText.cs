using UnityEngine;

namespace SKU
{
    [System.Serializable]
    public class LanguageElementText : ALanguageElement
    {
        [SerializeField]
        private string _localization;

        public string Get()
        {
            return _localization;
        }
    }
}