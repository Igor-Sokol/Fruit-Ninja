using CuttingSystem.Implementations;
using Managers;
using UnityEngine;

namespace CuttingSystem.Fabrics
{
    public class ComboIncreaseFabric : CuttingServiceFabric
    {
        [SerializeField] private ComboManager comboManager;

        public override ICuttingService Create()
        {
            return new ComboIncrease(comboManager);
        }
    }
}