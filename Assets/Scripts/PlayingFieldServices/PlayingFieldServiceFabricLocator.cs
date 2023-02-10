using System;
using System.Linq;
using UnityEngine;

namespace PlayingFieldServices
{
    public class PlayingFieldServiceFabricLocator : Singleton<PlayingFieldServiceFabricLocator>
    {
        [SerializeField] private PlayingFieldServiceFabric[] playingFieldServiceFabrics;

        public PlayingFieldServiceFabric GetServiceFabric(Type fabricType)
        {
            return playingFieldServiceFabrics.FirstOrDefault(s => s.GetType() == fabricType);
        }
    }
}