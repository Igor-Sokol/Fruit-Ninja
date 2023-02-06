using System;
using System.Linq;
using UnityEngine;

namespace CuttingSystem
{
    public class CuttingServiceFabricLocator : Singleton<CuttingServiceFabricLocator>
    {
        [SerializeField] private CuttingServiceFabric[] cuttingServices;

        public CuttingServiceFabric GetServiceFabric(Type fabricType)
        {
            return cuttingServices.FirstOrDefault(s => s.GetType() == fabricType);
        }
    }
}