using System.Collections;
using System.Linq;
using Adaptive;
using Animations;
using BlockComponents;
using DifficultySystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnSystem
{
    public class SpawnerManager : MonoBehaviour
    {
        private float[] _spawnerPriority;
        private Coroutine spawnerHandler;

        [SerializeField] private PlayingField playingField;
        [SerializeField] private DynamicDifficulty difficultyController;
        [SerializeField] private AnimationManager animationManager;
        [SerializeField] private BlockContainer blockContainer;
        [SerializeField] private BlockPool blockPool;
        [SerializeField] private Spawner[] spawners;
        [SerializeField] private float spawnScale; 

        private void Awake()
        {
            CreatePriorityArray();
        }

        private void Start()
        {
            InitSpawnersPosition();
            EnableSpawners();
        }

        public void EnableSpawners()
        {
            spawnerHandler = StartCoroutine(Spawn());
        }

        public void DisableSpawners()
        {
            if (spawnerHandler != null)
            {
                StopCoroutine(spawnerHandler);
            }
        }
        
        private IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < difficultyController.FruitsInPack; i++)
                {
                    var block = blockPool.GetRandomFruit();
                    block.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);
                    blockContainer.AddBlock(block);
                    block.BlockAnimator.SetAnimations(animationManager.GetRandomAnimations());
                    var randomSpawner = GetRandomSpawner();
                    randomSpawner.Launch(block.BlockPhysic);
                
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
}