using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;
using SKU.StateMachine;

public class ExampleStateMachineMain : MonoBehaviour {

    StateMachine _machine;

	void Awake()
    {
        Log.StateMachine("Create State Machine");
        _machine = new StateMachine();
    }

    void Start()
    {
        Log.StateMachine("Initialize State Machine");
        _machine.Initialize<ExampleGenericStateFirst>();

        Log.StateMachine("Do");
        _machine.Do();

        Log.StateMachine("Change State");
        Log.StateMachine("Can Go To Second ? " + _machine.CanGoTo<ExampleGenericStateSecond>().ToString());
        _machine.GoTo<ExampleGenericStateSecond>();
    }
}
