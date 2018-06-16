using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using SKU;

public class PopupExample : PopupPanelBase {

    public void Init(string value)
    {
        GetComponentInChildren<Text>().text = value;
    }

}