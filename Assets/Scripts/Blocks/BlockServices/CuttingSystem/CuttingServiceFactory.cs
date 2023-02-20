using System;
using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingServiceFactory : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract ICuttingService GetService();
    }
}