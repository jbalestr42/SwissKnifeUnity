using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SKU { 

    [CreateAssetMenu(fileName = "Language", menuName = "SKU/DefaultLanguage")]
    public class Language : ScriptableObject {
        public string LanguageKey;
        public List<LanguageElement> Elements;

        private Dictionary<string, string> _elements;

        public void Load()
        {
            _elements = new Dictionary<string, string>();

            for(int i = 0; i < Elements.Count; ++i)
            {
                _elements.Add(Elements[i].Key, Elements[i].Text);
            }
        }

        public string Get(string key)
        {
            string value;
            _elements.TryGetValue(key, out value);

            return value;
        }
    }
}