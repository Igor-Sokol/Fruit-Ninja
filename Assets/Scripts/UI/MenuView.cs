using SceneChangeSystem;
using ScoreSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Score score;
        [SerializeField] private Button gameButton;
        [SerializeField] private string sceneName;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            SetScore();
        }

        private void OnEnable()
        {
            scoreManager.ScoreLoaded += SetScore;
            gameButton.onClick.AddListener(GameButton);
            exitButton.onClick.AddListener(ExitButton);
        }

        private void OnDisable()
        {
            scoreManager.ScoreLoaded -= SetScore;
            gameButton.onClick.RemoveListener(GameButton);
            exitButton.onClick.RemoveListener(ExitButton);
        }

        private void SetScore()
        {
            score.ForceSetValue(scoreManager.BestScore);
        }

        private void GameButton()
        {
            SceneChanger.Instance.LoadScene(sceneName);
        }
    
        private void ExitButton()
        {
            Application.Quit();
        }
    }
}