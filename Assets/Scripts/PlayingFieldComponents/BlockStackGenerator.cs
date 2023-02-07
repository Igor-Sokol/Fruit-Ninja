using System;
using System.Collections.Generic;
using System.Linq;
using BlockComponents;
using DifficultySystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlayingFieldComponents
{
    public class BlockStackGenerator : MonoBehaviour
    {
        private ObjectPool<Block> _pool;

        [SerializeField] private DynamicDifficulty dynamicDifficulty; 
        [SerializeField] private Block prefab;
        [SerializeField] private BlockStackSetting[] blocks;

        private void Awake()
        {
            _pool = new ObjectPool<Block>();
            _pool.Init(prefab, transform);
        }

        public Block GetEmptyBlock()
        {
            return _pool.Get();
        }
        
        public void ReturnBlock(Block block)
        {
            _pool.Return(block);
        }
        
        public IEnumerable<Block> GetBlocks()
        {
            int blocksCount = dynamicDifficulty.FruitsInPack;
            Dictionary<BlockStackSetting, int> endSettings = new Dictionary<BlockStackSetting, int>();
            List<BlockStackSetting> availableStackSettings = new List<BlockStackSetting>(blocks);
            List<(BlockStackSetting, float)> weightArray = CreatePriorityArray(availableStackSettings, b => b.Priority);

            for (int i = 0; i < blocksCount; i++)
            {
                BlockStackSetting nextStack = GetRandomItem(weightArray);

                float percentage = endSettings.ContainsKey(nextStack)
                    ? ((endSettings[nextStack] + 1) / (float)blocksCount)
                    : 0;

                if (percentage > nextStack.MaximumAmountPercentage)
                {
                    availableStackSettings.Remove(nextStack);
                    weightArray = CreatePriorityArray(availableStackSettings, b => b.Priority);
                    i--;
                }
                else
                {
                    if (endSettings.ContainsKey(nextStack))
                    {
                        endSettings[nextStack]++;
                    }
                    else
                    {
                        endSettings.Add(nextStack, 1);
                    }
                }
            }

            return Get();

            IEnumerable<Block> Get()
            {
                foreach (var setting in endSettings)
                {
                    for (int i = 0; i < setting.Value; i++)
                    {
                        var settingObjects = setting.Key.Blocks;
                        var settingObject = settingObjects[Random.Range(0, settingObjects.Length)];
                        var block = _pool.Get();
                        block.SetUp(settingObject);
                        yield return block;
                    }
                }
            }
        }
        
        private T GetRandomItem<T>(IReadOnlyList<(T item, float weight)> items)
        {
            float random = Random.value;

            for (int i = 0; i < items.Count; i++)
            {
                if (random <= items[i].weight)
                {
                    return items[i].item;
                }
            }

            throw new ArgumentException("Incorrect items weight.", nameof(items));
        }
        
        private List<(T, float)> CreatePriorityArray<T>(IReadOnlyList<T> items, Func<T, float> getPriority)
        {
            List<(T, float)> result = new List<(T, float)>();

            float prioritiesSum = items.Sum(getPriority);
            if (prioritiesSum <= 0)
            {
                throw new ArgumentException("Items have zero priorities.", nameof(items));
            }
        
            float temp = 0;
            foreach (var item in items)
            {
                temp += getPriority(item) / prioritiesSum;
                result.Add((item, temp));
            }

            return result;
        }
    }
}