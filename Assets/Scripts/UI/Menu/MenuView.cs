using DependencyInjection;
using SceneChangeSystem;
using ScoreSystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Menu
{
    public class MenuView : MonoBehaviour
    {
        private SceneChanger _sceneChanger;
        
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private TextValue textValue;
        [SerializeField] private Button gameButton;
        [SerializeField] private string sceneName;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            SetScore();
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();
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
            textValue.ForceSetValue(scoreManager.BestScore);
        }

        private void GameButton()
        {
            _sceneChanger.LoadScene(sceneName);
        }
    
        private void ExitButton()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }
    }
}