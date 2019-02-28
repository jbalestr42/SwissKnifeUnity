using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;
using SKU.StateMachine;

public class ExampleUnityStateFirst : UnityState {

    public override void SetPossibleTransition()
    {
        _possibleTransition.Add(typeof(ExampleUnityStateSecond));
        Log.StateMachine("First - Adding Second as possible transition");
    }


    public override void Initialize()
    {
        Log.StateMachine("First - state Initialize");
    }

    public override void OnEnter()
    {
        Log.StateMachine("First - OnEnter ");
    }

    public override void Do()
    {
        Log.StateMachine("First - Do");
    }

    public override void OnExit()
    {
        Log.StateMachine("First - OnExit");
    }

    public override void DoUpdate()
    {
        Log.StateMachine("First - Update");
    }

    public override void DoLateUpdate()
    {
        Log.StateMachine("First - LateUpdate");
    }

    public override void DoFixedUpdate()
    {
        Log.StateMachine("First - FixedUpdate");
    }

    public override void DoOnEnable()
    {
        Log.StateMachine("First - DoOnEnable");
    }

    public override void DoOnDisable()
    {
        Log.StateMachine("First - DoOnDisable");
    }

    public override void DoOnDestroy()
    {
        Log.StateMachine("First - DoOnDestroy");
    }

}

public class ExampleUnityStateSecond : UnityState
{
    public override void SetPossibleTransition()
    {
        _possibleTransition.Add(typeof(ExampleUnityStateFirst));
        Log.StateMachine("Second - Adding Second as possible transition");
    }


    public override void Initialize()
    {
        Log.StateMachine("Second - state Initialize");
    }

    public override void OnEnter()
    {
        Log.StateMachine("Second - OnEnter ");
    }

    public override void Do()
    {
        Log.StateMachine("Second - Do");
    }

    public override void OnExit()
    {
        Log.StateMachine("Second - OnExit");
    }

    public override void DoUpdate()
    {
        Log.StateMachine("Second - Update");
    }

    public override void DoLateUpdate()
    {
        Log.StateMachine("Second - LateUpdate");
    }

    public override void DoFixedUpdate()
    {
        Log.StateMachine("Second - FixedUpdate");
    }

    public override void DoOnEnable()
    {
        Log.StateMachine("Second - DoOnEnable");
    }

    public override void DoOnDisable()
    {
        Log.StateMachine("Second - DoOnDisable");
    }

    public override void DoOnDestroy()
    {
        Log.StateMachine("Second - DoOnDestroy");
    }
}