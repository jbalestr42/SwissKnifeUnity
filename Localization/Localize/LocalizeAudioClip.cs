using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU { 
    public class LocalizeAudioClip : ALocalize {

        private AudioSource _audioSource;

        private void Start()
        {
            bool gotError = false;

            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                Log.Localization("Missing AudioClip to be localized on the gameobject [" + gameObject.name + "]", gameObject);
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
            _audioSource.clip = GameManager.Instance.Localization.GetAudioClip(Key);
        }

        public override void ReloadLocalization()
        {
            LoadElement();
        }
    }
}