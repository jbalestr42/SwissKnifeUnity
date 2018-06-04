using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SKU;
using System;

public class InputFieldPopupPanel : PopupPanelBase {

    [SerializeField]
    private Button _okButton;

    [SerializeField]
    private Button _cancelButton;

    [SerializeField]
    private InputField _inputField;

    public void Initialize(Action<string> callback, Action<string> callbackWrongInput = null)
    {
        _cancelButton.onClick.AddListener(OnClickCloseButton);
        _okButton.onClick.AddListener(
            delegate {
                if (CheckFunction(_inputField.text))
                {
                    callback(_inputField.text);
                    OnClickCloseButton();
                } else
                {
                    if (callbackWrongInput != null)
                    {
                        callbackWrongInput(_inputField.text);
                    }
                }
            }
            );
    }

    protected virtual bool CheckFunction(string value)
    {
        return true;
    }
}
