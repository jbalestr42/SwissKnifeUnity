using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeText : ALocalize {

        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
            InitializeElement();
        }

        protected override void LoadElement()
        {
            if (_text != null)
            {
                _text.text = GameManager.Instance.Localization.GetString(Key);
            }
            else
            {
                Log.WarningLocalization("Missing TEXT to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}