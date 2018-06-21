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
        var popup = PopupManager.Instance.Get<InputFieldPopupPanel>(typeof(InputFieldPopupPanel));
        popup.Initialize("Enter a number",
            (string value) => {
            Log.Gameplay("Value is " + value);
            }, checkFunction,
        IsNotANumber);
    }

    public void OnClickFourth()
    {
        var popup = PopupManager.Instance.Get<TextButtonPopup>(typeof(TextButtonPopup));
        popup.Initialize("This is a description set by the user");
    }

    private bool checkFunction(string value)
    {
        int number = 0;
        if (int.TryParse(value, out number)) {
            return true;
        }

        return false;
    }

    private void IsNotANumber(string value)
    {
        var popup = PopupManager.Instance.Get<PopupExample>(typeof(PopupExample));
        popup.Init("[" + value + "] is not a number");
    }
}
