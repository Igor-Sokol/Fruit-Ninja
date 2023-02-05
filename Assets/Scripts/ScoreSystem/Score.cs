using System.Collections;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class Score : MonoBehaviour
    {
        private float _timer;
        private float _previousScore;
        private Coroutine _coroutineHandler;
        private int _score;
        
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private string text;
        [SerializeField] private float scoreChangeTime;

        public void SetValue(int score)
        {
            _score = score;

            _coroutineHandler ??= StartCoroutine(ScoreChanger());
        }

        public void ForceSetValue(int score)
        {
            _previousScore = score;
            ChangeText(score);
        }

        private void ChangeText(int score)
        {
            tmpText.text = text + score;
        }
        
        private IEnumerator ScoreChanger()
        {
            _timer = 0f;

            float tempScore = 0;
            while (tempScore < _score)
            {
                _timer += Time.deltaTime;

                tempScore = Mathf.Lerp(_previousScore, _score, _timer / scoreChangeTime);

                ChangeText((int)tempScore);

                yield return null;
            }

            _previousScore = _score;
            _coroutineHandler = null;
        }
    }
}