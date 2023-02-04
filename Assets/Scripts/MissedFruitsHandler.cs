using BlockComponents;
using HealthSystem;
using UnityEngine;

public class MissedFruitsHandler : MonoBehaviour
{
    [SerializeField] private BlockContainer fruitsContainer;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private BlockDeadZone blockDeadZone;

    private void OnEnable()
    {
        blockDeadZone.OnBlocksRemoved += CheckContainer;
    }

    private void OnDisable()
    {
        blockDeadZone.OnBlocksRemoved -= CheckContainer;
    }

    private void CheckContainer(BlockContainer blockContainer, int deletedBlocks)
    {
        if (blockContainer == fruitsContainer)
        {
            healthBar.RemoveHeart(deletedBlocks);
        }
    }
}
