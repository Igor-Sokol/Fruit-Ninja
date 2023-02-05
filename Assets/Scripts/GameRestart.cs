using System.Collections;
using System.Linq;
using BlockComponents;
using DifficultySystem;
using HealthSystem;
using ScoreSystem;
using SpawnSystem;
using UI;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    [SerializeField] private HealthService healthService;
    [SerializeField] private HealthView healthView;
    [SerializeField] private LosePopUp losePopUp;
    [SerializeField] private BladeMover bladeMover;
    [SerializeField] private SpawnerManager spawnerManager;
    [SerializeField] private BlockContainer[] containers;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private DynamicDifficulty difficulty;

    private void OnEnable()
    {
        healthService.OnPlayerLose += OnPlayerLose;
    }

    private void OnDisable()
    {
        healthService.OnPlayerLose -= OnPlayerLose;
    }

    public void RestartGame()
    {
        scoreManager.Clear();
        bladeMover.Active = true;
        difficulty.Clear();
        healthService.Clear();
        healthView.Clear();
        spawnerManager.EnableSpawners();
    }

    private void OnPlayerLose()
    {
        spawnerManager.DisableSpawners();
        bladeMover.Active = false;

        StartCoroutine(CheckEmptyPlayingField());
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