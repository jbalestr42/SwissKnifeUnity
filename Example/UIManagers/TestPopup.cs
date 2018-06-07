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
        var popup = PopupManager.Instance.Get<IntInputFieldPopupPanel>(typeof(IntInputFieldPopupPanel));
        popup.Initialize((string value) => {
            Log.Gameplay("Value is " + value);
        });
    }
}
