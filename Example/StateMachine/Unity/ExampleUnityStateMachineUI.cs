using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU.StateMachine;

public class ExampleUnityStateMachineUI : MonoBehaviour {

    public UnityStateMachine StateMachine;

	public void UI_OnDestroy()
    {
        Destroy(StateMachine.gameObject);
    }

    public void UI_GoToFirstState()
    {
        StateMachine.GoTo<ExampleUnityStateFirst>();
    }

    public void UI_GoToSecondState()
    {
        StateMachine.GoTo<ExampleUnityStateSecond>();
    }
}
