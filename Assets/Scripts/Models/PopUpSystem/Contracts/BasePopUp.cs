using UnityEngine;

namespace Models.PopUpSystem.Contracts
{
    public abstract class BasePopUp : MonoBehaviour
    {
        [SerializeField] protected string panelUniqueId;

        public string PanelUniqueId => panelUniqueId;
        public PopUpManager PopUpManager { get; private set; }

        public void Init(PopUpManager popUpManager)
        {
            PopUpManager = popUpManager;
        }

        public abstract void Show();
        public abstract void Hide();
    }
}