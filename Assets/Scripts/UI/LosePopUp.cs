using SceneChangeSystem;
using ScoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class LosePopUp : MonoBehaviour
    {
        [SerializeField] private GameStarter gameStarter;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Score currentScoreText;
        [SerializeField] private Score bestScoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private string sceneName;
        [SerializeField] private Animation animationRenderer;
        [SerializeField] private string enableAnimation;
        [SerializeField] private string disableAnimation;

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
            currentScoreText.ForceSetValue(0);
            currentScoreText.SetValue(currentScore);
            bestScoreText.ForceSetValue(0);
            bestScoreText.SetValue(bestScore);

            Enable();
        }

        private void RestartButton()
        {
            gameStarter.ReInitGame();
            gameStarter.StartGame();
            Disable();
        }

        private void MenuButton()
        {
            SceneChanger.Instance.LoadScene(sceneName);
        }
        
        private void Enable()
        {
            animationRenderer.Play(enableAnimation);
            canvasGroup.interactable = true;
        }

        private void Disable()
        {
            animationRenderer.Play(disableAnimation);
            canvasGroup.interactable = false;
        }
    }
}