using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LosePopUp : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TMP_Text currentScoreText;
        [SerializeField] private TMP_Text bestScoreText;
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
            currentScoreText.text = currentScore.ToString();
            bestScoreText.text = bestScore.ToString();
            
            Enable();
        }

        private void RestartButton()
        {
            gameManager.RestartGame();
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