using System;
using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingServiceSetting : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract Type CuttingServiceFabricType { get; }
        public abstract ICuttingService GetService();
    }
}