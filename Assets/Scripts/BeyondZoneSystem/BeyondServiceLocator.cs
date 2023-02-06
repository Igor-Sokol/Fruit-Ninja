using System;
using System.Linq;
using UnityEngine;

namespace BeyondZoneSystem
{
    public class BeyondServiceLocator : Singleton<BeyondServiceLocator>
    {
        [SerializeField] private BeyondServiceFabric[] beyondServices;

        public BeyondServiceFabric GetServiceFabric(Type fabricType)
        {
            return beyondServices.FirstOrDefault(s => s.GetType() == fabricType);
        }
    }
}