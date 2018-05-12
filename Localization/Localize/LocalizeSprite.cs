using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeSprite : ALocalize {

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            InitializeElement();
        }

        protected override void LoadElement()
        {
            if (_image != null) { 
                _image.sprite = GameManager.Instance.Localization.GetSprite(Key);
            } else
            {
                Log.WarningLocalization("Missing SPRITE to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}