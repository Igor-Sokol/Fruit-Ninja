using System;
using GameSystems.SceneChangeSystem;
using Managers;
using Models.DependencyInjection;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class LosePopUp : MonoBehaviour
    {
        private SceneChanger _sceneChanger;
        
        [SerializeField] private GameStarter gameStarter;
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
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();
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

        public void Show(int currentScore, int bestScore)
        {
            currentTextValueText.ForceSetValue(0);
            currentTextValueText.SetValue(currentScore);
            bestTextValueText.ForceSetValue(0);
            bestTextValueText.SetValue(bestScore);

            Enable();
        }

        private void RestartButton()
        {
            gameStarter.ReInitGame();
            Disable();
        }

        private void MenuButton()
        {
            _sceneChanger.LoadScene(sceneName);
        }
        
        private void Enable()
        {
            animationRenderer.Play(enableAnimation);
            canvasGroup.blocksRaycasts = true;
        }

        private void Disable()
        {
            animationRenderer.Play(disableAnimation);
            canvasGroup.blocksRaycasts = false;
        }

        private void AnimationDisableCallback()
        {
            gameStarter.StartGame();
        }
    }
}