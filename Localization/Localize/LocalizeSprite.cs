using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeSprite : ALocalize {

        private Image _image;

        private void Start()
        {
            bool gotError = false;

            _image = GetComponent<Image>();
            if (_image == null)
            {
                Log.Localization("Missing sprite to be localized on the gameobject [" + gameObject.name + "]", gameObject);
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
            _image.sprite = GameManager.Instance.Localization.GetSprite(Key);
        }

        public override void ReloadLocalization()
        {
            LoadElement();
        }
    }
}