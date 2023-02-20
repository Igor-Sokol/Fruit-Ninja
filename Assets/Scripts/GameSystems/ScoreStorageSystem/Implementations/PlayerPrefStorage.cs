using UnityEngine;

namespace ScoreStorageSystem.Implementations
{
    public class PlayerPrefStorage : ScoreStorage
    {
        [SerializeField] private string prefKey;
        
        public override void SaveScore(int score)
        {
            PlayerPrefs.SetInt(prefKey, score);
        }

        public override int LoadScore()
        {
            return PlayerPrefs.GetInt(prefKey);
        }
    }
}