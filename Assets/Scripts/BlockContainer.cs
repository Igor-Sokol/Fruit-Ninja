using System.Collections.Generic;
using Adaptive;
using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    private List<Block> _blocks;

    [SerializeField] private PlayingField playingField;
    [SerializeField] private Transform container;

    public IEnumerable<Block> Blocks => _blocks.ToArray();

    private void Awake()
    {
        _blocks = new List<Block>();
    }

    public void AddBlock(Block block)
    {
        _blocks.Add(block);
        block.transform.parent = container;
    }

    public void RemoveBlock(Block block)
    {
        _blocks.Remove(block);
    }
}