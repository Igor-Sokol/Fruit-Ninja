using GameSystems.SceneChangeSystem;
using Models.DependencyInjection;
using Models.PopUpSystem.Contracts;
using UnityEngine;
using UnityEngine.UI;

namespace Models.PopUpSystem.Panels
{
    public class PausePopUp : BasePopUp
    {
        private SceneChanger _sceneChanger;
        
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private string sceneName;
        [SerializeField] private Animator animationRenderer;
        [SerializeField] private string enableAnimation;
        [SerializeField] private string disableAnimation;
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();
        }
        
        private void OnEnable()
        {
            continueButton.onClick.AddListener(ContinueButton);
            menuButton.onClick.AddListener(MenuButton);
        }

        private void OnDisable()
        {
            continueButton.onClick.RemoveListener(ContinueButton);
            menuButton.onClick.RemoveListener(MenuButton);
        }
        
        public override void Show()
        {
            animationRenderer.enabled = true;
            animationRenderer.Play(enableAnimation);
            canvasGroup.blocksRaycasts = true;
            Time.timeScale = 0;
        }

        public override void Hide()
        {
            animationRenderer.Play(disableAnimation);
        }
        
        private void ContinueButton()
        {
            PopUpManager.Hide(this);
        }

        private void MenuButton()
        {
            Time.timeScale = 1;
            _sceneChanger.LoadScene(sceneName);
        }

        private void AnimationDisableCallback()
        {
            Time.timeScale = 1;
            canvasGroup.blocksRaycasts = false;
            animationRenderer.enabled = false;
        }
    }
}