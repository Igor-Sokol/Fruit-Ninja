using System;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlockInteraction
{
    public class BlockPool : MonoBehaviour
    {
        private ObjectPool<Block> _pool;

        [SerializeField] private Block prefab;
        [SerializeField] private BlockSetting[] blockSettings;

        private void Start()
        {
            _pool = new ObjectPool<Block>();
            _pool.Init(prefab, transform);
        }

        public Block GetRandomFruit()
        {
            var fruit = _pool.Get();
            fruit.SetUp(blockSettings[Random.Range(0, blockSettings.Length)]);

            return fruit;
        }

        public void ReturnBlock(Block blockPhysic)
        {
            _pool.Return(blockPhysic);
        }
    }
}