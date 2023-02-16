using UnityEngine;

namespace DifficultySystem
{
    public abstract class DifficultySetting : MonoBehaviour, IDifficultySetting
    {
        public abstract int FruitsInPack { get; }
        public abstract float PackInterval { get; }
        public abstract float FruitInterval { get; }
    }
}