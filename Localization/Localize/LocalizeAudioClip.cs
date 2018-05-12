﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeAudioClip : ALocalize<AudioSource> {

        protected override void LoadElement()
        {
            if (_localizationContainer != null)
            {
                _localizationContainer.clip = GameManager.Instance.Localization.GetAudioClip(Key);
            }
            else
            {
                Log.WarningLocalization("Missing AUDIOCLIP to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}