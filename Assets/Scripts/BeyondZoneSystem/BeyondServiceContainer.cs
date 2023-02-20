using System;
using System.Linq;
using UnityEngine;

namespace BeyondZoneSystem
{
    public class BeyondServiceContainer : Singleton<BeyondServiceContainer>
    {
        [SerializeField] private BeyondServiceFactory[] beyondServices;

        public BeyondServiceFactory GetServiceFabric(Type fabricType)
        {
            return beyondServices.FirstOrDefault(s => s.GetType() == fabricType);
        }
    }
}