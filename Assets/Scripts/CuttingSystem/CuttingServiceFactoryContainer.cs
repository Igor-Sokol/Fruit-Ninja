using System;
using System.Linq;
using UnityEngine;

namespace CuttingSystem
{
    public class CuttingServiceFactoryContainer : Singleton<CuttingServiceFactoryContainer>
    {
        [SerializeField] private CuttingServiceFactory[] cuttingServices;

        public CuttingServiceFactory GetServiceFabric(Type fabricType)
        {
            return cuttingServices.FirstOrDefault(s => s.GetType() == fabricType);
        }
    }
}