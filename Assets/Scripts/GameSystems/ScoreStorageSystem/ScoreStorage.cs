using UnityEngine;

namespace ScoreStorageSystem
{
    public abstract class ScoreStorage : MonoBehaviour, IScoreStorage
    {
        public abstract void SaveScore(int score);

        public abstract int LoadScore();
    }
}