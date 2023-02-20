using System;
using UnityEngine;

namespace GameSystems.DifficultySystem
{
    [Serializable]
    public struct DifficultyPoint
    {
        [SerializeField][Range(0, 1)] private float difficultyPercentage;
        [SerializeField] private float minute;

        public float DifficultyPercentage => difficultyPercentage;
        public float Minute => minute;
    }
}