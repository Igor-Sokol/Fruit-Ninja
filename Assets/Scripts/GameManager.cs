using System.Collections;
using System.Linq;
using BlockComponents;
using DifficultySystem;
using HealthSystem;
using SpawnSystem;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private LosePopUp losePopUp;
    [SerializeField] private BladeMover bladeMover;
    [SerializeField] private SpawnerManager spawnerManager;
    [SerializeField] private BlockContainer[] containers;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private DynamicDifficulty difficulty;

    private void OnEnable()
    {
        healthBar.OnPlayerLose += OnPlayerLose;
    }

    private void OnDisable()
    {
        healthBar.OnPlayerLose -= OnPlayerLose;
    }

    public void RestartGame()
    {
        scoreManager.Clear();
        bladeMover.Active = true;
        difficulty.Clear();
        healthBar.Init();
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