using System.Collections;
using System.Linq;
using Adaptive;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerManager : MonoBehaviour
{
    private float[] _spawnerPriority;

    [SerializeField] private PlayingField playingField;
    [SerializeField] private Block prefab;
    [SerializeField] private BlockContainer blockContainer;
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
            for (int i = 0; i < 5; i++)
            {
                var block = Instantiate(prefab);
                blockContainer.AddBlock(block);
                var randomSpawner = GetRandomSpawner();
                randomSpawner.Launch(block);
                
                yield return new WaitForSeconds(0.5f);
            }
            
            yield return new WaitForSeconds(3);
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