using System.Collections;
using System.Linq;
using DifficultySystem;
using HealthSystem;
using PlayingFieldComponents;
using SceneChangeSystem;
using ScoreSystem;
using SpawnSystem;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameStarter : MonoBehaviour
    {
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
            if (SceneChanger.IsValid)
            {
                SceneChanger.Instance.OnSceneLoaded += OnSceneLoaded;
            }
            else
            {
                StartGame();
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
            SceneChanger.Instance.OnSceneLoaded -= OnSceneLoaded;
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