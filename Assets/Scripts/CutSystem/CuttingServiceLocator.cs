using System.Linq;
using CutSystem.CuttingServices;
using UnityEngine;

namespace CutSystem
{
    public class CuttingServiceLocator : Singleton<CuttingServiceLocator>
    {
        [SerializeField] private CuttingService[] cuttingServices;

        public CuttingService GetService(CuttingServiceType serviceType)
        {
            return serviceType switch
            {
                CuttingServiceType.FruitCutter => cuttingServices.OfType<FruitCutter>().FirstOrDefault(),
                _ => null,
            };
        }
    }
}