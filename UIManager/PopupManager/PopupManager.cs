using System.Collections.Generic;
using UnityEngine;
using System;

namespace SKU
{
    public class PopupManager : UIManagerParts
    {
        #region Getter 
        
        public static PopupManager Instance { get { return UIManager.Instance.Get(typeof(PopupManager)) as PopupManager; } }

        #endregion

        #region Variables

        [SerializeField]
        private List<APopupPanelBase> _popupPanelsList;
        private ListUnserializerTypeObject<APopupPanelBase> _popupPanels;

        #endregion

        #region Methods 

        public T Get<T>(Type key) where T : APopupPanelBase
        {
            APopupPanelBase popup;
            _popupPanels.Dic.TryGetValue(key, out popup);

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
            _popupPanels = new ListUnserializerTypeObject<APopupPanelBase>();
            _popupPanels.Initialize(_popupPanelsList, true);
        }

        #endregion
    }
}