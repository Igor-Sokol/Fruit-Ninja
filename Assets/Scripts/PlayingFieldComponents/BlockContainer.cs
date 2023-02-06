using System.Collections.Generic;
using BlockComponents;
using UnityEngine;

namespace PlayingFieldComponents
{
    public class BlockContainer : MonoBehaviour
    {
        private List<Block> _blocks;

        public IEnumerable<Block> Blocks => _blocks;
        public int BlocksCount => _blocks.Count;


        private void Awake()
        {
            _blocks = new List<Block>();
        }

        public void AddBlock(Block block)
        {
            _blocks.Add(block);
            block.transform.SetParent(transform);
        }

        public void RemoveBlock(Block block)
        {
            _blocks.Remove(block);
        }
    }
}