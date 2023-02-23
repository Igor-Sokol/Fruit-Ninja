using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextValue : MonoBehaviour
    {
        private float _timer;
        private float _previousValue;
        private Coroutine _coroutineHandler;
        private int _value;
        
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private float valueChangeTime;
        [SerializeField] private string formatMask;

        public void SetValue(int score)
        {
            _value = score;

            if (valueChangeTime <= 0)
            {
                ForceSetValue(score);
            }
            else
            {
                _coroutineHandler ??= StartCoroutine(ValueChanger());
            }
        }

        public void ForceSetValue(int score)
        {
            _previousValue = score;
            ChangeText(score);
        }

        private void ChangeText(int score)
        {
            formatMask ??= tmpText.text;

            tmpText.text = string.Format(formatMask, score, WordEnding(score));
        }

        private string WordEnding(int number)
        {
            if (number % 100 > 10 && number % 100 < 20)
            {
                return $"ов";
            }

            if (number % 10 == 1)
            {
                return string.Empty;
            }

            if (number % 10 >= 2 && number % 10 <= 3)
            {
                return $"а";
            }
	
            return $"ов";
        }
        
        private IEnumerator ValueChanger()
        {
            _timer = 0f;

            float tempValue = 0;
            while (tempValue < _value)
            {
                _timer += Time.deltaTime;

                tempValue = Mathf.Lerp(_previousValue, _value, _timer / valueChangeTime);

                ChangeText((int)tempValue);

                yield return null;
            }

            _previousValue = _value;
            _coroutineHandler = null;
        }
    }
}