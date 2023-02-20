using System;
using UnityEngine;

namespace BeyondZoneSystem
{
    public abstract class BeyondServiceFactory : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract IBeyondService GetService();
    }
}