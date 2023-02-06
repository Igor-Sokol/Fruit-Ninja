using System;
using UnityEngine;

namespace BeyondZoneSystem
{
    public abstract class BeyondServiceSetting : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract Type CuttingServiceFabricType { get; }
        public abstract IBeyondService GetService();
    }
}