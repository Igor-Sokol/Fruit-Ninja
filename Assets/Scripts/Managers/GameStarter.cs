using System.Collections;
using System.Linq;
using GameSystems.DifficultySystem.Implementations;
using GameSystems.HealthSystem;
using GameSystems.SceneChangeSystem;
using GameSystems.ScoreSystem;
using GameSystems.SpawnSystem;
using Models.DependencyInjection;
using Models.PopUpSystem;
using Models.Timers.TimerActions;
using Models.Timers.TimerSystem;
using PlayingFieldComponents;
using UI.Game;
using UnityEngine;

namespace Managers
{
    public class GameStarter : MonoBehaviour
    {
        private SceneChanger _sceneChanger;
        private PopUpManager _popUpManager;
        
        [SerializeField] private HealthService healthService;
        [SerializeField] private HealthView healthView;
        [SerializeField] private BladeMover bladeMover;
        [SerializeField] private SpawnerManager spawnerManager;
        [SerializeField] private BlockContainer[] containers;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private DynamicDifficulty difficulty;

        private void Start()
        {
            Init();

            if (_sceneChanger.SceneLoaded)
            {
                StartGame();
            }
            else
            {
                _sceneChanger.OnSceneLoaded += OnSceneLoaded;
            }
        }

        private void Init()
        {
            _sceneChanger = ProjectContext.Instance.GetService<SceneChanger>();
            _popUpManager = ProjectContext.Instance.GetService<PopUpManager>();
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
            Timer.Instance.GetTimerCounter(typeof(SamuraiTimeAction))?.ForceEnd();
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
            
            _popUpManager.Show("LosePopUp");
        }
    }
}