using System;
using UnityEngine;

namespace PlayingFieldServices
{
    public abstract class PlayingFieldServiceFactory : ScriptableObject
    {
        public abstract Type CuttingServiceType { get; }
        public abstract IPlayingFieldService GetService();
    }
}