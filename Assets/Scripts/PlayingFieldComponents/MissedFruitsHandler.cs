using HealthSystem;
using UnityEngine;

namespace PlayingFieldComponents
{
    public class MissedFruitsHandler : MonoBehaviour
    {
        [SerializeField] private BlockContainer fruitsContainer;
        [SerializeField] private HealthService healthService;
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
                healthService.RemoveHealth(deletedBlocks);
            }
        }
    }
}
