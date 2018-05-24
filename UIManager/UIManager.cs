using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace SKU { 
    public enum AvailableCanvas
    {
        Canvas = 0
    }

    public abstract class UIManagerParts : MonoBehaviour
    {
        [SerializeField]
        private AvailableCanvas _canvasToInstantiate;

        public AvailableCanvas CanvasToInstantiate { get { return _canvasToInstantiate; } }

        public abstract void Init();
    }

    [CreateAssetMenu(fileName = "UIManager", menuName = "SKU/Managers/UIManager")]
    public class UIManager : AManagers {

        #region Getter 

        public static UIManager Instance
        {
            get { return GameManager.Instance.Get(typeof(UIManager)) as UIManager; }
        }

        #endregion

        #region Variables

        public const string kTagCanvas = "Canvas";

        [SerializeField]
        private GameObject _canvasPrefab;

        [SerializeField]
        private List<UIManagerParts> _UIManagerParts;

        private GameObject _canvas;
        private Dictionary<Type, UIManagerParts> _uiManagers;

        public GameObject Canvas { get { return _canvas; } }

        public UIManagerParts Get(Type key)
        {
            UIManagerParts value = null;

            if (!_uiManagers.TryGetValue(key, out value))
            {
                Log.Error("The UI manager does not contains a manager of type [" + key.ToString() + "]");
            }

            return value;
        }

        #endregion

        #region Methods

        private Transform GetCanvas(AvailableCanvas canvasSelected)
        {
            switch(canvasSelected) {
                case AvailableCanvas.Canvas:
                    return _canvas.transform;

                default:
                    Log.Warning("Canvas selected by default");
                    return _canvas.transform;
            }
        }

        #endregion

        #region Override 

        public override void Init()
        {
            _canvas = GameObject.FindGameObjectWithTag(kTagCanvas);

            if (_canvas == null)
            {
                _canvas = Instantiate(_canvasPrefab);
            }

            _uiManagers = new Dictionary<Type, UIManagerParts>();

            for (int i = 0; i < _UIManagerParts.Count; ++i)
            {
                UIManagerParts newPart = Instantiate(_UIManagerParts[i], GetCanvas(_UIManagerParts[i].CanvasToInstantiate));
                newPart.Init();

                _uiManagers.Add(_UIManagerParts[i].GetType(), newPart);
            }
        }

        #endregion

    }
}