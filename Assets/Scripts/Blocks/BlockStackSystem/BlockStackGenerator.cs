using System;
using System.Collections.Generic;
using System.Linq;
using Blocks.BlockComponents;
using GameSystems.DifficultySystem;
using Managers;
using Models.ObjectPools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Blocks.BlockStackSystem
{
    public class BlockStackGenerator : MonoBehaviour
    {
        private ObjectPool<Block> _pool;
        private IDifficultySetting _currentCurrentDifficultySetting;
        private BlockStackSetting[] _blockStackSettings;

        [SerializeField] private DifficultySetting dynamicDifficulty;
        [SerializeField] private TimeScaleManager timeScaleManager;
        [SerializeField] private Block prefab;
        [SerializeField] private BlockStackSetting[] blocks;

        public IDifficultySetting CurrentDifficultySetting => _currentCurrentDifficultySetting;
        public IDifficultySetting DefaultDifficultySetting => dynamicDifficulty;
        public BlockStackSetting[] CurrentStackSettings => _blockStackSettings;
        public BlockStackSetting[] DefaultStackSettings => blocks;

        private void Awake()
        {
            _pool = new ObjectPool<Block>();
            _pool.Init(prefab, transform);
            
            SetDifficult(DefaultDifficultySetting);
            SetStackSettings(DefaultStackSettings);
        }

        public Block GetEmptyBlock()
        {
            var block = _pool.Get();
            block.SetTimeScaleManager(timeScaleManager);

            return block;
        }
        
        public void ReturnBlock(Block block)
        {
            _pool.Return(block);
        }

        public void SetDifficult(DifficultySetting difficultySetting)
        {
            _currentCurrentDifficultySetting = difficultySetting;
        }
        
        public void SetDifficult(IDifficultySetting difficultySetting)
        {
            _currentCurrentDifficultySetting = difficultySetting;
        }

        public void SetStackSettings(BlockStackSetting[] stackSettings)
        {
            _blockStackSettings = stackSettings;
        }

        public IEnumerable<Block> GetBlocks()
        {
            return GetBlocks(_blockStackSettings, _currentCurrentDifficultySetting.FruitsInPack);
        }
        
        public IEnumerable<Block> GetBlocks(BlockStackSetting[] stackSettings, int count)
        {
            int blocksCount = count;
            Dictionary<BlockStackSetting, int> endSettings = new Dictionary<BlockStackSetting, int>();
            List<BlockStackSetting> availableStackSettings = new List<BlockStackSetting>(stackSettings.Where(b => b.Restrictions.All(r => !r.IsRestricted())));
            List<(BlockStackSetting, float)> weightArray = CreatePriorityArray(availableStackSettings, b => b.Priority);

            for (int i = 0; i < blocksCount; i++)
            {
                if (!TryGetRandomItem(weightArray, out var nextStack))
                {
                    break;
                }

                float percentage = endSettings.ContainsKey(nextStack)
                    ? ((endSettings[nextStack] + 1) / (float)blocksCount)
                    : 0;
                float currentCount = endSettings.ContainsKey(nextStack)
                    ? endSettings[nextStack] + 1 : 0;

                if (percentage > nextStack.MaxAmountPercentage || currentCount > nextStack.MaxAllowable)
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
                        block.SetTimeScaleManager(timeScaleManager);
                        yield return block;
                    }
                }
            }
        }
        
        private bool TryGetRandomItem<T>(IReadOnlyList<(T item, float weight)> items, out T result)
        {
            float random = Random.value;

            for (int i = 0; i < items.Count; i++)
            {
                if (random <= items[i].weight)
                {
                    result = items[i].item;
                    return true;
                }
            }

            result = default;
            return false;
        }
        
        private List<(T, float)> CreatePriorityArray<T>(IReadOnlyList<T> items, Func<T, float> getPriority)
        {
            List<(T, float)> result = new List<(T, float)>();

            float prioritiesSum = items.Sum(getPriority);
            if (prioritiesSum <= 0)
            {
                foreach (var item in items)
                {
                    result.Add((item, 0f));
                }

                return result;
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