using System;
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

            tmpText.text = string.Format(formatMask, score);
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