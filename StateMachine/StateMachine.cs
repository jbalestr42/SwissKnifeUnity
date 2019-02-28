using System;

namespace SKU.StateMachine
{
    public class StateMachine
    {
        protected State _currentState;

        public void Initialize<T>() where T: State, new()
        {
            _currentState = new T();
            _currentState.OnEnter();
        }

        public void Do()
        {
            _currentState.Do();
        }

        public bool GoTo<T>() where T: State, new()
        {
            if (CanGoTo<T>())
            {
                _currentState.OnExit();

                _currentState = new T();
                _currentState.OnEnter();

                return true;
            }

            return false;
        }

        public bool CanGoTo<T>() where T: State
        {
            return _currentState.CanGoTo(typeof(T));
        }
    }
}
