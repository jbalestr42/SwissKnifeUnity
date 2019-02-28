using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SKU.StateMachine
{
    public class UnityStateMachine : MonoBehaviour
    {
        [SerializeField]
        private String _firstState = String.Empty;

        protected UnityState _currentState;

        #region Unity

        private void Awake()
        {
            Type type = Type.GetType(_firstState);
            _currentState = (UnityState)Activator.CreateInstance(type);
        }

        private void Start()
        {
            _currentState.OnEnter();
        }

        private void OnEnable()
        {
            _currentState.DoOnEnable();
        }

        private void Update()
        {
            _currentState.DoUpdate();
        }

        private void LateUpdate()
        {
            _currentState.DoLateUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.DoFixedUpdate();
        }

        private void OnDisable()
        {
            _currentState.DoOnDisable();
        }

        private void OnDestroy()
        {
            _currentState.DoOnDestroy();
        }

        #endregion

        public void Do()
        {
            _currentState.Do();
        }

        public bool GoTo<T>() where T : UnityState, new()
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

        public bool CanGoTo<T>() where T : UnityState
        {
            return _currentState.CanGoTo(typeof(T));
        }
    }
}