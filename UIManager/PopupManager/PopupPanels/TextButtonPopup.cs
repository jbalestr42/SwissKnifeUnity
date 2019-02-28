using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SKU
{
    public class TextButtonPopup : PopupPanelBase
    {
        [SerializeField]
        private Button _okButton = null;

        [SerializeField]
        private Text _description = null;

        public void Initialize(string descriptionText, Action okButtonAdditionalAction = null)
        {
            _description.text = descriptionText;

            _okButton.onClick.AddListener(
                delegate
                {
                    if (okButtonAdditionalAction != null)
                    {
                        okButtonAdditionalAction();
                    }

                    OnClickCloseButton();
                }
            );
        }
    }
}