using CuttingSystem.Implementations;
using Managers;
using UI.Game;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class ComboIncreaseFabric : CuttingServiceFabric
    {
        [SerializeField] private ComboManager comboManager;
        [SerializeField] private ComboRenderer comboRenderer;

        public override ICuttingService Create()
        {
            return new ComboIncrease(comboManager, comboRenderer);
        }
    }
}