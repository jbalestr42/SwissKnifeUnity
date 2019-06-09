using System;
using System.Collections.Generic;
using UnityEngine;

namespace SKU
{

<<<<<<< HEAD
    public enum ClickType
=======
    enum ClickType
>>>>>>> 63e3851897397eb6d15945cf0cf285b0ad50a48b
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

<<<<<<< HEAD
        public Action SimpleLeftClick;
        public Action SimpleRightClick;

        private InputHandler _inputHandler = null;

        private Dictionary<ClickType, Action> _inputsMap = new Dictionary<ClickType, Action>();
=======
        public float _deathZoneForClickDetection = 0.1f;
        public float _thresholdForMaintainedClick = 0.5f;

        public Action SimpleLeftClick;
        public Action SimpleRightClick;
        public Action MaintainedLeftClick;
        public Action MaintainedRightClick;

        private InputHandler _inputHandler = null;
        private float _clickDuration = 0f;
        private bool _maintainedTriggered = false;

        private ClickType _lastClick = ClickType.None;
        private Dictionary<ClickType, ClickStatus> _inputs = new Dictionary<ClickType, ClickStatus>();
>>>>>>> 63e3851897397eb6d15945cf0cf285b0ad50a48b

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
<<<<<<< HEAD
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
=======
            ClickStatus clicStatus = _inputs[clickType];
            int clicIndex = (int)clickType;

            if (!Input.GetMouseButton(clicIndex) && !Input.GetMouseButtonUp(clicIndex))
            {
                clicStatus.TimeMaintained = 0f;
                clicStatus.HasBeenMaintained = false;
                _inputs[clickType] = clicStatus;

                return;
            }

            if (Input.GetMouseButton(clicIndex) && !Input.GetMouseButtonDown(clicIndex))
            {
                clicStatus.TimeMaintained += Time.deltaTime;
            }

            if (clicStatus.TimeMaintained >= _thresholdForMaintainedClick && !clicStatus.HasBeenMaintained)
            {
                clicStatus.HasBeenMaintained = true;
                _inputs[clickType] = clicStatus;

                return;
            }

            if (clicStatus.TimeMaintained >= _deathZoneForClickDetection && clicStatus.HasBeenMaintained)
            {
                _inputs[clickType] = clicStatus;
                return;
            }

            if (Input.GetMouseButtonUp(clicIndex))
            {
                clicStatus.HasBeenMaintained = false;
                SimpleLeftClick.Invoke();
            }

            _inputs[clickType] = clicStatus;
>>>>>>> 63e3851897397eb6d15945cf0cf285b0ad50a48b
        }
    }
}
