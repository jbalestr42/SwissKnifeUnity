using System;
using System.Collections.Generic;
using UnityEngine;

namespace SKU
{

    public enum ClickType
    enum ClickType
    {
        None = -1,
        Left = 0,
        Right = 1,
        Middle
    }

    [CreateAssetMenu(fileName = "InputManager", menuName = "SKU/Managers/InputManager")]
    public class InputManager : AManagers
    {
        private class ClickStatus
        {
            public float TimeMaintained = 0f;
            public bool HasBeenMaintained = false;
        }

        public Action SimpleLeftClick;
        public Action SimpleRightClick;

        private InputHandler _inputHandler = null;

        private Dictionary<ClickType, Action> _inputsMap = new Dictionary<ClickType, Action>();

        public static InputManager Instance
        {
            get { return GameManager.Instance.Get(typeof(InputManager)) as InputManager; }
        }

        public override void Init()
        {
            if (_inputHandler == null)
            {
                _inputHandler = GameManager.Instance.gameObject.AddComponent<InputHandler>();
                _inputHandler.SetInputManager(this, Update);
            }

<<<<<<< HEAD
            _inputsMap.Add(ClickType.Left, SimpleLeftClick);
            _inputsMap.Add(ClickType.Right, SimpleRightClick);
=======
            _inputs.Add(ClickType.Left, new ClickStatus());
            _inputs.Add(ClickType.Right, new ClickStatus());
>>>>>>> 63e3851897397eb6d15945cf0cf285b0ad50a48b
        }

        private void Update() {
            ClicLogic(ClickType.Left);
            ClicLogic(ClickType.Right);
        }

        private void ClicLogic(ClickType clickType)
        {
            int clicIndex = (int)clickType;

            if (Input.GetMouseButtonUp(clicIndex))
            {
                _inputsMap[clickType]?.Invoke();
            }
        }

        public void AddListener(ClickType clickType, Action action)
        {
            _inputsMap[clickType] += action;
        }

        public void RemoveListener(ClickType clickType, Action action)
        {
            _inputsMap[clickType] -= action;
        }
    }
}
