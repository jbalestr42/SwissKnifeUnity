using System;
using UnityEngine;

namespace SKU
{
    public class InputHandler : MonoBehaviour
    {
        private InputManager _inputManager = null;
        private Action _inputManagerUpdate = null;

        public void SetInputManager(InputManager inputManager, Action inputManagerAction)
        {
            _inputManager = inputManager;
            _inputManagerUpdate = inputManagerAction;

        }

        private void Update()
        {
            if (!_inputManager || _inputManagerUpdate == null)
            {
                return;
            }

            _inputManagerUpdate.Invoke();
        }
    }
}