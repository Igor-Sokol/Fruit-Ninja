using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BlockComponents
{
    public class BlockPool : MonoBehaviour
    {
        private ObjectPool<BlockComponents.Block> _pool;

        [SerializeField] private BlockComponents.Block prefab;
        [SerializeField] private BlockSetting[] blockSettings;

        private void Start()
        {
            _pool = new ObjectPool<BlockComponents.Block>();
            _pool.Init(prefab, transform);
        }

        public BlockComponents.Block GetRandomFruit()
        {
            var fruit = _pool.Get();
            fruit.SetUp(blockSettings[Random.Range(0, blockSettings.Length)]);

            return fruit;
        }

        public void ReturnBlock(BlockComponents.Block blockPhysic)
        {
            _pool.Return(blockPhysic);
        }
    }
}