using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SKU;
using SKU.StateMachine;

public class ExampleGenericStateFirst : State {

    public override void SetPossibleTransition()
    {
        _possibleTransition.Add(typeof(ExampleGenericStateSecond));
        Log.StateMachine("First - Adding Second as possible transition");
    }
    public override void Initialize()
    {
        Log.StateMachine("First - state Initialize");
    }

    public override void OnEnter()
    {
        Log.StateMachine("First - OnEnter");
    }

    public override void Do()
    {
        Log.StateMachine("First - Do");
    }

    public override void OnExit()
    {
        Log.StateMachine("First - OnExit");
    }
}

public class ExampleGenericStateSecond : State
{
    public override void SetPossibleTransition()
    {
        _possibleTransition.Add(typeof(ExampleGenericStateFirst));
        Log.StateMachine("Second - Adding First as possible transition");
    }
    public override void Initialize()
    {
        Log.StateMachine("Second - state Initialize");
    }

    public override void OnEnter()
    {
        Log.StateMachine("Second - OnEnter");
    }

    public override void Do()
    {
        Log.StateMachine("Second - Do");
    }

    public override void OnExit()
    {
        Log.StateMachine("Second - OnExit");
    }
}