using Models.DependencyInjection;
using Models.PopUpSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PopUpButton : MonoBehaviour
    {
        private PopUpManager _popUpManager;
        
        [SerializeField] private Button button;
        [SerializeField] private string popUpId;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _popUpManager = ProjectContext.Instance.GetService<PopUpManager>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _popUpManager.Show(popUpId);
        }
    }
}