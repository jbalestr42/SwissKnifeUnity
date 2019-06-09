using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;

public class TestInputManager : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.AddListener(ClickType.Left, LeftClick);
        InputManager.Instance.AddListener(ClickType.Right, RightClick);
    }

    private void OnDisable()
    {
        InputManager.Instance.RemoveListener(ClickType.Left, LeftClick);
        InputManager.Instance.RemoveListener(ClickType.Left, LeftClick);
    }

    private void LeftClick()
    {
        Debug.Log("Left click detected");
    }

    private void RightClick()
    {
        Debug.Log("Right click detected");
    }
}
