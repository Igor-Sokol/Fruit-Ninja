using BlockComponents;
using BlockConfiguration;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlayingFieldComponents
{
    public class BlockPool : MonoBehaviour
    {
        private ObjectPool<Block> _pool;

        [SerializeField] private Block prefab;
        [SerializeField] private BlockSettingObject[] blockSettings;

        private void Awake()
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

        public Block GetEmptyBlock()
        {
            return _pool.Get();
        }
        
        public void ReturnBlock(Block block)
        {
            _pool.Return(block);
        }
    }
}