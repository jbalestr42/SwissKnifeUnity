using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SKU;
using System;

public class IntInputFieldPopupPanel : APopupPanelBase {

    [SerializeField]
    private Button _okButton;

    [SerializeField]
    private Button _cancelButton;

    [SerializeField]
    private InputField _inputField;

    public void Initialize(Action<string> callback)
    {
        _cancelButton.onClick.AddListener(OnClickCloseButton);
        _okButton.onClick.AddListener(
            delegate {
                callback(_inputField.text);
                OnClickCloseButton(); }
            );
    }
}
