using System;
using UnityEngine;

namespace PlayingFieldServices
{
    public abstract class PlayingFieldServiceSetting : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract Type CuttingServiceFabricType { get; }
        public abstract IPlayingFieldService GetService();
    }
}