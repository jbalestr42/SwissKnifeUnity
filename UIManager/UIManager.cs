using System.Collections.Generic;
using System;
using UnityEngine;

namespace SKU { 
    public enum AvailableCanvas
    {
        Canvas = 0
    }

    public abstract class AUIManagerParts : MonoBehaviour
    {
        private string _canvasToInstantiate;

        public string CanvasToInstantiate
        {
            get { return _canvasToInstantiate; }
            set { _canvasToInstantiate = value; }
        }

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

        [SerializeField]
        private StringGameObjectDictionary CanvasPrefab = StringGameObjectDictionary.New<StringGameObjectDictionary>();
        public Dictionary<string, GameObject> _canvasPrefab
        {
            get { return CanvasPrefab.dictionary; }
        }

        [SerializeField]
        private List<AUIManagerParts> _UIManagerParts = new List<AUIManagerParts>();

        private Dictionary<Type, AUIManagerParts> _uiManagers;

        public AUIManagerParts Get(Type key)
        {
            AUIManagerParts value = null;

            if (!_uiManagers.TryGetValue(key, out value))
            {
                Log.Error("The UI manager does not contains a manager of type [" + key.ToString() + "]");
            }

            return value;
        }

        #endregion

        #region Methods

        private Transform GetCanvas(string canvasSelected)
        {
            GameObject canvas = GameObject.FindGameObjectWithTag(canvasSelected);

            if (canvas == null)
            {
                Log.Error("The canvas [" + canvasSelected + "] is not existing.");
                return null;
            }

            return canvas.transform;
        }

        #endregion

        #region Override 

        public override void Init()
        {
            foreach (KeyValuePair < string, GameObject> pair in _canvasPrefab)
            {
                GameObject canvas = GameObject.FindGameObjectWithTag(pair.Key);

                if (canvas == null)
                {
                    Instantiate(pair.Value);
                }
            }

            _uiManagers = new Dictionary<Type, AUIManagerParts>();

            for (int i = 0; i < _UIManagerParts.Count; ++i)
            {   
                if (_UIManagerParts[i] == null)
                {
                    Log.Error("Element at index [" + i + "] of UIManagerParts is null");
                    continue;
                }

                if (!_uiManagers.ContainsKey(_UIManagerParts[i].GetType())) {
                    AUIManagerParts newPart = Instantiate(_UIManagerParts[i], GetCanvas(_UIManagerParts[i].CanvasToInstantiate));
                    newPart.Init();
                    _uiManagers.Add(_UIManagerParts[i].GetType(), newPart);
                } else
                {
                    Log.Error("An object of type [" + _UIManagerParts[i].GetType().ToString() + "] is already present inside the UIManager.");
                }
            }
        }

        #endregion

    }
}