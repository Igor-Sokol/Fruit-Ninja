using System;
using ScoreStorageSystem;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreManager : MonoBehaviour
    {
        private int _currentScore;
        private int _bestScore;

        [SerializeField] private ScoreStorage scoreStorage;
        
        public int CurrentScore => _currentScore;
        public int BestScore => _bestScore;
        public event Action<int> GameScoreChanged;
        public event Action<int> BestScoreChanged;
        public event Action ScoreLoaded;

        private void Awake()
        {
            Load();
        }

        public void AddScore(int score)
        {
            _currentScore += score;
            GameScoreChanged?.Invoke(_currentScore);

            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
                scoreStorage.SaveScore(_bestScore);
                BestScoreChanged?.Invoke(_bestScore);
            }
        }

        public void Load()
        {
            _currentScore = 0;
            _bestScore = scoreStorage.LoadScore();
            ScoreLoaded?.Invoke();
        }
    }
}
