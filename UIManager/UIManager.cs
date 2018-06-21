using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SKU { 
    public enum AvailableCanvas
    {
        Canvas = 0
    }

    public abstract class AUIManagerParts : MonoBehaviour
    {
        [SerializeField]
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
        private Canvas _canvasArchetype;

        [SerializeField]
        private EventSystem _eventSystemArchetype;

        [SerializeField]
        private List<string> _canvas;

        [SerializeField]
        private List<AUIManagerParts> _UIManagerParts = new List<AUIManagerParts>();

        public List<String> Canvas { get { return _canvas; } }

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
            for(int i = 0; i < _canvas.Count; ++i)
            {
                if (String.IsNullOrEmpty(_canvas[i]))
                {
                    Log.UI("Null value for the tag of a canvas detected inside the UIManager");
                    continue;
                }

                if (GameObject.FindGameObjectWithTag(_canvas[i]) == null)
                {
                    GameObject newCanvas = Instantiate(_canvasArchetype, null).gameObject;
                    newCanvas.tag = _canvas[i];
                    newCanvas.transform.SetAsLastSibling();
                }
            }

            if (GameObject.FindObjectOfType<EventSystem>() == null)
            {
                if (_eventSystemArchetype == null)
                {
                    Log.Error("No Event System in the scene and no event system set as archetype inside the UIManager");
                } else
                {
                    Instantiate(_eventSystemArchetype, null).transform.SetAsLastSibling();
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