using BlockComponents;
using Managers;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class ComboIncrease : ICuttingService
    {
        private readonly ComboManager _comboManager;

        public ComboIncrease(ComboManager comboManager)
        {
            _comboManager = comboManager;
        }
        
        public void Cut(Block block, Vector2 bladeVector)
        {
            _comboManager.IncreaseCombo();
        }
    }
}