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

    public delegate bool CheckFunction(string value);
    private CheckFunction _checkFunction;

    public void Initialize(string placeHolderText, Action<string> callback, CheckFunction callbackCheck = null, Action<string> callbackWrongInput = null)
    {
        if (callbackCheck == null)
        {
            _checkFunction = BaseCheckFunction;
        }
        else
        {
            _checkFunction = callbackCheck;
        }

        _inputField.text = placeHolderText;
        _cancelButton.onClick.AddListener(OnClickCloseButton);
        _okButton.onClick.AddListener(
            delegate
            {
                if (_checkFunction(_inputField.text))
                {
                    callback(_inputField.text);
                    OnClickCloseButton();
                }
                else
                {
                    if (callbackWrongInput != null)
                    {
                        callbackWrongInput(_inputField.text);
                    }
                }
            }
        );
    }

    private bool BaseCheckFunction(string value)
    {
        return true;
    }
}
