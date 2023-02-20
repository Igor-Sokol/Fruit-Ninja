using System;
using UnityEngine;

namespace Blocks.BlockServices.CuttingSystem
{
    public abstract class CuttingServiceFactory : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract ICuttingService GetService();
    }
}