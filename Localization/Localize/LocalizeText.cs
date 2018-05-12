using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeText : ALocalize<Text> {

        protected override void LoadElement()
        {
            if (_localizationContainer != null)
            {
                _localizationContainer.text = GameManager.Instance.Localization.GetString(Key);
            }
            else
            {
                Log.WarningLocalization("Missing TEXT to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}