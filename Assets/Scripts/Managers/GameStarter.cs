using System.Collections;
using System.Linq;
using GameSystems.DifficultySystem.Implementations;
using GameSystems.HealthSystem;
using GameSystems.SceneChangeSystem;
using GameSystems.ScoreSystem;
using GameSystems.SpawnSystem;
using Models.DependencyInjection;
using PlayingFieldComponents;
using UI;
using UI.Game;
using UnityEngine;

namespace Managers
{
    public class GameStarter : MonoBehaviour
    {
        private SceneChanger _sceneChanger;
        
        [SerializeField] private HealthService healthService;
        [SerializeField] private HealthView healthView;
        [SerializeField] private LosePopUp losePopUp;
        [SerializeField] private BladeMover bladeMover;
        [SerializeField] private SpawnerManager spawnerManager;
        [SerializeField] private BlockContainer[] containers;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private DynamicDifficulty difficulty;

        private void Start()
        {
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();

            if (_sceneChanger.SceneLoaded)
            {
                StartGame();
            }
            else
            {
                _sceneChanger.OnSceneLoaded += OnSceneLoaded;
            }
        }

        private void OnEnable()
        {
            healthService.OnPlayerLose += OnPlayerLose;
        }

        private void OnDisable()
        {
            healthService.OnPlayerLose -= OnPlayerLose;
        }

        public void StartGame()
        {
            bladeMover.Active = true;
            spawnerManager.EnableSpawners();
        }

        public void ReInitGame()
        {
            difficulty.Clear();
            healthService.Clear();
            healthView.Clear();
            scoreManager.Load();
        }

        private void OnPlayerLose()
        {
            spawnerManager.DisableSpawners();
            bladeMover.Active = false;

            StartCoroutine(CheckEmptyPlayingField());
        }

        private void OnSceneLoaded()
        {
            _sceneChanger.OnSceneLoaded -= OnSceneLoaded;
            StartGame();
        }
    
        private IEnumerator CheckEmptyPlayingField()
        {
            while (true)
            {
                if (containers.All(c => c.BlocksCount == 0))
                {
                    break;
                }

                yield return null;
            }
        
            losePopUp.Show(scoreManager.CurrentScore, scoreManager.BestScore);
        }
    }
}