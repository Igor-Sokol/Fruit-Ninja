using UnityEngine;

namespace GameSystems.ScoreStorageSystem
{
    public abstract class ScoreStorage : MonoBehaviour, IScoreStorage
    {
        public abstract void SaveScore(int score);

        public abstract int LoadScore();
    }
}