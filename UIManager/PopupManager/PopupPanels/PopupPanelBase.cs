using UnityEngine;
using UnityEngine.UI;

namespace SKU
{
    public abstract class PopupPanelBase : MonoBehaviour
    {
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
}
