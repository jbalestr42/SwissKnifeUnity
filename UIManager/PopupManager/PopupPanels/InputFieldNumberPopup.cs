using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;

public class InputFieldNumberPopup : InputFieldPopupPanel {

    protected override bool CheckFunction(string value)
    {
        int result;
        bool isNumeric = int.TryParse(value, out result);
        if (isNumeric && !string.IsNullOrEmpty(value)) {
            return true;
        }

        return false;
    }
}
