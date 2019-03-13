using System.Collections;
using System.Collections.Generic;
using System;

namespace SKU.StateMachine {
    public abstract class State
    {
        protected StateMachine _stateMachine;
        protected List<Type> _possibleTransition = new List<Type>();

        public StateMachine StateMachine { set { _stateMachine = value; } }

        public State()
        {
            SetPossibleTransition();
            Initialize();
        }

        public abstract void SetPossibleTransition();
        public abstract void Initialize();

        public bool CanGoTo(Type nextType)
        {
            return _possibleTransition.Contains(nextType);
        }

        public abstract void OnEnter();
        public abstract void Do();
        public abstract void OnExit();

    }

    public abstract class UnityState : State
    {
        public virtual void DoOnEnable() { }
        public virtual void DoUpdate() { }
        public virtual void DoLateUpdate() { }
        public virtual void DoFixedUpdate() { }
        public virtual void DoOnDisable() { }
        public virtual void DoOnDestroy() { }
    }
}
