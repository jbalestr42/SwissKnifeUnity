using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace SKU
{
    public abstract class PopupPanel : MonoBehaviour {
        [SerializeField]
        private Button _closeButton;

        protected void Awake()
        {
            _closeButton.onClick.AddListener(OnClickCloseButton);
        }

        protected void OnClickCloseButton()
        {
            Destroy(gameObject);
        }
    }

    public class PopupManager : UIManagerParts
    {
        #region Getter 
        
        public static PopupManager Instance { get { return UIManager.Instance.Get(typeof(PopupManager)) as PopupManager; } }

        #endregion

        #region Variables

        [SerializeField]
        private List<PopupPanel> _popupPanelsList;

        private Dictionary<Type, PopupPanel> _popupPanels;

        #endregion

        #region Methods 

        public T Get<T>(Type key) where T : PopupPanel
        {
            PopupPanel popup;
            _popupPanels.TryGetValue(key, out popup);

            if (popup == null)
            {
                Log.Error("No popup of type [" + key.ToString() + "] are registered in the popupmanager.", gameObject);
                return null;
            }

            return Instantiate(popup, this.transform) as T;
        }

        #endregion

        #region Override

        public override void Init()
        {
            _popupPanels = new Dictionary<Type, PopupPanel>();

            for (int i = 0; i < _popupPanelsList.Count; ++i)
            {
                _popupPanels.Add(_popupPanelsList[i].GetType(), _popupPanelsList[i]);
            }

            _popupPanelsList.Clear();
        }

        #endregion
    }
}