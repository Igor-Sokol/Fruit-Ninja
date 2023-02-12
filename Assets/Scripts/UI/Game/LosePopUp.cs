using Managers;
using SceneChangeSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game
{
    public class LosePopUp : MonoBehaviour
    {
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
            SceneChanger.Instance.LoadScene(sceneName);
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