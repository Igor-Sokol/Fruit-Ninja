using ScoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class LosePopUp : MonoBehaviour
    {
        [FormerlySerializedAs("gameRestar")] [FormerlySerializedAs("gameRestarter")] [FormerlySerializedAs("gameManager")] [SerializeField] private GameRestart gameRestart;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Score currentScoreText;
        [SerializeField] private Score bestScoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Animation animationRenderer;
        [SerializeField] private string enableAnimation;
        [SerializeField] private string disableAnimation;

        private void OnEnable()
        {
            restartButton.onClick.AddListener(RestartButton);
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(RestartButton);
        }

        public void Show(int currentScore, int bestScore)
        {
            currentScoreText.SetValue(currentScore);
            bestScoreText.SetValue(bestScore);

            Enable();
        }

        private void RestartButton()
        {
            gameRestart.RestartGame();
            Disable();
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