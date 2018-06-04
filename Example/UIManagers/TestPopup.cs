using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;

public class TestPopup : MonoBehaviour {

	public void OnClickOne()
    {
        PopupManager.Instance.Get<PopupExample>(typeof(PopupExample));
    }

    public void OnClickSecond()
    {
        PopupManager.Instance.Get<PopupExample>(typeof(PopupExampleSecond));
    }

    public void OnClickThird()
    {
        var popup = PopupManager.Instance.Get<InputFieldPopupPanel>(typeof(InputFieldNumberPopup));
        popup.Initialize((string value) => {
            Log.Gameplay("Value is " + value);
        }, IsNotANumber);
    }

    private void IsNotANumber(string value)
    {
        var popup = PopupManager.Instance.Get<PopupExample>(typeof(PopupExample));
        popup.Init("[" + value + "] is not a number");
    }
}
