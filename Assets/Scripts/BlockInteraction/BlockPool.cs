using UnityEngine;

namespace BlockInteraction
{
    public class BlockPool : MonoBehaviour
    {
        [SerializeField] private ObjectPool<Block>[] pools;

        public Block GetRandomFruit()
        {
            return pools[Random.Range(0, pools.Length)].Get();
        }

        public void ReturnBlock(Block block)
        {
            foreach (var t in pools)
            {
                if (t.Return(block))
                {
                    break;
                }
            }
        }
    }
}