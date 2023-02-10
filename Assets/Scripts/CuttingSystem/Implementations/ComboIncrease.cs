using BlockComponents;
using Managers;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Implementations
{
    public class ComboIncrease : ICuttingService
    {
        private readonly ComboManager _comboManager;
        private readonly ComboRenderer _comboRenderer;
        private bool _changeComboPosition;

        public void Init(bool changeComboPosition)
        {
            _changeComboPosition = changeComboPosition;
        }
        
        public ComboIncrease(ComboManager comboManager, ComboRenderer comboRenderer)
        {
            _comboManager = comboManager;
            _comboRenderer = comboRenderer;
        }
        
        public ServiceCallbackAction Cut(Block block, Vector2 bladeVector)
        {
            _comboManager.IncreaseCombo();

            if (_changeComboPosition)
            {
                _comboRenderer.SetPosition(block.transform.position);
            }

            return ServiceCallbackAction.None;
        }
    }
}