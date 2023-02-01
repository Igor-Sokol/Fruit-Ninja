using System.Collections.Generic;
using Adaptive;
using BlockInteraction;
using UnityEngine;

public class BlockContainer : MonoBehaviour
{
    private List<Block> _blocks;

    [SerializeField] private PlayingField playingField;

    public IEnumerable<Block> Blocks => _blocks.ToArray();

    private void Awake()
    {
        _blocks = new List<Block>();
    }

    public void AddBlock(Block block)
    {
        _blocks.Add(block);
    }

    public void RemoveBlock(Block block)
    {
        _blocks.Remove(block);
    }
}