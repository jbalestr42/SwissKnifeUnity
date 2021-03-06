﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeText : ALocalize<Text> {

        public override void LoadLocalization()
        {
            if (_localizationContainer != null)
            {
                _localizationContainer.text = LocalizationManager.Instance.GetString(Key);
            }
            else
            {
                Log.WarningLocalization("Missing TEXT to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}