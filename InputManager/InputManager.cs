using System;
using System.Collections.Generic;
using UnityEngine;

namespace SKU
{

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

            _inputs.Add(ClickType.Left, new ClickStatus());
            _inputs.Add(ClickType.Right, new ClickStatus());
        }

        private void Update() {
            ClicLogic(ClickType.Left);
            ClicLogic(ClickType.Right);
        }

        private void ClicLogic(ClickType clickType)
        {
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
        }
    }
}
