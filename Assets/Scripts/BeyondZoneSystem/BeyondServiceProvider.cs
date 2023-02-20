using System;
using UnityEngine;

namespace BeyondZoneSystem
{
    public abstract class BeyondServiceProvider : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract Type CuttingServiceFactoryType { get; }
        public abstract IBeyondService GetService();
    }
}