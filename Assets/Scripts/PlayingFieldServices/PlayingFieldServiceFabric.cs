using UnityEngine;

namespace PlayingFieldServices
{
    public abstract class PlayingFieldServiceFabric : MonoBehaviour, IServiceFabric
    {
        public abstract IPlayingFieldService Create();
    }
}