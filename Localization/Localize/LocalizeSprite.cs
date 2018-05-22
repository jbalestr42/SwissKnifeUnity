using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeSprite : ALocalize<Image> {

        public override void LoadLocalization()
        {
            if (_localizationContainer != null)
            {
                _localizationContainer.sprite = LocalizationManager.Instance.GetSprite(Key);
            } else
            {
                Log.WarningLocalization("Missing SPRITE to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}