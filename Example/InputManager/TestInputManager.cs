using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;

public class TestInputManager : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.SimpleLeftClick += LeftClick;
        InputManager.Instance.SimpleRightClick += RightClick;
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
