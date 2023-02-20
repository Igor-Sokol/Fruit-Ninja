using System.Collections;
using System.Linq;
using Animations;
using Blocks.BlockStackSystem;
using PlayingFieldComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameSystems.SpawnSystem
{
    public class SpawnerManager : MonoBehaviour
    {
        private float[] _spawnerPriority;
        private Coroutine _spawnerHandler;

        [SerializeField] private PlayingField playingField;
        [SerializeField] private AnimationManager animationManager;
        [SerializeField] private BlockContainer blockContainer;
        [SerializeField] private BlockStackGenerator blockStackGenerator;
        [SerializeField] private Spawner[] spawners;
        [SerializeField] private float spawnScale; 

        private void Awake()
        {
            CreatePriorityArray();
        }

        private void Start()
        {
            InitSpawnersPosition();
        }

        public void EnableSpawners()
        {
            _spawnerHandler = StartCoroutine(Spawn());
        }

        public void DisableSpawners()
        {
            if (_spawnerHandler != null)
            {
                StopCoroutine(_spawnerHandler);
            }
        }
        
        private IEnumerator Spawn()
        {
            while (true)
            {
                float blocksCount = 0f;
                foreach (var block in blockStackGenerator.GetBlocks())
                {
                    block.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);
                    blockContainer.AddBlock(block);
                    block.BlockAnimator.SetAnimations(animationManager.GetRandomAnimations());
                    var randomSpawner = GetRandomSpawner();
                    randomSpawner.Launch(block.BlockPhysic);
                    blocksCount++;

                    if (blocksCount >= blockStackGenerator.CurrentDifficultySetting.FruitsInPack) break;
                    
                    yield return new WaitForSeconds(blockStackGenerator.CurrentDifficultySetting.FruitInterval);
                }

                yield return new WaitForSeconds(blockStackGenerator.CurrentDifficultySetting.PackInterval);
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