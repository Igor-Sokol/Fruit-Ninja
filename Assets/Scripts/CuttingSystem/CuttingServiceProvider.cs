using System;
using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingServiceProvider : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract Type CuttingServiceFactoryType { get; }
        public abstract ICuttingService GetService();
    }
}