using UnityEngine;

namespace CuttingSystem
{
    public abstract class CuttingServiceSetting : ScriptableObject
    {
        public abstract CuttingServiceType CuttingServiceType { get; }
    }
}