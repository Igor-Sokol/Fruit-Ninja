using GameSystems.SceneChangeSystem;
using GameSystems.ScoreSystem;
using Managers;
using Models.Blur;
using Models.DependencyInjection;
using Models.PopUpSystem.Contracts;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Models.PopUpSystem.Panels
{
    public class LosePopUp : BasePopUp
    {
        private SceneChanger _sceneChanger;
        private ScoreManager _scoreManager;
        private GameStarter _gameStarter;

        [SerializeField] private BlurController blurController;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextValue currentTextValueText;
        [SerializeField] private TextValue bestTextValueText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private string sceneName;
        [SerializeField] private Animation animationRenderer;
        [SerializeField] private string enableAnimation;
        [SerializeField] private string disableAnimation;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();
            _scoreManager = ProjectContext.Instance.GetService<ScoreManager>();
            _gameStarter = ProjectContext.Instance.GetService<GameStarter>();
            blurController.BlurSetting = ProjectContext.Instance.GetService<MobileBlur>();
        }

        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartButton);
            menuButton.onClick.AddListener(MenuButton);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(RestartButton);
            menuButton.onClick.RemoveListener(MenuButton);
        }

        public override void Show()
        {
            currentTextValueText.ForceSetValue(0);
            currentTextValueText.SetValue(_scoreManager.CurrentScore);
            bestTextValueText.ForceSetValue(0);
            bestTextValueText.SetValue(_scoreManager.BestScore);
            animationRenderer.Play(enableAnimation);
            blurController.BlurSetting.enabled = true;
            blurController.Blur = 2f;
            canvasGroup.blocksRaycasts = true;
        }

        public override void Hide()
        {
            animationRenderer.Play(disableAnimation);
            canvasGroup.blocksRaycasts = false;
        }
        
        private void RestartButton()
        {
            _gameStarter.ReInitGame();
            PopUpManager.Hide(this);
        }

        private void MenuButton()
        {
            _sceneChanger.LoadScene(sceneName);
        }

        private void AnimationDisableCallback()
        {
            _gameStarter.StartGame();
            blurController.Blur = 0f;
            blurController.BlurSetting.enabled = false;
        }
    }
}