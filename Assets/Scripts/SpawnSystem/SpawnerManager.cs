using System.Collections;
using System.Linq;
using Adaptive;
using BlockInteraction;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    private float[] _spawnerPriority;

    [SerializeField] private PlayingField playingField;
    [SerializeField] private DynamicDifficulty difficultyController;
    [SerializeField] private BlockContainer blockContainer;
    [SerializeField] private BlockPool blockPool;
    [SerializeField] private Spawner[] spawners;

    private void Awake()
    {
        CreatePriorityArray();
        InitSpawnersPosition();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < difficultyController.FruitsInPack; i++)
            {
                var block = blockPool.GetRandomFruit();
                blockContainer.AddBlock(block);
                var randomSpawner = GetRandomSpawner();
                randomSpawner.Launch(block);
                
                yield return new WaitForSeconds(difficultyController.FruitInterval);
            }
            
            yield return new WaitForSeconds(difficultyController.PackInterval);
        }
    }

    private void InitSpawnersPosition()
    {
        foreach (var spawner in spawners)
        {
            spawner.transform.position = playingField.PositionFromPercentage(spawner.PercentagePosition);
        }
    }
    
    private Spawner GetRandomSpawner()
    {
        float random = Random.value;

        for (int i = 0; i < _spawnerPriority.Length; i++)
        {
            if (random <= _spawnerPriority[i])
            {
                return spawners[i];
            }
        }

        return null;
    }
    
    private void CreatePriorityArray()
    {
        _spawnerPriority = new float[spawners.Length];

        float prioritiesSum = spawners.Sum(s => s.Priority);
        
        float temp = 0;
        for (int i = 0; i < spawners.Length; i++)
        {
            temp += spawners[i].Priority / prioritiesSum;
            _spawnerPriority[i] = temp;
        }
    }
}