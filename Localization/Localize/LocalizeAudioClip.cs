using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeAudioClip : ALocalize {

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            InitializeElement();
        }

        protected override void LoadElement()
        {
            if (_audioSource != null)
            {
                _audioSource.clip = GameManager.Instance.Localization.GetAudioClip(Key);
            }
            else
            {
                Log.WarningLocalization("Missing AUDIOCLIP to be localized on the gameobject [" + gameObject.name + "]", gameObject);
            }
        }
    }
}