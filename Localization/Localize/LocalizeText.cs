using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeText : ALocalize {

        private Text _text;

        private void Start()
        {
            bool gotError = false;

            _text = GetComponent<Text>();
            if (_text == null)
            {
                Log.WarningLocalization("Missing text to be localized on the gameobject [" + gameObject.name + "]", gameObject);
                gotError = true;
            }

            if (IsKeyEmpty())
            {
                gotError = true;
            }

            if (gotError)
            {
                return;
            }

            GameManager.Instance.Localization.AddLocalizedText(this);
            LoadElement();
        }

        protected override void LoadElement()
        {
            _text.text = GameManager.Instance.Localization.GetString(Key);
        }
    }
}